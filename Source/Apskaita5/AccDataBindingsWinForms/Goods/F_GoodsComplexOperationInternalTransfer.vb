Imports ApskaitaObjects.Goods
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists

Friend Class F_GoodsComplexOperationInternalTransfer
    Implements IObjectEditForm, ISupportsPrinting, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.GoodsInfoList), GetType(HelperLists.WarehouseInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of GoodsComplexOperationInternalTransfer)
    Private _ListViewManager As DataListViewEditControlManager(Of GoodsInternalTransferItem)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _DocumentToEdit As GoodsComplexOperationInternalTransfer = Nothing
    Private _GoodsID As Integer = 0


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then
                If _DocumentToEdit Is Nothing OrElse _DocumentToEdit.IsNew Then
                    Return Integer.MinValue
                Else
                    Return _DocumentToEdit.ID
                End If
            End If
            Return _FormManager.DataSource.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(GoodsComplexOperationInternalTransfer)
        End Get
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal goodsID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _GoodsID = goodsID

    End Sub

    Public Sub New(ByVal documentToEdit As GoodsComplexOperationInternalTransfer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _DocumentToEdit = documentToEdit

    End Sub


    Private Sub F_GoodsComplexOperationInternalTransfer_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _DocumentToEdit Is Nothing Then
            Using frm As New F_NewGoodsOperation(Of GoodsComplexOperationInternalTransfer)(_GoodsID)
                frm.ShowDialog()
                _DocumentToEdit = frm.Result
            End Using
        End If

        If _DocumentToEdit Is Nothing Then
            Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        Try

            _FormManager = New CslaActionExtenderEditForm(Of GoodsComplexOperationInternalTransfer) _
                (Me, GoodsComplexOperationInternalTransferBindingSource, _DocumentToEdit, _
                _RequiredCachedLists, nOkButton, ApplyButton, nCancelButton, _
                Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(ItemsDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ConfigureButtons()

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of GoodsInternalTransferItem) _
                (ItemsDataListView, Nothing, AddressOf OnItemsDelete, _
                 Nothing, Nothing, _DocumentToEdit)

            _ListViewManager.AddCancelButton = False
            _ListViewManager.AddButtonHandler("Rodyti apribojimus", _
                "Rodyti apribojimus eilutei.", AddressOf OnItemClicked)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            SetupDefaultControls(Of GoodsComplexOperationInternalTransfer) _
                (Me, GoodsComplexOperationInternalTransferBindingSource, _
                 _DocumentToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub OnItemsDelete(ByVal items As GoodsInternalTransferItem())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.OperationalLimitAcquisition.FinancialDataCanChange _
            OrElse Not _FormManager.DataSource.OperationalLimitAcquisition.ParentFinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}{2}{3}", vbCrLf, _
                _FormManager.DataSource.OperationalLimitAcquisition.FinancialDataCanChangeExplanation, _
                vbCrLf, _FormManager.DataSource.OperationalLimitAcquisition.ParentFinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As GoodsInternalTransferItem In items
            If Not item.ChronologyValidatorAcquisition.FinancialDataCanChange OrElse _
                Not item.ChronologyValidatorTransfer.FinancialDataCanChange Then
                MsgBox(String.Format("Klaida. Eilutės {0} pašalinti neleidžiama:{1}{2}{3}{4}", _
                item.GoodsName, vbCrLf, item.ChronologyValidatorAcquisition.FinancialDataCanChangeExplanation, _
                vbCrLf, item.ChronologyValidatorTransfer.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If
        Next
        For Each item As GoodsInternalTransferItem In items
            _FormManager.DataSource.Items.Remove(item)
        Next
    End Sub

    Private Sub OnItemClicked(ByVal item As GoodsInternalTransferItem)
        If item Is Nothing Then Exit Sub

        Dim limitations As String = item.ChronologyValidatorAcquisition.LimitsExplanation
        limitations = AddWithNewLine(limitations, item.ChronologyValidatorTransfer.LimitsExplanation, False)

        If String.IsNullOrEmpty(limitations.Trim) Then
            MsgBox("Jokie ribojimai šiai eilutei netaikomi.", MsgBoxStyle.Information, "Info")
        Else
            MsgBox("Taikomi ribojimai:" & vbCrLf & limitations.Trim, MsgBoxStyle.Information, "Info")
        End If

    End Sub

    Private Sub AddNewItemsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddNewItemsButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim ids As Integer() = GoodsOperationManager.RequestUserToChooseGoods()

        If ids Is Nothing OrElse ids.Length < 1 Then Exit Sub

        Dim wf As Integer = 0
        If Not _FormManager.DataSource.WarehouseFrom Is Nothing AndAlso Not _FormManager.DataSource.WarehouseFrom.IsEmpty Then
            wf = _FormManager.DataSource.WarehouseFrom.ID
        End If
        Dim wt As Integer = 0
        If Not _FormManager.DataSource.WarehouseTo Is Nothing AndAlso Not _FormManager.DataSource.WarehouseTo.IsEmpty Then
            wt = _FormManager.DataSource.WarehouseTo.ID
        End If

        'GoodsInternalTransferItemList.NewGoodsInternalTransferItemList(ids, wf, wt, _
        '    _FormManager.DataSource.OperationalLimitAcquisition.BaseValidator)
        _QueryManager.InvokeQuery(Of GoodsInternalTransferItemList)(Nothing, _
            "NewGoodsInternalTransferItemList", True, AddressOf OnNewItemsFetched, _
            ids, wf, wt, _FormManager.DataSource.OperationalLimitAcquisition.BaseValidator)

    End Sub

    Private Sub OnNewItemsFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        Try
            _FormManager.DataSource.AddRange(DirectCast(result, GoodsInternalTransferItemList))
        Catch ex As Exception
            ShowError(ex, New Object() {_FormManager.DataSource, result})
        End Try

    End Sub

    Private Sub RefreshCostsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshCostsButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If _FormManager.DataSource.WarehouseFrom Is Nothing OrElse _FormManager.DataSource.WarehouseFrom.IsEmpty Then
            MsgBox("Klaida. Nepasirinktas sandėlis.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        ElseIf _FormManager.DataSource.Items.Count < 1 Then
            MsgBox("Klaida. Nesuformuota nė viena eilutė.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try
            GoodsCostItemList.GetGoodsCostItemList(_FormManager.DataSource.GetCostsParams())
            _QueryManager.InvokeQuery(Of GoodsCostItemList)(Nothing, "GetGoodsCostItemList", True, _
                AddressOf OnCostItemsFetched, New Object() {_FormManager.DataSource.GetCostsParams()})
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Private Sub OnCostItemsFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        Dim warning As String = ""

        Try
            _FormManager.DataSource.RefreshCosts(DirectCast(result, GoodsCostItemList), warning)
        Catch ex As Exception
            ShowError(ex, New Object() {_FormManager.DataSource, result})
            Exit Sub
        End Try

        If Not StringIsNullOrEmpty(warning) Then
            MsgBox(warning, MsgBoxStyle.Exclamation, "Įspėjimas")
        End If

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If _FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.JournalEntryID > 0 Then Exit Sub
        OpenJournalEntryEditForm(_QueryManager, _FormManager.DataSource.JournalEntryID)
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
            PrintObject(_FormManager.DataSource, False, 0, "VidinisPrekiuJudejimas", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "VidinisPrekiuJudejimas", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Public Function ChronologicContent() As String _
        Implements ISupportsChronologicValidator.ChronologicContent
        If _FormManager.DataSource Is Nothing Then Return ""
        Return _FormManager.DataSource.OperationalLimitAcquisition.LimitsExplanation _
            & vbCrLf & vbCrLf & _FormManager.DataSource.OperationalLimitTransfer.LimitsExplanation
    End Function

    Public Function HasChronologicContent() As Boolean _
        Implements ISupportsChronologicValidator.HasChronologicContent

        Return Not _FormManager.DataSource Is Nothing AndAlso _
            (Not StringIsNullOrEmpty(_FormManager.DataSource.OperationalLimitAcquisition.LimitsExplanation) _
             OrElse Not StringIsNullOrEmpty(_FormManager.DataSource.OperationalLimitTransfer.LimitsExplanation))

    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
    End Sub

    Private Sub ConfigureButtons()

        WarehouseFromAccGridComboBox.Enabled = Not _FormManager.DataSource Is Nothing AndAlso _
            Not _FormManager.DataSource.WarehouseFromIsReadOnly
        WarehouseToAccGridComboBox.Enabled = Not _FormManager.DataSource Is Nothing AndAlso _
            Not _FormManager.DataSource.WarehouseToIsReadOnly

        AddNewItemsButton.Enabled = Not _FormManager.DataSource Is Nothing
        RefreshCostsButton.Enabled = Not _FormManager.DataSource Is Nothing

        nCancelButton.Enabled = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew
        nOkButton.Enabled = Not _FormManager.DataSource Is Nothing
        ApplyButton.Enabled = Not _FormManager.DataSource Is Nothing

        EditedBaner.Visible = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew

    End Sub

End Class