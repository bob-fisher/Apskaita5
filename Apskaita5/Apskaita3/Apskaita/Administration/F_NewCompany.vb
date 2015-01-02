Imports AccDataAccessLayer.Security
Public Class F_NewCompany

    Private WithEvents Obj As General.Company

    Private Sub F_NewCompany_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_NewCompany_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        LoadCurrencyCodeListToComboBox(BaseCurrencyComboBox, False)

        Try
            Obj = General.Company.NewCompany
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        CompanyBindingSource.DataSource = Obj
        SaveCompanyButton.Enabled = General.Company.CanAddObject
        Me.ReadWriteAuthorization1.ResetControlAuthorization()

    End Sub

    Private Sub SaveCompanyButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles SaveCompanyButton.Click

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų: " & Environment.NewLine & _
                Obj.BrokenRulesCollection.ToString, MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        If Not YesOrNo("Ar tikrai norite sukurti naujos įmonės duomenų bazę?") Then Exit Sub

        Using busy As New StatusBusy

            Me.CompanyBindingSource.RaiseListChangedEvents = False
            Me.CompanyBindingSource.EndEdit()

            Dim ErrorOccured As Boolean = False
            Try
                Dim tmp As General.Company = Obj.Clone
                Obj = tmp.Save()
            Catch ex As Exception
                ShowError(ex)
                ErrorOccured = True
            Finally
                Me.CompanyBindingSource.RaiseListChangedEvents = True
                Me.CompanyBindingSource.ResetBindings(False)
            End Try

            If ErrorOccured Then Exit Sub

            DatabaseInfoList.InvalidateCache()
            BOMapper.DatabasesToMenu()
        End Using

        If YesOrNo("Įmonė sėkmingai įregistruota. Ar norite prisijungti " _
                    & "prie sukurtos įmonės?") Then

            Dim DBlist As DatabaseInfoList = Nothing

            Dim ErrorOccured As Boolean = False
            Try
                Using busy As New StatusBusy
                    DBlist = DatabaseInfoList.GetDatabaseList
                End Using
            Catch ex As Exception
                ShowError(ex)
                ErrorOccured = True
            End Try

            If Not ErrorOccured Then

                For Each db As DatabaseInfo In DBlist
                    If db.DatabaseName.Trim.ToLower = Obj.CompanyDatabaseName.Trim.ToLower Then

                        Try
                            Using busy As New StatusBusy
                                AccPrincipal.Login(db.DatabaseName, New CustomCacheManager)
                                Dim tmpcomp As General.Company = General.Company.GetCompany
                                BOMapper.LogInToGUI()
                            End Using
                        Catch ex As Exception
                            ShowError(ex)
                        End Try

                        Exit For

                    End If
                Next

            End If

        End If

        Me.Hide()
        Me.Close()

    End Sub

End Class