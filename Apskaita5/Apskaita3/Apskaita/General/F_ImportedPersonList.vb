Imports ApskaitaObjects.General
Public Class F_ImportedPersonList

    Private Obj As ImportedPersonList = Nothing


    Private Sub F_ImportedPersonList_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Obj Is Nothing AndAlso Obj.Count > 0 Then
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

        GetDataGridViewLayOut(ImportedPersonListDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_ImportedPersonList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        AddDGVColumnSelector(ImportedPersonListDataGridView)
        SetDataGridViewLayOut(ImportedPersonListDataGridView)
        SetFormLayout(Me)

    End Sub


    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        SaveObj()
    End Sub

    Private Sub PasteButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles PasteButton.Click
        LoadData(Clipboard.GetText)
    End Sub

    Private Sub OpenFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenFileButton.Click

        Dim FileName As String

        Using OFD As New OpenFileDialog
            OFD.Multiselect = False
            If OFD.ShowDialog(Me) <> System.Windows.Forms.DialogResult.OK Then Exit Sub
            FileName = OFD.FileName
        End Using
        If FileName Is Nothing OrElse String.IsNullOrEmpty(FileName.Trim) _
            OrElse Not IO.File.Exists(FileName) Then Exit Sub

        Dim source As String

        Try
            Using busy As New StatusBusy
                source = IO.File.ReadAllText(FileName, New System.Text.UnicodeEncoding)
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko atidaryti failo: " & ex.Message, ex))
            Exit Sub
        End Try

        LoadData(source)

    End Sub

    Private Sub HelpButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nHelpButton.Click

        MsgBox("Importuojami duomenys, nepriklausomai nuo šaltinio, turi atitikti šiuos reikalavimus:" _
            & vbCrLf & "Duomenų eilutės turi būti atskirtos naudojant cr lf simbolius." _
            & vbCrLf & "Duomenų stulpeliai turi būti atskirti naudojant tab simbolį." _
            & vbCrLf & "Duomenyse negali būti simbolių, naudojamų kaip skirtukai, t.y. cr lf arba tab." _
            & vbCrLf & ImportedPerson.GetPasteStringColumnsDescription, MsgBoxStyle.Information, "Info")
        Clipboard.SetText(String.Join(vbTab, ImportedPerson.GetPasteStringColumns), TextDataFormat.UnicodeText)

    End Sub



    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Duomenyse yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, _
                MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings.Trim) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.GetAllWarnings.Trim & vbCrLf
        Else
            Question = ""
        End If
        Question = Question & "Ar tikrai norite importuoti kontrahentų duomenis?"
        Answer = "Duomenys sėkmingai importuoti."

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(ImportedPersonListBindingSource, Nothing, Nothing, True, False)

            Try
                Obj = LoadObject(Of ImportedPersonList)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub LoadData(ByVal source As String)

        If Not Obj Is Nothing AndAlso Obj.Count > 0 Then

            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then Exit Sub
            If answ = "Taip" AndAlso Not SaveObj() Then Exit Sub

        End If

        Using bm As New BindingsManager(ImportedPersonListBindingSource, Nothing, Nothing, True, False)

            Try
                Obj = LoadObject(Of ImportedPersonList)(Nothing, "GetImportedPersonList", True, source)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

    End Sub

End Class