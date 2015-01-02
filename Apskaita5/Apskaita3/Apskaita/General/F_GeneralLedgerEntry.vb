Public Class F_GeneralLedgerEntry
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As General.JournalEntry
    Private JEEditID As Integer = -1
    Private Loading As Boolean = True
    Private NewObj As General.JournalEntry = Nothing


    Public Sub New(ByVal NewJournalEntry As General.JournalEntry)
        InitializeComponent()
        NewObj = NewJournalEntry
    End Sub

    Public Sub New(ByVal JournalEntryEditID As Integer)
        InitializeComponent()
        JEEditID = JournalEntryEditID
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Obj Is Nothing Then Return 0
            Return Obj.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(General.JournalEntry)
        End Get
    End Property


    Private Sub F_GeneralLedgerEntry_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList), _
            GetType(HelperLists.TemplateJournalEntryInfoList)) Then Exit Sub

    End Sub

    Private Sub F_GeneralLedgerEntry_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then
                e.Cancel = True
                Exit Sub
            End If
            If answ = "Taip" Then
                If Not SaveObj(False) Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        GetDataGridViewLayOut(DebetListDataGridView)
        GetDataGridViewLayOut(CreditListDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_GeneralLedgerEntry_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If JEEditID > 0 AndAlso Not General.JournalEntry.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not JEEditID > 0 AndAlso Not General.JournalEntry.CanAddObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka naujai informacijai įvesti.", _
                MsgBoxStyle.Exclamation, "Klaida")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList), _
            GetType(HelperLists.TemplateJournalEntryInfoList)) Then Exit Sub

        If Not SetDataSources() Then Exit Sub

        Try

            If JEEditID > 0 Then

                Try
                    Obj = LoadObject(Of General.JournalEntry)(Nothing, "GetJournalEntry", False, JEEditID)
                Catch ex As Exception
                    ShowError(ex)
                    DisableAllControls(Me)
                    Exit Sub
                End Try

            ElseIf Not NewObj Is Nothing Then

                Obj = NewObj

            Else

                Obj = General.JournalEntry.NewJournalEntry

            End If

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        JournalEntryBindingSource.DataSource = Obj

        ReadWriteAuthorization1.ResetControlAuthorization()

        SetDataGridViewLayOut(DebetListDataGridView)
        SetDataGridViewLayOut(CreditListDataGridView)
        SetFormLayout(Me)

        If Obj.DocType <> DocumentType.None Then

            DisableAllControls(Me)
            ViewRelationsButton.Enabled = True
            ViewDocumentButton.Enabled = True
            ViewDocumentButton.Visible = (Obj.DocType <> DocumentType.ClosingEntries)
            LimitationsButton.Enabled = True
            LimitationsButton.Visible = Not String.IsNullOrEmpty(Obj.ChronologyValidator.LimitsExplanation.Trim)

        ElseIf Not Obj.IsNew AndAlso Not General.JournalEntry.CanEditObject Then

            DisableAllControls(Me)
            ViewRelationsButton.Enabled = True
            MsgBox("Klaida. Jūsų teisių nepakanka informacijai redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida")

        Else
            ConfigureButtons()
        End If

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles nOkButton.Click

        If Obj.IsNew Then
            If Not SaveObj(True) Then Exit Sub
        Else
            If Not SaveObj(False) Then Exit Sub
            Me.Hide()
            Me.Close()
        End If

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        SaveObj(False)
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nCancelButton.Click
        CancelObj()
    End Sub


    Private Sub NewItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewItemButton.Click

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then Exit Sub
            If answ = "Taip" Then
                If Not SaveObj(False) Then Exit Sub
            End If
        End If

        Using bm As New BindingsManager(JournalEntryBindingSource, DebetListBindingSource, _
            CreditListBindingSource, True, True)

            Obj = General.JournalEntry.NewJournalEntry
            bm.SetNewDataSource(Obj)

        End Using

        ConfigureButtons()

    End Sub

    Private Sub LoadTemplateButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LoadTemplateButton.Click

        If Not Obj.IsNew AndAlso Not General.JournalEntry.CanEditObject Then Exit Sub

        If Not Obj.IsNew AndAlso Not YesOrNo("DĖMESIO. Jūs redaguojate jau " & _
            "registruotą apskaitoje įrašą. Ar tikrai norite įkrauti šabloną?") Then Exit Sub

        If TemplateComboBox.SelectedIndex < 0 Then
            MsgBox("Klaida. Nepasirinktas šablonas.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim Tmpl As HelperLists.TemplateJournalEntryInfo = LoadObjectFromCombo _
            (Of HelperLists.TemplateJournalEntryInfo)(TemplateComboBox, "")
        If Tmpl Is Nothing Then
            MsgBox("Klaida. Nepasirinktas šablonas.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Obj.LoadJournalEntryFromTemplate(Tmpl)

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click
        If Not Obj Is Nothing Then MsgBox(Obj.ChronologyValidator.LimitsExplanation, _
            MsgBoxStyle.Information, "")
    End Sub

    Private Sub ViewRelationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewRelationsButton.Click
        If Obj Is Nothing Then Exit Sub
        MDIParent1.LaunchForm(GetType(F_IndirectRelationInfoList), False, False, Obj.ID, Obj.ID)
    End Sub

    Private Sub ViewDocumentButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewDocumentButton.Click
        If Obj Is Nothing OrElse Obj.DocType = DocumentType.ClosingEntries _
            OrElse Obj.DocType = DocumentType.None Then Exit Sub
        OpenDocumentInEditForm(Obj.ID, Obj.DocType)
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



    Private Function SaveObj(ByVal ReplaceWithNewPerson As Boolean) As Boolean

        If Not Obj.IsDirty AndAlso ReplaceWithNewPerson Then
            Using bm As New BindingsManager(JournalEntryBindingSource, DebetListBindingSource, _
                CreditListBindingSource, True, False)
                Obj = General.JournalEntry.NewJournalEntry
                bm.SetNewDataSource(Obj)
            End Using
            Return True
        End If
        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.BrokenRulesCollection.ToString( _
                Csla.Validation.RuleSeverity.Error), MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Obj.BrokenRulesCollection.WarningCount > 0 Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.BrokenRulesCollection.ToString(Csla.Validation.RuleSeverity.Warning) & vbCrLf
        Else
            Question = ""
        End If
        If Obj.IsNew Then
            Question = Question & "Ar tikrai norite įtraukti naujus duomenis?"
            Answer = "Nauji duomenys sėkmingai įtraukti."
        Else
            Question = Question & "Ar tikrai norite pakeisti duomenis?"
            Answer = "Duomenys sėkmingai pakeisti."
        End If

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(JournalEntryBindingSource, DebetListBindingSource, _
            CreditListBindingSource, True, False)

            Try
                Obj = LoadObject(Of General.JournalEntry)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            If ReplaceWithNewPerson Then Obj = General.JournalEntry.NewJournalEntry
            bm.SetNewDataSource(Obj)

        End Using

        If Not General.JournalEntry.CanEditObject Then
            DisableAllControls(Me)
            DebetListDataGridView.Enabled = True
            DebetListDataGridView.ReadOnly = True
            CreditListDataGridView.Enabled = True
            CreditListDataGridView.ReadOnly = True
        Else
            ConfigureButtons()
        End If

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()

        If Obj Is Nothing OrElse Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub

        Using bm As New BindingsManager(JournalEntryBindingSource, _
            DebetListBindingSource, CreditListBindingSource, True, True)
        End Using

    End Sub

    Private Sub ConfigureButtons()

        If Obj Is Nothing Then Exit Sub

        EditedBaner.Visible = Not (Obj.IsNew)

        LoadTemplateButton.Enabled = Obj.ChronologyValidator.FinancialDataCanChange
        TemplateComboBox.Enabled = Obj.ChronologyValidator.FinancialDataCanChange

        nCancelButton.Enabled = Not Obj.IsNew

        DebetListDataGridView.AllowUserToAddRows = Obj.ChronologyValidator.FinancialDataCanChange
        CreditListDataGridView.AllowUserToAddRows = Obj.ChronologyValidator.FinancialDataCanChange
        DebetListDataGridView.AllowUserToDeleteRows = Obj.ChronologyValidator.FinancialDataCanChange
        CreditListDataGridView.AllowUserToDeleteRows = Obj.ChronologyValidator.FinancialDataCanChange
        DebetListDataGridView.ReadOnly = Not Obj.ChronologyValidator.FinancialDataCanChange
        CreditListDataGridView.ReadOnly = Not Obj.ChronologyValidator.FinancialDataCanChange

        LimitationsButton.Visible = Not String.IsNullOrEmpty(Obj.ChronologyValidator.LimitsExplanation.Trim)

    End Sub

    Private Function SetDataSources() As Boolean

        Try

            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn3, True)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn8, True)

            LoadPersonInfoListToGridCombo(DataGridViewTextBoxColumn5, True, True, True, True)
            LoadPersonInfoListToGridCombo(DataGridViewTextBoxColumn10, True, True, True, True)
            LoadPersonInfoListToGridCombo(PersonAccGridComboBox, True, True, True, True)

            TemplateComboBox.DataSource = HelperLists.TemplateJournalEntryInfoList.GetCachedFilteredList(True)
            TemplateComboBox.ValueMember = "GetMe"
            TemplateComboBox.DisplayMember = "Name"

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class