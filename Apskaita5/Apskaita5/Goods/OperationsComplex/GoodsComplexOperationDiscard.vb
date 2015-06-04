Namespace Goods

    <Serializable()> _
    Public Class GoodsComplexOperationDiscard
        Inherits BusinessBase(Of GoodsComplexOperationDiscard)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _JournalEntryID As Integer = 0
        Private _OperationalLimit As ComplexChronologicValidator = Nothing
        Private _Date As Date = Today
        Private _OldDate As Date = Today
        Private _DocumentNumber As String = ""
        Private _Content As String = ""
        Private _OldWarehouseID As Integer = 0
        Private _Warehouse As WarehouseInfo = Nothing
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _Items As GoodsDiscardItemList

        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemsSortedList As Csla.SortedBindingList(Of GoodsDiscardItem) = Nothing


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        Public ReadOnly Property OperationalLimit() As ComplexChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationalLimit
            End Get
        End Property

        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property OldDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldDate
            End Get
        End Property

        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DocumentNumber.Trim <> value.Trim Then
                    _DocumentNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property OldWarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldWarehouseID
            End Get
        End Property

        Public Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As WarehouseInfo)
                CanWriteProperty(True)
                If Not _OperationalLimit.FinancialDataCanChange Then
                    PropertyHasChanged()
                    Exit Property
                End If
                If Not (_Warehouse Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Warehouse Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Warehouse.ID = value.ID) Then
                    _Warehouse = value
                    UpdateItemsWithWarehouse(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        Public ReadOnly Property Items() As GoodsDiscardItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Items
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Content.Trim) _
                    OrElse _Items.Count > 0)
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Items.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _Items.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error).Trim
            result = AddWithNewLine(result, _Items.GetAllBrokenRules, False)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning).Trim
            result = AddWithNewLine(result, _Items.GetAllWarnings(), False)


            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Public Function GetSortedList() As Csla.SortedBindingList(Of GoodsDiscardItem)

            If _ItemsSortedList Is Nothing Then
                _ItemsSortedList = New Csla.SortedBindingList(Of GoodsDiscardItem)(_Items)
            End If

            Return _ItemsSortedList

        End Function

        Public Function GetCostsParams() As GoodsCostParam()
            Dim result As New List(Of GoodsCostParam)
            If _Warehouse Is Nothing OrElse Not _Warehouse.ID > 0 Then Return result.ToArray
            For Each i As GoodsDiscardItem In _Items
                result.Add(GoodsCostParam.GetGoodsCostParam(i.GoodsInfo.ID, _Warehouse.ID, _
                    i.Amount, i.Discard.ID, 0, i.GoodsInfo.ValuationMethod, _Date))
            Next
            Return result.ToArray
        End Function

        Public Sub ReloadCostInfo(ByVal list As GoodsCostItemList)

            If list Is Nothing Then Throw New ArgumentNullException("Klaida. " _
                & "Metodui GoodsComplexOperationDiscard.ReloadCostInfo " _
                & "nenurodytas (null) GoodsCostItemList parametras.")

            If Not _OperationalLimit.BaseValidator.FinancialDataCanChange Then _
                Throw New Exception("Klaida. Finansinių operacijos duomenų keisti negalima." _
                & vbCrLf & _OperationalLimit.BaseValidator.FinancialDataCanChangeExplanation)

            _Items.ReloadCostInfo(list)

        End Sub

        Public Sub AddNewGoodsItem(ByVal item As GoodsDiscardItem)

            If _Items.ContainsGood(item.GoodsInfo.ID) Then Throw New Exception( _
                "Klaida. Eilutė prekei '" & item.GoodsName & "' jau yra.")

            If item.RequiresJournalEntry AndAlso Not _OperationalLimit. _
                BaseValidator.FinancialDataCanChange Then Throw New Exception( _
                "Klaida. Neleidžiama pridėti eilutės, kuri reikalauja bednrojo " _
                & "žurnalo operacijos keitimo:" & vbCrLf & _OperationalLimit. _
                BaseValidator.FinancialDataCanChangeExplanation)

            item.SetDate(_Date)
            item.SetWarehouse(_Warehouse)

            _Items.Add(item)

            _OperationalLimit.MergeNewValidationItem(item.Discard.OperationLimitations)

            ValidationRules.CheckRules()

        End Sub


        Private Sub UpdateItemsWithWarehouse(ByVal value As WarehouseInfo)
            _Items.SetWarehouse(_Warehouse)
            _OperationalLimit.ReloadValidationItems(_Items.GetLimitations())
        End Sub


        Public Overrides Function Save() As GoodsComplexOperationDiscard

            If IsNew AndAlso Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            If Not IsNew AndAlso Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            If Not _Items.Count > 0 Then Throw New Exception("Klaida. Neįvesta nė viena eilutė.")

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf & Me.GetAllBrokenRules)
            Return MyBase.Save

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return "Goods.GoodsComplexOperationDiscard"
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("DocumentNumber", "dokumento numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Content", "operacijos aprašymas"))
            ValidationRules.AddRule(AddressOf CommonValidation.InfoObjectRequired, _
                New CommonValidation.InfoObjectRequiredRuleArgs("Warehouse", "sandėlis", "ID"))
            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "OperationalLimit"))

            ValidationRules.AddDependantProperty("Warehouse", "Date", False)

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationDiscard1")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscard1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscard2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscard3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscard3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewGoodsComplexOperationDiscard() As GoodsComplexOperationDiscard
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            Dim result As New GoodsComplexOperationDiscard
            result._Items = GoodsDiscardItemList.NewGoodsDiscardItemList
            result._OperationalLimit = ComplexChronologicValidator.NewComplexChronologicValidator( _
                 ConvertEnumHumanReadable(GoodsOperationType.Discard), _
                 SimpleChronologicValidator.NewSimpleChronologicValidator( _
                 ConvertEnumHumanReadable(GoodsOperationType.Discard)), Nothing)
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Public Shared Function GetGoodsComplexOperationDiscard(ByVal nID As Integer) As GoodsComplexOperationDiscard
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of GoodsComplexOperationDiscard)(New Criteria(nID))
        End Function

        Public Shared Sub DeleteGoodsComplexOperationDiscard(ByVal id As Integer)
            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenų ištrynimui.")
            DataPortal.Delete(New Criteria(id))
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim obj As ComplexOperationPersistenceObject = ComplexOperationPersistenceObject. _
                GetComplexOperationPersistenceObject(criteria.ID, True)

            Fetch(obj)

        End Sub

        Private Sub Fetch(ByVal obj As ComplexOperationPersistenceObject)

            If obj.OperationType <> GoodsComplexOperationType.BulkDiscard Then _
                Throw New Exception("Klaida. Kompleksinė operacija, kurios ID=" _
                & obj.ID.ToString & ", yra ne prekių nurašymas, o " _
                & ConvertEnumHumanReadable(obj.OperationType))

            _Content = obj.Content
            _DocumentNumber = obj.DocNo
            _ID = obj.ID
            _InsertDate = obj.InsertDate
            _JournalEntryID = obj.JournalEntryID
            _Date = obj.OperationDate
            _UpdateDate = obj.UpdateDate
            _Warehouse = obj.Warehouse

            Dim parentValidator As IChronologicValidator = SimpleChronologicValidator. _
                GetSimpleChronologicValidator(_ID, _Date, _
                ConvertEnumHumanReadable(GoodsComplexOperationType.BulkDiscard))

            Using myData As DataTable = OperationalLimitList.GetDataSourceForComplexOperation(_ID, _Date)
                Dim objList As List(Of OperationPersistenceObject) = _
                    OperationPersistenceObject.GetOperationPersistenceObjectList(_ID)
                _Items = GoodsDiscardItemList.GetGoodsDiscardItemList(objList, parentValidator, myData)
            End Using

            _OperationalLimit = ComplexChronologicValidator.GetComplexChronologicValidator( _
                _ID, _Date, ConvertEnumHumanReadable(GoodsOperationType.Discard), _
                parentValidator, _Items.GetLimitations())

            _OldWarehouseID = _Warehouse.ID
            _OldDate = _Date

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            PrepareOperationConsignments()

            CheckIfCanUpdate()

            DoSave()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            ComplexOperationPersistenceObject.CheckIfUpdateDateChanged(_ID, _UpdateDate)

            PrepareOperationConsignments()

            CheckIfCanUpdate()

            DoSave()

        End Sub

        Private Sub DoSave()

            Dim obj As ComplexOperationPersistenceObject = GetPersistenceObj()

            Dim entry As General.JournalEntry = GetJournalEntry()

            Dim transactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not transactionExisted Then DatabaseAccess.TransactionBegin()

            If Not entry Is Nothing Then
                entry = entry.SaveChild
                _JournalEntryID = entry.ID
                obj.JournalEntryID = _JournalEntryID
            ElseIf entry Is Nothing AndAlso Not IsNew AndAlso _JournalEntryID > 0 Then
                General.JournalEntry.DeleteJournalEntryChild(_JournalEntryID)
                _JournalEntryID = 0
                obj.JournalEntryID = 0
            End If

            If IsNew Then
                _ID = obj.Save(_OperationalLimit.FinancialDataCanChange, _
                    _OperationalLimit.FinancialDataCanChange, False)
            Else
                obj.Save(_OperationalLimit.FinancialDataCanChange, _
                    _OperationalLimit.FinancialDataCanChange, False)
            End If

            _Items.Update(Me)

            If Not transactionExisted Then DatabaseAccess.TransactionCommit()

            If IsNew Then _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate
            _OldDate = _Date
            _OldWarehouseID = _Warehouse.ID

            MarkOld()

            ReloadLimitations()

        End Sub

        Private Function GetPersistenceObj() As ComplexOperationPersistenceObject

            Dim obj As ComplexOperationPersistenceObject
            If IsNew Then
                obj = ComplexOperationPersistenceObject.NewComplexOperationPersistenceObject
            Else
                obj = ComplexOperationPersistenceObject.GetComplexOperationPersistenceObject(_ID, False)
            End If

            obj.AccountOperation = 0
            obj.GoodsID = 0
            obj.Warehouse = _Warehouse
            obj.SecondaryWarehouse = Nothing
            obj.OperationType = GoodsComplexOperationType.BulkDiscard
            obj.Content = _Content
            obj.DocNo = _DocumentNumber
            obj.JournalEntryID = _JournalEntryID
            obj.OperationDate = _Date

            Return obj

        End Function


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            Dim OperationToDelete As GoodsComplexOperationDiscard = New GoodsComplexOperationDiscard
            OperationToDelete.DataPortal_Fetch(DirectCast(criteria, Criteria))

            If Not OperationToDelete._OperationalLimit.FinancialDataCanChange Then _
                Throw New Exception("Klaida. Negalima ištrinti prekių " _
                    & "nurašymo urmu operacijos:" & vbCrLf & OperationToDelete. _
                    _OperationalLimit.FinancialDataCanChangeExplanation)

            If OperationToDelete.JournalEntryID > 0 Then IndirectRelationInfoList. _
                CheckIfJournalEntryCanBeDeleted(OperationToDelete.JournalEntryID, _
                DocumentType.GoodsWriteOff)

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            ComplexOperationPersistenceObject.DeleteConsignmentDiscards(DirectCast(criteria, Criteria).ID)

            ComplexOperationPersistenceObject.DeleteOperations(DirectCast(criteria, Criteria).ID)

            ComplexOperationPersistenceObject.Delete(DirectCast(criteria, Criteria).ID)

            If OperationToDelete.JournalEntryID > 0 Then General.JournalEntry. _
                DeleteJournalEntryChild(OperationToDelete.JournalEntryID)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

        End Sub


        Private Sub CheckIfCanUpdate()

            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Prekių nurašymo operacijoje " _
                & "yra klaidų: " & BrokenRulesCollection.ToString)

            _Items.SetValues(Me)

            Dim exceptionText As String = ""

            If IsNew Then
                exceptionText = AddWithNewLine(exceptionText, _Items.CheckIfCanUpdate( _
                    Nothing, _OperationalLimit.BaseValidator, False), False)
            Else
                Using myData As DataTable = OperationalLimitList.GetDataSourceForComplexOperation(_ID, _OldDate)
                    exceptionText = AddWithNewLine(exceptionText, _Items.CheckIfCanUpdate( _
                        myData, _OperationalLimit.BaseValidator, False), False)
                End Using
            End If

            If Not String.IsNullOrEmpty(exceptionText.Trim.Trim) Then _
                Throw New Exception(exceptionText.Trim)

        End Sub

        Private Sub ReloadLimitations()

            Using myData As DataTable = OperationalLimitList.GetDataSourceForComplexOperation(_ID, _Date)
                _Items.ReloadLimitations(myData, _OperationalLimit.BaseValidator)
            End Using

            _OperationalLimit.ReloadValidationItems(_ID, _Date, _Items.GetLimitations)

            ValidationRules.CheckRules()

        End Sub

        Private Sub PrepareOperationConsignments()
            _Items.PrepareOperationConsignments()
        End Sub

        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew OrElse Not _JournalEntryID > 0 Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.GoodsWriteOff)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, DocumentType.GoodsWriteOff)
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentNumber

            Dim fullBookEntryList As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)

            For Each i As GoodsDiscardItem In _Items
                fullBookEntryList.AddRange(i.GetBookEntryInternalList())
            Next

            If Not fullBookEntryList.Count > 0 Then Return Nothing

            fullBookEntryList.Aggregate()

            result.DebetList.Clear()
            result.CreditList.Clear()

            result.DebetList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)
            result.CreditList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)

            If Not result.IsValid Then Throw New Exception("Klaida. Nepavyko generuoti " _
                & "bendrojo žurnalo įrašo:" & result.ToString & vbCrLf & result.GetAllBrokenRules)

            Return result

        End Function

#End Region

    End Class

End Namespace