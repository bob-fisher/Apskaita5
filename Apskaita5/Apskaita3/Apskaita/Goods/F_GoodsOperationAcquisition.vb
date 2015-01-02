Imports ApskaitaObjects.Goods
Imports ApskaitaObjects.HelperLists
Public Class F_GoodsOperationAcquisition
    Implements IObjectEditForm

    Private Obj As GoodsOperationAcquisition = Nothing
    Private Loading As Boolean = True
    Private OperationID As Integer = 0
    Private GoodsID As Integer = 0
    Private WarehouseID As Integer = 0
    Private ChildObject As Documents.InvoiceAttachedObject = Nothing


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not ChildObject Is Nothing Then Return DirectCast(ChildObject.ValueObject, _
                GoodsOperationAcquisition).ID
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(GoodsOperationAcquisition)
        End Get
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal nOperationID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        OperationID = nOperationID

    End Sub

    Public Sub New(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GoodsID = nGoodsID
        WarehouseID = nWarehouseID

    End Sub

    Public Sub New(ByRef nChildObject As Documents.InvoiceAttachedObject)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        If nChildObject Is Nothing Then Throw New ArgumentNullException("ChildObject negali būti null.")

        If nChildObject.Type <> Documents.InvoiceAttachedObjectType.GoodsAcquisition Then _
            Throw New Exception("Klaida. Objekto tipas nėra prekių įsigijimas.")

        ' Add any initialization after the InitializeComponent() call.
        ChildObject = nChildObject

    End Sub


    Private Sub F_GoodsOperationAcquisition_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.WarehouseInfoList)) Then Exit Sub

    End Sub

    Private Sub F_GoodsOperationAcquisition_FormClosing(ByVal sender As Object, _
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

        If Not Obj Is Nothing AndAlso Obj.IsDirty Then CancelObj()

        GetFormLayout(Me)

    End Sub

    Private Sub F_GoodsOperationAcquisition_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If ChildObject Is Nothing Then

            If Not GoodsOperationAcquisition.CanGetObject AndAlso OperationID > 0 Then
                MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                    MsgBoxStyle.Exclamation, "Klaida.")
                DisableAllControls(Me)
                Exit Sub
            ElseIf Not GoodsOperationAcquisition.CanAddObject AndAlso Not OperationID > 0 Then
                MsgBox("Klaida. Jūsų teisių nepakanka prekių duomenims tvarkyti.", _
                    MsgBoxStyle.Exclamation, "Klaida.")
                DisableAllControls(Me)
                Exit Sub
            End If

        End If

        If Not SetDataSources() Then Exit Sub

        If ChildObject Is Nothing Then

            If OperationID > 0 Then

                Try
                    Obj = LoadObject(Of GoodsOperationAcquisition)(Nothing, "GetGoodsOperationAcquisition", _
                        True, OperationID)

                Catch ex As Exception
                    ShowError(ex)
                    DisableAllControls(Me)
                    Exit Sub
                End Try

            Else

                Try
                    Obj = LoadObject(Of GoodsOperationAcquisition)(Nothing, "NewGoodsOperationAcquisition", _
                        True, GoodsID)
                Catch ex As Exception
                    ShowError(ex)
                    DisableAllControls(Me)
                    Exit Sub
                End Try

            End If

            GoodsOperationAcquisitionBindingSource.DataSource = Obj

            ConfigureLimitationButton(Obj)

        Else

            DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition).BeginEdit()
            GoodsOperationAcquisitionBindingSource.DataSource = _
                DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition)

            ConfigureLimitationButton(DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition))
            DateDateTimePicker.Enabled = False

        End If

        SetFormLayout(Me)

        ConfigureButtons()

        If Not Obj Is Nothing AndAlso Not Obj.IsNew AndAlso Not GoodsOperationAcquisition.CanEditObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka prekių duomenims redaguoti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not Obj Is Nothing AndAlso Obj.ComplexOperationID > 0 Then
            MsgBox("Klaida. Ši operacija yra sudedamoji kompleksinės operacijos dalis. " _
                & "Ją redaguoti galima tik per atitinkamą kompleksinį dokumentą.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nOkButton.Click

        If Not ChildObject Is Nothing Then

            If Not DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition).IsValid Then
                If Not YesOrNo("Redaguojamuose prekių įsigijimo duomenyse yra klaidų:" & vbCrLf _
                    & DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition). _
                    BrokenRulesCollection.ToString(Csla.Validation.RuleSeverity.Error) _
                    & vbCrLf & vbCrLf & "Ar tikrai norite uždaryti formą?") Then Exit Sub
            End If

            If DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition).IsDirty Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If
            BindingsManager.UnBind(True, False, New BindingSource() {GoodsOperationAcquisitionBindingSource})
            If Me.DialogResult = Windows.Forms.DialogResult.OK Then
                DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition).ApplyEdit()
            Else
                DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition).CancelEdit()
            End If
            Me.Close()

        ElseIf Not Obj Is Nothing Then

            If SaveObj() Then Me.Close()

        End If

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        If Not ChildObject Is Nothing OrElse Obj Is Nothing Then Exit Sub
        If SaveObj() Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nCancelButton.Click

        If Not ChildObject Is Nothing Then

            BindingsManager.UnBind(True, True, New BindingSource() {GoodsOperationAcquisitionBindingSource})
            DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition).CancelEdit()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        ElseIf Not Obj Is Nothing Then

            CancelObj()

        End If

    End Sub


    Private Sub RefreshJournalEntryInfoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshJournalEntryInfoButton.Click

        If Not ChildObject Is Nothing OrElse Obj Is Nothing Then Exit Sub

        Dim JEList As ActiveReports.JournalEntryInfoList

        Try
            JEList = LoadObject(Of ActiveReports.JournalEntryInfoList)(Nothing, "GetList", _
                True, Obj.Date, Obj.Date, "", -1, -1, DocumentType.None, False, "", "")
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

        JournalEntryInfoComboBox.DataSource = JEList

    End Sub

    Private Sub AttachJournalEntryInfoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AttachJournalEntryInfoButton.Click

        If Not ChildObject Is Nothing OrElse Obj Is Nothing Then Exit Sub

        If JournalEntryInfoComboBox.SelectedItem Is Nothing Then Exit Sub

        Try
            Obj.LoadAssociatedJournalEntry(CType(JournalEntryInfoComboBox.SelectedItem, _
                ActiveReports.JournalEntryInfo))
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

    End Sub

    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click

        If Not ChildObject Is Nothing Then
            MsgBox(ChildObject.ChronologyValidator.LimitsExplanation & vbCrLf & vbCrLf & _
                ChildObject.ChronologyValidator.BackgroundExplanation, MsgBoxStyle.Information, "")
        ElseIf Not Obj Is Nothing Then
            MsgBox(Obj.OperationLimitations.LimitsExplanation & vbCrLf & vbCrLf & _
                Obj.OperationLimitations.GetBackgroundDescription, MsgBoxStyle.Information, "")
        End If

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click

        If Obj Is Nothing OrElse Not Obj.JournalEntryID > 0 Then Exit Sub

        MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, _
            Obj.JournalEntryID, Obj.JournalEntryID)

    End Sub


    Private Function SaveObj() As Boolean

        If Obj Is Nothing OrElse Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.BrokenRulesCollection.ToString( _
                Csla.Validation.RuleSeverity.Error), MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Obj.BrokenRulesCollection.WarningCount > 0 Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.BrokenRulesCollection.ToString(Csla.Validation.RuleSeverity.Warning) & vbCrLf
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

        Using bm As New BindingsManager(GoodsOperationAcquisitionBindingSource, Nothing, Nothing, True, False)

            Try
                Obj = LoadObject(Of GoodsOperationAcquisition)(Obj, "Save", False)
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
        If Obj Is Nothing OrElse Obj.IsNew Then Exit Sub
        Using bm As New BindingsManager(GoodsOperationAcquisitionBindingSource, Nothing, Nothing, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.WarehouseInfoList)) Then Return False

        Try

            CachedListsLoaders.LoadWarehouseInfoListToGridCombo(WarehouseAccGridComboBox, False)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        Dim current As GoodsOperationAcquisition = Nothing
        If Not ChildObject Is Nothing Then
            current = DirectCast(ChildObject.ValueObject, GoodsOperationAcquisition)
        ElseIf Not Obj Is Nothing Then
            current = Obj
        End If

        WarehouseAccGridComboBox.Enabled = Not current Is Nothing AndAlso Not current.WarehouseIsReadOnly
        UnitCostAccTextBox.ReadOnly = current Is Nothing OrElse current.UnitCostIsReadOnly
        AmmountAccTextBox.ReadOnly = current Is Nothing OrElse current.AmmountIsReadOnly
        TotalCostAccTextBox.ReadOnly = current Is Nothing OrElse current.TotalCostIsReadOnly
        DateDateTimePicker.Enabled = Not current Is Nothing AndAlso Not current.DateIsReadOnly
        DescriptionTextBox.ReadOnly = current Is Nothing OrElse current.DescriptionIsReadOnly

        ApplyButton.Enabled = ChildObject Is Nothing AndAlso Not Obj Is Nothing
        nCancelButton.Enabled = Not ChildObject Is Nothing OrElse (Not Obj Is Nothing AndAlso Not Obj.IsNew)

        EditedBaner.Visible = Not current Is Nothing AndAlso Not current.IsNew

        AttachJournalEntryInfoButton.Enabled = Not current Is Nothing AndAlso _
            Not current.AssociatedJournalEntryIsReadOnly
        JournalEntryInfoComboBox.Enabled = Not current Is Nothing AndAlso _
            Not current.AssociatedJournalEntryIsReadOnly
        RefreshJournalEntryInfoButton.Enabled = Not current Is Nothing AndAlso _
            Not current.AssociatedJournalEntryIsReadOnly

        ViewJournalEntryButton.Visible = Not Obj Is Nothing

    End Sub

    Private Sub ConfigureLimitationButton(ByVal asset As GoodsOperationAcquisition)

        If Not asset.OperationLimitations.FinancialDataCanChange OrElse _
            asset.OperationLimitations.MaxDateApplicable OrElse _
            asset.OperationLimitations.MinDateApplicable Then
            LimitationsButton.Visible = True
            LimitationsButton.Image = My.Resources.Action_lock_icon_32p
        Else
            LimitationsButton.Visible = False
        End If

    End Sub

End Class