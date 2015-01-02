Imports ApskaitaObjects.Workers
Imports ApskaitaObjects.ActiveReports
Public Class F_WorkerInfoCard
    Implements ISupportsPrinting

    Private Loading As Boolean = True
    Private Obj As WorkerWageInfoReport


    Private Sub F_WorkerInfoCard_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList)) Then Exit Sub

    End Sub

    Private Sub F_WorkerInfoCard_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetFormLayout(Me)
    End Sub

    Private Sub F_WorkerInfoCard_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not WorkerWageInfoReport.CanGetObject Then
            MsgBox("Klaida. Vartotojo teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        SetFormLayout(Me)

    End Sub

    Private Sub RefreshLabourContractsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshLabourContractsButton.Click

        Dim CurrentWorker As HelperLists.PersonInfo = Nothing
        Try
            CurrentWorker = DirectCast(WorkerAccGridComboBox.SelectedValue, HelperLists.PersonInfo)
        Catch ex As Exception
        End Try
        If CurrentWorker Is Nothing OrElse not CurrentWorker.ID>0  Then
            MsgBox("Klaida. Nepasirinktas darbuotojas.")
            Exit Sub
        End If

        Dim LCL As ShortLabourContractList
        Try
            LCL = LoadObject(Of ShortLabourContractList)(Nothing, "GetListForPerson", True, _
                CurrentWorker.ID)
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        LabourContractComboBox.DataSource = Nothing
        LabourContractComboBox.DataSource = LCL
        LabourContractComboBox.SelectedIndex = -1

        MsgBox("Darbo sutarčių sąrašas gautas.", MsgBoxStyle.Information, "Info")

    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim nPersonID As Integer
        Dim nPersonInfo As String
        Dim nSerial As String = ""
        Dim nNumber As Integer = 0

        If WorkerAccGridComboBox.SelectedValue Is Nothing OrElse _
            Not CType(WorkerAccGridComboBox.SelectedValue, HelperLists.PersonInfo).ID > 0 Then
            MsgBox("Klaida. Nepasirinktas darbuotojas.")
            Exit Sub
        End If

        nPersonID = CType(WorkerAccGridComboBox.SelectedValue, HelperLists.PersonInfo).ID
        nPersonInfo = CType(WorkerAccGridComboBox.SelectedValue, HelperLists.PersonInfo).ToString

        If LabourContractComboBox.SelectedItem Is Nothing OrElse _
            Not CType(LabourContractComboBox.SelectedItem, ShortLabourContract).Number > 0 Then

            If Not IsConsolidatedCheckBox.Checked Then
                MsgBox("Klaida. Nepasirinkta darbo sutartis.")
                Exit Sub
            End If

        Else

            nSerial = CType(LabourContractComboBox.SelectedItem, ShortLabourContract).Serial.Trim
            nNumber = CType(LabourContractComboBox.SelectedItem, ShortLabourContract).Number

        End If

        Using bm As New BindingsManager(WageSheetBindingSource, Nothing, Nothing, False, True)

            Try
                Obj = LoadObject(Of WorkerWageInfoReport)(Nothing, "GetWorkerWageInfoReport", True, _
                    DateFromDateTimePicker.Value.Date, DateToDateTimePicker.Value.Date, _
                    nPersonID, nSerial, nNumber, IsConsolidatedCheckBox.Checked, nPersonInfo)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        Using busy As New StatusBusy

            Try
                Dim OldData As DataTable = DirectCast(WorkerInfoDataGridView.DataSource, DataTable)
                OldData.Dispose()
                WorkerInfoDataGridView.DataSource = Nothing
            Catch ex As Exception
            End Try

            Try
                WorkerInfoDataGridView.DataSource = Obj.GetWorkerInfoCardDatatable
            Catch ex As Exception
                ShowError(ex)
            End Try

        End Using

        WorkerInfoDataGridView.Select()

    End Sub

    Private Sub WorkerInfoDataGridView_RowPrePaint(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) _
        Handles WorkerInfoDataGridView.RowPrePaint

        If WorkerInfoDataGridView.Item(0, e.RowIndex).Value.ToString.Trim.ToLower = "metai" Then
            WorkerInfoDataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightCoral
            WorkerInfoDataGridView.Rows(e.RowIndex).DefaultCellStyle.Font = _
                New Font(WorkerInfoDataGridView.DefaultCellStyle.Font, FontStyle.Bold)
        ElseIf WorkerInfoDataGridView.Item(0, e.RowIndex).Value.ToString.Trim.ToLower = "iš viso:" Then
            WorkerInfoDataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGray
            WorkerInfoDataGridView.Rows(e.RowIndex).DefaultCellStyle.Font = _
                New Font(WorkerInfoDataGridView.DefaultCellStyle.Font, FontStyle.Bold)
        End If

    End Sub

    Private Sub WorkerInfoDataGridView_SelectionChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles WorkerInfoDataGridView.SelectionChanged

        If WorkerInfoDataGridView.SelectedRows.Count > 0 Then _
            WorkerInfoDataGridView.SelectedRows.Item(0).Selected = False

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

        If Not PrepareCache(Me, GetType(HelperLists.PersonInfoList)) Then Return False

        Try
            LoadPersonInfoListToGridCombo(WorkerAccGridComboBox, True, False, False, True)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class