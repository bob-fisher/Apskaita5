Namespace HelperLists

    <Serializable()> _
Public Class PersonGroupInfoList
        Inherits ReadOnlyListBase(Of PersonGroupInfoList, PersonGroupInfo)

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.PersonGroupInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement filter and sorting in gridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of PersonGroupInfo) = Nothing

        Public Shared Function GetList() As PersonGroupInfoList

            Dim result As PersonGroupInfoList = CacheManager.GetItemFromCache(Of PersonGroupInfoList)( _
                GetType(PersonGroupInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of PersonGroupInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(PersonGroupInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean) _
            As Csla.FilteredBindingList(Of PersonGroupInfo)

            Dim FilterToApply(0) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)

            Dim result As Csla.FilteredBindingList(Of PersonGroupInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of PersonGroupInfo)) _
                (GetType(PersonGroupInfoList), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As PersonGroupInfoList = PersonGroupInfoList.GetList
                result = New Csla.FilteredBindingList(Of PersonGroupInfo) _
                (BaseList, AddressOf PersonGroupInfoFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(PersonGroupInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(PersonGroupInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(PersonGroupInfoList))
        End Function

        Private Shared Function PersonGroupInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            ' no criteria to apply
            If filterValue Is Nothing OrElse Not TypeOf filterValue Is Object() _
                OrElse DirectCast(filterValue, Object()).Length < 1 OrElse _
                Not ConvertDbBoolean(DirectCast(DirectCast(filterValue, Object())(0), Integer)) Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))

            Dim CI As PersonGroupInfo = DirectCast(item, PersonGroupInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As PersonGroupInfoList
            Dim result As New PersonGroupInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Public Function GetFilteredList() As Csla.FilteredBindingList(Of PersonGroupInfo)

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of PersonGroupInfo) _
                    (New Csla.SortedBindingList(Of PersonGroupInfo)(Me), AddressOf PersonGroupInfoFilter)
                Dim _Filter As Object()
                _Filter = New Object() {ConvertDbBoolean(False)}
                _FilteredList.ApplyFilter("", _Filter)

            End If

            Return _FilteredList

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

            Dim myComm As New SQLCommand("FetchPersonGroupInfoList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(PersonGroupInfo.GetEmptyPersonGroupInfo)
                For Each dr As DataRow In myData.Rows
                    Add(PersonGroupInfo.GetPersonGroupInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace
