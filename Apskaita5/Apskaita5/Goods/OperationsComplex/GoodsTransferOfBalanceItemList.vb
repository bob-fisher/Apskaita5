Namespace Goods

    <Serializable()> _
    Public Class GoodsTransferOfBalanceItemList
        Inherits BusinessListBase(Of GoodsTransferOfBalanceItemList, GoodsTransferOfBalanceItem)

#Region " Business Methods "

        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Public Function ContainsGood(ByVal GoodsID As Integer, ByVal WarehouseID As Integer) As Boolean
            For Each i As GoodsTransferOfBalanceItem In Me
                If i.GoodsInfo.ID = GoodsID AndAlso i.Warehouse.ID = WarehouseID Then Return True
            Next
            For Each i As GoodsTransferOfBalanceItem In Me.DeletedList
                If Not i.IsNew AndAlso i.GoodsInfo.ID = GoodsID AndAlso i.Warehouse.ID = WarehouseID Then Return True
            Next
            Return False
        End Function


        Friend Sub SetDate(ByVal value As Date)
            RaiseListChangedEvents = False
            For Each i As GoodsTransferOfBalanceItem In Me
                i.SetDate(value)
            Next
            RaiseListChangedEvents = True
        End Sub


        Friend Function GetLimitations() As OperationalLimitList()
            Dim result As New List(Of OperationalLimitList)
            For Each i As GoodsTransferOfBalanceItem In Me
                result.Add(i.OperationLimitations)
            Next
            Return result.ToArray
        End Function

        Friend Sub ReloadLimitations(ByVal LimitationsDataSource As DataTable)
            RaiseListChangedEvents = False
            For Each i As GoodsTransferOfBalanceItem In Me
                If Not i.IsNew Then i.ReloadLimitations(LimitationsDataSource)
            Next
            For Each i As GoodsTransferOfBalanceItem In Me.DeletedList
                If Not i.IsNew Then i.ReloadLimitations(LimitationsDataSource)
            Next
            RaiseListChangedEvents = True
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsTransferOfBalanceItemList() As GoodsTransferOfBalanceItemList
            Return New GoodsTransferOfBalanceItemList
        End Function

        Friend Shared Function GetGoodsTransferOfBalanceItemList( _
            ByVal objList As List(Of OperationPersistenceObject), _
            ByVal LimitationsDataSource As DataTable) As GoodsTransferOfBalanceItemList
            Return New GoodsTransferOfBalanceItemList(objList, LimitationsDataSource)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal LimitationsDataSource As DataTable)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
            Fetch(objList, LimitationsDataSource)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal LimitationsDataSource As DataTable)

            RaiseListChangedEvents = False

            For Each obj As OperationPersistenceObject In objList
                If obj.OperationType <> GoodsOperationType.TransferOfBalance Then _
                    Throw New Exception("Klaida. Sugadinti duomenys. Likučių perkėlimo kompleksinei " _
                    & "operacijai priskirta prekių operacija, kurios tipas " _
                    & ConvertEnumHumanReadable(obj.OperationType) & ".")
                Add(GoodsTransferOfBalanceItem.GetGoodsTransferOfBalanceItem(obj, LimitationsDataSource))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As GoodsComplexOperationTransferOfBalance)

            RaiseListChangedEvents = False

            For Each item As GoodsTransferOfBalanceItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As GoodsTransferOfBalanceItem In Me
                If item.IsNew Then
                    item.Insert(parent.JournalEntryID, parent.ID, parent.DocumentNumber, parent.Content)
                ElseIf item.IsDirty Then
                    item.Update(parent.JournalEntryID, parent.ID, parent.DocumentNumber, parent.Content)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub AddNewTransferOfBalanceItems(ByVal operationDate As Date, ByVal SourceString As String)

            Dim goodsList As GoodsInfoList = GoodsInfoList.GetListServerSide
            Dim warehouseList As WarehouseInfoList = WarehouseInfoList.GetListServerSide

            Dim currentWarehouse As WarehouseInfo = Nothing
            Dim currentGoods As GoodsInfo = Nothing
            Dim currentGoodsName, currentWarehouseName As String

            RaiseListChangedEvents = False

            For Each s As String In SourceString.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

                currentGoodsName = GetField(s, vbTab, 0)
                currentWarehouseName = GetField(s, vbTab, 1)

                currentGoods = goodsList.GetItem(currentGoodsName)
                currentWarehouse = warehouseList.GetItem(currentWarehouseName)

                If Not currentGoods Is Nothing AndAlso currentGoods.ID > 0 AndAlso _
                    Not currentWarehouse Is Nothing AndAlso currentWarehouse.ID > 0 Then

                    If Not ContainsGood(currentGoods.ID, currentWarehouse.ID) Then

                        Me.Add(GoodsTransferOfBalanceItem.NewGoodsTransferOfBalanceItem( _
                            currentGoods, currentWarehouse, operationDate, s))

                    End If

                End If

            Next

            RaiseListChangedEvents = True

        End Sub


        Friend Function CheckIfCanUpdate(ByVal LimitationsDataSource As DataTable, _
            ByVal ThrowOnInvalid As Boolean) As String

            Dim result As String = ""

            For Each i As GoodsTransferOfBalanceItem In Me
                result = AddWithNewLine(result, i.CheckIfCanUpdate(LimitationsDataSource, ThrowOnInvalid), False)
            Next

            For Each i As GoodsTransferOfBalanceItem In Me.DeletedList
                If Not i.IsNew Then result = AddWithNewLine(result, _
                    i.CheckIfCanDelete(LimitationsDataSource, ThrowOnInvalid), False)
            Next

            Return result

        End Function

        Friend Sub PrepareOperationConsignments()
            RaiseListChangedEvents = False
            For Each i As GoodsTransferOfBalanceItem In Me
                i.GetConsignment()
            Next
            RaiseListChangedEvents = True
        End Sub

#End Region

    End Class

End Namespace