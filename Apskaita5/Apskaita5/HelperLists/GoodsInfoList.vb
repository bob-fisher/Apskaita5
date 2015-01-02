Namespace HelperLists

    <Serializable()> _
    Public Class GoodsInfoList
        Inherits ReadOnlyListBase(Of GoodsInfoList, GoodsInfo)

#Region " Business Methods "

        Public Function GetItem(ByVal id As Integer) As GoodsInfo
            For Each i As GoodsInfo In Me
                If i.ID = id Then Return i
            Next
            Return Nothing
        End Function

        Public Function GetItemByBarCode(ByVal BarCode As String) As GoodsInfo
            If BarCode Is Nothing OrElse String.IsNullOrEmpty(BarCode.Trim) Then Return Nothing
            For Each i As GoodsInfo In Me
                If Not String.IsNullOrEmpty(i.GoodsBarcode.Trim) AndAlso _
                    i.GoodsBarcode.Trim.ToLower = BarCode.Trim.ToLower Then Return i
            Next
            Return Nothing
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList() As GoodsInfoList

            Dim result As GoodsInfoList = CacheManager.GetItemFromCache(Of GoodsInfoList)( _
                GetType(GoodsInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of GoodsInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(GoodsInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowObsolete As Boolean, _
            ByVal ShowEmpty As Boolean, ByVal TradedType As Documents.TradedItemType) _
            As Csla.FilteredBindingList(Of GoodsInfo)

            Dim FilterToApply(2) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowObsolete)
            FilterToApply(1) = ConvertDbBoolean(ShowEmpty)
            FilterToApply(2) = ConvertEnumDatabaseCode(TradedType)

            Dim result As Csla.FilteredBindingList(Of GoodsInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of GoodsInfo)) _
                (GetType(GoodsInfoList), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As GoodsInfoList = GoodsInfoList.GetList
                result = New Csla.FilteredBindingList(Of GoodsInfo)(BaseList, _
                    AddressOf GoodsInfoFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(GoodsInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(GoodsInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(GoodsInfoList))
        End Function

        Private Shared Function GoodsInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing Then Return True

            Dim ShowObsolete As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))
            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(1), Integer))
            Dim TradedType As Documents.TradedItemType = _
                ConvertEnumDatabaseCode(Of Documents.TradedItemType) _
                (DirectCast(DirectCast(filterValue, Object())(2), Integer))


            ' no criteria to apply
            If ShowObsolete AndAlso ShowEmpty AndAlso TradedType = Documents.TradedItemType.All Then Return True

            Dim CI As GoodsInfo = DirectCast(item, GoodsInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False
            If Not ShowObsolete AndAlso CI.IsObsolete AndAlso CI.ID > 0 Then Return False
            If TradedType <> Documents.TradedItemType.All AndAlso CI.TradeItemType <> _
                Documents.TradedItemType.All AndAlso CI.TradeItemType <> TradedType Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As GoodsInfoList
            Dim result As New GoodsInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
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

            Dim myComm As New SQLCommand("FetchGoodsInfoList")
            
            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(GoodsInfo.NewGoodsInfo)

                For Each dr As DataRow In myData.Rows
                    Add(GoodsInfo.GetGoodsInfo(dr, 0))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace