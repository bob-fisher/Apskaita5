Namespace HelperLists

    <Serializable()> _
Public Class GoodsGroupInfoList
        Inherits ReadOnlyListBase(Of GoodsGroupInfoList, GoodsGroupInfo)

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsGroupInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList() As GoodsGroupInfoList

            Dim result As GoodsGroupInfoList = CacheManager.GetItemFromCache(Of GoodsGroupInfoList)( _
                GetType(GoodsGroupInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of GoodsGroupInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(GoodsGroupInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean) _
            As Csla.FilteredBindingList(Of GoodsGroupInfo)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")

            Dim FilterToApply(0) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)

            Dim result As Csla.FilteredBindingList(Of GoodsGroupInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of GoodsGroupInfo)) _
                (GetType(GoodsGroupInfoList), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As GoodsGroupInfoList = GoodsGroupInfoList.GetList
                result = New Csla.FilteredBindingList(Of GoodsGroupInfo) _
                    (New Csla.SortedBindingList(Of GoodsGroupInfo)(BaseList), _
                    AddressOf GoodsGroupInfoListFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(GoodsGroupInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(GoodsGroupInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(GoodsGroupInfoList))
        End Function

        Private Shared Function GoodsGroupInfoListFilter(ByVal item As Object, _
            ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse Not TypeOf filterValue Is Object() _
                OrElse Not DirectCast(filterValue, Object()).Length > 0 Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))

            ' no criteria to apply
            If ShowEmpty Then Return True

            Dim CI As GoodsGroupInfo = DirectCast(item, GoodsGroupInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As GoodsGroupInfoList
            Dim result As New GoodsGroupInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Friend Shared Function GetGoodsGroupInfoListOnServer() As GoodsGroupInfoList
            Dim result As New GoodsGroupInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Public Function GetGoodsGroupInfoByName(ByVal groupName As String) As GoodsGroupInfo
            If groupName Is Nothing OrElse String.IsNullOrEmpty(groupName.Trim) Then Return Nothing
            For Each g As GoodsGroupInfo In Me
                If g.Name.Trim.ToUpper = groupName.Trim.ToUpper Then Return g
            Next
            Return Nothing
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

            RaiseListChangedEvents = False
            IsReadOnly = False

            Dim myComm As New SQLCommand("FetchGoodsGroupInfoList")

            Using myData As DataTable = myComm.Fetch

                Add(GoodsGroupInfo.GetEmptyGoodsGroupInfo())

                For Each dr As DataRow In myData.Rows
                    Add(GoodsGroupInfo.GetGoodsGroupInfo(dr))
                Next

            End Using

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace