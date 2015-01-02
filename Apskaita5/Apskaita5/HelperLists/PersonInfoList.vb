Namespace HelperLists

    <Serializable()> _
Public Class PersonInfoList
        Inherits ReadOnlyListBase(Of PersonInfoList, PersonInfo)

#Region " Business Methods "

        Public Function GetPersonInfo(ByVal code As String) As PersonInfo
            For Each p As PersonInfo In Me
                If p.Code.Trim.ToLower = code.Trim.ToLower Then Return p
            Next
            Return Nothing
        End Function

        Public Function GetPersonInfo(ByVal id As Integer) As PersonInfo
            For Each p As PersonInfo In Me
                If p.ID = id Then Return p
            Next
            Return Nothing
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.PersonInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement filter and sorting in gridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of PersonInfo) = Nothing
        <NonSerialized()> _
        Private _Filter() As Object = Nothing


        Public Shared Function GetList() As PersonInfoList

            Dim result As PersonInfoList = CacheManager.GetItemFromCache(Of PersonInfoList)( _
                GetType(PersonInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of PersonInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(PersonInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean, _
            ByVal ShowClients As Boolean, ByVal ShowSuppliers As Boolean, _
            ByVal ShowWorkers As Boolean) As Csla.FilteredBindingList(Of PersonInfo)

            Dim FilterToApply(3) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)
            FilterToApply(1) = ConvertDbBoolean(ShowClients)
            FilterToApply(2) = ConvertDbBoolean(ShowSuppliers)
            FilterToApply(3) = ConvertDbBoolean(ShowWorkers)

            Dim result As Csla.FilteredBindingList(Of PersonInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of PersonInfo)) _
                (GetType(PersonInfoList), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As PersonInfoList = PersonInfoList.GetList
                result = New Csla.FilteredBindingList(Of PersonInfo)(BaseList, AddressOf PersonInfoFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(PersonInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(PersonInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(PersonInfoList))
        End Function

        Private Shared Function PersonInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse DirectCast(filterValue, Object()).Length < 4 Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))
            Dim ShowClients As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(1), Integer))
            Dim ShowSuppliers As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(2), Integer))
            Dim ShowWorkers As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(3), Integer))

            ' no criteria to apply
            If ShowEmpty AndAlso ShowClients AndAlso ShowSuppliers AndAlso ShowWorkers Then Return True

            Dim CI As PersonInfo = DirectCast(item, PersonInfo)

            If ShowClients AndAlso ShowSuppliers AndAlso ShowWorkers AndAlso ShowEmpty Then Return True

            If CI.ID > 0 AndAlso ShowWorkers AndAlso ShowSuppliers AndAlso ShowWorkers Then
                Return True
            Else
                If CI.ID > 0 AndAlso ShowClients AndAlso CI.IsClient Then Return True
                If CI.ID > 0 AndAlso ShowSuppliers AndAlso CI.IsSupplier Then Return True
                If CI.ID > 0 AndAlso ShowWorkers AndAlso CI.IsWorker Then Return True
            End If
            If ShowEmpty AndAlso Not CI.ID > 0 Then Return True

            Return False

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As PersonInfoList
            Dim result As New PersonInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function

        Friend Shared Function GetListServerSide() As PersonInfoList
            Dim result As New PersonInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Public Function GetFilteredList() As Csla.FilteredBindingList(Of PersonInfo)

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of PersonInfo) _
                    (New Csla.SortedBindingList(Of PersonInfo)(Me), AddressOf PersonInfoFilter)
                _Filter = New Object() {ConvertDbBoolean(False)}
                _FilteredList.ApplyFilter("", _Filter)

            End If

            Return _FilteredList

        End Function

        Public Function ApplyFilter(ByVal ShowClients As Boolean, _
            ByVal ShowSuppliers As Boolean, ByVal ShowWorkers As Boolean) As Boolean

            If _FilteredList Is Nothing Then _FilteredList = _
                New Csla.FilteredBindingList(Of PersonInfo) _
                (New Csla.SortedBindingList(Of PersonInfo)(Me), AddressOf PersonInfoFilter)

            Dim FilterToApply(3) As Object
            FilterToApply(0) = ConvertDbBoolean(False)
            FilterToApply(1) = ConvertDbBoolean(ShowClients)
            FilterToApply(2) = ConvertDbBoolean(ShowSuppliers)
            FilterToApply(3) = ConvertDbBoolean(ShowWorkers)
            _Filter = FilterToApply

            _FilteredList.ApplyFilter("", _Filter)

            Return True

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

            Dim myComm As New SQLCommand("FetchPersonInfoList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(PersonInfo.GetEmptyPersonInfo)
                For Each dr As DataRow In myData.Rows
                    Add(PersonInfo.GetPersonInfo(dr, 0))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace