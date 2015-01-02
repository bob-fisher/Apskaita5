Imports ApskaitaObjects.Goods
Public Class F_ProductionCalculation
    Implements IObjectEditForm

    Private Obj As ProductionCalculation = Nothing
    Private Loading As Boolean = True
    Private OperationID As Integer = 0


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(ProductionCalculation)
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


    Private Sub F_ProductionCalculation_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.GoodsInfoList), _
            GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_ProductionCalculation_FormClosing(ByVal sender As Object, _
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
        GetDataGridViewLayOut(ComponentListDataGridView)
        GetDataGridViewLayOut(CostListDataGridView)

    End Sub

    Private Sub F_ProductionCalculation_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not ProductionCalculation.CanGetObject AndAlso OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        ElseIf Not ProductionCalculation.CanAddObject AndAlso Not OperationID > 0 Then
            MsgBox("Klaida. Jūsų teisių nepakanka prekių duomenims tvarkyti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        If OperationID > 0 Then

            Try
                Obj = LoadObject(Of ProductionCalculation)(Nothing, _
                    "GetProductionCalculation", True, OperationID)
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        Else

            Try
                Obj = ProductionCalculation.NewProductionCalculation
            Catch ex As Exception
                ShowError(ex)
                DisableAllControls(Me)
                Exit Sub
            End Try

        End If

        ProductionCalculationBindingSource.DataSource = Obj

        AddDGVColumnSelector(ComponentListDataGridView)
        AddDGVColumnSelector(CostListDataGridView)

        SetDataGridViewLayOut(ComponentListDataGridView)
        SetDataGridViewLayOut(CostListDataGridView)
        SetFormLayout(Me)

        ConfigureButtons()

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
       ByVal e As System.EventArgs) Handles nOkButton.Click
        If Obj Is Nothing Then Exit Sub
        If SaveObj() Then Me.Close()
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        If Obj Is Nothing Then Exit Sub
        If SaveObj() Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nCancelButton.Click
        If Obj Is Nothing Then Exit Sub
        CancelObj()
    End Sub


    Private Function SaveObj() As Boolean

        If Obj Is Nothing OrElse Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, _
                MsgBoxStyle.Exclamation, "Klaida.")
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

        Using bm As New BindingsManager(ProductionCalculationBindingSource, _
            ComponentListBindingSource, CostListBindingSource, True, False)

            Try
                Obj = LoadObject(Of ProductionCalculation)(Obj, "Save", False)
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
        Using bm As New BindingsManager(ProductionCalculationBindingSource, _
            ComponentListBindingSource, CostListBindingSource, True, True)
        End Using
    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.GoodsInfoList), _
            GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            LoadGoodsInfoListToGridCombo(GoodsAccGridComboBox, False, Documents.TradedItemType.All)
            LoadGoodsInfoListToGridCombo(DataGridViewTextBoxColumn2, False, Documents.TradedItemType.All)
            LoadAccountInfoListToGridCombo(DataGridViewTextBoxColumn5, True, 5, 6)

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

    Private Sub ConfigureButtons()

        nCancelButton.Enabled = Not Obj Is Nothing AndAlso Not Obj.IsNew
        nOkButton.Enabled = Not Obj Is Nothing
        ApplyButton.Enabled = Not Obj Is Nothing

        EditedBaner.Visible = Not Obj Is Nothing AndAlso Not Obj.IsNew

    End Sub

End Class