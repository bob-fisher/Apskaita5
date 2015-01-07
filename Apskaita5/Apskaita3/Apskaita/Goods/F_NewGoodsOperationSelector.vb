Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Goods
Public Class F_NewGoodsOperationSelector

    Private Sub F_NewGoodsOperationSelector_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not PrepareCache(Me, GetType(HelperLists.WarehouseInfoList), _
            GetType(HelperLists.AccountInfoList), GetType(HelperLists.ProductionCalculationInfoList)) Then Exit Sub

        Try

            LoadGoodsInfoListToGridCombo(GoodsInfoListAccGridComboBox, False, Documents.TradedItemType.All)
            LoadWarehouseInfoListToGridCombo(WarehouseInfoListAccGridComboBox, False)
            LoadProductionCalculationInfoListToGridCombo(CalculationInfoListAccGridComboBox, True, False)
            SimpleOperationTypeComboBox.DataSource = GetEnumValuesHumanReadableList( _
                GetType(Goods.GoodsOperationType), False, GoodsOperationType.Discard, _
                    GoodsOperationType.Acquisition, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.ValuationMethodChange, GoodsOperationType.AccountSalesNetCostsChange, _
                    GoodsOperationType.AccountValueReductionChange, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.AccountDiscountsChange)
            ComplexOperationTypeComboBox.DataSource = GetEnumValuesHumanReadableList( _
                GetType(Goods.GoodsComplexOperationType), False, GoodsComplexOperationType.BulkDiscard, _
                GoodsComplexOperationType.InternalTransfer, GoodsComplexOperationType.Production, _
                GoodsComplexOperationType.BulkPriceCut, GoodsComplexOperationType.Inventorization)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
        End Try

        Try
            If WarehouseInfoList.GetList.Count = 1 Then
                WarehouseInfoListAccGridComboBox.SelectedValue = WarehouseInfoList.GetList.Item(0)
            ElseIf WarehouseInfoList.GetList.Count = 2 Then
                WarehouseInfoListAccGridComboBox.SelectedValue = WarehouseInfoList.GetList.Item(1)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub CreateOperationButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CreateOperationButton.Click

        Dim GoodsID As Integer = 0
        Dim WarehouseID As Integer = 0

        Try
            GoodsID = DirectCast(GoodsInfoListAccGridComboBox.SelectedValue, GoodsInfo).ID
        Catch ex As Exception
        End Try
        Try
            WarehouseID = DirectCast(WarehouseInfoListAccGridComboBox.SelectedValue, WarehouseInfo).ID
        Catch ex As Exception
        End Try

        If SimpleOperationRadioButton.Checked Then

            Dim simpleType As Goods.GoodsOperationType
            Try
                simpleType = ConvertEnumHumanReadable(Of Goods.GoodsOperationType) _
                    (SimpleOperationTypeComboBox.SelectedItem.ToString)
            Catch ex As Exception
                MsgBox("Klaida. Nepasirinktas operacijos tipas.", MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End Try

            If Not GoodsID > 0 Then
                MsgBox("Klaida. Nepasirinkta prekė.", MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            ElseIf Not WarehouseID > 0 AndAlso OperationRequiresWarehouseID(simpleType) Then
                MsgBox("Klaida. Nepasirinktas sandėlis.", MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If

            Select Case simpleType
                Case Goods.GoodsOperationType.Acquisition
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationAcquisition), _
                        False, False, 0, GoodsID, WarehouseID)
                Case Goods.GoodsOperationType.ConsignmentAdditionalCosts
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationAdditionalCosts), _
                        False, False, 0, GoodsID, WarehouseID)
                Case Goods.GoodsOperationType.ConsignmentDiscount
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationDiscount), _
                        False, False, 0, GoodsID, WarehouseID)
                Case Goods.GoodsOperationType.Discard
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationDiscard), _
                        False, False, 0, GoodsID, WarehouseID)
                Case Goods.GoodsOperationType.PriceCut
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationPriceCut), _
                        False, False, 0, GoodsID, WarehouseID)
                Case Goods.GoodsOperationType.Transfer
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationTransfer), _
                        False, False, 0, GoodsID, WarehouseID)
                Case Goods.GoodsOperationType.ValuationMethodChange
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationValuationMethod), _
                        False, False, 0, GoodsID, True)
                Case Goods.GoodsOperationType.AccountDiscountsChange, _
                    Goods.GoodsOperationType.AccountPurchasesChange, _
                    Goods.GoodsOperationType.AccountSalesNetCostsChange, _
                    Goods.GoodsOperationType.AccountValueReductionChange
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationAccountChange), _
                        False, False, 0, GoodsID, simpleType)
            End Select


        Else

            Dim complexType As Goods.GoodsComplexOperationType
            Try
                complexType = ConvertEnumHumanReadable(Of Goods.GoodsComplexOperationType) _
                    (ComplexOperationTypeComboBox.SelectedItem.ToString)
            Catch ex As Exception
                MsgBox("Klaida. Nepasirinktas operacijos tipas.", MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End Try

            If Not GoodsID > 0 AndAlso complexType = GoodsComplexOperationType.Production Then
                MsgBox("Klaida. Nepasirinkta prekė.", MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            ElseIf Not WarehouseID > 0 AndAlso OperationRequiresWarehouseID(complexType) Then
                MsgBox("Klaida. Nepasirinktas sandėlis.", MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If

            Select Case complexType
                Case Goods.GoodsComplexOperationType.Inventorization
                    MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationInventorization), _
                        False, False, 0, WarehouseID, InventorizationDateDateTimePicker.Value)
                Case Goods.GoodsComplexOperationType.BulkDiscard
                    MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationDiscard), False, False, 0)
                Case Goods.GoodsComplexOperationType.BulkPriceCut
                    MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationPriceCut), False, False, 0)
                Case Goods.GoodsComplexOperationType.InternalTransfer
                    MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationInternalTransfer), False, False, 0)
                Case Goods.GoodsComplexOperationType.Production

                    Dim CalculationID As Integer = 0
                    Try
                        CalculationID = DirectCast(CalculationInfoListAccGridComboBox.SelectedValue, _
                            ProductionCalculationInfo).ID
                    Catch ex As Exception
                    End Try

                    MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationProduction), _
                        False, False, 0, GoodsID, CalculationID)

            End Select

        End If

        Me.Close()

    End Sub

    Private Sub SimpleOperationRadioButton_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SimpleOperationRadioButton.CheckedChanged
        SimpleOperationTypeComboBox.Enabled = SimpleOperationRadioButton.Checked
        ComplexOperationTypeComboBox.Enabled = Not SimpleOperationRadioButton.Checked
        CalculationInfoListAccGridComboBox.Enabled = Not SimpleOperationRadioButton.Checked
        InventorizationDateDateTimePicker.Enabled = Not SimpleOperationRadioButton.Checked
        If Not SimpleOperationTypeComboBox.Enabled Then SimpleOperationTypeComboBox.SelectedIndex = -1
        If Not ComplexOperationTypeComboBox.Enabled Then ComplexOperationTypeComboBox.SelectedIndex = -1
        If Not CalculationInfoListAccGridComboBox.Enabled Then CalculationInfoListAccGridComboBox.SelectedValue = Nothing
    End Sub


    Private Function OperationRequiresWarehouseID(ByVal OperationType As GoodsOperationType) As Boolean
        Return (OperationType = GoodsOperationType.Acquisition OrElse _
            OperationType = GoodsOperationType.ConsignmentAdditionalCosts OrElse _
            OperationType = GoodsOperationType.ConsignmentDiscount OrElse _
            OperationType = GoodsOperationType.Discard OrElse _
            OperationType = GoodsOperationType.Inventorization OrElse _
            OperationType = GoodsOperationType.PriceCut OrElse _
            OperationType = GoodsOperationType.Transfer)
    End Function

    Private Function OperationRequiresWarehouseID(ByVal OperationType As GoodsComplexOperationType) As Boolean
        Return (OperationType = GoodsComplexOperationType.Inventorization)
    End Function

End Class