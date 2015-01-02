Imports ApskaitaObjects.Assets
Public Class F_LongTermAssetCustomGroupList
    Private Obj As LongTermAssetCustomGroupList

    Private Sub F_LongTermAssetCustomGroupList_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_LongTermAssetCustomGroupList_FormClosing(ByVal sender As Object, _
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

        GetFormLayout(Me)
    End Sub

    Private Sub F_LongTermAssetCustomGroupList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Obj = LoadObject(Of LongTermAssetCustomGroupList)(Nothing, _
                "GetLongTermAssetCustomGroupList", True)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        LongTermAssetCustomGroupListBindingSource.DataSource = Obj

        SetFormLayout(Me)

    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nOkButton.Click
        If SaveObj() Then Me.Close()
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        SaveObj()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nCancelButton.Click
        CancelObj()
    End Sub



    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question As String
        'If Obj.BrokenRulesCollection.WarningCount > 0 Then
        '    Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
        '        & Obj.BrokenRulesCollection.ToString(Csla.Validation.RuleSeverity.Warning) & vbCrLf
        'Else
        Question = ""
        'End If
        Question = Question & "Ar tikrai norite pakeisti duomenis?"

        If Not YesOrNo(Question) Then Return False

        Using busy As New StatusBusy

            Using bm As New BindingsManager(LongTermAssetCustomGroupListBindingSource, _
                Nothing, Nothing, True, False)

                Try
                    Obj = LoadObject(Of LongTermAssetCustomGroupList)(Obj, "Save", False)
                Catch ex As Exception
                    ShowError(ex)
                    Return False
                End Try

                bm.SetNewDataSource(Obj)

            End Using

        End Using

        MsgBox("Duomenys sėkmingai pakeisti.", MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        Using bm As New BindingsManager(LongTermAssetCustomGroupListBindingSource, Nothing, Nothing, True, True)
        End Using
    End Sub

End Class