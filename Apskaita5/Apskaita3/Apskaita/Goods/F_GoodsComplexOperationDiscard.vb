Imports ApskaitaObjects.Goods
Public Class F_GoodsComplexOperationDiscard
    Implements IObjectEditForm, ISupportsPrinting

    Private Obj As GoodsComplexOperationDiscard = Nothing
    Private Loading As Boolean = True
    Private OperationID As Integer = 0


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(GoodsComplexOperationDiscard)
        End Get
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nOperationID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        OperationID = nOperationID

    End Sub


    Private Sub F_GoodsComplexOperationDiscard_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.GoodsInfoList), _
            GetType(HelperLists.WarehouseInfoList)) Then Exit Sub

    End Sub

    Private Sub F_GoodsComplexOperationDiscard_FormClosing(ByVal sender As Object, _
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

        If Not Obj Is Nothing AndAlso Obj.IsDirty Then CancelObj()

        GetFormLayout(Me)
        GetDataGridViewLayOut(ItemsDataGridView)

    End Sub

    Private Sub F_GoodsComplexOperationDiscard_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not GoodsComplexOperationDiscard.CanGetObject AndAlso OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not GoodsComplexOperationDiscard.CanAddObject AndAlso Not OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka prekių duomenims tvarkyti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        If OperationID > 0 Then

            Try
                Obj = LoadObject(Of GoodsComplexOperationDiscard)(Nothing, _
                    "GetGoodsComplexOperationDiscard", True, OperationID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        Else

            Try
                Obj = GoodsComplexOperationDiscard.NewGoodsComplexOperationDiscard
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        End If

        GoodsComplexOperationDiscardBindingSource.DataSource = Obj

        AddDGVColumnSelector(ItemsDataGridView)

        SetDataGridViewLayOut(ItemsDataGridView)
        SetFormLayout(Me)

        ConfigureLimitationButton(Obj)
        ConfigureButtons()

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
       ByVal e As System.EventArgs) Handles nOkButton.Click
        If Obj Is Nothing Then Exit Sub
        If SaveObj() Then Me.Close()
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        If Obj Is Nothing Then Exit Sub
        If SaveObj() Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nCancelButton.Click
        If Obj Is Nothing Then Exit Sub
        CancelObj()
    End Sub


    Private Sub AddNewItemButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddNewItemButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim newGoodsInfo As HelperLists.GoodsInfo = Nothing
        Try
            newGoodsInfo = DirectCast(GoodsInfoListAccGridComboBox.SelectedValue, HelperLists.GoodsInfo)
        Catch ex As Exception
        End Try

        If newGoodsInfo Is Nothing OrElse Not newGoodsInfo.ID > 0 Then
            MsgBox("Klaida. Nepasirinkta prekė.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        ElseIf Obj.Items.ContainsGood(newGoodsInfo.ID) Then
            MsgBox("Klaida. Tokia prekė jau yra įtraukta.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try
            Dim newItem As GoodsDiscardItem = LoadObject(Of GoodsDiscardItem) _
                (Nothing, "NewGoodsDiscardItem", True, newGoodsInfo.ID, Obj.OperationalLimit.BaseValidator)
            Obj.AddNewGoodsItem(newItem)
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub RefreshCostsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshCostsButton.Click

        If Obj Is Nothing Then Exit Sub

        If Obj.Warehouse Is Nothing OrElse Not Obj.Warehouse.ID > 0 Then
            MsgBox("Klaida. Nepasirinktas sandėlis.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        ElseIf Obj.Items.Count < 1 Then
            MsgBox("Klaida. Nesuformuota nė viena eilutė.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try
            Dim CostItemList As GoodsCostItemList = LoadObject(Of GoodsCostItemList) _
                (Nothing, "GetGoodsCostItemList", True, New Object() {Obj.GetCostsParams()})
            Obj.ReloadCostInfo(CostItemList)
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click

        If Obj Is Nothing Then Exit Sub
        MsgBox(Obj.OperationalLimit.LimitsExplanation, MsgBoxStyle.Information, "")

    End Sub

    Private Sub ItemsDataGridView_CellBeginEdit(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles ItemsDataGridView.CellBeginEdit

        Dim curItem As GoodsDiscardItem = Nothing
        Try
            curItem = DirectCast(ItemsDataGridView.Rows(e.RowIndex).DataBoundItem, GoodsDiscardItem)
        Catch ex As Exception
        End Try

        If curItem Is Nothing OrElse (ItemsDataGridView.Columns(e.ColumnIndex) Is _
            DataGridViewTextBoxColumn7 AndAlso Not curItem.FinancialDataCanChange) OrElse _
            (ItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn10 AndAlso _
            (Not curItem.RequiresJournalEntry OrElse Not curItem.FinancialDataCanChange)) Then
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub ItemsDataGridView_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles ItemsDataGridView.UserDeletingRow

        Dim curItem As GoodsDiscardItem = Nothing
        Try
            curItem = DirectCast(e.Row.DataBoundItem, GoodsDiscardItem)
        Catch ex As Exception
        End Try

        If curItem Is Nothing Then
            MsgBox("Klaida. Neidentifikuota norima ištrinti eilutė.", MsgBoxStyle.Exclamation, "Klaida")
            e.Cancel = True
            Exit Sub
        End If

        If Not curItem.IsNew AndAlso Not Obj.OperationalLimit.BaseValidator.FinancialDataCanChange Then
            MsgBox("Klaida. Eilučių duomenų pašalinti negalima:" & vbCrLf _
                & Obj.OperationalLimit.BaseValidator.FinancialDataCanChangeExplanation, _
                MsgBoxStyle.Exclamation, "Klaida")
            e.Cancel = True
            Exit Sub
        ElseIf Not curItem.IsNew AndAlso Not curItem.FinancialDataCanChange Then
            MsgBox("Klaida. Šios eilutės duomenų pašalinti negalima:" & vbCrLf _
                & curItem.ExplainFinancialLimitations, MsgBoxStyle.Exclamation, "Klaida")
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub ItemsDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles ItemsDataGridView.CellDoubleClick

        If ItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn7 OrElse _
            ItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn10 OrElse _
            ItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn11 Then Exit Sub

        Dim curItem As GoodsDiscardItem = Nothing
        Try
            curItem = DirectCast(ItemsDataGridView.Rows(e.RowIndex).DataBoundItem, GoodsDiscardItem)
        Catch ex As Exception
        End Try

        If curItem Is Nothing Then Exit Sub

        Dim limitations As String = curItem.ExplainAllLimitations

        If String.IsNullOrEmpty(limitations.Trim) Then
            MsgBox("Jokie ribojimai šiai eilutei netaikomi.", MsgBoxStyle.Information, "Info")
        Else
            MsgBox("Taikomi ribojimai:" & vbCrLf & limitations.Trim, MsgBoxStyle.Information, "Info")
        End If

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If Obj Is Nothing OrElse Not Obj.JournalEntryID > 0 Then Exit Sub
        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, _
            Obj.JournalEntryID, Obj.JournalEntryID)
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


    Private Function SaveObj() As Boolean

        If Obj Is Nothing OrElse Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings.Trim) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf & Obj.GetAllWarnings & vbCrLf
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

        Using bm As New BindingsManager(GoodsComplexOperationDiscardBindingSource, _
            ItemsBindingSource, Nothing, True, False)

            Try
                Obj = LoadObject(Of GoodsComplexOperationDiscard)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Obj.IsNew Then Exit Sub
        Using bm As New BindingsManager(GoodsComplexOperationDiscardBindingSource, _
            ItemsBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.GoodsInfoList), _
            GetType(HelperLists.WarehouseInfoList)) Then Return False

        Try

            LoadGoodsInfoListToGridCombo(GoodsInfoListAccGridComboBox, True, Documents.TradedItemType.All)
            LoadWarehouseInfoListToGridCombo(WarehouseAccGridComboBox, False)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn10, True, 6)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        WarehouseAccGridComboBox.Enabled = Not Obj Is Nothing AndAlso _
            Obj.OperationalLimit.FinancialDataCanChange

        AddNewItemButton.Enabled = Not Obj Is Nothing
        RefreshCostsButton.Enabled = Not Obj Is Nothing

        nCancelButton.Enabled = Not Obj Is Nothing AndAlso Not Obj.IsNew
        nOkButton.Enabled = Not Obj Is Nothing
        ApplyButton.Enabled = Not Obj Is Nothing

        EditedBaner.Visible = Not Obj Is Nothing AndAlso Not Obj.IsNew

    End Sub

    Private Sub ConfigureLimitationButton(ByVal asset As GoodsComplexOperationDiscard)

        If Not asset.OperationalLimit.FinancialDataCanChange OrElse _
            asset.OperationalLimit.MaxDateApplicable OrElse _
            asset.OperationalLimit.MinDateApplicable Then
            LimitationsButton.Visible = True
            LimitationsButton.Image = My.Resources.Action_lock_icon_32p
        Else
            LimitationsButton.Visible = False
        End If

    End Sub

End Class