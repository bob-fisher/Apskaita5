Namespace Goods

    <Serializable()> _
    Public Class GoodsComponentItem
        Inherits BusinessBase(Of GoodsComponentItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _Discard As GoodsOperationDiscard = Nothing
        Private _Amount As Double = 0
        Private _AmountPerProductionUnit As Double = 0
        Private _NormativeUnitCost As Double = 0
        Private _UnitCost As Double = 0
        Private _TotalCost As Double = 0
        Private _AccountContrary As Long = 0
        Private _Remarks As String = ""


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.ID
            End Get
        End Property

        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo
            End Get
        End Property

        Public ReadOnly Property GoodsName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.Name
            End Get
        End Property

        Public ReadOnly Property GoodsMeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.MeasureUnit
            End Get
        End Property

        Public ReadOnly Property GoodsAccountingMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethodHumanReadable
            End Get
        End Property

        Public ReadOnly Property GoodsValuationMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.ValuationMethodHumanReadable
            End Get
        End Property

        Friend ReadOnly Property Discard() As GoodsOperationDiscard
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard
            End Get
        End Property

        Public Property AmountPerProductionUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountPerProductionUnit, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If value < 0 Then value = 0
                If AmountPerProductionUnitIsReadOnly Then Exit Property

                If CRound(_AmountPerProductionUnit, 6) <> CRound(value, 6) Then

                    Dim ammountCalculated As Double = 0
                    If CRound(_AmountPerProductionUnit, 6) > 0 Then ammountCalculated = _
                        CRound(_Amount / _AmountPerProductionUnit, 6)

                    _AmountPerProductionUnit = CRound(value, 6)
                    PropertyHasChanged()

                    If CRound(ammountCalculated, 6) > 0 Then Amount = _
                        (_AmountPerProductionUnit * ammountCalculated)
                    
                End If
            End Set
        End Property

        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If value < 0 Then value = 0
                If AmountIsReadOnly Then Exit Property

                If CRound(_Amount, 6) <> CRound(value, 6) Then

                    _Amount = CRound(value, 6)
                    PropertyHasChanged()

                    _TotalCost = CRound(_UnitCost * _Amount)
                    PropertyHasChanged("TotalCost")

                    _Discard.Ammount = _Amount

                    If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then _
                        _Discard.SetNormativeCosts(_NormativeUnitCost, _TotalCost)

                End If

            End Set
        End Property

        Public Property NormativeUnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NormativeUnitCost, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If value < 0 Then value = 0

                If NormativeUnitCostIsReadOnly Then Exit Property

                If CRound(_NormativeUnitCost, 6) <> CRound(value, 6) Then

                    _NormativeUnitCost = CRound(value, 6)
                    PropertyHasChanged()

                    _UnitCost = CRound(value, 6)
                    _TotalCost = CRound(_UnitCost * _Amount)
                    PropertyHasChanged("UnitCost")
                    PropertyHasChanged("TotalCost")
                    _Discard.SetNormativeCosts(_NormativeUnitCost, _TotalCost)

                End If

            End Set
        End Property

        Public ReadOnly Property UnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitCost, 6)
            End Get
        End Property

        Public ReadOnly Property TotalCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalCost)
            End Get
        End Property

        Public Property AccountContrary() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountContrary
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountContraryIsReadOnly Then Exit Property
                If _AccountContrary <> value Then
                    _AccountContrary = value
                    PropertyHasChanged()
                    _Discard.AccountGoodsDiscardCosts = value
                End If
            End Set
        End Property

        Public Property Remarks() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Remarks.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Remarks.Trim <> value.Trim Then
                    _Remarks = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Discard.IsDirty
            End Get
        End Property


        Public ReadOnly Property AmountPerProductionUnitIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _Discard.OperationLimitations.FinancialDataCanChange _
                    OrElse Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property AmountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _Discard.OperationLimitations.FinancialDataCanChange _
                    OrElse Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property NormativeUnitCostIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent _
                    OrElse Not _Discard.OperationLimitations.FinancialDataCanChange _
                    OrElse Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property AccountContraryIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent _
                    OrElse Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange
            End Get
        End Property


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _GoodsInfo.Name & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _GoodsInfo.Name & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function

        Public Function GetChronologyValidator() As OperationalLimitList
            Return _Discard.OperationLimitations
        End Function


        Friend Sub ReloadCostInfo(ByVal costInfo As GoodsCostItem)

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then Exit Sub

            If Not _Discard.OperationLimitations.FinancialDataCanChange Then _
                Throw New Exception("Klaida. Finansinių žaliavos '" & _GoodsInfo.Name _
                & "' duomenų keisti negalima:" & vbCrLf & _Discard.OperationLimitations. _
                FinancialDataCanChangeExplanation)

            If Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange Then _
                Throw New Exception("Klaida. Jokių finansinių gamybos operacijos duomenų keisti negalima:" _
                & vbCrLf & _Discard.OperationLimitations.BaseValidator.FinancialDataCanChangeExplanation)

            If CostInfo Is Nothing Then
                _UnitCost = 0
                _TotalCost = 0
                PropertyHasChanged("UnitCost")
                PropertyHasChanged("TotalCost")
                Exit Sub
            End If

            If CostInfo.GoodsID <> _GoodsInfo.ID Then Throw New Exception( _
                "Klaida. Nesutampa prekių ID ir prekių partijos vertės ID.")
            If Not _Discard.Warehouse Is Nothing AndAlso CostInfo.WarehouseID <> _Discard.Warehouse.ID Then _
                Throw New Exception("Klaida. Nesutampa prekių ir prekių partijos sandėliai.")
            If CostInfo.Amount <> CRound(_Amount, 6) Then _
                Throw New Exception("Klaida. Nesutampa nurodytas prekių kiekis " & _
                "ir prekių kiekis, kuriam paskaičiuota vertė.")
            If CostInfo.ValuationMethod <> _GoodsInfo.ValuationMethod Then Throw New Exception( _
                "Klaida. Nesutampa prekių ir prekių partijos vertinimo metodas.")
            If CostInfo.NotEnoughInStock Then Throw New Exception("Sandėlyje nepakanka prekių/žaliavų '" _
                & _GoodsInfo.Name & "'.")

            _UnitCost = CostInfo.UnitCosts
            _TotalCost = CostInfo.TotalCosts
            PropertyHasChanged("UnitCost")
            PropertyHasChanged("TotalCost")

            _Discard.ReloadCostInfo(CostInfo)

        End Sub

        Friend Sub RecalculateForProductionAmount(ByVal AmmountInProduction As Double)

            If Not _Discard.OperationLimitations.FinancialDataCanChange Then _
                Throw New Exception("Klaida. Finansinių žaliavos '" & _GoodsInfo.Name _
                & "' duomenų keisti negalima:" & vbCrLf & _Discard.OperationLimitations. _
                FinancialDataCanChangeExplanation)

            If Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange Then _
                Throw New Exception("Klaida. Jokių finansinių gamybos operacijos duomenų keisti negalima:" _
                & vbCrLf & _Discard.OperationLimitations.BaseValidator.FinancialDataCanChangeExplanation)

            Amount = (_AmountPerProductionUnit * AmmountInProduction)

        End Sub


        Friend Sub SetDate(ByVal value As Date)
            If _Discard.Date.Date <> value.Date Then
                _Discard.SetDate(value)
                PropertyHasChanged()
            End If
        End Sub

        Friend Sub SetWarehouse(ByVal value As WarehouseInfo)

            If Not (_Discard.Warehouse Is Nothing AndAlso value Is Nothing) _
                AndAlso Not (Not _Discard.Warehouse Is Nothing AndAlso Not value Is Nothing _
                AndAlso _Discard.Warehouse.ID = value.ID) Then

                If Not _Discard.OperationLimitations.FinancialDataCanChange Then _
                    Throw New Exception("Klaida. Finansinių žaliavos '" & _GoodsInfo.Name _
                    & "' duomenų keisti negalima:" & vbCrLf & _Discard.OperationLimitations. _
                    FinancialDataCanChangeExplanation)

                If Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange Then _
                    Throw New Exception("Klaida. Jokių finansinių gamybos operacijos duomenų keisti negalima:" _
                    & vbCrLf & _Discard.OperationLimitations.BaseValidator.FinancialDataCanChangeExplanation)

                _Discard.Warehouse = value
                PropertyHasChanged()

            End If

        End Sub

        Friend Sub SetValues(ByVal parent As GoodsComplexOperationProduction)

            If _Discard.Date.Date <> parent.Date Then
                _Discard.SetDate(parent.Date)
                PropertyHasChanged()
            End If

            If _Discard.OperationLimitations.FinancialDataCanChange AndAlso _
                _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange Then _
                SetWarehouse(parent.WarehouseForComponents)

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                _Discard.AccountGoodsDiscardCosts = _AccountContrary
                _Discard.SetNormativeCosts(_NormativeUnitCost, _TotalCost)
            Else
                If parent.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                    _Discard.AccountGoodsDiscardCosts = parent.GoodsInfo.AccountPurchases
                Else
                    _Discard.AccountGoodsDiscardCosts = parent.WarehouseForProduction.WarehouseAccount
                End If
            End If

        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return _GoodsInfo.Name & " sunaudojimas gamyboje"
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Amount", "kiekis"))

            ValidationRules.AddRule(AddressOf NormativeUnitCostValidation, _
                New Validation.RuleArgs("NormativeUnitCost"))
            ValidationRules.AddRule(AddressOf AccountContraryValidation, _
                New Validation.RuleArgs("AccountContrary"))

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property NormativeUnitCost is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function NormativeUnitCostValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsComponentItem = DirectCast(target, GoodsComponentItem)

            If ValObj._GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic _
                AndAlso Not CRound(ValObj._NormativeUnitCost, 6) > 0 Then
                e.Description = "Žaliavai/detalei """ & ValObj._GoodsInfo.Name _
                    & """ nenurodyta normatyvinė savikaina."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountContrary is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountContraryValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsComponentItem = DirectCast(target, GoodsComponentItem)

            If ValObj._GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic _
                AndAlso Not ValObj._AccountContrary > 0 Then
                e.Description = "Žaliavai/detalei """ & ValObj._GoodsInfo.Name _
                    & """ nenurodyta kontrarinė savikainos sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsComponentItem(ByVal calculationComponent _
            As ProductionComponentItem, ByVal productionAmount As Double, _
            ByVal parentValidator As IChronologicValidator) As GoodsComponentItem
            Return New GoodsComponentItem(calculationComponent, productionAmount, parentValidator)
        End Function

        Public Shared Function NewGoodsComponentItem(ByVal GoodsID As Integer, _
            ByVal parentValidator As IChronologicValidator) As GoodsComponentItem
            Return DataPortal.Create(Of GoodsComponentItem)(New Criteria(GoodsID, parentValidator))
        End Function

        Friend Shared Function GetGoodsComponentItem(ByVal obj As OperationPersistenceObject, _
            ByVal productionAmount As Double, ByVal parentValidator As IChronologicValidator, _
            ByVal LimitationsDataSource As DataTable) As GoodsComponentItem
            Return New GoodsComponentItem(obj, productionAmount, parentValidator, LimitationsDataSource)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal calculationComponent As ProductionComponentItem, _
            ByVal productionAmount As Double, ByVal parentValidator As IChronologicValidator)
            MarkAsChild()
            Create(calculationComponent, productionAmount, parentValidator)
        End Sub

        Private Sub New(ByVal obj As OperationPersistenceObject, ByVal productionAmount As Double, _
            ByVal parentValidator As IChronologicValidator, ByVal LimitationsDataSource As DataTable)
            MarkAsChild()
            Fetch(obj, productionAmount, parentValidator, LimitationsDataSource)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As Integer
            Private mParentValidator As IChronologicValidator
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public ReadOnly Property ParentValidator() As IChronologicValidator
                Get
                    Return mParentValidator
                End Get
            End Property
            Public Sub New(ByVal id As Integer, ByVal nParentValidator As IChronologicValidator)
                mId = id
                mParentValidator = nParentValidator
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            MarkAsChild()

            _GoodsInfo = GoodsSummary.GetGoodsSummary(criteria.Id)
            _Discard = GoodsOperationDiscard.NewGoodsOperationDiscardChild(_GoodsInfo, criteria.ParentValidator)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal calculationComponent As ProductionComponentItem, _
            ByVal productionAmount As Double, ByVal parentValidator As IChronologicValidator)

            If Not CRound(productionAmount, 6) > 0 Then productionAmount = 1

            _Discard = GoodsOperationDiscard.NewGoodsOperationDiscardChild( _
                calculationComponent.Goods.ID, parentValidator)
            _Discard.Ammount = calculationComponent.Amount
            _GoodsInfo = _Discard.GoodsInfo

            _AmountPerProductionUnit = calculationComponent.Amount / productionAmount
            _Amount = calculationComponent.Amount

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                _NormativeUnitCost = calculationComponent.NormativeUnitCost
                _UnitCost = calculationComponent.NormativeUnitCost
                _TotalCost = CRound(_NormativeUnitCost * _Amount)
            Else
                _NormativeUnitCost = 0
                _UnitCost = 0
                _TotalCost = 0
            End If

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal obj As OperationPersistenceObject, ByVal productionAmount As Double, _
            ByVal parentValidator As IChronologicValidator, ByVal LimitationsDataSource As DataTable)

            _GoodsInfo = obj.GoodsInfo
            _Amount = -obj.Amount
            If CRound(productionAmount, 6) > 0 Then _AmountPerProductionUnit = _
                CRound(_Amount / productionAmount, 6)
            _UnitCost = obj.UnitValue
            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                _NormativeUnitCost = _UnitCost
                _TotalCost = -obj.AccountOperationValue
            Else
                _NormativeUnitCost = 0
                _TotalCost = -obj.TotalValue
            End If
            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then _
                _AccountContrary = obj.AccountOperation
            If obj.Content.Split(New String() {"<#>"}, StringSplitOptions.RemoveEmptyEntries).Length > 1 Then _
                _Remarks = obj.Content.Split(New String() {"<#>"}, StringSplitOptions.RemoveEmptyEntries)(1)

            _Discard = GoodsOperationDiscard.GetGoodsOperationDiscardChild(obj, parentValidator, _
                LimitationsDataSource)

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then _
                _NormativeUnitCost = _UnitCost

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Friend Sub Update(ByVal parent As GoodsComplexOperationProduction)

            Dim operationContent As String = parent.Content
            If Not String.IsNullOrEmpty(_Remarks.Trim.Trim) Then operationContent = _
                operationContent & "<#>" & _Remarks.Trim

            _Discard.SaveChild(parent.JournalEntryID, parent.ID, parent.Date, operationContent, _
                parent.DocumentNumber)

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()
            _Discard.DeleteGoodsOperationDiscardChild()
            MarkNew()
        End Sub

        
        Friend Function CheckIfCanUpdate(ByVal LimitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator, ByVal ThrowOnInvalid As Boolean) As String
            Return _Discard.CheckIfCanUpdate(LimitationsDataSource, parentValidator, ThrowOnInvalid)
        End Function

        Friend Function CheckIfCanDelete(ByVal LimitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator, ByVal ThrowOnInvalid As Boolean) As String
            If IsNew Then Return ""
            Return _Discard.CheckIfCanDelete(LimitationsDataSource, parentValidator, ThrowOnInvalid)
        End Function

        Friend Function GetBookEntryInternal(ByVal invert As Boolean) As BookEntryInternal

            Dim result As BookEntryInternal = BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
            If invert Then
                result = BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas)
            Else
                result = BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
            End If

            result.Ammount = _TotalCost
            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                result.Account = _AccountContrary
            Else
                result.Account = _Discard.Warehouse.WarehouseAccount
            End If

            Return result

        End Function

        Friend Sub PrepareConsignements()

            If Not IsNew AndAlso Not _Discard.OperationLimitations.FinancialDataCanChange Then Exit Sub

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then Exit Sub

            _Discard.GetDiscardList()

            _TotalCost = _Discard.TotalCost
            _UnitCost = _Discard.UnitCost

        End Sub

#End Region

    End Class

End Namespace