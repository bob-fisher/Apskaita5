Namespace Documents

    <Serializable()> _
    Public Class Offset
        Inherits BusinessBase(Of Offset)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _ChronologicValidator As SimpleChronologicValidator
        Private _Date As Date = Today
        Private _OldDate As Date = Today
        Private _DocumentNumber As String = ""
        Private _Content As String = ""
        Private _SumDebit As Double = 0
        Private _SumCredit As Double = 0
        Private _BalanceItemID As Integer = 0
        Private _BalanceSum As Double = 0
        Private _BalanceAccount As Long = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _ItemList As OffsetItemList


        Private SuspendChildListChangedEvents As Boolean = False
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemListSortedList As Csla.SortedBindingList(Of OffsetItem) = Nothing

        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property ChronologicValidator() As SimpleChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
            End Get
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

        Public ReadOnly Property SumDebit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDebit)
            End Get
        End Property

        Public ReadOnly Property SumCredit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumCredit)
            End Get
        End Property

        Public ReadOnly Property BalanceItemID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BalanceItemID
            End Get
        End Property

        Public Property BalanceSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceSum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property
                If CRound(_BalanceSum) <> CRound(value) Then
                    _BalanceSum = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        Public Property BalanceAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BalanceAccount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property
                If _BalanceAccount <> value Then
                    _BalanceAccount = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property ItemList() As OffsetItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ItemList
            End Get
        End Property

        Public ReadOnly Property ItemListSorted() As Csla.SortedBindingList(Of OffsetItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ItemListSortedList Is Nothing Then _ItemListSortedList = _
                    New Csla.SortedBindingList(Of OffsetItem)(_ItemList)
                Return _ItemListSortedList
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) OrElse _ItemList.Count > 0)
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _ItemList.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _ItemList.IsValid
            End Get
        End Property



        Public Overrides Function Save() As Offset

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf & Me.GetAllBrokenRules)

            Return MyBase.Save

        End Function


        Private Sub Recalculate(ByVal RaisePropertyHasChanged As Boolean)

            _SumDebit = 0
            _SumCredit = 0

            For Each i As OffsetItem In _ItemList
                _SumDebit = CRound(_SumDebit + i.Debit)
                _SumCredit = CRound(_SumCredit + i.Credit)
            Next

            If CRound(_BalanceSum) > 0 Then
                _SumCredit = CRound(_SumCredit + _BalanceSum)
            ElseIf CRound(_BalanceSum) < 0 Then
                _SumDebit = CRound(_SumDebit - _BalanceSum)
            End If

            If RaisePropertyHasChanged Then
                PropertyHasChanged("SumCredit")
                PropertyHasChanged("SumDebit")
            End If

        End Sub


        Public Function GetAllBrokenRules() As String
            Dim result As String = ""
            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            If Not _ItemList.IsValid Then result = AddWithNewLine(result, _
                _ItemList.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then _
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            result = AddWithNewLine(result, _ItemList.GetAllWarnings, False)
            Return result
        End Function


        Private Sub ItemList_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _ItemList.ListChanged

            If SuspendChildListChangedEvents Then Exit Sub

            Recalculate(True)

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As Offset = DirectCast(MyBase.GetClone(), Offset)
            result.RestoreChildListsHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildListsHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildListsHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of TaskTimeSpans loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _ItemList.ListChanged, AddressOf ItemList_Changed
            Catch ex As Exception
            End Try
            AddHandler _ItemList.ListChanged, AddressOf ItemList_Changed
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _DocumentNumber
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "ChronologicValidator"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("DocumentNumber", "užskaitos dokumento numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Content", _
                "užskaitos dokumento turinys (trumpas apibūdinimas)"))

            ValidationRules.AddRule(AddressOf SumDebitValidation, _
                New Validation.RuleArgs("SumDebit"))
            ValidationRules.AddRule(AddressOf BalanceAccountValidation, _
                New Validation.RuleArgs("BalanceAccount"))

            ValidationRules.AddDependantProperty("SumCredit", "SumDebit", False)
            ValidationRules.AddDependantProperty("BalanceSum", "SumDebit", False)
            ValidationRules.AddDependantProperty("BalanceSum", "BalanceAccount", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property SumDebit is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumDebitValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Offset = DirectCast(target, Offset)

            If Not CRound(ValObj._SumDebit) > 0 Then
                e.Description = "Nenurodytos korespondencijų sumos."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf CRound(ValObj._SumDebit) <> CRound(ValObj._SumCredit) Then
                e.Description = "Nesutampa debeto ir kredito korespondencijų sumos."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property BalanceAccount is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function BalanceAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Offset = DirectCast(target, Offset)

            If CRound(ValObj._BalanceSum) <> 0 AndAlso Not ValObj._BalanceAccount > 0 Then

                e.Description = "Nenurodyta balanso išlyginimo pajamų/sąnaudų sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf CRound(ValObj._BalanceSum) > 0 AndAlso _
                Convert.ToInt16(ValObj._BalanceAccount.ToString.Substring(0, 1)) <> _
                GetCurrentCompany.AccountClassPrefix51 AndAlso _
                Convert.ToInt16(ValObj._BalanceAccount.ToString.Substring(0, 1)) <> _
                GetCurrentCompany.AccountClassPrefix52 Then

                e.Description = "Teigiamas užskaitos balansas reiškia, kad įmonė turi " _
                    & "naudos iš užskaitos, todėl teigtina, kad turėtų būti pasirenkama " _
                    & "5 klasės balansavimo rezultato sąskaita."
                e.Severity = Validation.RuleSeverity.Warning
                Return False

            ElseIf CRound(ValObj._BalanceSum) < 0 AndAlso _
                Convert.ToInt16(ValObj._BalanceAccount.ToString.Substring(0, 1)) <> _
                GetCurrentCompany.AccountClassPrefix61 AndAlso _
                Convert.ToInt16(ValObj._BalanceAccount.ToString.Substring(0, 1)) <> _
                GetCurrentCompany.AccountClassPrefix62 Then

                e.Description = "Neigiamas užskaitos balansas reiškia, kad įmonė turi " _
                    & "nuostolio iš užskaitos, todėl teigtina, kad turėtų būti pasirenkama " _
                    & "6 klasės balansavimo rezultato sąskaita."
                e.Severity = Validation.RuleSeverity.Warning
                Return False

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.Offset2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Offset1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Offset2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Offset3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Offset3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewOffset() As Offset

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Dim result As New Offset
            result._ItemList = OffsetItemList.NewOffsetItemList
            result._ChronologicValidator = SimpleChronologicValidator.NewSimpleChronologicValidator("užskaita")
            result.ValidationRules.CheckRules()
            Return result

        End Function

        Public Shared Function GetOffset(ByVal nID As Integer) As Offset
            Return DataPortal.Fetch(Of Offset)(New Criteria(nID))
        End Function

        Public Shared Sub DeleteOffset(ByVal id As Integer)
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

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims gauti.")

            Dim myComm As New SQLCommand("FetchOffset")
            myComm.AddParam("?BD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    "Klaida. Objektas, kurio ID='" & criteria.ID & "', nerastas.)")

                Dim dr As DataRow = myData.Rows(0)

                If ConvertEnumDatabaseStringCode(Of DocumentType)(CStrSafe(dr.Item(3)).Trim) _
                    <> DocumentType.Offset Then Throw New Exception("Klaida. Objektas, kurio ID='" _
                    & criteria.ID & "', yra ne užskaitos dokumentas (" & _
                    ConvertEnumHumanReadable(ConvertEnumDatabaseStringCode(Of DocumentType) _
                    (CStrSafe(dr.Item(3)).Trim)) & ").")

                _ID = criteria.ID

                _Date = CDateSafe(dr.Item(0), Today)
                _DocumentNumber = CStrSafe(dr.Item(1)).Trim
                _Content = CStrSafe(dr.Item(2)).Trim
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(4), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(5), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime

            End Using

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _Date, "užskaita")

            Dim BalanceItem As OffsetItem = Nothing

            _ItemList = OffsetItemList.GetOffsetItemList(Me, BalanceItem)

            If Not BalanceItem Is Nothing AndAlso BalanceItem.ID > 0 Then
                _BalanceItemID = BalanceItem.ID
                If BalanceItem.Type = BookEntryType.Debetas Then
                    _BalanceSum = -BalanceItem.Sum
                Else
                    _BalanceSum = BalanceItem.Sum
                End If
                _BalanceAccount = BalanceItem.Account
            End If

            Recalculate(False)

            MarkOld()
            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            If _Date.Date <= GetCurrentCompany.LastClosingDate.Date Then Throw New Exception( _
                "Klaida. Neleidžiama koreguoti operacijų po uždarymo (" _
                & GetCurrentCompany.LastClosingDate & ").")

            Dim CurrentJournalEntry As General.JournalEntry = GetJournalEntry()

            DatabaseAccess.TransactionBegin()

            CurrentJournalEntry = CurrentJournalEntry.SaveServerSide

            _ID = CurrentJournalEntry.ID
            _InsertDate = CurrentJournalEntry.InsertDate
            _UpdateDate = CurrentJournalEntry.UpdateDate

            Dim BalanceItem As OffsetItem = OffsetItem.GetBalanceOffsetItem(0, _BalanceSum, _BalanceAccount)
            If Not BalanceItem Is Nothing Then
                BalanceItem.Insert(Me)
                _BalanceItemID = BalanceItem.ID
            End If

            ItemList.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _ChronologicValidator.CurrentOperationDate, "užskaita")
            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf & Me.GetAllBrokenRules)

            Dim CurrentJournalEntry As General.JournalEntry = GetJournalEntry()

            DatabaseAccess.TransactionBegin()

            CurrentJournalEntry = CurrentJournalEntry.SaveServerSide
            _UpdateDate = CurrentJournalEntry.UpdateDate

            If _ChronologicValidator.FinancialDataCanChange Then

                Dim BalanceItem As OffsetItem = OffsetItem.GetBalanceOffsetItem( _
                _BalanceItemID, _BalanceSum, _BalanceAccount)
                If Not BalanceItem Is Nothing Then
                    If (CRound(BalanceSum) = 0 OrElse Not BalanceAccount > 0) _
                        AndAlso _BalanceItemID > 0 Then
                        BalanceItem.DeleteSelf()
                    ElseIf _BalanceItemID > 0 Then
                        BalanceItem.Update(Me)
                    Else
                        BalanceItem.Insert(Me)
                    End If
                End If

            End If

            ItemList.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pašalinti.")

            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(DirectCast(criteria, Criteria).ID, DocumentType.Offset)

            DatabaseAccess.TransactionBegin()

            General.JournalEntry.DoDelete(DirectCast(criteria, Criteria).ID)

            Dim myComm As New SQLCommand("DeleteAllOffsetItems")
            myComm.AddParam("?CD", DirectCast(criteria, Criteria).ID)
            myComm.Execute()

            DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub


        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.Offset)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.Offset)
                If result.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    "Klaida. Dokumento atnaujinimo data pasikeitė. Teigtina, kad kitas " _
                    & "vartotojas redagavo šį objektą.")
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentNumber

            If _ChronologicValidator.FinancialDataCanChange Then

                Dim FullBookEntryList As BookEntryInternalList = BookEntryInternalList. _
                    NewBookEntryInternalList(BookEntryType.Debetas)

                For Each i As OffsetItem In _ItemList

                    If i.Type = BookEntryType.Debetas Then
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, i.Account, i.SumLTL, i.Person))
                    Else
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Kreditas, i.Account, i.SumLTL, i.Person))
                    End If

                    If i.CurrencyRateChangeImpact > 0 AndAlso i.AccountCurrencyRateChangeImpact > 0 Then
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Kreditas, i.AccountCurrencyRateChangeImpact, _
                            i.CurrencyRateChangeImpact, Nothing))
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, i.Account, i.CurrencyRateChangeImpact, i.Person))
                    ElseIf i.CurrencyRateChangeImpact < 0 AndAlso i.AccountCurrencyRateChangeImpact > 0 Then
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, i.AccountCurrencyRateChangeImpact, _
                            -i.CurrencyRateChangeImpact, Nothing))
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Kreditas, i.Account, -i.CurrencyRateChangeImpact, i.Person))
                    End If

                Next

                If CRound(_BalanceSum) > 0 AndAlso _BalanceAccount > 0 Then
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _BalanceAccount, CRound(_BalanceSum), Nothing))
                ElseIf CRound(_BalanceSum) < 0 AndAlso _BalanceAccount > 0 Then
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _BalanceAccount, CRound(-_BalanceSum), Nothing))
                End If

                FullBookEntryList.Aggregate()

                result.DebetList.Clear()
                result.CreditList.Clear()

                result.DebetList.LoadBookEntryListFromInternalList(FullBookEntryList, False)
                result.CreditList.LoadBookEntryListFromInternalList(FullBookEntryList, False)

            End If

            If Not result.IsValid Then Throw New Exception("Klaida. Nepavyko generuoti " _
                & "bendrojo žurnalo įrašo.")

            Return result

        End Function

#End Region

    End Class

End Namespace