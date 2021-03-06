Imports AccControlsWinForms
Imports ApskaitaObjects.ActiveReports
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccDataBindingsWinForms.Printing
Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.Documents

Friend Class F_BookEntryInfoListParent
    Implements ISupportsPrinting

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.AccountInfoList), GetType(HelperLists.PersonInfoList),
        GetType(HelperLists.PersonGroupInfoList)}

    Private _TypesAbleToDelete As DocumentType() = New DocumentType() _
        {DocumentType.Offset, DocumentType.AccumulatedCosts,
        DocumentType.TransferOfBalance, DocumentType.HolidayReserve,
        DocumentType.None, DocumentType.ClosingEntries, DocumentType.BankOperation, DocumentType.TillIncomeOrder,
        DocumentType.TillSpendingOrder, DocumentType.InvoiceMade, DocumentType.InvoiceReceived,
        DocumentType.WageSheet, DocumentType.AdvanceReport, DocumentType.ImprestSheet}

    Private _FormManager As CslaActionExtenderReportForm(Of BookEntryInfoListParent)
    Private _ListViewManager As DataListViewEditControlManager(Of BookEntryInfo)
    Private _QueryManager As CslaActionExtenderQueryObject
    Private _DeleteSuccessMessage As String = ""

    Private _DateFrom, _DateTo As Date
    Private _AccountNumber As Long = 0
    Private _PersonID As Integer = 0


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal accountNumber As Long, ByVal dateFrom As Date,
        ByVal dateTo As Date, Optional ByVal personID As Integer = 0)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _AccountNumber = accountNumber
        _DateFrom = dateFrom
        _DateTo = dateTo
        _PersonID = personID

    End Sub


    Private Sub F_AccountTurnoverInfo_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub
        If _AccountNumber > 0 Then
            AccountAccGridComboBox.SelectedValue = _AccountNumber
            DateFromAccDatePicker.Value = _DateFrom
            DateToAccDatePicker.Value = _DateTo
            If _PersonID > 0 Then
                For Each p As HelperLists.PersonInfo In HelperLists.PersonInfoList.GetList
                    If p.ID = _PersonID Then
                        PersonAccGridComboBox.SelectedValue = p
                        Exit For
                    End If
                Next
            End If
            RefreshButton.PerformClick()
        End If

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList),
            GetType(HelperLists.PersonInfoList), GetType(HelperLists.PersonGroupInfoList)) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of BookEntryInfo) _
                (ItemsDataListView, ContextMenuStrip1, Nothing, Nothing,
                 AddressOf ItemActionIsAvailable, Nothing)

            _ListViewManager.AddCancelButton = True
            _ListViewManager.AddButtonHandler(My.Resources.F_JournalEntryInfoList_EditLabel,
                My.Resources.F_JournalEntryInfoList_EditTooltipLabel, AddressOf EditItem)
            _ListViewManager.AddButtonHandler(My.Resources.F_JournalEntryInfoList_CopyJournalEntryLabel,
                My.Resources.F_JournalEntryInfoList_CopyJournalEntryToolTipLabel, AddressOf CopyJournalEntry)
            _ListViewManager.AddButtonHandler(My.Resources.F_JournalEntryInfoList_DeleteLabel,
                My.Resources.F_JournalEntryInfoList_DeleteTooltipLabel, AddressOf DeleteItem)
            _ListViewManager.AddButtonHandler(My.Resources.F_JournalEntryInfoList_CorrespondencesLabel,
                My.Resources.F_JournalEntryInfoList_CorrespondencesTooltipLabel, AddressOf ShowItemJournalEntry)
            _ListViewManager.AddButtonHandler(My.Resources.F_JournalEntryInfoList_RelationsLabel,
                My.Resources.F_JournalEntryInfoList_RelationsTooltipLabel, AddressOf ShowItemRelations)

            _ListViewManager.AddMenuItemHandler(EditToolStripMenuItem, AddressOf EditItem)
            _ListViewManager.AddMenuItemHandler(CopyJournalEntryToolStripMenuItem, AddressOf CopyJournalEntry)
            _ListViewManager.AddMenuItemHandler(DeleteToolStripMenuItem, AddressOf DeleteItem)
            _ListViewManager.AddMenuItemHandler(CorrespondationsToolStripMenuItem, AddressOf ShowItemJournalEntry)
            _ListViewManager.AddMenuItemHandler(RelationsToolStripMenuItem, AddressOf ShowItemRelations)

            _FormManager = New CslaActionExtenderReportForm(Of BookEntryInfoListParent) _
                (Me, BookEntryInfoListParentBindingSource, Nothing, _RequiredCachedLists,
                 RefreshButton, ProgressFiller1, "GetBookEntryInfoListParent",
                 AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(ItemsDataListView)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            PrepareControl(PersonGroupComboBox, New PersonGroupFieldAttribute(
                ValueRequiredLevel.Optional))
            PrepareControl(PersonAccGridComboBox, New PersonFieldAttribute(
                ValueRequiredLevel.Optional, True, True, True, False))
            PrepareControl(AccountAccGridComboBox, New AccountFieldAttribute(
                ValueRequiredLevel.Optional, False))

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        DateFromAccDatePicker.Value = Today.AddMonths(-3)

        Return True

    End Function


    Private Function GetReportParams() As Object()

        Dim person As HelperLists.PersonInfo = Nothing
        If PersonAccGridComboBox.SelectedValue IsNot Nothing Then _
            person = DirectCast(PersonAccGridComboBox.SelectedValue, HelperLists.PersonInfo)
        Dim group As HelperLists.PersonGroupInfo = Nothing
        If PersonGroupComboBox.SelectedValue IsNot Nothing Then _
            group = DirectCast(PersonGroupComboBox.SelectedValue, HelperLists.PersonGroupInfo)
        Dim account As Long = 0
        Try
            account = Convert.ToInt64(AccountAccGridComboBox.SelectedValue)
        Catch ex As Exception
        End Try

        Return New Object() {DateFromAccDatePicker.Value.Date,
            DateToAccDatePicker.Value.Date, account, person, group,
            IncludeSubAccountsCheckBox.Checked}

    End Function

    Private Function ItemActionIsAvailable(ByVal item As BookEntryInfo,
        ByVal action As String) As Boolean

        If item Is Nothing OrElse action Is Nothing Then Return False

        If action.Trim.ToLower = "EditItem".ToLower Then

            If item.DocType = DocumentType.ClosingEntries Then
                Return False
            Else
                Return True
            End If

        ElseIf action.Trim.ToLower = "DeleteItem".ToLower Then

            If Array.IndexOf(_TypesAbleToDelete, item.DocType) < 0 Then
                Return False
            Else
                Return True
            End If

        ElseIf action.Trim.ToLower = "ShowItemJournalEntry".ToLower Then

            If item.DocType = DocumentType.None Then
                Return False
            Else
                Return True
            End If

        ElseIf action.Trim.ToLower = "ShowItemRelations".ToLower Then
            Return True
        End If

        Return False

    End Function

    Private Sub EditItem(ByVal item As BookEntryInfo)
        OpenObjectEditForm(_QueryManager, item.JournalEntryID, item.DocType)
    End Sub

    Private Sub DeleteItem(ByVal item As BookEntryInfo)

        If item.DocType = DocumentType.ClosingEntries Then
            If Not YesOrNo("Ar tikrai norite pašalinti 5/6 klasių uždarymo duomenis iš duomenų bazės?") Then Exit Sub
        ElseIf item.DocType = DocumentType.None Then
            If Not YesOrNo("Ar tikrai norite pašalinti bendrojo žurnalo įrašo duomenis iš duomenų bazės?") Then Exit Sub
        Else
            If Not YesOrNo("Ar tikrai norite pašalinti dokumento duomenis iš duomenų bazės?") Then Exit Sub
        End If

        _DeleteSuccessMessage = "Dokumento duomenys sėkmingai pašalinti iš įmonės duomenų bazės."
        If item.DocType = DocumentType.ClosingEntries Then
            _DeleteSuccessMessage = "5/6 klasių uždarymo duomenys sėkmingai pašalinti iš įmonės duomenų bazės."
        ElseIf item.DocType = DocumentType.None Then
            _DeleteSuccessMessage = "Bendojo žurnalo įrašo duomenys sėkmingai pašalinti iš įmonės duomenų bazės."
        End If

        If item.DocType = DocumentType.Offset Then
            _QueryManager.InvokeQuery(Of Documents.Offset)(Nothing, "DeleteOffset", False,
                AddressOf OnItemDeleted, item.JournalEntryID)
        ElseIf item.DocType = DocumentType.AccumulatedCosts Then
            _QueryManager.InvokeQuery(Of Documents.AccumulativeCosts)(Nothing, "DeleteAccumulativeCosts", False,
                AddressOf OnItemDeleted, item.JournalEntryID)
        ElseIf item.DocType = DocumentType.TransferOfBalance Then
            _QueryManager.InvokeQuery(Of General.TransferOfBalance)(Nothing, "DeleteTransferOfBalance", False,
                AddressOf OnItemDeleted)
        ElseIf item.DocType = DocumentType.HolidayReserve Then
            _QueryManager.InvokeQuery(Of Workers.HolidayPayReserve)(Nothing, "DeleteHolidayPayReserve", False,
                AddressOf OnItemDeleted, item.JournalEntryID)
        ElseIf item.DocType = DocumentType.BankOperation Then
            'BankOperation.DeleteBankOperation(item.ID)
            _QueryManager.InvokeQuery(Of BankOperation)(Nothing, "DeleteBankOperation", True,
                AddressOf OnItemDeleted, item.Id)
        ElseIf item.DocType = DocumentType.TillIncomeOrder Then
            'TillIncomeOrder.DeleteTillIncomeOrder(item.ID)
            _QueryManager.InvokeQuery(Of TillIncomeOrder)(Nothing, "DeleteTillIncomeOrder", True,
                AddressOf OnItemDeleted, item.Id)
        ElseIf item.DocType = DocumentType.TillSpendingOrder Then
            'TillSpendingsOrder.DeleteTillSpendingsOrder(item.ID)
            _QueryManager.InvokeQuery(Of TillSpendingsOrder)(Nothing, "DeleteTillSpendingsOrder", True,
                AddressOf OnItemDeleted, item.Id)
        ElseIf item.DocType = InvoiceInfoType.InvoiceMade Then
            'InvoiceMade.DeleteInvoiceMade(item.ID)
            _QueryManager.InvokeQuery(Of InvoiceMade)(Nothing, "DeleteInvoiceMade", False,
                AddressOf OnItemDeleted, item.ID)
        ElseIf item.DocType = InvoiceInfoType.InvoiceReceived Then
            'InvoiceReceived.DeleteInvoiceReceived(item.ID)
            _QueryManager.InvokeQuery(Of InvoiceReceived)(Nothing, "DeleteInvoiceReceived", False,
                AddressOf OnItemDeleted, item.Id)
        ElseIf item.DocType = DocumentType.AdvanceReport Then
            ' AdvanceReport.DeleteAdvanceReport(item.ID)
            _QueryManager.InvokeQuery(Of AdvanceReport)(Nothing, "DeleteAdvanceReport", False,
                AddressOf OnItemDeleted, item.Id)
        ElseIf item.DocType = DocumentType.WageSheet Then
            ' WageSheet.DeleteWageSheet(item.ID)
            _QueryManager.InvokeQuery(Of Workers.WageSheet)(Nothing, "DeleteWageSheet", False,
                AddressOf OnItemDeleted, item.Id)
        ElseIf item.DocType = DocumentType.ImprestSheet Then
            ' ImprestSheet.DeleteImprestSheet(item.ID)
            _QueryManager.InvokeQuery(Of Workers.ImprestSheet)(Nothing, "DeleteImprestSheet", False,
                AddressOf OnItemDeleted, item.Id)
        Else
            _QueryManager.InvokeQuery(Of General.JournalEntry)(Nothing, "DeleteJournalEntry", False, _
                AddressOf OnItemDeleted, item.JournalEntryID)
        End If

    End Sub

    Private Sub OnItemDeleted(ByVal nullResult As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo(_DeleteSuccessMessage & vbCrLf & "Atnaujinti ataskaitos duomenis?") Then Exit Sub
        RefreshButton.PerformClick()
    End Sub

    Private Sub CopyJournalEntry(ByVal item As BookEntryInfo)
        If item Is Nothing OrElse Not item.JournalEntryID > 0 OrElse item.DocType <> DocumentType.None Then Exit Sub
        'General.JournalEntry.GetJournalEntry(item.JournalEntryID)
        _QueryManager.InvokeQuery(Of General.JournalEntry)(Nothing, "GetJournalEntry", True, _
            AddressOf OnJournalEntryFetched, item.JournalEntryID)
    End Sub

    Private Sub OnJournalEntryFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If result Is Nothing Then Exit Sub
        OpenObjectEditForm(DirectCast(result, General.JournalEntry).GetJournalEntryCopy())
    End Sub

    Private Sub ShowItemJournalEntry(ByVal item As BookEntryInfo)
        OpenJournalEntryEditForm(_QueryManager, item.JournalEntryID)
    End Sub

    Private Sub ShowItemRelations(ByVal item As BookEntryInfo)
        If item Is Nothing Then Exit Sub
        _QueryManager.InvokeQuery(Of HelperLists.IndirectRelationInfoList) _
            (Nothing, "GetIndirectRelationInfoList", True, _
             AddressOf OpenObjectEditForm, item.JournalEntryID)
    End Sub


    Private Sub ClearButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ClearButton.Click
        DateFromAccDatePicker.Value = Today.AddMonths(-3)
        DateToAccDatePicker.Value = Today
        AccountAccGridComboBox.SelectedValue = Nothing
        PersonAccGridComboBox.SelectedValue = Nothing
        PersonGroupComboBox.SelectedValue = Nothing
        IncludeSubAccountsCheckBox.Checked = False
    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetMailDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems
        Return Nothing
    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick
        If _FormManager.DataSource Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(_FormManager.DataSource, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, False, 0, "SaskaitosApyvarta", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "SaskaitosApyvarta", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function

End Class



