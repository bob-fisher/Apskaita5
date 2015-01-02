Imports ApskaitaObjects.Workers
Public Class F_WageSheet
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As WageSheet
    Private WageSheetID As Integer = -1
    Private Loading As Boolean = True
    Private PrintDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private PrintPreviewDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private EmailDropDown As Windows.Forms.ToolStripDropDown = Nothing

    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing AndAlso Not Obj.IsNew Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(WageSheet)
        End Get
    End Property


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nWageSheetID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        WageSheetID = nWageSheetID

    End Sub


    Private Sub F_WageSheet_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_WageSheet_FormClosing(ByVal sender As Object, _
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

        GetDataGridViewLayOut(ItemsDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_WageSheet_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If WageSheetID > 0 AndAlso Not Workers.WageSheet.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        YearComboBox.SelectedIndex = 0
        MonthComboBox.SelectedIndex = Today.Month - 1

        If WageSheetID > 0 Then

            Try
                Obj = LoadObject(Of WageSheet)(Nothing, "GetWageSheet", False, WageSheetID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

            WageSheetBindingSource.DataSource = Obj

        End If

        ConfigureButtons()
        ReadWriteAuthorization1.ResetControlAuthorization()

        AddDGVColumnSelector(ItemsDataGridView)

        SetDataGridViewLayOut(ItemsDataGridView)
        SetFormLayout(Me)

        If Not Obj Is Nothing AndAlso Not Obj.IsNew AndAlso Not Workers.WageSheet.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            ItemsDataGridView.Enabled = True
            ItemsDataGridView.ReadOnly = True
            TabControl1.Enabled = True
        End If

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
           ByVal e As System.EventArgs) Handles nOkButton.Click

        If Not SaveObj() Then Exit Sub
        Me.Hide()
        Me.Close()

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        If SaveObj() Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nCancelButton.Click
        CancelObj()
    End Sub


    Private Sub NewWageSheetButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewWageSheetButton.Click

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then Exit Sub
            If answ = "Taip" Then
                If Not SaveObj() Then Exit Sub
            End If
        End If

        Dim cYear As Integer = 0
        Try
            cYear = CInt(YearComboBox.SelectedItem.ToString)
        Catch ex As Exception
        End Try
        Dim cMonth As Integer = MonthComboBox.SelectedIndex + 1

        If Not cYear > 0 OrElse Not cMonth > 0 Then
            MsgBox("Klaida. Nepasirinkti metai arba mėnuo.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Using bm As New BindingsManager(WageSheetBindingSource, _
            ItemsBindingSource, Nothing, False, True)

            Try
                Obj = LoadObject(Of WageSheet)(Nothing, "NewWageSheet", True, cYear, cMonth)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        ConfigureButtons()

    End Sub

    Private Sub RefreshTaxesButton_Click(ByVal sender As System.Object, _
           ByVal e As System.EventArgs) Handles RefreshTaxesButton.Click
        If Obj Is Nothing Then Exit Sub
        Try
            Using busy As New StatusBusy
                Obj.UpdateTaxRates()
            End Using
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub RefreshWageTarifButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshWageTarifButton.Click
        If Obj Is Nothing Then Exit Sub
        Try
            Using busy As New StatusBusy
                Obj.UpdateWageRates()
            End Using
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub GetVDUButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetVDUButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim SelItems() As WorkersVDUInfo = Obj.GetWorkersVDUInfoArray

        If SelItems Is Nothing OrElse SelItems.Length < 1 Then
            MsgBox("Klaida. Nepasirinktas nė vienas darbuotojas.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                Dim VDUInfoItems As WorkersVDUInfoList = LoadObject(Of WorkersVDUInfoList) _
                    (Nothing, "GetList", True, SelItems, Obj.Year, Obj.Month)
                Obj.UpdateWorkersVDUInfo(VDUInfoItems)
            End Using
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        MsgBox("VDU duomenys sėkmingai gauti.", MsgBoxStyle.Information, "Info")

    End Sub

    Private Sub CalculateNPDButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CalculateNPDButton.Click

        If Obj Is Nothing Then Exit Sub

        Try
            Using busy As New StatusBusy
                Obj.CalculateNPD()
            End Using
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click
        If Obj Is Nothing OrElse String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim) Then Exit Sub
        MsgBox(Obj.ChronologicValidator.LimitsExplanation, MsgBoxStyle.MsgBoxHelp, "Taikomi Ribojimai")
    End Sub

    Private Sub ItemsDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles ItemsDataGridView.CellDoubleClick

        If Obj Is Nothing OrElse e.RowIndex < 0 OrElse ItemsDataGridView.Columns(e.ColumnIndex). _
            DataPropertyName <> "UnusedHolidayDaysForCompensation" Then Exit Sub

        If Not Obj.ChronologicValidator.FinancialDataCanChange Then
            MsgBox("Klaida. Finansinių žiniaraščio duomenų keisti neleidžiama:" & vbCrLf _
                & Obj.ChronologicValidator.FinancialDataCanChangeExplanation, _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        If Not YesOrNo("Gauti šio darbuotojo nepanaudotų atostogų kiekį?") Then Exit Sub

        Dim SelItem As WageItem = CType(ItemsDataGridView.Rows(e.RowIndex).DataBoundItem, _
            WageItem)

        Dim UH As UnusedHolidayInfo
        Try
            UH = LoadObject(Of UnusedHolidayInfo)(Nothing, "GetUnusedHolidayInfo", True, _
                New Date(Obj.Year, Obj.Month, Date.DaysInMonth(Obj.Year, Obj.Month)), _
                SelItem.PersonID, SelItem.ContractSerial, SelItem.ContractNumber, False)
            SelItem.UnusedHolidayDaysForCompensation = UH.UnusedHolidayAmmount
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        MsgBox("Darbuotojo nepanaudotų atostogų kiekis sėkmingai gautas.", _
            MsgBoxStyle.Information, "Info")

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If Obj Is Nothing OrElse Not Obj.ID > 0 Then Exit Sub
        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, Obj.ID, Obj.ID)
    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetMailDropDownItems

        If EmailDropDown Is Nothing Then
            EmailDropDown = New ToolStripDropDown
            EmailDropDown.Items.Add("DU apskaičiavimo žin.", Nothing, AddressOf OnMailClick)
            EmailDropDown.Items.Add("Mokėjimo lapeliai", Nothing, AddressOf OnMailClick)
        End If

        Return EmailDropDown

    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems

        If PrintDropDown Is Nothing Then
            PrintDropDown = New ToolStripDropDown
            PrintDropDown.Items.Add("DU apskaičiavimo žin.", Nothing, AddressOf OnPrintClick)
            PrintDropDown.Items.Add("Mokėjimo lapeliai", Nothing, AddressOf OnPrintClick)
        End If

        Return PrintDropDown

    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems

        If PrintPreviewDropDown Is Nothing Then
            PrintPreviewDropDown = New ToolStripDropDown
            PrintPreviewDropDown.Items.Add("DU apskaičiavimo žin.", Nothing, AddressOf OnPrintPreviewClick)
            PrintPreviewDropDown.Items.Add("Mokėjimo lapeliai", Nothing, AddressOf OnPrintPreviewClick)
        End If

        Return PrintPreviewDropDown

    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick

        If Obj Is Nothing Then Exit Sub

        Dim Version As Integer = 0
        If GetSenderText(sender).Trim.ToLower.Contains("du apskaičiavimo žin.") Then
            Version = 1
        ElseIf GetSenderText(sender).Trim.ToLower.Contains("mokėjimo lapeliai") Then
            Version = 2
        End If

        Using frm As New F_SendObjToEmail(Obj, Version)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick

        If Obj Is Nothing Then Exit Sub

        Dim Version As Integer = 0
        If GetSenderText(sender).Trim.ToLower.Contains("du apskaičiavimo žin.") Then
            Version = 1
        ElseIf GetSenderText(sender).Trim.ToLower.Contains("mokėjimo lapeliai") Then
            Version = 2
        End If

        Try
            PrintObject(Obj, False, Version)
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick

        If Obj Is Nothing Then Exit Sub

        Dim Version As Integer = 0
        If GetSenderText(sender).Trim.ToLower.Contains("du apskaičiavimo žin.") Then
            Version = 1
        ElseIf GetSenderText(sender).Trim.ToLower.Contains("mokėjimo lapeliai") Then
            Version = 2
        End If

        Try
            PrintObject(Obj, True, Version)
        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function



    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, MsgBoxStyle.Exclamation, "Klaida.")
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

        Using bm As New BindingsManager(WageSheetBindingSource, ItemsBindingSource, Nothing, True, False)

            Try
                Obj = LoadObject(Of WageSheet)(Obj, "Save", False)
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
        If Obj Is Nothing OrElse Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub
        Using bm As New BindingsManager(WageSheetBindingSource, ItemsBindingSource, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            For Each cl As DataGridViewColumn In ItemsDataGridView.Columns
                If cl.DataPropertyName = "BonusType" Then
                    CType(cl, DataGridViewComboBoxColumn).Items.Clear()
                    CType(cl, DataGridViewComboBoxColumn).Items.Add(BonusType.k)
                    CType(cl, DataGridViewComboBoxColumn).Items.Add(BonusType.m)
                    Exit For
                End If
            Next

            YearComboBox.Items.Clear()
            For i As Integer = 1 To 10
                YearComboBox.Items.Add((Today.Year - i + 1).ToString)
            Next

            LoadAccountInfoListToGridCombo(CostAccountAccGridComboBox, True, 6)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        RateGPMAccTextBox.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RateGuaranteeFundAccTextBox.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RateHRAccTextBox1.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RateONAccTextBox1.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RatePSDEmployeeAccTextBox.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RatePSDEmployerAccTextBox.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RateSCAccTextBox1.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RateSickLeaveAccTextBox1.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RateSODRAEmployeeAccTextBox.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RateSODRAEmployerAccTextBox.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        NPDFormulaTextBox.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)
        RefreshTaxesButton.Enabled = (Not Obj Is Nothing AndAlso Obj.ChronologicValidator.FinancialDataCanChange)
        RefreshWageTarifButton.Enabled = (Not Obj Is Nothing AndAlso Obj.ChronologicValidator.FinancialDataCanChange)

        ItemsDataGridView.ReadOnly = (Obj Is Nothing OrElse Not Obj.ChronologicValidator.FinancialDataCanChange)

        CostAccountAccGridComboBox.Enabled = (Not Obj Is Nothing AndAlso Obj.ChronologicValidator.FinancialDataCanChange)
        GetVDUButton.Enabled = (Not Obj Is Nothing AndAlso Obj.ChronologicValidator.FinancialDataCanChange)
        CalculateNPDButton.Enabled = (Not Obj Is Nothing AndAlso Obj.ChronologicValidator.FinancialDataCanChange)

        DateDateTimePicker.Enabled = (Not Obj Is Nothing)
        NumberAccTextBox.Enabled = (Not Obj Is Nothing)
        IsNonClosingCheckBox.Enabled = (Not Obj Is Nothing)
        RemarksTextBox.ReadOnly = (Obj Is Nothing)

        nOkButton.Enabled = (Not Obj Is Nothing)
        ApplyButton.Enabled = (Not Obj Is Nothing)
        nCancelButton.Enabled = (Not Obj Is Nothing AndAlso Not Obj.IsNew)

        LimitationsButton.Visible = (Not Obj Is Nothing AndAlso _
            Not String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim))

        NewWageSheetButton.Enabled = WageSheet.CanAddObject AndAlso (Obj Is Nothing OrElse Obj.IsNew)
        YearComboBox.Enabled = WageSheet.CanAddObject AndAlso (Obj Is Nothing OrElse Obj.IsNew)
        MonthComboBox.Enabled = WageSheet.CanAddObject AndAlso (Obj Is Nothing OrElse Obj.IsNew)

        EditedBaner.Visible = (Not Obj Is Nothing AndAlso Not Obj.IsNew)

    End Sub

End Class