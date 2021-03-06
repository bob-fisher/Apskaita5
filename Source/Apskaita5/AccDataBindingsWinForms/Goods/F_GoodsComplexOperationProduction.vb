Imports ApskaitaObjects.Goods
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists

Friend Class F_GoodsComplexOperationProduction
    Implements IObjectEditForm, ISupportsPrinting, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.GoodsInfoList), GetType(HelperLists.WarehouseInfoList), _
         GetType(HelperLists.AccountInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of GoodsComplexOperationProduction)
    Private _ComponentListViewManager As DataListViewEditControlManager(Of GoodsComponentItem)
    Private _CostsListViewManager As DataListViewEditControlManager(Of GoodsProductionCostItem)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _DocumentToEdit As GoodsComplexOperationProduction = Nothing
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
            Return GetType(GoodsComplexOperationProduction)
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

    Public Sub New(ByVal documentToEdit As GoodsComplexOperationProduction)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _DocumentToEdit = documentToEdit

    End Sub


    Private Sub F_GoodsComplexOperationProduction_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _DocumentToEdit Is Nothing Then
            Using frm As New F_NewGoodsProductionOperation(_GoodsID)
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

            _FormManager = New CslaActionExtenderEditForm(Of GoodsComplexOperationProduction) _
                (Me, GoodsComplexOperationProductionBindingSource, _DocumentToEdit, _
                _RequiredCachedLists, nOkButton, ApplyButton, nCancelButton, _
                Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(ComponentItemsDataListView, CostsItemsDataListView)

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

            _ComponentListViewManager = New DataListViewEditControlManager(Of GoodsComponentItem) _
                (ComponentItemsDataListView, Nothing, AddressOf OnComponentItemsDelete, _
                 Nothing, Nothing, _DocumentToEdit)

            _CostsListViewManager = New DataListViewEditControlManager(Of GoodsProductionCostItem) _
                (CostsItemsDataListView, Nothing, AddressOf OnCostsItemsDelete, _
                 AddressOf OnCostsItemAdd, Nothing, _DocumentToEdit)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            SetupDefaultControls(Of GoodsComplexOperationProduction)(Me, _
                GoodsComplexOperationProductionBindingSource, _DocumentToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub OnComponentItemsDelete(ByVal items As GoodsComponentItem())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidatorAcquisition.FinancialDataCanChange _
            OrElse Not _FormManager.DataSource.ChronologyValidatorDiscard.BaseValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}{2}{3}", vbCrLf, _
                _FormManager.DataSource.ChronologyValidatorAcquisition.FinancialDataCanChangeExplanation, _
                vbCrLf, _FormManager.DataSource.ChronologyValidatorDiscard.BaseValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As GoodsComponentItem In items
            If Not item.ChronologyValidator.FinancialDataCanChange Then
                MsgBox(String.Format("Klaida. Eilutės {0} pašalinti neleidžiama:{1}{2}", _
                item.GoodsName, vbCrLf, item.ChronologyValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If
        Next
        For Each item As GoodsComponentItem In items
            _FormManager.DataSource.ComponentItems.Remove(item)
        Next
    End Sub

    Private Sub OnCostsItemAdd()
        If Not _FormManager.DataSource.ChronologyValidatorAcquisition.FinancialDataCanChange _
            OrElse Not _FormManager.DataSource.ChronologyValidatorDiscard.BaseValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pridėti neleidžiama:{0}{1}{2}{3}", vbCrLf, _
                _FormManager.DataSource.ChronologyValidatorAcquisition.FinancialDataCanChangeExplanation, _
                vbCrLf, _FormManager.DataSource.ChronologyValidatorDiscard.BaseValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        _FormManager.DataSource.CostsItems.AddNew()
    End Sub

    Private Sub OnCostsItemsDelete(ByVal items As GoodsProductionCostItem())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidatorAcquisition.FinancialDataCanChange _
            OrElse Not _FormManager.DataSource.ChronologyValidatorDiscard.BaseValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}{2}{3}", vbCrLf, _
                _FormManager.DataSource.ChronologyValidatorAcquisition.FinancialDataCanChangeExplanation, _
                vbCrLf, _FormManager.DataSource.ChronologyValidatorDiscard.BaseValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As GoodsProductionCostItem In items
            _FormManager.DataSource.CostsItems.Remove(item)
        Next
    End Sub

    Private Sub AddNewItemsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddNewItemsButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim ids As Integer() = GoodsOperationManager.RequestUserToChooseGoods()

        If ids Is Nothing OrElse ids.Length < 1 Then Exit Sub

        Dim wd As Integer = 0
        If Not _FormManager.DataSource.WarehouseForComponents Is Nothing AndAlso Not _FormManager.DataSource.WarehouseForComponents.IsEmpty Then
            wd = _FormManager.DataSource.WarehouseForComponents.ID
        End If

        'GoodsComponentItemList.NewGoodsComponentItemList(ids, wd, _FormManager.DataSource.ChronologyValidatorDiscard.BaseValidator)
        _QueryManager.InvokeQuery(Of GoodsComponentItemList)(Nothing, "NewGoodsComponentItemList", True, _
            AddressOf OnNewItemsFetched, ids, wd, _FormManager.DataSource.ChronologyValidatorDiscard.BaseValidator)

    End Sub

    Private Sub OnNewItemsFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        Try
            _FormManager.DataSource.AddRange(DirectCast(result, GoodsComponentItemList))
        Catch ex As Exception
            ShowError(ex, New Object() {_FormManager.DataSource, result})
        End Try

    End Sub

    Private Sub RefreshCostsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshCostsButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Try
            'GoodsCostItemList.GetGoodsCostItemList(_FormManager.DataSource.GetCostsParams())
            _QueryManager.InvokeQuery(Of GoodsCostItemList)(Nothing, "GetGoodsCostItemList", True, _
                AddressOf OnCostItemsFetched, New Object() {_FormManager.DataSource.GetCostsParams()})
        Catch ex As Exception
            ShowError(ex, Nothing)
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

    Private Sub RecalculateForProductionAmountButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RecalculateForProductionAmountButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Try
            _FormManager.DataSource.RecalculateForProductionAmount()
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

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
            PrintObject(_FormManager.DataSource, False, 0, "GamybosAktas", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "GamybosAktas", Me, "")
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
        Return _FormManager.DataSource.ChronologyValidatorAcquisition.LimitsExplanation _
            & vbCrLf & vbCrLf & _FormManager.DataSource.ChronologyValidatorDiscard.LimitsExplanation
    End Function

    Public Function HasChronologicContent() As Boolean _
        Implements ISupportsChronologicValidator.HasChronologicContent

        Return Not _FormManager.DataSource Is Nothing AndAlso _
            (Not StringIsNullOrEmpty(_FormManager.DataSource.ChronologyValidatorAcquisition.LimitsExplanation) _
             OrElse Not StringIsNullOrEmpty(_FormManager.DataSource.ChronologyValidatorDiscard.LimitsExplanation))

    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
    End Sub

    Private Sub ConfigureButtons()

        If _FormManager.DataSource Is Nothing Then Exit Sub

        WarehouseForComponentsAccGridComboBox.Enabled = Not _FormManager.DataSource Is Nothing AndAlso _
            Not _FormManager.DataSource.WarehouseForComponentsIsReadOnly
        WarehouseForProductionAccGridComboBox.Enabled = Not _FormManager.DataSource Is Nothing AndAlso _
            Not _FormManager.DataSource.WarehouseForProductionIsReadOnly
        AmountAccTextBox.ReadOnly = _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.AmountIsReadOnly

        _CostsListViewManager.IsReadOnly = (_FormManager.DataSource Is Nothing OrElse _
            Not _FormManager.DataSource.ChronologyValidatorDiscard.FinancialDataCanChange)

        nCancelButton.Enabled = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew
        nOkButton.Enabled = Not _FormManager.DataSource Is Nothing
        ApplyButton.Enabled = Not _FormManager.DataSource Is Nothing

        EditedBaner.Visible = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew

    End Sub

End Class