Namespace HelperLists

    <Serializable()> _
    Public Class ProductionCalculationInfoList
        Inherits ReadOnlyListBase(Of ProductionCalculationInfoList, ProductionCalculationInfo)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.ProductionCalculationInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList() As ProductionCalculationInfoList

            Dim result As ProductionCalculationInfoList = _
                CacheManager.GetItemFromCache(Of ProductionCalculationInfoList)( _
                GetType(ProductionCalculationInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of ProductionCalculationInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(ProductionCalculationInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean, _
            ByVal ShowObsolete As Boolean) As Csla.FilteredBindingList(Of ProductionCalculationInfo)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai informacijai gauti.")

            Dim FilterToApply(1) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)
            FilterToApply(1) = ConvertDbBoolean(ShowObsolete)

            Dim result As Csla.FilteredBindingList(Of ProductionCalculationInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of ProductionCalculationInfo)) _
                (GetType(ProductionCalculationInfoList), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As ProductionCalculationInfoList = ProductionCalculationInfoList.GetList
                result = New Csla.FilteredBindingList(Of ProductionCalculationInfo)(BaseList, _
                AddressOf ProductionCalculationInfoListFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(ProductionCalculationInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(ProductionCalculationInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(ProductionCalculationInfoList))
        End Function

        Private Shared Function ProductionCalculationInfoListFilter(ByVal item As Object, _
            ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse Not TypeOf filterValue Is Object() _
                OrElse Not DirectCast(filterValue, Object()).Length > 0 Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))
            Dim ShowObsolete As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(1), Integer))

            ' no criteria to apply
            If ShowEmpty AndAlso ShowObsolete Then Return True

            Dim CI As ProductionCalculationInfo = DirectCast(item, ProductionCalculationInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False
            If Not ShowObsolete AndAlso CI.ID > 0 AndAlso CI.IsObsolete Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As ProductionCalculationInfoList
            Dim result As New ProductionCalculationInfoList
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
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchProductionCalculationInfoList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(ProductionCalculationInfo.NewProductionCalculationInfo())

                For Each dr As DataRow In myData.Rows
                    Add(ProductionCalculationInfo.GetProductionCalculationInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace