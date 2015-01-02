Imports ApskaitaObjects.Goods
Public Class F_GoodsComplexOperationInventorization
    Implements IObjectEditForm, ISupportsPrinting

    Private Obj As GoodsComplexOperationInventorization = Nothing
    Private Loading As Boolean = True
    Private OperationID As Integer = 0
    Private WarehouseID As Integer = 0
    Private OperationDate As Date = Today


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(GoodsComplexOperationInventorization)
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

    Public Sub New(ByVal nWarehouseID As Integer, ByVal nOperationDate As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        WarehouseID = nWarehouseID
        OperationDate = nOperationDate

    End Sub


    Private Sub F_GoodsComplexOperationInventorization_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_GoodsComplexOperationInventorization_FormClosing(ByVal sender As Object, _
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

    Private Sub F_GoodsComplexOperationInventorization_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not GoodsComplexOperationInventorization.CanGetObject AndAlso OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not GoodsComplexOperationInventorization.CanAddObject AndAlso Not OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka prekių duomenims tvarkyti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        If OperationID > 0 Then

            Try
                Obj = LoadObject(Of GoodsComplexOperationInventorization)(Nothing, _
                    "GetGoodsComplexOperationInventorization", True, OperationID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        Else

            Try
                Obj = LoadObject(Of GoodsComplexOperationInventorization)(Nothing, _
                    "NewGoodsComplexOperationInventorization", True, OperationDate, WarehouseID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        End If

        GoodsComplexOperationInventorizationBindingSource.DataSource = Obj

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


    Private Sub ItemsDataGridView_CellBeginEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles ItemsDataGridView.CellBeginEdit

        If Obj Is Nothing OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse _
            (Not ItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn17 AndAlso _
            Not ItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn20) Then Exit Sub

        Dim currentItem As GoodsInventorizationItem = Nothing
        Try
            currentItem = DirectCast(ItemsDataGridView.Rows(e.RowIndex).DataBoundItem, GoodsInventorizationItem)
        Catch ex As Exception
        End Try

        If currentItem Is Nothing OrElse (ItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn17 _
            AndAlso Not currentItem.OperationLimitations.FinancialDataCanChange) OrElse _
            (ItemsDataGridView.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn20 _
            AndAlso Not Obj.OperationalLimit.BaseValidator.FinancialDataCanChange) Then
            e.Cancel = True
        End If

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click

        If Obj Is Nothing Then Exit Sub
        MsgBox(Obj.OperationalLimit.LimitsExplanation, MsgBoxStyle.Information, "")

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

        Using bm As New BindingsManager(GoodsComplexOperationInventorizationBindingSource, _
            ItemsBindingSource, Nothing, True, False)

            Try
                Obj = LoadObject(Of GoodsComplexOperationInventorization)(Obj, "Save", False)
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
        Using bm As New BindingsManager(GoodsComplexOperationInventorizationBindingSource, _
            ItemsBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn20, False)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        DataGridViewTextBoxColumn17.ReadOnly = Obj Is Nothing OrElse _
            Not Obj.OperationalLimit.FinancialDataCanChange OrElse _
            Not Obj.OperationalLimit.BaseValidator.FinancialDataCanChange

        DataGridViewTextBoxColumn20.ReadOnly = Obj Is Nothing OrElse _
            Not Obj.OperationalLimit.BaseValidator.FinancialDataCanChange

        nCancelButton.Enabled = Not Obj Is Nothing AndAlso Not Obj.IsNew
        nOkButton.Enabled = Not Obj Is Nothing
        ApplyButton.Enabled = Not Obj Is Nothing

        EditedBaner.Visible = Not Obj Is Nothing AndAlso Not Obj.IsNew

    End Sub

    Private Sub ConfigureLimitationButton(ByVal asset As GoodsComplexOperationInventorization)
        LimitationsButton.Visible = Not String.IsNullOrEmpty(asset.OperationalLimit.LimitsExplanation.Trim)
    End Sub

End Class