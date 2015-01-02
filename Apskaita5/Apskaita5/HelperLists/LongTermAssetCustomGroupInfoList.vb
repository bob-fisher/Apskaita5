Namespace HelperLists

    <Serializable()> _
    Public Class LongTermAssetCustomGroupInfoList
        Inherits ReadOnlyListBase(Of LongTermAssetCustomGroupInfoList, LongTermAssetCustomGroupInfo)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.LongTermAssetCustomGroupInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of LongTermAssetCustomGroupInfo) = Nothing
        <NonSerialized()> _
        Private _Filter() As Object = Nothing

        Public Shared Function GetList() As LongTermAssetCustomGroupInfoList

            Dim result As LongTermAssetCustomGroupInfoList = _
                CacheManager.GetItemFromCache(Of LongTermAssetCustomGroupInfoList)( _
                GetType(LongTermAssetCustomGroupInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of LongTermAssetCustomGroupInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(LongTermAssetCustomGroupInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean) _
            As Csla.FilteredBindingList(Of LongTermAssetCustomGroupInfo)

            Dim FilterToApply(0) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)

            Dim result As Csla.FilteredBindingList(Of LongTermAssetCustomGroupInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of LongTermAssetCustomGroupInfo)) _
                (GetType(LongTermAssetCustomGroupInfoList), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As LongTermAssetCustomGroupInfoList = _
                    LongTermAssetCustomGroupInfoList.GetList
                result = New Csla.FilteredBindingList(Of LongTermAssetCustomGroupInfo) _
                    (BaseList, AddressOf LongTermAssetCustomGroupInfoFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(LongTermAssetCustomGroupInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(LongTermAssetCustomGroupInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(LongTermAssetCustomGroupInfoList))
        End Function

        Private Shared Function LongTermAssetCustomGroupInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse DirectCast(filterValue, Object()).Length < 1 Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))

            ' no criteria to apply
            If ShowEmpty Then Return True

            Dim CI As LongTermAssetCustomGroupInfo = DirectCast(item, LongTermAssetCustomGroupInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As LongTermAssetCustomGroupInfoList
            Dim result As New LongTermAssetCustomGroupInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Public Function GetFilteredList() As Csla.FilteredBindingList(Of LongTermAssetCustomGroupInfo)

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of LongTermAssetCustomGroupInfo) _
                    (New Csla.SortedBindingList(Of LongTermAssetCustomGroupInfo) _
                    (Me), AddressOf LongTermAssetCustomGroupInfoFilter)
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

            Dim myComm As New SQLCommand("FetchLongTermAssetCustomGroupInfoList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(LongTermAssetCustomGroupInfo.NewLongTermAssetCustomGroupInfo)

                For Each dr As DataRow In myData.Rows
                    Add(LongTermAssetCustomGroupInfo.GetLongTermAssetCustomGroupInfo(dr, 0))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace