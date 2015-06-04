Imports ApskaitaObjects.HelperLists
Namespace ActiveReports

    <Serializable()> _
    Public Class InvoiceInfoItemList
        Inherits ReadOnlyListBase(Of InvoiceInfoItemList, InvoiceInfoItem)

#Region " Business Methods "

        Private _InfoType As InvoiceInfoType
        Private _DateFrom As Date
        Private _DateTo As Date
        Private _Person As PersonInfo


        Public ReadOnly Property InfoType() As InvoiceInfoType
            Get
                Return _InfoType
            End Get
        End Property

        Public ReadOnly Property InfoTypeHumanReadable() As String
            Get
                Return ConvertEnumHumanReadable(_InfoType)
            End Get
        End Property

        Public ReadOnly Property DateFrom() As Date
            Get
                Return _DateFrom
            End Get
        End Property

        Public ReadOnly Property DateTo() As Date
            Get
                Return _DateTo
            End Get
        End Property

        Public ReadOnly Property Person() As PersonInfo
            Get
                Return _Person
            End Get
        End Property


        Public Sub SaveToFfData(ByVal fileName As String, ByVal version As Integer)

            If Count < 1 Then Throw New Exception("Klaida. Sąrašas tuščias.")

            ' clear temporary file if present
            Dim tempFileName As String = AppPath() & FILENAMEFFDATATEMP
            If IO.File.Exists(tempFileName) Then IO.File.Delete(tempFileName)

            ' Set culture params that were used when parsing declaration's
            ' numbers and dates to string
            Dim oldCulture As Globalization.CultureInfo = _
                DirectCast(Threading.Thread.CurrentThread.CurrentCulture.Clone, Globalization.CultureInfo)

            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("lt-LT", False)

            Dim ffDataFormatDataSet As DataSet = Nothing

            Try

                If _InfoType = InvoiceInfoType.InvoiceMade Then
                    If version = 1 Then
                        ffDataFormatDataSet = GetFFDataForFR0672_1()
                    ElseIf version = 2 Then
                        ffDataFormatDataSet = GetFFDataForFR0672_2()
                    Else
                        Throw New NotImplementedException("Klaida. Deklaracijos FR0672 versijos " & _
                            version.ToString & " eksportas į ffdata formatą nepalaikomas.")
                    End If
                Else
                    If version = 1 Then
                        ffDataFormatDataSet = GetFFDataForFR0671_1()
                    ElseIf version = 2 Then
                        ffDataFormatDataSet = GetFFDataForFR0671_2()
                    Else
                        Throw New NotImplementedException("Klaida. Deklaracijos FR0671 versijos " & _
                            version.ToString & " eksportas į ffdata formatą nepalaikomas.")
                    End If
                End If

                If ffDataFormatDataSet Is Nothing Then Throw New Exception( _
                    "Klaida. Dėl nežinomų priežasčių nepavyko konvertuoti deklaracijos " _
                    & "duomenų į ffdata formatą.")

                Using ffDataFileStream As IO.FileStream = New IO.FileStream(fileName, IO.FileMode.Create)
                    ffDataFormatDataSet.WriteXml(ffDataFileStream)
                    ffDataFileStream.Close()
                End Using

            Catch ex As Exception

                If Not ffDataFormatDataSet Is Nothing Then ffDataFormatDataSet.Dispose()
                Threading.Thread.CurrentThread.CurrentCulture = oldCulture

                Throw

            End Try

            ffDataFormatDataSet.Dispose()
            Threading.Thread.CurrentThread.CurrentCulture = oldCulture

        End Sub

        Private Function GetFFDataForFR0671_1() As DataSet

            Dim i As Integer
            Dim currentUser As AccDataAccessLayer.Security.AccIdentity = GetCurrentIdentity()
            Dim currentCompany As Settings.CompanyInfo = GetCurrentCompany

            Dim declarationFileName As String = AppPath() & FILENAMEFFDATAFR0671

            Dim pageCount As Integer = Convert.ToInt32(Math.Ceiling((Count - 14) / 8))

            If pageCount > 0 Then

                Dim myDoc As New Xml.XmlDocument
                myDoc.Load(declarationFileName)

                For i = 1 To pageCount
                    Dim AddP As Xml.XmlElement = DirectCast(myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(0). _
                        ChildNodes(0).ChildNodes(1).Clone, Xml.XmlElement)
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(0).ChildNodes(0).AppendChild(AddP)
                    Dim AddPg As Xml.XmlElement = DirectCast(myDoc.ChildNodes(1).ChildNodes(0). _
                        ChildNodes(1).ChildNodes(1).Clone, Xml.XmlElement)
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).AppendChild(AddPg)
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).ChildNodes(i + 1).Attributes(1).Value = (2 + i).ToString
                Next

                myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).Attributes(0).Value = _
                    (2 + pageCount).ToString

                myDoc.Save(AppPath() & FILENAMEFFDATATEMP)

            Else
                IO.File.Copy(declarationFileName, AppPath() & FILENAMEFFDATATEMP)
            End If

            ' read ffdata xml structure to dataset
            Dim formDataSet As New DataSet
            Using formFileStream As IO.FileStream = New IO.FileStream( _
                AppPath() & FILENAMEFFDATATEMP, IO.FileMode.Open)
                formDataSet.ReadXml(formFileStream)
                formFileStream.Close()
            End Using

            ' GENERAL DATA

            formDataSet.Tables(0).Rows(0).Item(3) = currentUser.Name
            formDataSet.Tables(0).Rows(0).Item(4) = GetDateInFFDataFormat(Today.Date)
            formDataSet.Tables(1).Rows(0).Item(2) = AppPath() & FILENAMEMXFDFR0671

            Dim k As Integer = 1
            For i = 1 To formDataSet.Tables(8).Rows.Count ' bendri duomenys
                If formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_MM_Pavad" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = currentCompany.Name.ToUpper
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_MM_PVM" AndAlso _
                    currentCompany.CodeVat.Trim.Length > 2 Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = currentCompany.CodeVat.Substring(2)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_UzpildData" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(Today.Date)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_ML_Nuo" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(_DateFrom.Date)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_ML_Iki" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(_DateTo.Date)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E6" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = 1
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "LapoNr" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = k
                    k = k + 1
                End If
            Next

            ' DETAILS DATA

            For i = 1 To Math.Min(6, Count)
                formDataSet.Tables(8).Rows((i - 1) * 7 + 5).Item(1) = i
                formDataSet.Tables(8).Rows((i - 1) * 7 + 6).Item(1) = _
                    GetDateInFFDataFormat(Items(i - 1).Date)
                formDataSet.Tables(8).Rows((i - 1) * 7 + 7).Item(1) = _
                    Items(i - 1).Number.ToUpper
                formDataSet.Tables(8).Rows((i - 1) * 7 + 8).Item(1) = _
                    GetNumberInFFDataFormat(Items(i - 1).SumLTL)
                formDataSet.Tables(8).Rows((i - 1) * 7 + 9).Item(1) = _
                    GetNumberInFFDataFormat(Items(i - 1).SumVatLTL)
                formDataSet.Tables(8).Rows((i - 1) * 7 + 10).Item(1) = _
                    Items(i - 1).PersonVatCode.ToUpper
                formDataSet.Tables(8).Rows((i - 1) * 7 + 11).Item(1) = _
                    GetLimitedLengthString(Items(i - 1).PersonName.ToUpper, 36)
            Next

            For j As Integer = 1 To CInt(Math.Max(Math.Ceiling((Count - 14) / 8), 0) + 1)
                For i = 1 To Math.Min(8, Count - 6 - (j - 1) * 8)
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 52 + 65 * (j - 1)).Item(1) = i + 6 + 8 * (j - 1)
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 53 + 65 * (j - 1)).Item(1) = _
                        GetDateInFFDataFormat(Items(i + 5 + 8 * (j - 1)).Date)
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 54 + 65 * (j - 1)).Item(1) = _
                        Items(i + 5 + 8 * (j - 1)).Number.ToUpper
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 55 + 65 * (j - 1)).Item(1) = _
                        GetNumberInFFDataFormat(Items(i + 5 + 8 * (j - 1)).SumLTL)
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 56 + 65 * (j - 1)).Item(1) = _
                        GetNumberInFFDataFormat(Items(i + 5 + 8 * (j - 1)).SumVatLTL)
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 57 + 65 * (j - 1)).Item(1) = _
                        Items(i + 5 + 8 * (j - 1)).PersonVatCode.ToUpper
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 58 + 65 * (j - 1)).Item(1) = _
                        GetLimitedLengthString(Items(i + 5 + 8 * (j - 1)).PersonName.ToUpper, 36)
                Next
            Next

            Return formDataSet

        End Function

        Private Function GetFFDataForFR0672_1() As DataSet

            Dim i As Integer
            Dim currentUser As AccDataAccessLayer.Security.AccIdentity = GetCurrentIdentity()
            Dim currentCompany As Settings.CompanyInfo = GetCurrentCompany

            Dim declarationFileName As String = AppPath() & FILENAMEFFDATAFR0672

            Dim pageCount As Integer = Convert.ToInt32(Math.Ceiling((Me.Count - 14) / 8))

            If pageCount > 0 Then

                Dim myDoc As New Xml.XmlDocument
                myDoc.Load(declarationFileName)

                For i = 1 To pageCount
                    Dim AddP As Xml.XmlElement = DirectCast(myDoc.ChildNodes(1).ChildNodes(0). _
                        ChildNodes(0).ChildNodes(0).ChildNodes(1).Clone, Xml.XmlElement)
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(0).ChildNodes(0).AppendChild(AddP)
                    Dim AddPg As Xml.XmlElement = DirectCast(myDoc.ChildNodes(1).ChildNodes(0). _
                        ChildNodes(1).ChildNodes(1).Clone, Xml.XmlElement)
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).AppendChild(AddPg)
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).ChildNodes(i + 1).Attributes(1).Value = (2 + i).ToString
                Next

                myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).Attributes(0).Value = _
                    (2 + pageCount).ToString

                myDoc.Save(AppPath() & FILENAMEFFDATATEMP)

            Else
                IO.File.Copy(declarationFileName, AppPath() & FILENAMEFFDATATEMP)
            End If

            ' read ffdata xml structure to dataset
            Dim formDataSet As New DataSet
            Using formFileStream As IO.FileStream = New IO.FileStream( _
                AppPath() & FILENAMEFFDATATEMP, IO.FileMode.Open)
                formDataSet.ReadXml(formFileStream)
                formFileStream.Close()
            End Using

            ' GENERAL DATA

            formDataSet.Tables(0).Rows(0).Item(3) = currentUser.Name
            formDataSet.Tables(0).Rows(0).Item(4) = GetDateInFFDataFormat(Today.Date)
            formDataSet.Tables(1).Rows(0).Item(2) = AppPath() & FILENAMEMXFDFR0672

            Dim k As Integer = 1
            For i = 1 To formDataSet.Tables(8).Rows.Count ' bendri duomenys
                If formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_MM_Pavad" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = currentCompany.Name.ToUpper
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_MM_PVM" AndAlso _
                    currentCompany.CodeVat.Trim.Length > 2 Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = currentCompany.CodeVat.Substring(2)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_UzpildData" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(Today.Date)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_ML_Nuo" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(_DateFrom.Date)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_ML_Iki" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(_DateTo.Date)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E6" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = 1
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "LapoNr" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = k
                    k = k + 1
                End If
            Next

            ' DETAILS DATA

            For i = 1 To Math.Min(6, Count)
                formDataSet.Tables(8).Rows((i - 1) * 7 + 8).Item(1) = i
                formDataSet.Tables(8).Rows((i - 1) * 7 + 9).Item(1) = _
                    GetDateInFFDataFormat(Items(i - 1).Date)
                formDataSet.Tables(8).Rows((i - 1) * 7 + 10).Item(1) = Items(i - 1).Number.ToUpper
                formDataSet.Tables(8).Rows((i - 1) * 7 + 11).Item(1) = _
                    GetNumberInFFDataFormat(Items(i - 1).SumLTL)
                formDataSet.Tables(8).Rows((i - 1) * 7 + 12).Item(1) = _
                    GetNumberInFFDataFormat(Items(i - 1).SumVatLTL)
                If Items(i - 1).PersonVatCode.Length > 2 Then
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 13).Item(1) = _
                        Items(i - 1).PersonVatCode.ToUpper
                Else
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 13).Item(1) = _
                        Items(i - 1).PersonCode.ToUpper
                End If
                formDataSet.Tables(8).Rows((i - 1) * 7 + 14).Item(1) = _
                    GetLimitedLengthString(Items(i - 1).PersonName.ToUpper, 36)
            Next

            For j As Integer = 1 To CInt(Math.Max(Math.Ceiling((Count - 14) / 8), 0) + 1)
                For i = 1 To Math.Min(8, Count - 6 - (j - 1) * 8)
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 60 + 65 * (j - 1)).Item(1) = i + 6 + 8 * (j - 1)
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 61 + 65 * (j - 1)).Item(1) = _
                        GetDateInFFDataFormat(Items(i + 5 + 8 * (j - 1)).Date)
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 62 + 65 * (j - 1)).Item(1) = _
                        Items(i + 5 + 8 * (j - 1)).Number.ToUpper
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 63 + 65 * (j - 1)).Item(1) = _
                        GetNumberInFFDataFormat(Items(i + 5 + 8 * (j - 1)).SumLTL)
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 64 + 65 * (j - 1)).Item(1) = _
                        GetNumberInFFDataFormat(Items(i + 5 + 8 * (j - 1)).SumVatLTL)
                    If Items(i + 5 + 8 * (j - 1)).PersonVatCode.Length > 2 Then
                        formDataSet.Tables(8).Rows((i - 1) * 7 + 65 + 65 * (j - 1)).Item(1) = _
                            Items(i + 5 + 8 * (j - 1)).PersonVatCode.ToUpper
                    Else
                        formDataSet.Tables(8).Rows((i - 1) * 7 + 65 + 65 * (j - 1)).Item(1) = _
                            Items(i + 5 + 8 * (j - 1)).PersonCode.ToUpper
                    End If
                    formDataSet.Tables(8).Rows((i - 1) * 7 + 66 + 65 * (j - 1)).Item(1) = _
                        GetLimitedLengthString(Items(i + 5 + 8 * (j - 1)).PersonName.ToUpper, 36)
                Next
            Next

            Return formDataSet

        End Function

        Private Function GetFFDataForFR0671_2() As DataSet

            Dim i As Integer
            Dim currentUser As AccDataAccessLayer.Security.AccIdentity = GetCurrentIdentity()
            Dim currentCompany As Settings.CompanyInfo = GetCurrentCompany()

            Dim declarationFileName As String = AppPath() & FILENAMEFFDATAFR0671_2

            Dim pageCount As Integer = Convert.ToInt32(Math.Ceiling((Me.Count) / 4))
            Dim sumLtl As Double = 0
            Dim sumVatLtl As Double = 0
            For Each n As InvoiceInfoItem In Me
                sumLtl += n.SumLTL
                sumVatLtl += n.SumVatLTL
            Next

            If pageCount > 1 Then
                Dim myDoc As New Xml.XmlDocument
                myDoc.Load(declarationFileName)
                For i = 1 To pageCount - 1
                    Dim AddP As Xml.XmlElement = DirectCast(myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(0). _
                        ChildNodes(0).ChildNodes(1).Clone, Xml.XmlElement)
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(0).ChildNodes(0).AppendChild(AddP)
                    Dim AddPg As Xml.XmlElement = DirectCast(myDoc.ChildNodes(1).ChildNodes(0). _
                        ChildNodes(1).ChildNodes(1).Clone, Xml.XmlElement)
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).AppendChild(AddPg)
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).ChildNodes(i + 1).Attributes(1).Value = (2 + i).ToString
                Next
                myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).Attributes(0).Value = _
                    (pageCount + 1).ToString
                myDoc.Save(AppPath() & FILENAMEFFDATATEMP)
            Else
                IO.File.Copy(declarationFileName, AppPath() & FILENAMEFFDATATEMP)
            End If

            ' read ffdata xml structure to dataset
            Dim formDataSet As New DataSet
            Using formFileStream As IO.FileStream = New IO.FileStream( _
                AppPath() & FILENAMEFFDATATEMP, IO.FileMode.Open)
                formDataSet.ReadXml(formFileStream)
                formFileStream.Close()
            End Using

            ' GENERAL DATA

            formDataSet.Tables(0).Rows(0).Item(3) = currentUser.Name
            formDataSet.Tables(0).Rows(0).Item(4) = GetDateInFFDataFormat(Today.Date)
            formDataSet.Tables(1).Rows(0).Item(2) = AppPath() & FILENAMEMXFDFR0671_2

            Dim k As Integer = 1
            For i = 1 To formDataSet.Tables(8).Rows.Count ' bendri duomenys
                If formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_MM_Pavad" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = currentCompany.Name.ToUpper
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_MM_PVM" _
                    AndAlso currentCompany.CodeVat.Length > 2 Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = currentCompany.CodeVat.Substring(2)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_UzpildData" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(Today.Date)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_ML_Nuo" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(_DateFrom.Date)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_ML_Iki" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(_DateTo.Date)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E6" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = 1
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E14" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = pageCount
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E19" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetNumberInFFDataFormat(sumLtl)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E20" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetNumberInFFDataFormat(sumVatLtl)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E21" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetNumberInFFDataFormat(sumLtl)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E22" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = GetNumberInFFDataFormat(sumVatLtl)
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E23" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = 0
                ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "LapoNr" Then
                    formDataSet.Tables(8).Rows(i - 1).Item(1) = k
                    k = k + 1
                End If
            Next

            ' DETAILS DATA

            For j As Integer = 1 To Convert.ToInt32(Math.Ceiling((Count) / 4))
                sumLtl = 0
                sumVatLtl = 0
                For i = 1 To Math.Min(4, Count - (4 * (j - 1)))
                    formDataSet.Tables(8).Rows((i - 1) * 8 + 20 + 43 * (j - 1)).Item(1) = i + 4 * (j - 1)
                    formDataSet.Tables(8).Rows((i - 1) * 8 + 21 + 43 * (j - 1)).Item(1) = _
                        GetDateInFFDataFormat(Items(4 * (j - 1) + i - 1).Date)
                    formDataSet.Tables(8).Rows((i - 1) * 8 + 22 + 43 * (j - 1)).Item(1) = _
                        Items(4 * (j - 1) + i - 1).Number
                    formDataSet.Tables(8).Rows((i - 1) * 8 + 23 + 43 * (j - 1)).Item(1) = _
                        GetNumberInFFDataFormat(Items(4 * (j - 1) + i - 1).SumLTL)
                    formDataSet.Tables(8).Rows((i - 1) * 8 + 24 + 43 * (j - 1)).Item(1) = _
                        GetNumberInFFDataFormat(Items(4 * (j - 1) + i - 1).SumVatLTL)
                    formDataSet.Tables(8).Rows((i - 1) * 8 + 26 + 43 * (j - 1)).Item(1) = _
                        Items(4 * (j - 1) + i - 1).PersonVatCode
                    formDataSet.Tables(8).Rows((i - 1) * 8 + 27 + 43 * (j - 1)).Item(1) = _
                        GetLimitedLengthString(Items(4 * (j - 1) + i - 1).PersonName, 32)
                    sumLtl = sumLtl + Items(4 * (j - 1) + i - 1).SumLTL
                    sumVatLtl = sumVatLtl + Items(4 * (j - 1) + i - 1).SumVatLTL
                Next
                formDataSet.Tables(8).Rows(52 + 43 * (j - 1)).Item(1) = GetNumberInFFDataFormat(sumLtl)
                formDataSet.Tables(8).Rows(53 + 43 * (j - 1)).Item(1) = GetNumberInFFDataFormat(sumVatLtl)
            Next

            Return formDataSet

        End Function

        Private Function GetFFDataForFR0672_2() As DataSet

            Dim i As Integer
            Dim currentUser As AccDataAccessLayer.Security.AccIdentity = GetCurrentIdentity()
            Dim currentCompany As Settings.CompanyInfo = GetCurrentCompany()

            Dim declarationFileName As String = AppPath() & FILENAMEFFDATAFR0672_2

            Dim pageCount As Integer = Convert.ToInt32(Math.Ceiling((Me.Count) / 4))
            Dim sumLtl As Double = 0
            Dim sumVatLtl As Double = 0
            For Each n As InvoiceInfoItem In Me
                sumLtl += n.SumLTL
                sumVatLtl += n.SumVatLTL
            Next

            Try
                If pageCount > 1 Then
                    Dim myDoc As New Xml.XmlDocument
                    myDoc.Load(declarationFileName)
                    For i = 1 To pageCount - 1
                        Dim AddP As Xml.XmlElement = DirectCast(myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(0). _
                            ChildNodes(0).ChildNodes(1).Clone, Xml.XmlElement)
                        myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(0).ChildNodes(0).AppendChild(AddP)
                        Dim AddPg As Xml.XmlElement = DirectCast(myDoc.ChildNodes(1).ChildNodes(0). _
                            ChildNodes(1).ChildNodes(1).Clone, Xml.XmlElement)
                        myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).AppendChild(AddPg)
                        myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).ChildNodes(i + 1).Attributes(1).Value = (2 + i).ToString
                    Next
                    myDoc.ChildNodes(1).ChildNodes(0).ChildNodes(1).Attributes(0).Value = _
                        (pageCount + 1).ToString
                    myDoc.Save(AppPath() & FILENAMEFFDATATEMP)
                Else
                    IO.File.Copy(declarationFileName, AppPath() & FILENAMEFFDATATEMP)
                End If
            Catch ex As Exception
                Throw New Exception("Failed to prepare ffdata file.", ex)
            End Try


            ' read ffdata xml structure to dataset
            Dim formDataSet As New DataSet
            Try
                Using formFileStream As IO.FileStream = New IO.FileStream( _
                    AppPath() & FILENAMEFFDATATEMP, IO.FileMode.Open)
                    formDataSet.ReadXml(formFileStream)
                    formFileStream.Close()
                End Using
            Catch ex As Exception
                Throw New Exception("Failed to read ffdata file.", ex)
            End Try


            ' GENERAL DATA

            Try

                formDataSet.Tables(0).Rows(0).Item(3) = currentUser.Name
                formDataSet.Tables(0).Rows(0).Item(4) = GetDateInFFDataFormat(Today.Date)
                formDataSet.Tables(1).Rows(0).Item(2) = AppPath() & FILENAMEMXFDFR0672_2

                Dim k As Integer = 1
                For i = 1 To formDataSet.Tables(8).Rows.Count ' bendri duomenys
                    If formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_MM_Pavad" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = currentCompany.Name.ToUpper
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_MM_PVM" _
                        AndAlso currentCompany.CodeVat.Length > 2 Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = currentCompany.CodeVat.Substring(2)
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_UzpildData" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(Today.Date)
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_ML_Nuo" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(_DateFrom.Date)
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "B_ML_Iki" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = GetDateInFFDataFormat(_DateTo.Date)
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E6" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = 1
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E14" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = pageCount
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E19" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = GetNumberInFFDataFormat(sumLtl)
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E20" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = GetNumberInFFDataFormat(sumVatLtl)
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E21" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = GetNumberInFFDataFormat(sumLtl)
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E22" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = GetNumberInFFDataFormat(sumVatLtl)
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "E23" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = 0
                    ElseIf formDataSet.Tables(8).Rows(i - 1).Item(0).ToString = "LapoNr" Then
                        formDataSet.Tables(8).Rows(i - 1).Item(1) = k
                        k = k + 1
                    End If
                Next
            Catch ex As Exception
                Throw New Exception("Failed to write general data to ffdata file.", ex)
            End Try

            ' DETAILS DATA

            Try
                For j As Integer = 1 To Convert.ToInt32(Math.Ceiling((Me.Count) / 4))
                    sumLtl = 0
                    sumVatLtl = 0
                    For i = 1 To Math.Min(4, Me.Items.Count - (4 * (j - 1)))
                        formDataSet.Tables(8).Rows((i - 1) * 9 + 21 + 48 * (j - 1)).Item(1) = i + 4 * (j - 1)
                        formDataSet.Tables(8).Rows((i - 1) * 9 + 22 + 48 * (j - 1)).Item(1) = _
                            GetDateInFFDataFormat(Me.Items(4 * (j - 1) + i - 1).Date)
                        formDataSet.Tables(8).Rows((i - 1) * 9 + 23 + 48 * (j - 1)).Item(1) = _
                            Me.Items(4 * (j - 1) + i - 1).Number
                        formDataSet.Tables(8).Rows((i - 1) * 9 + 24 + 48 * (j - 1)).Item(1) = _
                            GetNumberInFFDataFormat(Me.Items(4 * (j - 1) + i - 1).SumLTL)
                        formDataSet.Tables(8).Rows((i - 1) * 9 + 25 + 48 * (j - 1)).Item(1) = _
                            GetNumberInFFDataFormat(Me.Items(4 * (j - 1) + i - 1).SumVatLTL)
                        formDataSet.Tables(8).Rows((i - 1) * 9 + 26 + 48 * (j - 1)).Item(1) = 0

                        If Not String.IsNullOrEmpty(Me.Items(4 * (j - 1) + i - 1).PersonVatCode) Then
                            formDataSet.Tables(8).Rows((i - 1) * 9 + 28 + 48 * (j - 1)).Item(1) = _
                                Me.Items(4 * (j - 1) + i - 1).PersonVatCode
                        Else
                            formDataSet.Tables(8).Rows((i - 1) * 9 + 28 + 48 * (j - 1)).Item(1) = _
                                Me.Items(4 * (j - 1) + i - 1).PersonCode
                        End If
                        formDataSet.Tables(8).Rows((i - 1) * 9 + 29 + 48 * (j - 1)).Item(1) = _
                            GetLimitedLengthString(Me.Items(4 * (j - 1) + i - 1).PersonName, 32)
                        sumLtl = sumLtl + Me.Items(4 * (j - 1) + i - 1).SumLTL
                        sumVatLtl = sumVatLtl + Me.Items(4 * (j - 1) + i - 1).SumVatLTL
                    Next
                    formDataSet.Tables(8).Rows(57 + 48 * (j - 1)).Item(1) = GetNumberInFFDataFormat(sumLtl)
                    formDataSet.Tables(8).Rows(58 + 48 * (j - 1)).Item(1) = GetNumberInFFDataFormat(sumVatLtl)
                    formDataSet.Tables(8).Rows(59 + 48 * (j - 1)).Item(1) = 0
                Next
            Catch ex As Exception
                Throw New Exception("Failed to write details data to ffdata file.", ex)
            End Try

            Return formDataSet

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return CanGetObjectInvoiceMade() OrElse CanGetObjectInvoiceReceived()
        End Function

        Public Shared Function CanGetObjectInvoiceMade() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMadeInfolist1")
        End Function

        Public Shared Function CanGetObjectInvoiceReceived() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceReceivedInfolist1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of InvoiceInfoItem) = Nothing

        Public Shared Function GetList(ByVal nInfoType As InvoiceInfoType, ByVal nDateFrom As Date, _
            ByVal nDateTo As Date, ByVal nPerson As PersonInfo) As InvoiceInfoItemList

            If Not nPerson Is Nothing AndAlso Not nPerson.ID > 0 Then nPerson = Nothing

            Dim result As InvoiceInfoItemList = DataPortal.Fetch(Of InvoiceInfoItemList) _
                (New Criteria(nInfoType, nDateFrom, nDateTo, nPerson))

            Return result

        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of InvoiceInfoItem)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of InvoiceInfoItem)(Me)
            Return _SortedList
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private ReadOnly _InfoType As InvoiceInfoType
            Private ReadOnly _DateFrom As Date
            Private ReadOnly _DateTo As Date
            Private ReadOnly _Person As PersonInfo
            Public ReadOnly Property InfoType() As InvoiceInfoType
                Get
                    Return _InfoType
                End Get
            End Property
            Public ReadOnly Property DateFrom() As Date
                Get
                    Return _DateFrom
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo
                End Get
            End Property
            Public ReadOnly Property Person() As PersonInfo
                Get
                    Return _Person
                End Get
            End Property
            Public Sub New(ByVal nInfoType As InvoiceInfoType, ByVal nDateFrom As Date, _
                ByVal nDateTo As Date, ByVal nPerson As PersonInfo)
                _InfoType = nInfoType
                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _Person = nPerson
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If (criteria.InfoType = InvoiceInfoType.InvoiceMade AndAlso Not CanGetObjectInvoiceMade()) _
                OrElse (criteria.InfoType = InvoiceInfoType.InvoiceReceived AndAlso _
                Not CanGetObjectInvoiceReceived()) Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As SQLCommand

            If criteria.InfoType = InvoiceInfoType.InvoiceReceived Then

                If Not criteria.Person Is Nothing Then
                    myComm = New SQLCommand("FetchInvoiceInfoItemListForInvoiceReceivedByClient")
                Else
                    myComm = New SQLCommand("FetchInvoiceInfoItemListForInvoiceReceived")
                End If

            ElseIf criteria.InfoType = InvoiceInfoType.InvoiceMade Then

                If Not criteria.Person Is Nothing Then
                    myComm = New SQLCommand("FetchInvoiceInfoItemListForInvoiceMadeByClient")
                Else
                    myComm = New SQLCommand("FetchInvoiceInfoItemListForInvoiceMade")
                End If

            Else
                Throw New NotImplementedException("Dokumento tipas '" _
                    & criteria.InfoType.ToString() & "' neimplementuotas.")
            End If

            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            If Not criteria.Person Is Nothing Then myComm.AddParam("?PD", criteria.Person.ID)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(InvoiceInfoItem.GetInvoiceInfoItem(dr, criteria.InfoType))
                Next

                _InfoType = criteria.InfoType
                _DateFrom = criteria.DateFrom.Date
                _DateTo = criteria.DateTo.Date
                _Person = criteria.Person

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace