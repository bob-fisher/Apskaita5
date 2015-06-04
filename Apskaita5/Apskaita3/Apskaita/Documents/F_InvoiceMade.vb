Imports ApskaitaObjects.Documents
Imports ApskaitaObjects.Settings

Public Class F_InvoiceMade
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As InvoiceMade
    Private _InvoiceID As Integer = -1
    Private Loading As Boolean = True
    Private _CopyInvoice As Boolean = False
    Private PrintDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private PrintPreviewDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private EmailDropDown As Windows.Forms.ToolStripDropDown = Nothing


    Public ReadOnly Property ObjectID() As Integer _
        Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type _
        Implements IObjectEditForm.ObjectType
        Get
            Return GetType(InvoiceMade)
        End Get
    End Property


    Public Sub New(ByVal nInvoiceID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _InvoiceID = nInvoiceID

    End Sub

    Public Sub New(ByVal nInvoiceID As Integer, ByVal nCopyInvoice As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _InvoiceID = nInvoiceID
        _CopyInvoice = nCopyInvoice

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


    End Sub



    Private Sub F_InvoiceMade_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.DocumentSerialInfoList), _
            GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList), _
            GetType(HelperLists.CompanyRegionalInfoList), GetType(Settings.CommonSettings), _
            GetType(AccDataAccessLayer.Security.UserProfile)) Then Exit Sub

    End Sub

    Private Sub F_InvoiceMade_FormClosing(ByVal sender As Object, _
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
                If Not SaveObj() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        GetDataGridViewLayOut(InvoiceItemsSortedDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_InvoiceMade_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _InvoiceID > 0 AndAlso Not Documents.InvoiceMade.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not _InvoiceID > 0 AndAlso Not Documents.InvoiceMade.CanAddObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka naujam dokumentui įvesti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        If _InvoiceID > 0 Then

            Try
                Obj = LoadObject(Of InvoiceMade)(Nothing, "GetInvoiceMade", _
                    True, _InvoiceID)
                If _CopyInvoice Then Obj = Obj.GetInvoiceMadeCopy
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        Else

            Obj = InvoiceMade.NewInvoiceMade

        End If

        InvoiceMadeBindingSource.DataSource = Obj

        AddDGVColumnSelector(InvoiceItemsSortedDataGridView)

        SetDataGridViewLayOut(InvoiceItemsSortedDataGridView)
        SetFormLayout(Me)

        If Not Obj.IsNew AndAlso Not Documents.InvoiceMade.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            TabControl1.Enabled = True
            InvoiceItemsSortedDataGridView.Enabled = True
            InvoiceItemsSortedDataGridView.ReadOnly = True
            CopyInvoiceButton.Enabled = True
            Exit Sub
        End If

        ConfigureButtons()

        Dim h As New EditableDataGridViewHelper(InvoiceItemsSortedDataGridView)

    End Sub



    Private Sub OkButton_Click(ByVal sender As System.Object, _
       ByVal e As System.EventArgs) Handles IOkButton.Click

        If Not SaveObj() Then Exit Sub
        Me.Hide()
        Me.Close()

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IApplyButton.Click
        If Not SaveObj() Then Exit Sub
        If Not Obj.IsNew AndAlso Not InvoiceMade.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            TabControl1.Enabled = True
            InvoiceItemsSortedDataGridView.Enabled = True
            InvoiceItemsSortedDataGridView.ReadOnly = True
            CopyInvoiceButton.Enabled = True
            Exit Sub
        End If
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        CancelObj()
    End Sub


    Private Sub GetCurrencyRatesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetCurrencyRatesButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim paramList As New AccWebCrawler.CurrencyRateList

        paramList.Add(Obj.Date, Obj.CurrencyCode)

        If paramList.Count < 1 Then Exit Sub

        If Not YesOrNo("Gauti valiutos kursą?") Then Exit Sub

        Using frm As New AccWebCrawler.F_LaunchWebCrawler(paramList, GetCurrentCompany.BaseCurrency)

            If frm.ShowDialog <> Windows.Forms.DialogResult.OK OrElse frm.result Is Nothing _
                OrElse Not TypeOf frm.result Is AccWebCrawler.CurrencyRateList _
                OrElse DirectCast(frm.result, AccWebCrawler.CurrencyRateList).Count < 1 Then Exit Sub

            Obj.CurrencyRate = DirectCast(frm.result, AccWebCrawler.CurrencyRateList). _
                GetCurrencyRate(Obj.Date, Obj.CurrencyCode)

        End Using

    End Sub

    Private Sub AddAttachedObjectButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddAttachedObjectButton.Click

        If Obj Is Nothing Then Exit Sub

        Using frm As New F_AttachedObjectChooser(False)

            frm.ShowDialog()

            If Not frm.Result Then Exit Sub

            Dim exempt As String = ""
            Dim exemptLT As String = ""
            Dim hasExempt As Boolean = False
            Dim addExempt As Boolean = False

            Dim regionalDictionary As HelperLists.RegionalInfoDictionary = _
                HelperLists.RegionalInfoDictionary.GetList()

            If frm.SelectedType = InvoiceAttachedObjectType.Service Then
                hasExempt = regionalDictionary.GetVatExempts(RegionalizedObjectType.Service, _
                    frm.SelectedService.ID, Obj.LanguageCode, exemptLT, exempt)
            Else
                hasExempt = regionalDictionary.GetVatExempts(RegionalizedObjectType.Goods, _
                    frm.AttachedObjectParentID, Obj.LanguageCode, exemptLT, exempt)
            End If

            If hasExempt Then

                Dim question As String = "Pasirinktam objektui yra priskirta PVM išimtis:"

                If LanguagesEquals(Obj.LanguageCode, LanguageCodeLith, LanguageCodeLith) Then
                    question = AddWithNewLine(question, exemptLT, True)
                Else
                    question = AddWithNewLine(question, "Lietuvių kalba:", True)
                    question = AddWithNewLine(question, exemptLT, True)
                    question = AddWithNewLine(question, "Užsienio kalba:", True)
                    question = AddWithNewLine(question, exempt, True)
                End If

                question = AddWithNewLine(question, "", True)

                question = AddWithNewLine(question, "Pridėti prie sąskaitos faktūros PVM išimčių?", True)

                addExempt = YesOrNo(question)

            End If

            Try

                If frm.SelectedType = InvoiceAttachedObjectType.Service Then

                    Using busy As New StatusBusy
                        Obj.AttachNewObject(frm.SelectedService, regionalDictionary, addExempt)
                    End Using

                Else

                    Dim newAttachedObject As InvoiceAttachedObject
                    newAttachedObject = LoadObject(Of InvoiceAttachedObject)(Nothing, _
                        "NewInvoiceAttachedObject", True, frm.SelectedType, frm.AttachedObjectParentID, _
                        frm.AttachedObjectWarehouseID, Obj.ChronologyValidator.BaseValidator)

                    Using busy As New StatusBusy
                        Obj.AttachNewObject(newAttachedObject, regionalDictionary, addExempt)
                    End Using

                End If

            Catch ex As Exception
                ShowError(ex)
            End Try

        End Using

    End Sub

    Private Sub InvoiceItemsSortedDataGridView_CellBeginEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles InvoiceItemsSortedDataGridView.CellBeginEdit

        If e.RowIndex < 0 Then Exit Sub

        Dim item As InvoiceMadeItem = Nothing
        Try
            item = DirectCast(InvoiceItemsSortedDataGridView.Rows(e.RowIndex).DataBoundItem, InvoiceMadeItem)
        Catch ex As Exception
        End Try
        If item Is Nothing Then Exit Sub

        If (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is IncomeAccountDataGridViewTextBoxColumn _
            AndAlso item.AccountIncomeIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is VatAccountDataGridViewTextBoxColumn _
            AndAlso item.AccountVatIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn7 _
            AndAlso item.AmmountIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn8 _
            AndAlso item.UnitValueIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn10 _
            AndAlso item.SumCorrectionIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is VatRateDataGridViewTextBoxColumn _
            AndAlso item.VatRateIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn13 _
            AndAlso item.SumVatCorrectionIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is IncludeVatInObject _
            AndAlso item.IncludeVatInObjectIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn16 _
            AndAlso item.UnitValueLTLCorrectionIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn18 _
            AndAlso item.SumCorrectionLTLIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn20 _
            AndAlso item.SumVatCorrectionLTLIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is AccountDiscountDataGridViewAccGridComboBoxColumn _
            AndAlso item.AccountDiscountIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn22 _
            AndAlso item.DiscountIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn28 _
            AndAlso item.DiscountVatCorrectionIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn24 _
            AndAlso item.DiscountCorrectionLTLIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn26 _
            AndAlso item.DiscountVatLTLCorrectionIsReadOnly) Then e.Cancel = True

    End Sub

    Private Sub InvoiceItemsSortedDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles InvoiceItemsSortedDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        If InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn30 Then

            Dim attachedObject As InvoiceAttachedObject = Nothing
            Dim item As InvoiceMadeItem = Nothing
            Try
                item = DirectCast(InvoiceItemsSortedDataGridView. _
                    Rows(e.RowIndex).DataBoundItem, InvoiceMadeItem)
                attachedObject = item.AttachedObjectValue
            Catch ex As Exception
            End Try
            If attachedObject Is Nothing Then Exit Sub

            If attachedObject.Type = InvoiceAttachedObjectType.LongTermAssetPurchase Then

                Using frm As New F_LongTermAsset(attachedObject)
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then item.AttachedObjectChanged()
                End Using

            ElseIf attachedObject.Type = InvoiceAttachedObjectType.LongTermAssetSale Then

                Using frm As New F_LongTermAssetOperation(attachedObject)
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then item.AttachedObjectChanged()
                End Using

            ElseIf attachedObject.Type = InvoiceAttachedObjectType.GoodsAcquisition Then

                Using frm As New F_GoodsOperationAcquisition(attachedObject)
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then item.AttachedObjectChanged()
                End Using

            ElseIf attachedObject.Type = InvoiceAttachedObjectType.GoodsConsignmentAdditionalCosts Then

                Using frm As New F_GoodsOperationAdditionalCosts(attachedObject)
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then item.AttachedObjectChanged()
                End Using

            ElseIf attachedObject.Type = InvoiceAttachedObjectType.GoodsConsignmentDiscount Then

                Using frm As New F_GoodsOperationDiscount(attachedObject)
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then item.AttachedObjectChanged()
                End Using

            ElseIf attachedObject.Type = InvoiceAttachedObjectType.GoodsTransfer Then

                Using frm As New F_GoodsOperationTransfer(attachedObject)
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then item.AttachedObjectChanged()
                End Using

            End If

        End If

    End Sub

    Private Sub InvoiceItemsSortedDataGridView_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles InvoiceItemsSortedDataGridView.UserDeletingRow

        If e.Row Is Nothing Then Exit Sub

        Dim item As InvoiceMadeItem = Nothing
        Try
            item = DirectCast(e.Row.DataBoundItem, InvoiceMadeItem)
        Catch ex As Exception
        End Try
        If item Is Nothing Then Exit Sub

        If Not item.AttachedObjectValue Is Nothing AndAlso Not item.AttachedObjectValue. _
            ChronologyValidator.FinancialDataCanChange Then
            MsgBox("Klaida. Eilutės pašalinti neleidžiama:" & vbCrLf _
                & item.AttachedObjectValue.ChronologyValidator.FinancialDataCanChangeExplanation, _
                MsgBoxStyle.Exclamation, "Klaida")
            e.Cancel = True
        End If

    End Sub

    Private Sub RefreshNumberButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshNumberButton.Click

        If Obj Is Nothing OrElse Obj.Serial Is Nothing OrElse _
            String.IsNullOrEmpty(Obj.Serial.Trim) Then Exit Sub

        If Not Obj.IsNew Then
            If Not YesOrNo("DĖMESIO. Jūs redaguojate jau įtrauktą į duomenų bazę dokumentą. " _
                & "Ar tikrai norite suteikti jam naują numerį?") Then Exit Sub
        End If

        Using busy As New StatusBusy
            Try
                Obj.Number = CommandLastDocumentNumber.TheCommand( _
                    DocumentSerialType.Invoice, Obj.Serial.Trim, Obj.Date, _
                    Obj.AddDateToNumberOptionWasUsed) + 1
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Using

    End Sub

    Private Sub CopyInvoiceButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CopyInvoiceButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim info As InvoiceInfo.InvoiceInfo = Nothing
        Try
            Using busy As New StatusBusy
                info = Obj.GetInvoiceInfo(MDIParent1.InstanceGuid.ToString)
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko generuoti InvoiceInfo objekto: " _
                & ex.Message, ex))
            Exit Sub
        End Try

        If info Is Nothing Then
            MsgBox("Klaida. Dėl nežinomų priežasčių nepavyko generuoti InvoiceInfo objekto.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                System.Windows.Forms.Clipboard.SetText(InvoiceInfo.Factory. _
                    ToXmlString(Of InvoiceInfo.InvoiceInfo)(info), TextDataFormat.UnicodeText)
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko serializuoti InvoiceInfo objekto: " _
                & ex.Message, ex))
            Exit Sub
        End Try

        MsgBox("Sąskaita sėkmingai nukopijuota į ClipBoard'ą.", MsgBoxStyle.Information, "Info")

    End Sub

    Private Sub PasteInvoiceButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles PasteInvoiceButton.Click

        Dim clipboardText As String = System.Windows.Forms.Clipboard.GetText(TextDataFormat.UnicodeText)

        If clipboardText Is Nothing OrElse String.IsNullOrEmpty(clipboardText.Trim) Then

            MsgBox("Klaida. ClipBoard'as tuščias, t.y. nebuvo nukopijuota jokia sąskaita.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub

        End If

        Dim info As InvoiceInfo.InvoiceInfo = Nothing
        Try
            Using busy As New StatusBusy
                info = InvoiceInfo.Factory.FromXmlString(Of InvoiceInfo.InvoiceInfo)(clipboardText)
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko atkurti sąskaitos objekto. " _
                & "Teigtina, kad prieš tai į ClipBoard'ą buvo nukopijuota ne sąskaita, " _
                & "o šiaip kažkoks tekstas." & vbCrLf & "Klaidos tekstas: " & ex.Message, ex))
            Exit Sub
        End Try

        If info Is Nothing Then
            MsgBox("Klaida. Dėl nežinomų priežasčių nepavyko atkurti sąskaitos objekto.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then Exit Sub
            If answ = "Taip" Then
                If Not SaveObj() Then Exit Sub
            End If
        End If

        Dim UseExternalID As Boolean = False

        If MDIParent1.InstanceGuid.ToString.Trim <> info.SystemGuid.Trim Then

            Dim answer As String

            If info.ExternalID Is Nothing OrElse String.IsNullOrEmpty(info.ExternalID.Trim) Then
                If Not MyCustomSettings.AlwaysUseExternalIdInvoicesMade Then
                    answer = Ask("Sąskaita yra kopijuojama iš išorinės sistemos. " _
                        & "Ką priskirti išoriniam ID?", New ButtonStructure("Nieko", _
                        "Nepriskirti jokio išorinio ID."), New ButtonStructure( _
                        "ID", "Sąskaitos ID laikyti išoriniu ID."), New ButtonStructure( _
                        "Atšaukti", "Atšaukti kopijavimą."))
                Else
                    answer = "ID"
                End If
            Else
                answer = Ask("Sąskaita yra kopijuojama iš išorinės sistemos. " _
                    & "Ką priskirti išoriniam ID?", New ButtonStructure("Nieko", _
                    "Nepriskirti jokio išorinio ID."), New ButtonStructure( _
                    "ID", "Sąskaitos ID laikyti išoriniu ID."), New ButtonStructure( _
                    "Išorinį ID", "Sąskaitos išorinį ID laikyti išoriniu ID."), _
                    New ButtonStructure("Atšaukti", "Atšaukti kopijavimą."))
            End If

            If answer = "Nieko" Then
                info.SystemGuid = MDIParent1.InstanceGuid.ToString.Trim
            ElseIf answer = "Atšaukti" Then
                Exit Sub
            ElseIf answer = "Išorinį ID" Then
                UseExternalID = True
            End If

        End If

        Dim newObj As InvoiceMade = Nothing
        Dim newPerson As InvoiceInfo.ClientInfo = Nothing
        Try
            Using busy As New StatusBusy
                Dim personList As HelperLists.PersonInfoList = HelperLists.PersonInfoList.GetList
                newObj = InvoiceMade.NewInvoiceMade(info, MDIParent1.InstanceGuid.ToString, _
                    UseExternalID, personList, newPerson)
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko įkrauti kopijuojamos sąskaitos duomenų: " _
                & ex.Message, ex))
            Exit Sub
        End Try

        If newObj Is Nothing Then
            MsgBox("Klaida. Dėl nežinomų priežasčių nepavyko įkrauti kopijuojamos sąskaitos duomenų.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Using bm As New BindingsManager(InvoiceMadeBindingSource, _
            InvoiceItemsSortedBindingSource, Nothing, True, True)
            Obj = newObj
            bm.SetNewDataSource(Obj)
        End Using

        ConfigureButtons()

        If Not Obj.ExternalID Is Nothing AndAlso Not String.IsNullOrEmpty(Obj.ExternalID.Trim) Then

            Dim n As Integer = 0

            Try
                Using busy As New StatusBusy
                    n = CommandDocumentIdByExternalId.TheCommand( _
                        DocumentType.InvoiceMade, Obj.ExternalID)
                End Using
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            If n > 0 Then
                If YesOrNo("DĖMESIO. Sąskaita su tokiu išoriniu ID jau egzistuoja. " _
                    & "Įvesti sąskaitą iš naujo nebus leidžiama." & vbCrLf & vbCrLf _
                    & "Atidaryti egzistuojančią sąskaitą?") Then MDIParent1.LaunchForm( _
                    GetType(F_InvoiceMade), False, False, n, n)
            End If

        End If

        If Not newPerson Is Nothing Then MDIParent1.LaunchForm(GetType(F_Person), _
            False, False, 0, newPerson)

    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then Exit Sub
            If answ = "Taip" Then
                If Not SaveObj() Then Exit Sub
            End If
        End If

        Try
            Using busy As New StatusBusy
                Using bm As New BindingsManager(InvoiceMadeBindingSource, _
                    InvoiceItemsSortedBindingSource, Nothing, True, True)
                    Obj = InvoiceMade.NewInvoiceMade
                    bm.SetNewDataSource(Obj)
                End Using
                ConfigureButtons()
            End Using
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click
        If Obj Is Nothing Then Exit Sub
        MsgBox(Obj.ChronologyValidator.LimitsExplanation, MsgBoxStyle.Information, "")
    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If Obj Is Nothing OrElse Not Obj.ID > 0 Then Exit Sub
        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, Obj.ID, Obj.ID)
    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
       Implements ISupportsPrinting.GetMailDropDownItems

        If EmailDropDown Is Nothing Then
            EmailDropDown = New ToolStripDropDown
            EmailDropDown.Items.Add("Lietuvių klb.", Nothing, AddressOf OnMailClick)
        End If

        Return EmailDropDown

    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems

        If PrintDropDown Is Nothing Then
            PrintDropDown = New ToolStripDropDown
            PrintDropDown.Items.Add("Lietuvių klb.", Nothing, AddressOf OnPrintClick)

        End If

        Return PrintDropDown

    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems

        If PrintPreviewDropDown Is Nothing Then
            PrintPreviewDropDown = New ToolStripDropDown
            PrintPreviewDropDown.Items.Add("Lietuvių klb.", Nothing, AddressOf OnPrintPreviewClick)

        End If

        Return PrintPreviewDropDown

    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick
        If Obj Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(Obj, Convert.ToInt32(IIf(GetSenderText(sender).ToLower.Contains("lietuvių"), 1, 0)))
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, False, Convert.ToInt32(IIf(GetSenderText(sender).ToLower.Contains("lietuvių"), 1, 0)))
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, True, Convert.ToInt32(IIf(GetSenderText(sender).ToLower.Contains("lietuvių"), 1, 0)))
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings.Trim) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.GetAllWarnings & vbCrLf
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

        Using bm As New BindingsManager(InvoiceMadeBindingSource, _
            InvoiceItemsSortedBindingSource, Nothing, True, False)

            Try
                Obj = LoadObject(Of InvoiceMade)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ConfigureButtons()

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub
        Using bm As New BindingsManager(InvoiceMadeBindingSource, _
            InvoiceItemsSortedBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.DocumentSerialInfoList), _
            GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList), _
            GetType(HelperLists.CompanyRegionalInfoList), GetType(Settings.CommonSettings), _
            GetType(AccDataAccessLayer.Security.UserProfile)) Then Return False

        LoadEnumHumanReadableListToComboBox(TypeHumanReadableComboBox, GetType(InvoiceType), False)

        Try

            LoadCurrencyCodeListToComboBox(CurrencyCodeComboBox, False)

            LoadDocumentSerialInfoListToCombo(SerialComboBox, Settings.DocumentSerialType.Invoice, _
                True, False)

            LoadPersonInfoListToGridCombo(PayerAccGridComboBox, True, True, False, False)

            LoadAccountInfoListToGridCombo(AccountPayerAccGridComboBox, True, 1, 2, 3, 4)
            LoadAccountInfoListToGridCombo(IncomeAccountDataGridViewTextBoxColumn, True, 1, 2, 3, 4, 5, 6)
            LoadAccountInfoListToGridCombo(VatAccountDataGridViewTextBoxColumn, True, 1, 2, 3, 4, 5, 6)
            LoadAccountInfoListToGridCombo(AccountDiscountDataGridViewAccGridComboBoxColumn, True, 1, 2, 3, 4, 5, 6)

            LoadLanguageListToComboBox(LanguageNameComboBox, False)

            LoadTaxRateListToCombo(VatRateDataGridViewTextBoxColumn, TaxTarifType.Vat)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        If Obj Is Nothing Then Exit Sub

        CurrencyCodeComboBox.Enabled = Obj.ChronologyValidator.FinancialDataCanChange
        GetCurrencyRatesButton.Enabled = Obj.ChronologyValidator.FinancialDataCanChange
        CurrencyRateAccTextBox.ReadOnly = Not Obj.ChronologyValidator.FinancialDataCanChange
        AccountPayerAccGridComboBox.Enabled = Obj.ChronologyValidator.ParentFinancialDataCanChange
        TypeHumanReadableComboBox.Enabled = Obj.ChronologyValidator.FinancialDataCanChange
        AddAttachedObjectButton.Enabled = Obj.ChronologyValidator.ParentFinancialDataCanChange

        ICancelButton.Enabled = Not Obj.IsNew

        InvoiceItemsSortedDataGridView.AllowUserToAddRows = Obj.ChronologyValidator.ParentFinancialDataCanChange
        InvoiceItemsSortedDataGridView.AllowUserToDeleteRows = Obj.ChronologyValidator.ParentFinancialDataCanChange

        LimitationsButton.Visible = Not String.IsNullOrEmpty(Obj.ChronologyValidator.LimitsExplanation.Trim)

    End Sub

End Class