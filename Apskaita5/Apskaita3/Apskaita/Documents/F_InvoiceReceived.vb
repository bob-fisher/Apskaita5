Imports ApskaitaObjects.Documents
Imports ApskaitaObjects.HelperLists

Public Class F_InvoiceReceived
    Implements IObjectEditForm

    Private Obj As InvoiceReceived
    Private _InvoiceID As Integer = -1
    Private Loading As Boolean = True
    Private _CopyInvoice As Boolean = False


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
            Return GetType(InvoiceReceived)
        End Get
    End Property


    Public Sub New(ByVal nInvoiceID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _InvoiceID = nInvoiceID

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


    End Sub

    Public Sub New(ByVal nInvoiceID As Integer, ByVal nCopyInvoice As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _InvoiceID = nInvoiceID
        _CopyInvoice = nCopyInvoice

    End Sub



    Private Sub F_InvoiceReceived_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList), _
            GetType(HelperLists.AccountInfoList), GetType(Settings.CommonSettings), _
            GetType(HelperLists.RegionalInfoDictionary)) Then Exit Sub

    End Sub

    Private Sub F_InvoiceReceived_FormClosing(ByVal sender As Object, _
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

    Private Sub F_InvoiceReceived_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _InvoiceID > 0 AndAlso Not Documents.InvoiceReceived.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not _InvoiceID > 0 AndAlso Not Documents.InvoiceReceived.CanAddObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka naujam dokumentui įvesti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        If _InvoiceID > 0 Then

            Try
                Obj = LoadObject(Of InvoiceReceived)(Nothing, "GetInvoiceReceived", _
                    True, _InvoiceID)
                If _CopyInvoice Then Obj = Obj.GetInvoiceCopy
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        Else

            Obj = InvoiceReceived.NewInvoiceReceived

        End If

        InvoiceReceivedBindingSource.DataSource = Obj

        AddDGVColumnSelector(InvoiceItemsSortedDataGridView)

        SetDataGridViewLayOut(InvoiceItemsSortedDataGridView)
        SetFormLayout(Me)

        If Not Obj.IsNew AndAlso Not Documents.InvoiceReceived.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            CopyInvoiceButton.Enabled = True
            InvoiceItemsSortedDataGridView.Enabled = True
            InvoiceItemsSortedDataGridView.ReadOnly = True
            Exit Sub
        End If

        ConfigureButtons()
        ActualDateDateTimePicker.Enabled = Obj.ActualDateIsApplicable

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
        If Not Obj.IsNew AndAlso Not InvoiceReceived.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            CopyInvoiceButton.Enabled = True
            InvoiceItemsSortedDataGridView.Enabled = True
            InvoiceItemsSortedDataGridView.ReadOnly = True
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

        Using frm As New F_AttachedObjectChooser(True)

            frm.ShowDialog()
            If Not frm.Result Then Exit Sub

            Dim regionalizedDictionary As RegionalInfoDictionary = RegionalInfoDictionary.GetList()

            Try
                If frm.SelectedType = InvoiceAttachedObjectType.Service Then

                    Using busy As New StatusBusy
                        Obj.AttachNewObject(frm.SelectedService, regionalizedDictionary)
                    End Using

                Else

                    Dim newAttachedObject As InvoiceAttachedObject
                    newAttachedObject = LoadObject(Of InvoiceAttachedObject)(Nothing, _
                        "NewInvoiceAttachedObject", True, frm.SelectedType, frm.AttachedObjectParentID, _
                        frm.AttachedObjectWarehouseID, Obj.ChronologyValidator.BaseValidator)

                    Using busy As New StatusBusy
                        Obj.AttachNewObject(newAttachedObject, regionalizedDictionary)
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

        Dim item As InvoiceReceivedItem = Nothing
        Try
            item = DirectCast(InvoiceItemsSortedDataGridView.Rows(e.RowIndex).DataBoundItem, InvoiceReceivedItem)
        Catch ex As Exception
        End Try
        If item Is Nothing Then Exit Sub

        If (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is AccountCostsDataGridViewTextBoxColumn AndAlso _
            item.AccountCostsIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is AccountVatDataGridViewTextBoxColumn AndAlso _
            item.AccountVatIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn6 AndAlso _
            item.AmmountIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn7 AndAlso _
            item.UnitValueIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn9 AndAlso _
            item.SumCorrectionIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is VatRateDataGridViewTextBoxColumn AndAlso _
            item.VatRateIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn12 AndAlso _
            item.SumVatCorrectionIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is IncludeVatInObject AndAlso _
            item.IncludeVatInObjectIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn15 AndAlso _
            item.UnitValueLTLCorrectionIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn17 AndAlso _
            item.SumLTLCorrectionIsReadOnly) OrElse _
            (InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn19 AndAlso _
            item.SumVatLTLCorrectionIsReadOnly) Then e.Cancel = True

    End Sub

    Private Sub InvoiceItemsSortedDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles InvoiceItemsSortedDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        If InvoiceItemsSortedDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn21 Then

            Dim attachedObject As InvoiceAttachedObject = Nothing
            Dim item As InvoiceReceivedItem = Nothing
            Try
                item = DirectCast(InvoiceItemsSortedDataGridView. _
                    Rows(e.RowIndex).DataBoundItem, InvoiceReceivedItem)
                attachedObject = item.AttachedObjectValue
            Catch ex As Exception
            End Try
            If attachedObject Is Nothing Then Exit Sub

            If attachedObject.Type = InvoiceAttachedObjectType.LongTermAssetPurchase Then

                Using frm As New F_LongTermAsset(attachedObject)
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then item.AttachedObjectChanged()
                End Using

            ElseIf attachedObject.Type = InvoiceAttachedObjectType.LongTermAssetSale OrElse _
                attachedObject.Type = InvoiceAttachedObjectType.LongTermAssetAcquisitionValueChange Then

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

        Dim item As InvoiceReceivedItem = Nothing
        Try
            item = DirectCast(e.Row.DataBoundItem, InvoiceReceivedItem)
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
                If Not MyCustomSettings.AlwaysUseExternalIdInvoicesReceived Then
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

        Dim newObj As InvoiceReceived = Nothing
        Dim newPerson As InvoiceInfo.ClientInfo = Nothing
        Try
            Using busy As New StatusBusy
                Dim personList As HelperLists.PersonInfoList = HelperLists.PersonInfoList.GetList
                newObj = InvoiceReceived.NewInvoiceReceived(info, MDIParent1.InstanceGuid.ToString, _
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

        Using bm As New BindingsManager(InvoiceReceivedBindingSource, _
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
                        DocumentType.InvoiceReceived, Obj.ExternalID)
                End Using
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            If n > 0 Then
                If YesOrNo("DĖMESIO. Sąskaita su tokiu išoriniu ID jau egzistuoja. " _
                    & "Įvesti sąskaitą iš naujo nebus leidžiama." & vbCrLf & vbCrLf _
                    & "Atidaryti egzistuojančią sąskaitą?") Then MDIParent1.LaunchForm( _
                    GetType(F_InvoiceReceived), False, False, n, n)
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
                Using bm As New BindingsManager(InvoiceReceivedBindingSource, _
                    InvoiceItemsSortedBindingSource, Nothing, True, True)
                    Obj = InvoiceReceived.NewInvoiceReceived
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

    Private Sub ActualDateIsApplicableCheckBox_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ActualDateIsApplicableCheckBox.CheckedChanged
        ActualDateDateTimePicker.Enabled = ActualDateIsApplicableCheckBox.Checked
    End Sub

    Private Sub CalculateIndirectVatButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CalculateIndirectVatButton.Click

        If Obj Is Nothing Then Exit Sub

        Try
            Obj.CalculateIndirectVat()
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub


    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim uniqueInfo As InvoiceReceivedNumberUnique = Nothing

        If MyCustomSettings.CheckInvoiceReceivedNumber Then
            Try
                uniqueInfo = LoadObject(Of InvoiceReceivedNumberUnique)(Nothing, _
                    "GetInvoiceReceivedNumberUnique", False, Obj, _
                    MyCustomSettings.CheckInvoiceReceivedNumberWithDate, _
                    MyCustomSettings.CheckInvoiceReceivedNumberWithSupplier)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings.Trim) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf & Obj.GetAllWarnings & vbCrLf
            If Not uniqueInfo Is Nothing AndAlso Not uniqueInfo.IsUnique Then _
                Question = Question & uniqueInfo.ToString & vbCrLf
        ElseIf Not uniqueInfo Is Nothing AndAlso Not uniqueInfo.IsUnique Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf & uniqueInfo.ToString & vbCrLf
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

        Using bm As New BindingsManager(InvoiceReceivedBindingSource, _
            InvoiceItemsSortedBindingSource, Nothing, True, False)

            Try
                Obj = LoadObject(Of InvoiceReceived)(Obj, "Save", False)
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
        Using bm As New BindingsManager(InvoiceReceivedBindingSource, _
            InvoiceItemsSortedBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(Settings.CommonSettings), _
            GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList), _
            GetType(HelperLists.RegionalInfoDictionary)) Then Return False

        LoadEnumHumanReadableListToComboBox(TypeHumanReadableComboBox, GetType(InvoiceType), False)

        Try

            LoadCurrencyCodeListToComboBox(CurrencyCodeComboBox, False)

            LoadPersonInfoListToGridCombo(SupplierAccGridComboBox, True, False, True, False)

            LoadAccountInfoListToGridCombo(AccountSupplierAccGridComboBox, True, 1, 2, 3, 4)
            LoadAccountInfoListToGridCombo(AccountCostsDataGridViewTextBoxColumn, True, 1, 2, 3, 4, 5, 6)
            LoadAccountInfoListToGridCombo(AccountVatDataGridViewTextBoxColumn, True, 1, 2, 3, 4, 6)
            LoadAccountInfoListToGridCombo(IndirectVatAccountAccGridComboBox, True, 4)
            LoadAccountInfoListToGridCombo(IndirectVatCostsAccountAccGridComboBox, True, 2, 6)

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

        CurrencyCodeComboBox.Enabled = Obj.ChronologyValidator.FinancialDataCanChange AndAlso _
            Obj.ChronologyValidator.ParentFinancialDataCanChange
        GetCurrencyRatesButton.Enabled = Obj.ChronologyValidator.FinancialDataCanChange AndAlso _
            Obj.ChronologyValidator.ParentFinancialDataCanChange
        CurrencyRateAccTextBox.ReadOnly = Not Obj.ChronologyValidator.FinancialDataCanChange _
            OrElse Not Obj.ChronologyValidator.ParentFinancialDataCanChange

        AccountSupplierAccGridComboBox.Enabled = Obj.ChronologyValidator.ParentFinancialDataCanChange
        AddAttachedObjectButton.Enabled = Obj.ChronologyValidator.ParentFinancialDataCanChange
        IndirectVatAccountAccGridComboBox.Enabled = Obj.ChronologyValidator.ParentFinancialDataCanChange
        IndirectVatCostsAccountAccGridComboBox.Enabled = Obj.ChronologyValidator.ParentFinancialDataCanChange
        IndirectVatSumAccTextBox.ReadOnly = Not Obj.ChronologyValidator.ParentFinancialDataCanChange

        ICancelButton.Enabled = Not Obj.IsNew

        InvoiceItemsSortedDataGridView.AllowUserToAddRows = Obj.ChronologyValidator.ParentFinancialDataCanChange
        InvoiceItemsSortedDataGridView.AllowUserToDeleteRows = Obj.ChronologyValidator.ParentFinancialDataCanChange

        LimitationsButton.Visible = Not String.IsNullOrEmpty(Obj.ChronologyValidator.LimitsExplanation.Trim)

    End Sub

End Class