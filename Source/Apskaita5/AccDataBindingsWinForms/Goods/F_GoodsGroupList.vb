Imports ApskaitaObjects.Goods
Imports AccControlsWinForms

Friend Class F_GoodsGroupList
    Implements ISingleInstanceForm

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of GoodsGroupList)
    Private _ListViewManager As DataListViewEditControlManager(Of GoodsGroup)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_GoodsGroupList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' GoodsGroupList.GetGoodsGroupList()
            _QueryManager.InvokeQuery(Of GoodsGroupList)(Nothing, "GetGoodsGroupList", True, AddressOf OnDataSourceFetched)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

    End Sub

    Private Sub OnDataSourceFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If exceptionHandled Then
            DisableAllControls(Me)
            Exit Sub
        ElseIf result Is Nothing Then
            MsgBox("Klaida. Dėl nežinomų priežasčių nepavyko gauti prekių grupių duomenų.", _
                MsgBoxStyle.Exclamation, "Klaida")
            DisableAllControls(Me)
            Exit Sub
        End If

        Try

            _ListViewManager = New DataListViewEditControlManager(Of GoodsGroup) _
                (GoodsGroupListDataListView, Nothing, AddressOf OnItemsDelete, _
                 AddressOf OnItemAdd, Nothing, DirectCast(result, GoodsGroupList))

            _FormManager = New CslaActionExtenderEditForm(Of GoodsGroupList) _
                (Me, GoodsGroupListBindingSource, DirectCast(result, GoodsGroupList), _
                Nothing, nOkButton, ApplyButton, nCancelButton, Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(GoodsGroupListDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

    End Sub


    Private Sub OnItemsDelete(ByVal items As GoodsGroup())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        For Each item As GoodsGroup In items
            If Not item.IsNew AndAlso item.IsInUse Then
                MsgBox(String.Format("Klaida. Prekių grupei {0} yra priskirtų prekių. Jos pašalinti neleidžiama.", _
                    item.Name), MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If
        Next
        For Each item As GoodsGroup In items
            _FormManager.DataSource.Remove(item)
        Next
    End Sub

    Private Sub OnItemAdd()
        _FormManager.DataSource.AddNew()
    End Sub

End Class