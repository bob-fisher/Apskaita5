Namespace HelperLists

    <Serializable()> _
    Public Class CompanyRegionalInfoList
        Inherits ReadOnlyListBase(Of CompanyRegionalInfoList, CompanyRegionalInfo)

#Region " Business Methods "

        Public Function GetItemByLanguageCode(ByVal nLanguageCode As String) As CompanyRegionalInfo
            If nLanguageCode Is Nothing OrElse String.IsNullOrEmpty(nLanguageCode.Trim) Then _
                nLanguageCode = LanguageCodeLith.Trim.ToUpper
            For Each i As CompanyRegionalInfo In Me
                If i.LanguageCode.Trim.ToUpper = nLanguageCode.Trim.ToUpper Then Return i
            Next
            Return Nothing
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.CompanyRegionalInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of CompanyRegionalInfo) = Nothing

        Public Shared Function GetList() As CompanyRegionalInfoList

            Dim result As CompanyRegionalInfoList = CacheManager.GetItemFromCache(of CompanyRegionalInfoList)( _
                GetType(CompanyRegionalInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of CompanyRegionalInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(CompanyRegionalInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean) _
            As System.ComponentModel.BindingList(Of String)

            Dim FilterToApply(0) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)

            Dim result As System.ComponentModel.BindingList(Of String) = _
                CacheManager.GetItemFromCache(Of System.ComponentModel.BindingList(Of String)) _
                (GetType(CompanyRegionalInfoList), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As CompanyRegionalInfoList = CompanyRegionalInfoList.GetList
                result = New System.ComponentModel.BindingList(Of String)
                If ShowEmpty Then result.Add("")
                For Each i As CompanyRegionalInfo In BaseList
                    result.Add(i.LanguageName)
                Next
                CacheManager.AddCacheItem(GetType(CompanyRegionalInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(CompanyRegionalInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(CompanyRegionalInfoList))
        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As CompanyRegionalInfoList
            Dim result As New CompanyRegionalInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of CompanyRegionalInfo)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of CompanyRegionalInfo)(Me)
            Return _SortedList
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchCompanyRegionalInfoList")
            myComm.AddParam("?LC", LanguageCodeLith.Trim.ToUpper)
            myComm.AddParam("?IT", TokenInvoiceForm.Trim)
            myComm.AddParam("?LT", TokenCompanyLogo.Trim)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(CompanyRegionalInfo.GetCompanyRegionalInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace