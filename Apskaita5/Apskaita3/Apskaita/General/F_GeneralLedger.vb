Imports ApskaitaObjects.ActiveReports
Public Class F_GeneralLedger
    Implements ISupportsPrinting

    Private Obj As JournalEntryInfoList
    Private Loading As Boolean = True

    Private Sub F_GeneralLedger_Activated(ByVal sender As System.Object, _
         ByVal e As System.EventArgs) Handles MyBase.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonGroupInfoList), _
            GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_GeneralLedger_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetDataGridViewLayOut(JournalEntryInfoListDataGridView)
        GetFormLayout(Me)
    End Sub

    Private Sub F_GeneralLedger_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        DateFromDateTimePicker.Value = Today.AddMonths(-1)

        AddDGVColumnSelector(JournalEntryInfoListDataGridView)

        SetDataGridViewLayOut(JournalEntryInfoListDataGridView)
        SetFormLayout(Me)

        Me.EditToolStripMenuItem.Text = GeneralLedger_EditLabel
        Me.EditToolStripMenuItem.ToolTipText = GeneralLedger_EditTooltipLabel
        Me.DeleteToolStripMenuItem.Text = GeneralLedger_DeleteLabel
        Me.DeleteToolStripMenuItem.ToolTipText = GeneralLedger_DeleteTooltipLabel
        Me.CorrespondencesToolStripMenuItem.Text = GeneralLedger_CorrespondencesLabel
        Me.CorrespondencesToolStripMenuItem.ToolTipText = GeneralLedger_CorrespondencesTooltipLabel
        Me.RelationsToolStripMenuItem.Text = GeneralLedger_RelationsLabel
        Me.RelationsToolStripMenuItem.ToolTipText = GeneralLedger_RelationsTooltipLabel
        Me.CancelToolStripMenuItem.Text = GeneralLedger_CancelLabel
        Me.CancelToolStripMenuItem.ToolTipText = GeneralLedger_CancelTooltipLabel

    End Sub


    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim PrsFilter As Integer
        Dim PrsName As String = ""
        If PersonAccGridComboBox.SelectedValue Is Nothing OrElse _
            Not CType(PersonAccGridComboBox.SelectedValue, HelperLists.PersonInfo).ID > 0 Then
            PrsFilter = -1
        Else
            PrsFilter = CType(PersonAccGridComboBox.SelectedValue, HelperLists.PersonInfo).ID
            PrsName = PersonAccGridComboBox.SelectedValue.ToString
        End If

        Dim GrpFilter As Integer
        Dim GrpName As String = ""
        If PersonGroupComboBox.SelectedItem Is Nothing OrElse _
            Not CType(PersonGroupComboBox.SelectedItem, HelperLists.PersonGroupInfo).ID > 0 Then
            GrpFilter = -1
        Else
            GrpFilter = CType(PersonGroupComboBox.SelectedItem, HelperLists.PersonGroupInfo).ID
            GrpName = CType(PersonGroupComboBox.SelectedItem, HelperLists.PersonGroupInfo).Name
        End If

        Dim DocFilter As DocumentType = DocumentType.None
        Dim ApplyDocFilter As Boolean = False
        If DocTypeComboBox.SelectedIndex > 0 Then
            ApplyDocFilter = True
            DocFilter = ConvertEnumHumanReadable(Of DocumentType)(DocTypeComboBox.SelectedItem.ToString)
        End If

        Using bm As New BindingsManager(JournalEntryInfoListBindingSource, _
            Nothing, Nothing, False, True)

            Try
                Obj = LoadObject(Of ActiveReports.JournalEntryInfoList)(Nothing, "GetList", True, _
                    DateFromDateTimePicker.Value.Date, DateToDateTimePicker.Value.Date, _
                    ContentTextBox.Text.Trim, PrsFilter, GrpFilter, DocFilter, ApplyDocFilter, _
                    PrsName, GrpName)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj.GetItemsSortable)

        End Using

        JournalEntryInfoListDataGridView.Select()

    End Sub

    Private Sub JournalEntryInfoListDataGridView_CellMouseClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
        Handles JournalEntryInfoListDataGridView.CellMouseClick

        If e.Button <> Windows.Forms.MouseButtons.Right OrElse e.RowIndex < 0 Then Exit Sub

        Dim currentItem As JournalEntryInfo = Nothing
        Try
            currentItem = CType(JournalEntryInfoListDataGridView.Rows(e.RowIndex).DataBoundItem, _
                JournalEntryInfo)
        Catch ex As Exception
        End Try
        If currentItem Is Nothing Then Exit Sub

        JournalEntryInfoListDataGridView.ClearSelection()
        JournalEntryInfoListDataGridView.Rows(e.RowIndex).Selected = True

        Me.ContextMenuStrip1.Tag = currentItem
        Me.CorrespondencesToolStripMenuItem.Visible = (currentItem.DocType <> DocumentType.None)
        Me.EditToolStripMenuItem.Visible = (currentItem.DocType <> DocumentType.ClosingEntries)
        Me.DeleteToolStripMenuItem.Visible = (currentItem.DocType = DocumentType.None OrElse _
            currentItem.DocType = DocumentType.TransferOfBalance OrElse _
            currentItem.DocType = DocumentType.ClosingEntries OrElse _
            currentItem.DocType = DocumentType.Offset OrElse _
            currentItem.DocType = DocumentType.AccumulatedCosts)

        Me.ContextMenuStrip1.Show(JournalEntryInfoListDataGridView, _
            JournalEntryInfoListDataGridView.PointToClient(Cursor.Position))

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click, _
        DeleteToolStripMenuItem.Click, CorrespondencesToolStripMenuItem.Click, _
        RelationsToolStripMenuItem.Click

        Dim currentItem As JournalEntryInfo = Nothing
        Try
            currentItem = DirectCast(Me.ContextMenuStrip1.Tag, JournalEntryInfo)
        Catch ex As Exception
        End Try

        If currentItem Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinktos eilutės.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Select Case DirectCast(sender, ToolStripMenuItem).Text.Trim
            Case GeneralLedger_EditLabel.Trim
                OpenDocumentInEditForm(currentItem.Id, currentItem.DocType)
            Case GeneralLedger_DeleteLabel.Trim
                DeleteEntry(currentItem)
            Case GeneralLedger_CorrespondencesLabel.Trim
                MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, currentItem.Id, currentItem.Id)
            Case GeneralLedger_RelationsLabel.Trim
                MDIParent1.LaunchForm(GetType(F_IndirectRelationInfoList), False, False, currentItem.Id, currentItem.Id)
            Case Else
                MsgBox("Klaida. Neimplementuotas operacijos tipas '" & _
                    DirectCast(sender, ToolStripMenuItem).Text.Trim & "'.", _
                    MsgBoxStyle.Exclamation, "Klaida")
        End Select

    End Sub

    Private Sub JournalEntryInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles JournalEntryInfoListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        ' get the selected journal entry
        Dim currentItem As JournalEntryInfo = Nothing
        Try
            currentItem = DirectCast(JournalEntryInfoListDataGridView.Rows(e.RowIndex) _
                .DataBoundItem, JournalEntryInfo)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        If currentItem Is Nothing Then
            MsgBox("Klaida. Nepavyko nustatyti pasirinkto bendrojo žurnalo įrašo.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim buttonList As New List(Of ButtonStructure)
        If currentItem.DocType <> DocumentType.ClosingEntries Then buttonList.Add( _
            New ButtonStructure(GeneralLedger_EditLabel, GeneralLedger_EditTooltipLabel))
        If currentItem.DocType = DocumentType.None OrElse _
            currentItem.DocType = DocumentType.TransferOfBalance OrElse _
            currentItem.DocType = DocumentType.ClosingEntries OrElse _
            currentItem.DocType = DocumentType.Offset OrElse _
            currentItem.DocType = DocumentType.AccumulatedCosts Then buttonList.Add( _
            New ButtonStructure(GeneralLedger_DeleteLabel, GeneralLedger_DeleteTooltipLabel))
        If currentItem.DocType <> DocumentType.None Then buttonList.Add( _
            New ButtonStructure(GeneralLedger_CorrespondencesLabel, GeneralLedger_CorrespondencesTooltipLabel))
        buttonList.Add(New ButtonStructure(GeneralLedger_RelationsLabel, GeneralLedger_RelationsTooltipLabel))
        buttonList.Add(New ButtonStructure(GeneralLedger_CancelLabel, GeneralLedger_CancelTooltipLabel))

        ' ask what to do
        Dim ats As String = Ask("", buttonList.ToArray)

        If ats <> GeneralLedger_EditLabel AndAlso ats <> GeneralLedger_DeleteLabel AndAlso ats <> GeneralLedger_CorrespondencesLabel _
            AndAlso ats <> GeneralLedger_RelationsLabel Then Exit Sub

        If ats = GeneralLedger_EditLabel Then

            OpenDocumentInEditForm(currentItem.Id, currentItem.DocType)

        ElseIf ats = GeneralLedger_CorrespondencesLabel Then

            MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, currentItem.Id, currentItem.Id)

        ElseIf ats = GeneralLedger_RelationsLabel Then

            MDIParent1.LaunchForm(GetType(F_IndirectRelationInfoList), False, False, currentItem.Id, currentItem.Id)

        Else

            DeleteEntry(currentItem)

        End If

    End Sub

    Private Sub ClearButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ClearButton.Click
        DocTypeComboBox.SelectedIndex = -1
        PersonGroupComboBox.SelectedIndex = -1
        PersonAccGridComboBox.SelectedValue = Nothing
        ContentTextBox.Text = ""
    End Sub

    Private Sub NewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewJournalEntryButton.Click
        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, 0)
    End Sub

    Private Sub CloseAccountsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CloseAccountsButton.Click
        MDIParent1.LaunchForm(GetType(F_ClosingEntriesCommand), True, False, 0)
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
        If Obj Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(Obj, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, False, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, True, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.PersonGroupInfoList), _
            GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            LoadPersonGroupInfoListToCombo(PersonGroupComboBox)
            LoadPersonInfoListToGridCombo(PersonAccGridComboBox, True, True, True, True)

            DocTypeComboBox.DataSource = GetEnumValuesHumanReadableList(GetType(DocumentType), True)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub DeleteEntry(ByVal currentItem As JournalEntryInfo)

        If currentItem Is Nothing Then
            MsgBox("Klaida. Nenustatyta operacija.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        If currentItem.DocType = DocumentType.ClosingEntries Then
            If Not YesOrNo("Ar tikrai norite pašalinti 5/6 klasių uždarymo duomenis iš duomenų bazės?") Then Exit Sub
        ElseIf currentItem.DocType = DocumentType.None Then
            If Not YesOrNo("Ar tikrai norite pašalinti bendrojo žurnalo įrašo duomenis iš duomenų bazės?") Then Exit Sub
        Else
            If Not YesOrNo("Ar tikrai norite pašalinti dokumento duomenis iš duomenų bazės?") Then Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                If currentItem.DocType = DocumentType.Offset Then
                    Documents.Offset.DeleteOffset(currentItem.Id)
                ElseIf currentItem.DocType = DocumentType.AccumulatedCosts Then
                    Documents.AccumulativeCosts.DeleteAccumulativeCosts(currentItem.Id)
                ElseIf currentItem.DocType = DocumentType.TransferOfBalance Then
                    General.TransferOfBalance.DeleteTransferOfBalance()
                Else
                    General.JournalEntry.DeleteJournalEntry(currentItem.Id)
                End If
            End Using
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        Dim SuccessMessage As String = "Dokumento duomenys sėkmingai pašalinti iš įmonės duomenų bazės."
        If currentItem.DocType = DocumentType.ClosingEntries Then
            SuccessMessage = "5/6 klasių uždarymo duomenys sėkmingai pašalinti iš įmonės duomenų bazės."
        ElseIf currentItem.DocType = DocumentType.None Then
            SuccessMessage = "Bendojo žurnalo įrašo duomenys sėkmingai pašalinti iš įmonės duomenų bazės."
        End If

        If Not YesOrNo(SuccessMessage & vbCrLf & "Atnaujinti ataskaitos duomenis?") Then Exit Sub

        Me.RefreshButton_Click(Me, New EventArgs)

    End Sub

End Class