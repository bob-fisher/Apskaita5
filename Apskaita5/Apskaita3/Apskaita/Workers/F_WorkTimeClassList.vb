Imports ApskaitaObjects.Workers
Public Class F_WorkTimeClassList

    Private Obj As WorkTimeClassList
    Private Loading As Boolean = True


    Private Sub F_WorkTimeClassList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

    End Sub

    Private Sub F_WorkTimeClassList_FormClosing(ByVal sender As Object, _
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

        GetDataGridViewLayOut(WorkTimeClassListDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_WorkTimeClassList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not WorkTimeClassList.CanGetObject Then
            DisableAllControls(Me)
            Exit Sub
        End If

        Me.TypeHumanReadableDataGridViewComboBoxColumn.DataSource = _
            GetEnumValuesHumanReadableList(GetType(WorkTimeType), False)

        Try
            Obj = LoadObject(Of WorkTimeClassList)(Nothing, "GetWorkTimeClassList", False)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        Obj.BeginEdit()
        WorkTimeClassListBindingSource.DataSource = Obj

        IOkButton.Enabled = WorkTimeClassList.CanEditObject
        IApplyButton.Enabled = WorkTimeClassList.CanEditObject
        FetchTypicalWorkTimeClassListButton.Visible = (Obj.Count < 1)

        SetDataGridViewLayOut(WorkTimeClassListDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub IOkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click
        If Obj Is Nothing Then Exit Sub
        If SaveObj() Then
            Me.Hide()
            Me.Close()
        End If
    End Sub

    Private Sub IApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IApplyButton.Click
        If Obj Is Nothing Then Exit Sub
        SaveObj()
    End Sub

    Private Sub ICancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        If Obj Is Nothing Then Exit Sub
        CancelObj()
    End Sub


    Private Sub FetchTypicalWorkTimeClassListButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles FetchTypicalWorkTimeClassListButton.Click

        If Obj Is Nothing Then Exit Sub

        If Not YesOrNo("Ar tikrai norite generuoti tipinę darbo laiko klasių struktūrą?") Then Exit Sub

        Try
            Using bus As New StatusBusy
                Obj.AddWithTypicalCodes()
            End Using
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub DocumentSerialListDataGridView_CellBeginEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
        Handles WorkTimeClassListDataGridView.CellBeginEdit

        If Obj Is Nothing Then Exit Sub

        Dim SelectedItem As WorkTimeClass = Nothing
        Try
            SelectedItem = DirectCast(WorkTimeClassListDataGridView.Rows(e.RowIndex).DataBoundItem, WorkTimeClass)
        Catch ex As Exception
        End Try

        If SelectedItem Is Nothing OrElse SelectedItem.IsNew OrElse Not SelectedItem.IsInUse Then Exit Sub

        Dim SelectedField As DataGridViewColumn = WorkTimeClassListDataGridView.Columns(e.ColumnIndex)

        If SelectedField Is Nothing Then Exit Sub

        If SelectedField.DataPropertyName <> "Name" Then e.Cancel = True

    End Sub

    Private Sub DocumentSerialListDataGridView_UserDeletingRow(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles WorkTimeClassListDataGridView.UserDeletingRow

        If Obj Is Nothing Then Exit Sub

        Dim SelectedItem As WorkTimeClass = Nothing
        Try
            SelectedItem = DirectCast(e.Row.DataBoundItem, WorkTimeClass)
        Catch ex As Exception
        End Try

        If SelectedItem Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If

        If Not SelectedItem.IsNew AndAlso SelectedItem.IsInUse Then
            MsgBox("Klaida. Šis darbo laiko tipas buvo naudojamas sudarant darbo " _
                & "laiko apskaitos žiniaraščius. Jos pašalinti neleidžiama.", _
                MsgBoxStyle.Exclamation, "Klaida")
            e.Cancel = True
            Exit Sub
        End If

        If Not SelectedItem.IsNew AndAlso Not YesOrNo("Ar tikrai norite pašalinti darbo laiko tipą?") Then
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub DocumentSerialListDataGridView_RowLeave(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles WorkTimeClassListDataGridView.RowLeave
        If WorkTimeClassListDataGridView.Rows(e.RowIndex).IsNewRow AndAlso _
            e.RowIndex = WorkTimeClassListDataGridView.Rows.Count - 1 Then _
            WorkTimeClassListDataGridView.CancelEdit()
    End Sub



    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.GetAllWarnings & vbCrLf
        Else
            Question = ""
        End If
        Question = Question & "Ar tikrai norite pakeisti duomenis?"
        Answer = "Duomenys sėkmingai pakeisti."

        If Not YesOrNo(Question) Then Return False

        Using busy As New StatusBusy

            Using bm As New BindingsManager(WorkTimeClassListBindingSource, Nothing, Nothing, True, False)

                Obj.ApplyEdit()

                Try
                    Obj = LoadObject(Of WorkTimeClassList)(Obj, "Save", False)
                Catch ex As Exception
                    ShowError(ex)
                    Return False
                End Try

                bm.SetNewDataSource(Obj)

            End Using

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        Using bm As New BindingsManager(WorkTimeClassListBindingSource, Nothing, Nothing, True, True)
            Obj.CancelEdit()
            Obj.BeginEdit()
        End Using
    End Sub

End Class