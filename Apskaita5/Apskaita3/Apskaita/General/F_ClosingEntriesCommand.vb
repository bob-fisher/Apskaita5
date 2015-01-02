Imports ApskaitaObjects.General
Imports ApskaitaObjects.HelperLists
Public Class F_ClosingEntriesCommand

    Private Loading As Boolean = True
    Private JournalEntryID As Integer = 0


    Private Sub F_ClosingEntriesCommand_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_ClosingEntriesCommand_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GetFormLayout(Me)
    End Sub

    Private Sub F_ClosingEntriesCommand_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub
        SetFormLayout(Me)

        Dim CC As Settings.CompanyInfo = GetCurrentCompany()
        ConsolidatedAccountAccGridComboBox.SelectedValue = _
            CC.GetDefaultAccount(DefaultAccountType.ClosingSummary)
        CurrentProfitAccountAccGridComboBox.SelectedValue = _
            CC.GetDefaultAccount(DefaultAccountType.CurrentProfit)
        FormerProfitAccountAccGridComboBox.SelectedValue = _
            CC.GetDefaultAccount(DefaultAccountType.FormerProfit)

    End Sub


    Private Sub IOkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click
        If SaveObj() Then
            Me.Hide()
            Me.Close()
        End If
    End Sub

    Private Sub ICancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        Me.Hide()
        Me.Close()
    End Sub


    Private Function SaveObj() As Boolean

        If Not ClosingEntriesCommand.CanExecuteCommand() Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai operacijai.", MsgBoxStyle.Exclamation, "Klaida")
            Return False
        End If

        If ClosingDateDateTimePicker.Value.Date <= GetCurrentCompany.LastClosingDate.Date Then
            MsgBox("Klaida. Nurodyta operacijos data yra ankstesnė " & _
                "nei paskutinio 5/6 klasių uždarymo data.", MsgBoxStyle.Exclamation, "Klaida")
            Return False
        End If

        If ConsolidatedAccountAccGridComboBox.SelectedValue Is Nothing OrElse _
            Not Long.Parse(ConsolidatedAccountAccGridComboBox.SelectedValue.ToString) > 0 Then
            MsgBox("Klaida. Nenurodyta suvestinės sąskaita.", MsgBoxStyle.Exclamation, "Klaida")
            Return False
        End If


        If Not YesOrNo("DĖMESIO. Uždarius 5/6 klases nebebus leidžiama taisyti ar įvesti " & _
            "įrašų/dokumentų ankstesne nei uždarymo data. Ar tikrai norite tęsti?") Then Return False

        Using busy As New StatusBusy

            Dim nCurrentProfitAccount As Long = 0
            Dim nFormerProfitAccount As Long = 0
            Try
                nCurrentProfitAccount = Long.Parse(CurrentProfitAccountAccGridComboBox.SelectedValue.ToString)
            Catch ex As Exception
            End Try
            Try
                nFormerProfitAccount = Long.Parse(FormerProfitAccountAccGridComboBox.SelectedValue.ToString)
            Catch ex As Exception
            End Try

            Try
                JournalEntryID = General.ClosingEntriesCommand.TheCommand( _
                    ClosingDateDateTimePicker.Value.Date, _
                    Long.Parse(ConsolidatedAccountAccGridComboBox.SelectedValue.ToString), _
                    nCurrentProfitAccount, nFormerProfitAccount)
            Catch ex As Exception
                ShowError(ex)
                Exit Function
            End Try

        End Using

        If YesOrNo("Penktos/šeštos klasės uždarymo įrašas sėkmingai padarytas." _
            & vbCrLf & "Rodyti šio įrašo kontavimus?") Then MDIParent1.LaunchForm( _
            GetType(F_GeneralLedgerEntry), False, False, JournalEntryID, JournalEntryID)

        Return True

    End Function

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            LoadAccountInfoListToGridCombo(ConsolidatedAccountAccGridComboBox, True, 3)
            LoadAccountInfoListToGridCombo(CurrentProfitAccountAccGridComboBox, True, 3)
            LoadAccountInfoListToGridCombo(FormerProfitAccountAccGridComboBox, True, 3)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class