Namespace HelperLists

    <Serializable()> _
    Public Class CashAccountInfoList
        Inherits ReadOnlyListBase(Of CashAccountInfoList, CashAccountInfo)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.CashAccountInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement filter and sorting in gridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of CashAccountInfo) = Nothing
        <NonSerialized()> _
        Private _Filter() As Object = Nothing

        Public Shared Function GetList() As CashAccountInfoList

            Dim result As CashAccountInfoList = CacheManager.GetItemFromCache(Of CashAccountInfoList)( _
                GetType(CashAccountInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of CashAccountInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(CashAccountInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowObsolete As Boolean, _
            ByVal ShowEmpty As Boolean) As Csla.FilteredBindingList(Of CashAccountInfo)

            Dim FilterToApply(1) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowObsolete)
            FilterToApply(1) = ConvertDbBoolean(ShowEmpty)

            Dim result As Csla.FilteredBindingList(Of CashAccountInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of CashAccountInfo)) _
                (GetType(CashAccountInfoList), FilterToApply)


            If result Is Nothing Then

                Dim BaseList As CashAccountInfoList = CashAccountInfoList.GetList
                result = New Csla.FilteredBindingList(Of CashAccountInfo)(BaseList, _
                    AddressOf CashAccountInfoFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(CashAccountInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(CashAccountInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(CashAccountInfoList))
        End Function

        Private Shared Function CashAccountInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing Then Return True

            Dim ShowObsolete As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))
            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(1), Integer))

            ' no criteria to apply
            If ShowObsolete AndAlso ShowEmpty Then Return True

            Dim CI As CashAccountInfo = DirectCast(item, CashAccountInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False
            If Not ShowObsolete AndAlso CI.IsObsolete AndAlso CI.ID > 0 Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As CashAccountInfoList
            Dim result As New CashAccountInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Public Function GetFilteredList() As Csla.FilteredBindingList(Of CashAccountInfo)

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of CashAccountInfo) _
                    (New Csla.SortedBindingList(Of CashAccountInfo)(Me), AddressOf CashAccountInfoFilter)
                _Filter = New Object() {ConvertDbBoolean(True), ConvertDbBoolean(False)}
                _FilteredList.ApplyFilter("", _Filter)

            End If

            Return _FilteredList

        End Function

        Public Function ApplyFilter(ByVal ShowObsolete As Boolean) As Boolean

            If _FilteredList Is Nothing Then _FilteredList = _
                New Csla.FilteredBindingList(Of CashAccountInfo) _
                (New Csla.SortedBindingList(Of CashAccountInfo)(Me), AddressOf CashAccountInfoFilter)

            If _Filter Is Nothing OrElse _Filter.Length <> 2 OrElse _
                Convert.ToInt32(_Filter(0)) <> ConvertDbBoolean(ShowObsolete) Then

                _Filter = New Object() {ConvertDbBoolean(ShowObsolete), ConvertDbBoolean(False)}
                _FilteredList.ApplyFilter("", _Filter)

                Return True

            End If

            Return False

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
                "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")

            Dim myComm As New SQLCommand("FetchCashAccountInfoList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(CashAccountInfo.GetCashAccountInfo(dr, 0))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace