Imports ApskaitaObjects.HelperLists
Public Class F_Declarations

    Private Obj As ActiveReports.Declaration = Nothing

    Private ReportDataSet As ReportData
    Private TblGeneral As BindingSource
    Private Tbl1 As BindingSource = Nothing
    Private Tbl2 As BindingSource = Nothing
    Private Tbl3 As BindingSource = Nothing
    Private Tbl4 As BindingSource = Nothing
    Private TblCompany As BindingSource = Nothing
    Private _NumberOfTablesInUse As Integer
    Private _ReportFileName As String = ""


    Private Sub F_Declarations_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_Declarations_FormClosed(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not ReportDataSet Is Nothing Then ReportDataSet.Dispose()
        If Not TblGeneral Is Nothing Then TblGeneral.Dispose()
        If Not Tbl1 Is Nothing Then Tbl1.Dispose()
        If Not Tbl2 Is Nothing Then Tbl2.Dispose()
        If Not Tbl3 Is Nothing Then Tbl3.Dispose()
        If Not Tbl4 Is Nothing Then Tbl4.Dispose()
        If Not TblCompany Is Nothing Then TblCompany.Dispose()
        GetFormLayout(Me)
    End Sub

    Private Sub F_Declarations_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not ActiveReports.Declaration.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        SetFormLayout(Me)

    End Sub


    Private Sub DeclarationTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles DeclarationTypeComboBox.SelectedIndexChanged

        If DeclarationTypeComboBox.SelectedIndex < 0 Then Exit Sub

        Dim CurrType As DeclarationType
        Try
            CurrType = ConvertEnumHumanReadable(Of DeclarationType) _
                (DeclarationTypeComboBox.SelectedItem.ToString.Trim)
        Catch ex As Exception
            MsgBox("Klaida. Nepavyko nustatyti deklaracijos tipo.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End Try

        MonthComboBox.Enabled = (CurrType = DeclarationType.FR0572 OrElse _
            CurrType = DeclarationType.FR0572_3 OrElse CurrType = DeclarationType.FR0572_4 _
            OrElse CurrType = DeclarationType.SAM_2 OrElse CurrType = DeclarationType.SAM_3)
        QuarterComboBox.Enabled = (CurrType = DeclarationType.SAM_1 OrElse CurrType = DeclarationType.SAM_Aut_1)
        YearComboBox.Enabled = (CurrType <> DeclarationType.SD13_1 AndAlso CurrType <> DeclarationType.SD13_2)
        DateFromDateTimePicker.Enabled = (CurrType = DeclarationType.SD13_1 OrElse _
            CurrType = DeclarationType.SD13_2)
        DateToDateTimePicker.Enabled = (CurrType = DeclarationType.SD13_1 OrElse _
            CurrType = DeclarationType.SD13_2)
        SODRADepartmentComboBox.Enabled = (CurrType = DeclarationType.SD13_1 OrElse _
            CurrType = DeclarationType.SAM_1 OrElse CurrType = DeclarationType.SD13_2 _
            OrElse CurrType = DeclarationType.SAM_Aut_1 OrElse CurrType = DeclarationType.SAM_2 _
            OrElse CurrType = DeclarationType.SAM_3)
        SODRAAccountAccGridComboBox.Enabled = (CurrType = DeclarationType.SAM_1 _
            OrElse CurrType = DeclarationType.SAM_Aut_1)
        SODRAAccountAccGridComboBox2.Enabled = (CurrType = DeclarationType.SAM_1 _
            OrElse CurrType = DeclarationType.SAM_Aut_1)
        MunicipalitiesMTGCComboBox.Enabled = (CurrType = DeclarationType.FR0572 OrElse _
            CurrType = DeclarationType.FR0572_3 OrElse CurrType = DeclarationType.FR0573 OrElse _
            CurrType = DeclarationType.FR0573_3 OrElse CurrType = DeclarationType.FR0572_4)
        SodraRateComboBox.Enabled = (CurrType = DeclarationType.SAM_3)
        RefreshSodraRateButton.Enabled = (CurrType = DeclarationType.SAM_3)

        If Not MonthComboBox.Enabled Then MonthComboBox.SelectedIndex = -1
        If Not QuarterComboBox.Enabled Then QuarterComboBox.SelectedIndex = -1
        If Not YearComboBox.Enabled Then YearComboBox.SelectedIndex = -1
        If Not SODRADepartmentComboBox.Enabled Then SODRADepartmentComboBox.SelectedIndex = -1
        If Not SODRAAccountAccGridComboBox.Enabled Then SODRAAccountAccGridComboBox.SelectedValue = Nothing
        If Not SODRAAccountAccGridComboBox2.Enabled Then SODRAAccountAccGridComboBox2.SelectedValue = Nothing
        If Not MunicipalitiesMTGCComboBox.Enabled Then MunicipalitiesMTGCComboBox.SelectedIndex = -1
        If Not SodraRateComboBox.Enabled Then SodraRateComboBox.SelectedIndex = -1
        If CurrType <> DeclarationType.SD13_1 AndAlso CurrType <> DeclarationType.SD13_2 Then
            DateFromDateTimePicker.Value = Today
            DateToDateTimePicker.Value = Today
        End If

    End Sub

    Private Sub OnRenderingComplete(ByVal sender As Object, _
            ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) _
            Handles DeclarationReportViewer.RenderingComplete
        DeclarationReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        DeclarationReportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
        DeclarationReportViewer.ZoomPercent = 75
    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim DType As DeclarationType
        Try
            DType = ConvertEnumHumanReadable(Of DeclarationType) _
                (DeclarationTypeComboBox.SelectedItem.ToString.Trim)
        Catch ex As Exception
            MsgBox("Klaida. Nepasirinktas deklaracijos tipas.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End Try

        Dim DYear As Integer = 0
        Dim DMonth As Integer = MonthComboBox.SelectedIndex + 1
        Dim DQuarter As Byte = Convert.ToByte(QuarterComboBox.SelectedIndex + 1)
        Dim DSodraAccount As Long = 0
        Dim DSodraAccount2 As Long = 0
        Dim SodraRate As Double = 0
        Try
            DSodraAccount = DirectCast(SODRAAccountAccGridComboBox.SelectedValue, Long)
        Catch ex As Exception
        End Try
        Try
            DSodraAccount2 = DirectCast(SODRAAccountAccGridComboBox2.SelectedValue, Long)
        Catch ex As Exception
        End Try
        Try
            SodraRate = CDbl(SodraRateComboBox.SelectedItem)
        Catch ex As Exception
        End Try
        Dim DSodraDepartment As String = ""
        Dim DMunicipalityCode As String = ""

        Try
            DYear = Integer.Parse(YearComboBox.SelectedItem.ToString)
        Catch ex As Exception
        End Try
        If Not SODRADepartmentComboBox.SelectedItem Is Nothing Then _
            DSodraDepartment = DirectCast(SODRADepartmentComboBox.SelectedItem, NameValueItem).Name
        If Not MunicipalitiesMTGCComboBox.SelectedValue Is Nothing Then
            DMunicipalityCode = MunicipalitiesMTGCComboBox.SelectedValue.Trim
        End If

        Dim GpmCode As String = ""
        Try
            GpmCode = ApskaitaObjects.Settings.CommonSettings.GetList.CodeWageGPM
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        Try
            Obj = LoadObject(Of ActiveReports.Declaration)(Nothing, "GetDeclaration", True, DType, _
                DateDateTimePicker.Value.Date, DateFromDateTimePicker.Value.Date, _
                DateToDateTimePicker.Value.Date, DSodraDepartment, SodraRate, DYear, CInt(DQuarter), _
                DMonth, DSodraAccount, DSodraAccount2, DMunicipalityCode, GpmCode)
            'Obj = ActiveReports.Declaration.GetDeclaration(DType, _
            '    DateDateTimePicker.Value.Date, DateFromDateTimePicker.Value.Date, _
            '    DateToDateTimePicker.Value.Date, DSodraDepartment, DYear, DQuarter, _
            '    DMonth, DSodraAccount, DSodraAccount2, DMunicipalityCode, GpmCode)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        If (Obj.DeclarationType = DeclarationType.SAM_1 OrElse _
            Obj.DeclarationType = DeclarationType.SAM_Aut_1 OrElse _
            Obj.DeclarationType = DeclarationType.SAM_2) AndAlso _
            Not String.IsNullOrEmpty(Obj.Warning.Trim) Then _
            MsgBox(Obj.Warning.Trim, MsgBoxStyle.Information, "Info")

        Try
            Using busy As New StatusBusy
                RefreshReportViewer()
                GetFFdataButton.Enabled = True
            End Using
        Catch ex As Exception
            ShowError(ex)
        End Try

        DeclarationReportViewer.Select()
        DeclarationReportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
        DeclarationReportViewer.ZoomPercent = 75

    End Sub

    Private Sub GetFFdataButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetFFdataButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim FileName As String = ""

        Using SFD As New SaveFileDialog
            SFD.Filter = "FFData failai|*.ffdata|Visi failai|*.*"
            SFD.CheckFileExists = False
            SFD.AddExtension = True
            SFD.DefaultExt = ".ffdata"
            If SFD.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            FileName = SFD.FileName.Trim
        End Using

        If String.IsNullOrEmpty(FileName) Then Exit Sub

        Try

            Obj.SaveToFFData(FileName, MyCustomSettings.UserName)

            If Obj.DeclarationType = DeclarationType.FR0572 OrElse _
                Obj.DeclarationType = DeclarationType.FR0573 OrElse _
                Obj.DeclarationType = DeclarationType.SAM_1 OrElse _
                Obj.DeclarationType = DeclarationType.SAM_Aut_1 OrElse _
                Obj.DeclarationType = DeclarationType.SD13_1 Then _
                    MsgBox("DĖMESIO!!! Ši deklaracija ar jos versija yra nebenaudojama. " & _
                        "Atidarant suformuotą ffdata failą ABBYY eFormFiller programa, " & _
                        "jums gali būti pasiūlyta atnaujinti formą. Šito daryti GRIEŽTAI " & _
                        "NEGALIMA, nes sugadinsite programos saugomą senos formos šabloną.", _
                        MsgBoxStyle.Exclamation, "Info")

            If YesOrNo("Failas sėkmingai išsaugotas. Atidaryti?") Then _
                System.Diagnostics.Process.Start(FileName)

        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub RefreshSodraRateButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshSodraRateButton.Click

        If DeclarationTypeComboBox.SelectedIndex < 0 Then Exit Sub

        Dim CurrType As DeclarationType
        Try
            CurrType = ConvertEnumHumanReadable(Of DeclarationType) _
                (DeclarationTypeComboBox.SelectedItem.ToString.Trim)
        Catch ex As Exception
            MsgBox("Klaida. Nepavyko nustatyti deklaracijos tipo.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End Try

        If CurrType <> DeclarationType.SAM_3 Then
            MsgBox("Klaida. SODROS tarifas aktualus tik SAM v.3 deklaracijai.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim DYear As Integer = 0
        Dim DMonth As Integer = MonthComboBox.SelectedIndex + 1
        Try
            DYear = Integer.Parse(YearComboBox.SelectedItem.ToString)
        Catch ex As Exception
            MsgBox("Klaida.Nepasirinkti metai.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End Try

        Dim RateObj As ActiveReports.SodraRateInfo

        Try
            RateObj = LoadObject(Of ActiveReports.SodraRateInfo)(Nothing, "GetSodraRateInfo", _
                True, DYear, DMonth)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        SodraRateComboBox.DataSource = RateObj.Rates

    End Sub

    Private Sub RefreshReportViewer()
        DeclarationReportViewer.LocalReport.DataSources.Clear()
        DeclarationReportViewer.Reset()

        If Obj Is Nothing Then Exit Sub

        ReportDataSet = MapObjToReport(Obj, _ReportFileName, _NumberOfTablesInUse, 1)

        If _NumberOfTablesInUse < 0 Then _NumberOfTablesInUse = 0
        If _NumberOfTablesInUse > 4 Then _NumberOfTablesInUse = 4
        InitializeBindingSources(_NumberOfTablesInUse)

        Dim NewSourceGeneral As New Microsoft.Reporting.WinForms.ReportDataSource
        NewSourceGeneral.Value = TblGeneral
        NewSourceGeneral.Name = "ReportData_TableGeneral"
        DeclarationReportViewer.LocalReport.DataSources.Add(NewSourceGeneral)

        Dim NewSourceCompany As New Microsoft.Reporting.WinForms.ReportDataSource
        NewSourceCompany.Value = TblCompany
        NewSourceCompany.Name = "ReportData_TableCompany"
        DeclarationReportViewer.LocalReport.DataSources.Add(NewSourceCompany)


        For i As Integer = 1 To _NumberOfTablesInUse

            Dim NewSource As New Microsoft.Reporting.WinForms.ReportDataSource

            If i = 1 Then
                NewSource.Value = Tbl1
                NewSource.Name = "ReportData_Table1"
            ElseIf i = 2 Then
                NewSource.Value = Tbl2
                NewSource.Name = "ReportData_Table2"
            ElseIf i = 3 Then
                NewSource.Value = Tbl3
                NewSource.Name = "ReportData_Table3"
            Else
                NewSource.Value = Tbl4
                NewSource.Name = "ReportData_Table4"
            End If

            DeclarationReportViewer.LocalReport.DataSources.Add(NewSource)

        Next

        DeclarationReportViewer.LocalReport.ReportPath = AppPath() & "\Reports\" & _ReportFileName

        DeclarationReportViewer.RefreshReport()

    End Sub


    Private Sub InitializeBindingSources(ByVal NumberOfTablesInUse As Integer)
        TblGeneral = New BindingSource(ReportDataSet, "TableGeneral")
        TblCompany = New BindingSource(ReportDataSet, "TableCompany")
        If NumberOfTablesInUse < 1 Then Exit Sub
        If NumberOfTablesInUse >= 1 Then Tbl1 = New BindingSource(ReportDataSet, "Table1")
        If NumberOfTablesInUse >= 2 Then Tbl2 = New BindingSource(ReportDataSet, "Table2")
        If NumberOfTablesInUse >= 3 Then Tbl3 = New BindingSource(ReportDataSet, "Table3")
        If NumberOfTablesInUse >= 4 Then Tbl4 = New BindingSource(ReportDataSet, "Table4")
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            LoadAccountInfoListToGridCombo(SODRAAccountAccGridComboBox, True, 4)
            LoadAccountInfoListToGridCombo(SODRAAccountAccGridComboBox2, True, 4)

            YearComboBox.Items.Clear()
            For i As Integer = 1 To 10
                YearComboBox.Items.Add((Today.Year - i + 1).ToString)
            Next

            DeclarationTypeComboBox.DataSource = GetEnumValuesHumanReadableList( _
                GetType(DeclarationType), False, DeclarationType.FR0572, _
                DeclarationType.FR0572_3, DeclarationType.FR0572_4, DeclarationType.FR0573, _
                DeclarationType.FR0573_3, DeclarationType.SAM_1, DeclarationType.SAM_2, _
                DeclarationType.SAM_3, DeclarationType.SAM_Aut_1, DeclarationType.SD13_1, _
                DeclarationType.SD13_2)

            Dim ML As NameValueItemList = NameValueItemList.GetNameValueItemList(SettingListType.MunicipalityCodeList)
            Dim SD As NameValueItemList = NameValueItemList.GetNameValueItemList(SettingListType.SodraBranchesList)

            SODRADepartmentComboBox.DataSource = SD
            SODRADepartmentComboBox.DisplayMember = "Name"
            SODRADepartmentComboBox.ValueMember = "Name"

            MunicipalitiesMTGCComboBox.LoadingType = MTGCComboBox.CaricamentoCombo.CustomObject
            MunicipalitiesMTGCComboBox.ColumnNum = 2
            MunicipalitiesMTGCComboBox.ValueForNothing = ""
            MunicipalitiesMTGCComboBox.SourcePropertiesString = "Value, Name"
            MunicipalitiesMTGCComboBox.ColumnWidth = "40; 100"
            MunicipalitiesMTGCComboBox.SourceObjectAddEmptyItem = True
            MunicipalitiesMTGCComboBox.SourceObject = ML

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class