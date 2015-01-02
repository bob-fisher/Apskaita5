Namespace General

    ''' <summary>
    ''' Represents ledger account, also known as T-account http://en.wikipedia.org/wiki/Debits_and_credits#T-accounts".
    ''' Can only be used as a child object for <see cref="General.AccountList"/>
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class Account
        Inherits BusinessBase(Of Account)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Friend Const ColumnCount As Integer = 3
        Public Const ColumnSequence As String = "Apskaitos sąskaitos duomenys privalo būti išdėstyti " _
            & "3 stulpeliuose: numeris, pavadinimas ir finansinės atskaitomybės eilutės pavadinimas."

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Long = 0
        Private _OldID As Long = 0
        Private _Name As String = ""
        Private _AssociatedReportItem As String = ""
        Private _Class As Byte = 0

        ''' <summary>
        ''' Account ID - <see cref="Long">Long</see> number that identifies account (required).
        ''' </summary>
        ''' <value></value>
        ''' <returns>Account ID (<see cref="Long">Long</see> number that identifies account).</returns>
        ''' <remarks>Must be more then 0.(required)</remarks>
        Public Property ID() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _ID <> value Then
                    _ID = value
                    PropertyHasChanged()
                    _Class = GetAccountClass(_ID)
                    PropertyHasChanged("Class")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Account name - short description of an account (required).
        ''' </summary>
        ''' <value></value>
        ''' <returns>short description of an account</returns>
        ''' <remarks>Not an empty string. (required)
        ''' Max length - 255 chars.
        ''' </remarks>
        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Associated <see cref="General.ConsolidatedReportItem" />. (required)
        ''' Uses <see cref="HelperLists.AssignableCRItemList" /> as DataSource.
        ''' </summary>
        ''' <value></value>
        ''' <returns>short description of an account</returns>
        ''' <remarks>Not an empty string. (required)
        ''' Max length - 255 chars.
        ''' </remarks>
        Public Property AssociatedReportItem() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AssociatedReportItem.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _AssociatedReportItem.Trim <> value.Trim Then
                    _AssociatedReportItem = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Class of account http://en.wikipedia.org/wiki/Debits_and_credits#Accounts_pertaining_to_the_five_accounting_elements. 
        ''' Maped by the first number ("prefix") in the <see cref="ID" /> and values of <see cref="General.Company.AccountClassPrefix11" />,
        ''' <see cref="General.Company.AccountClassPrefix12" />, <see cref="General.Company.AccountClassPrefix21" />, etc.
        ''' </summary>
        ''' <value></value>
        ''' <returns>Base class of account:
        ''' 0 - Invalid account, i.e. not <see cref="ID" /> > 0.
        ''' 1 - Long term assets;
        ''' 2 - Short term assets;
        ''' 3 - Equity;
        ''' 4 - Liabilities;
        ''' 5 - Income/Revenue;
        ''' 6 - Expense.</returns>
        ''' <remarks>Maping method <see cref="GetAccountClass" /> is invoked in the <see cref="ID" /> property setter.</remarks>
        Public ReadOnly Property [Class]() As Byte
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Class
            End Get
        End Property


        ''' <summary>
        ''' Gets a human readable desciption of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.
        ''' </summary>
        ''' <returns>A human readable desciption of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.</returns>
        ''' <remarks></remarks>
        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format("Klaida (-os) eilutėje '{0}':{1}{2}", Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        ''' <summary>
        ''' Gets a human readable desciption of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.
        ''' </summary>
        ''' <returns>A human readable desciption of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.</returns>
        ''' <remarks></remarks>
        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format("Eilutėje '{0}' gali būti klaida:{1}{2}", Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function

        ''' <summary>
        ''' Forces all validation rules to be applied to the Account instance.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub ValidateChild()
            Me.ValidationRules.CheckRules()
        End Sub


        ''' <summary>
        ''' Maps an account <see cref="ID" /> to the base class.
        ''' Maped by the first number ("prefix") in the <see cref="ID" /> and values of <see cref="General.Company.AccountClassPrefix11" />,
        ''' <see cref="General.Company.AccountClassPrefix12" />, <see cref="General.Company.AccountClassPrefix21" />, etc.
        ''' </summary>
        ''' <param name="accountID"></param>
        ''' <returns>Base class of account identified by <paramref name="accountID" />:
        ''' 0 - Invalid account, i.e. not <see cref="ID" /> > 0.
        ''' 1 - Long term assets;
        ''' 2 - Short term assets;
        ''' 3 - Equity;
        ''' 4 - Liabilities;
        ''' 5 - Income/Revenue;
        ''' 6 - Expense.</returns>
        ''' <remarks></remarks>
        Public Shared Function GetAccountClass(ByVal accountID As Long) As Byte

            If Not accountID > 0 Then Return 0

            Dim accountPrefix As Integer = CIntSafe(accountID.ToString.Substring(0, 1), 0)

            If Not accountPrefix > 0 Then Return 0

            Dim currentCompany As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()

            If accountPrefix = currentCompany.AccountClassPrefix11 _
                OrElse (currentCompany.AccountClassPrefix12 > 0 AndAlso _
                accountPrefix = currentCompany.AccountClassPrefix12) Then
                Return 1
            ElseIf accountPrefix = currentCompany.AccountClassPrefix21 _
                OrElse (currentCompany.AccountClassPrefix22 > 0 AndAlso _
                accountPrefix = currentCompany.AccountClassPrefix22) Then
                Return 2
            ElseIf accountPrefix = currentCompany.AccountClassPrefix31 _
                OrElse (currentCompany.AccountClassPrefix32 > 0 AndAlso _
                accountPrefix = currentCompany.AccountClassPrefix32) Then
                Return 3
            ElseIf accountPrefix = currentCompany.AccountClassPrefix41 _
                OrElse (currentCompany.AccountClassPrefix42 > 0 AndAlso _
                accountPrefix = currentCompany.AccountClassPrefix42) Then
                Return 4
            ElseIf accountPrefix = currentCompany.AccountClassPrefix51 _
                OrElse (currentCompany.AccountClassPrefix52 > 0 AndAlso _
                accountPrefix = currentCompany.AccountClassPrefix52) Then
                Return 5
            ElseIf accountPrefix = currentCompany.AccountClassPrefix61 _
                OrElse (currentCompany.AccountClassPrefix62 > 0 AndAlso _
                accountPrefix = currentCompany.AccountClassPrefix62) Then
                Return 6
            Else
                Return 0
            End If

        End Function


        ''' <summary>
        ''' Inherited method used to differentiate between accounts.
        ''' Having in mind that <see cref="ID" /> properties might get invalid or duplicate 
        ''' while editing the <see cref="General.AccountList" />, a private <see cref="Guid" /> 
        ''' is used for the purpose of differentiating between accounts.
        ''' </summary>
        ''' <returns>A <see cref="Guid" /> that is assigned every time 
        ''' an Account gets fetched or created, i.e. not persisted.</returns>
        ''' <remarks></remarks>
        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        ''' <summary>
        ''' Gets a human readable description of the Account instance.
        ''' </summary>
        ''' <returns>A human readable description of the Account instance:
        ''' <see cref="ID" /> - <see cref="Name" /></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return String.Format("{0} - {1}", _ID.ToString, _Name)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.ValueUniqueInCollection, _
                New CommonValidation.SimpleRuleArgs("ID", "sąskaitos numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("ID", "sąskaitos numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Name", "sąskaitos pavadinimas"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringMaxLength, _
                New CommonValidation.StringMaxLengthRuleArgs("Name", 255, "sąskaitos pavadinimas", _
                Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("AssociatedReportItem", _
                "susieta finansinės atskaitomybės eilutė"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewAccount() As Account
            Dim result As New Account
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function NewAccount(ByVal pasteString As String, _
            ByVal AssociatedReportItems As String()) As Account
            Return New Account(pasteString, AssociatedReportItems)
        End Function

        Friend Shared Function NewAccount(ByVal s As String) As Account
            Return New Account(s)
        End Function

        Friend Shared Function GetAccount(ByVal dr As DataRow) As Account
            Return New Account(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

        Private Sub New(ByVal s As String)
            MarkAsChild()
            Create(s)
        End Sub

        Private Sub New(ByVal pasteString As String, ByVal AssociatedReportItems As String())
            MarkAsChild()
            Create(pasteString, AssociatedReportItems)
        End Sub

#End Region

#Region " Data Access "

        ''' <summary>
        ''' Used when generating typical company setup: <see cref="General.ConsolidatedReport" /> and <see cref="General.AccountList" />.
        ''' </summary>
        ''' <param name="s">Text line from the typical company setup file.</param>
        ''' <remarks></remarks>
        Private Sub Create(ByVal s As String)

            _ID = CLongSafe(GetElement(s, 0), 0)
            _OldID = _ID
            _Name = GetElement(s, 1)
            _AssociatedReportItem = GetElement(s, 2)
            _Class = GetAccountClass(_ID)

        End Sub

        Private Sub Create(ByVal pasteString As String, ByVal AssociatedReportItems As String())

            _ID = CLongSafe(GetField(pasteString, vbTab, 0), 0)
            _OldID = _ID
            _Name = GetField(pasteString, vbTab, 1)
            _AssociatedReportItem = GetField(pasteString, vbTab, 2)
            _Class = GetAccountClass(_ID)

            If Array.IndexOf(AssociatedReportItems, _AssociatedReportItem.Trim.ToUpper) < 0 Then _
                _AssociatedReportItem = ""

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CLongSafe(dr.Item(0), 0)
            _OldID = _ID
            _Name = CStrSafe(dr.Item(1))
            _AssociatedReportItem = CStrSafe(dr.Item(2))
            _Class = GetAccountClass(_ID)

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As AccountList)

            Dim myComm As New SQLCommand("InsertAccount")
            AddWithParams(myComm)

            myComm.Execute()

            Me.MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As AccountList)

            Dim myComm As New SQLCommand("UpdateAccount")
            AddWithParams(myComm)
            myComm.AddParam("?TN", _OldID)

            myComm.Execute()

            ' UPDATE account numbers in other tables if it has changed
            If _ID <> _OldID AndAlso Not IsNew Then

                For i As Integer = 1 To 49

                    myComm = New SQLCommand("UpdateAccountsInDocuments" & i.ToString)
                    myComm.AddParam("?AA", _ID)
                    myComm.AddParam("?AB", _OldID)

                    myComm.Execute()

                Next

            End If

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteAccount")
            myComm.AddParam("?NR", _OldID)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)
            myComm.AddParam("?SN", _ID)
            myComm.AddParam("?SP", _Name)
            myComm.AddParam("?RS", _AssociatedReportItem)
        End Sub

        Friend Sub CheckIfCanDelete()

            Dim myComm As New SQLCommand("AccountWasUsed")
            myComm.AddParam("?CD", _OldID)
            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Exit Sub

                Dim typeDictionary As New Dictionary(Of String, String)
                typeDictionary.Add("AccumulativeCosts".Trim.ToLower, "sukauptų sąnaudų operacijoje")
                typeDictionary.Add("AdvanceReports".Trim.ToLower, "avanso apyskaitoje")
                typeDictionary.Add("Asmenys".Trim.ToLower, "kontrahento duomenyse")
                typeDictionary.Add("BankOperations".Trim.ToLower, "banko operacijoje")
                typeDictionary.Add("bzdata".Trim.ToLower, "bendrojo žurnalo operacijoje")
                typeDictionary.Add("CashAccounts".Trim.ToLower, "lėšų apskaitos sąskaitos duomenyse")
                typeDictionary.Add("CompanyAccounts".Trim.ToLower, "standartinėse įmonės sąskaitose")
                typeDictionary.Add("du_ziniarastis".Trim.ToLower, "darbo užmokesčio žiniaraštyje")
                typeDictionary.Add("goods".Trim.ToLower, "prekės duomenyse")
                typeDictionary.Add("goodscomplexoperations".Trim.ToLower, "kompleksinėje prekių operacijoje")
                typeDictionary.Add("goodsoperations".Trim.ToLower, "prekių operacijoje")
                typeDictionary.Add("goodsaccounts".Trim.ToLower, "prekių apskaitos sąskaitų pakeitimo operacijoje")
                typeDictionary.Add("InvoicesMade".Trim.ToLower, "išrašytoje sąskaitoje faktūroje")
                typeDictionary.Add("InvoicesReceived".Trim.ToLower, "gautoje sąskaitoje faktūroje")
                typeDictionary.Add("kalkuliac_d".Trim.ToLower, "gamybos kalkuliacijos kortelės duomenyse")
                typeDictionary.Add("kio".Trim.ToLower, "kasos išlaidų orderyje")
                typeDictionary.Add("kpo".Trim.ToLower, "kasos pajamų orderyje")
                typeDictionary.Add("OffsetItems".Trim.ToLower, "užskaitos operacijoje")
                typeDictionary.Add("Paslaugos".Trim.ToLower, "paslaugos duomenyse")
                typeDictionary.Add("Tipines_data".Trim.ToLower, "bednrojo žurnalo operacijos šablono duomenyse")
                typeDictionary.Add("Turtas".Trim.ToLower, "ilgalaikio turto duomenyse")
                typeDictionary.Add("Turtas_op".Trim.ToLower, "ilgalaikio turto operacijoje")
                typeDictionary.Add("warehouses".Trim.ToLower, "prekių sandėlio duomenyse")

                Dim result As String = "Klaida. Sąskaita " & _OldID.ToString _
                    & " yra naudojama apskaitos duomenyse:" & vbCrLf

                Dim typeString As String
                For Each dr As DataRow In myData.Rows
                    typeString = typeDictionary.Item(CStrSafe(dr.Item(0)).Trim.ToLower)
                    If typeString Is Nothing OrElse String.IsNullOrEmpty(typeString.Trim) Then _
                        typeString = "nenustatytoje programos vietoje"
                    result = AddWithNewLine(result, "* " & typeString & " - objekto ID=" _
                        & CIntSafe(dr.Item(1), 0).ToString & ", operacijos ID=" _
                        & CIntSafe(dr.Item(2), 0).ToString & ", operacijos data - " _
                        & CDateSafe(dr.Item(3), Date.MinValue).ToString("yyyy-MM-dd") & ".", False)
                Next

                Throw New Exception(result)

            End Using

        End Sub

#End Region

    End Class

End Namespace