<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_GoodsOperationDiscount
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim IDLabel As System.Windows.Forms.Label
        Dim InsertDateLabel As System.Windows.Forms.Label
        Dim UpdateDateLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim MeasureUnitLabel As System.Windows.Forms.Label
        Dim AccountingMethodHumanReadableLabel As System.Windows.Forms.Label
        Dim JournalEntryIDLabel As System.Windows.Forms.Label
        Dim JournalEntryDateLabel As System.Windows.Forms.Label
        Dim JournalEntryTypeHumanReadableLabel As System.Windows.Forms.Label
        Dim AccountGoodsGeneralLabel As System.Windows.Forms.Label
        Dim DocumentNumberLabel As System.Windows.Forms.Label
        Dim JournalEntryCorrespondenceLabel As System.Windows.Forms.Label
        Dim JournalEntryContentLabel As System.Windows.Forms.Label
        Dim NameLabel1 As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim AccountGoodsNetCostsLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim TotalValueChangeLabel As System.Windows.Forms.Label
        Dim TotalGoodsValueChangeLabel As System.Windows.Forms.Label
        Dim TotalNetValueChangeLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_GoodsOperationDiscount))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RefreshJournalEntryInfoButton = New System.Windows.Forms.Button
        Me.JournalEntryInfoComboBox = New System.Windows.Forms.ComboBox
        Me.AttachJournalEntryInfoButton = New System.Windows.Forms.Button
        Me.LimitationsButton = New System.Windows.Forms.Button
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.GoodsOperationDiscountBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.TotalNetValueChangeAccTextBox = New AccControls.AccTextBox
        Me.TotalValueChangeAccTextBox = New AccControls.AccTextBox
        Me.TotalGoodsValueChangeAccTextBox = New AccControls.AccTextBox
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel
        Me.AccountPurchasesIsClosedCheckBox = New System.Windows.Forms.CheckBox
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.AccountGoodsNetCostsAccGridComboBox = New AccControls.AccGridComboBox
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel
        Me.JournalEntryContentTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel
        Me.WarehouseAccountTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox1 = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel
        Me.DocumentNumberTextBox = New System.Windows.Forms.TextBox
        Me.JournalEntryCorrespondenceTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.JournalEntryIDTextBox = New System.Windows.Forms.TextBox
        Me.JournalEntryTypeHumanReadableTextBox = New System.Windows.Forms.TextBox
        Me.JournalEntryDateTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.MeasureUnitTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.AccountGoodsGeneralTextBox = New System.Windows.Forms.TextBox
        Me.AccountingMethodHumanReadableTextBox = New System.Windows.Forms.TextBox
        Me.ValuationMethodHumanReadableTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.EditedBaner = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.nCancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.nOkButton = New System.Windows.Forms.Button
        Me.ConsignmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ConsignmentsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn20 = New AccControls.DataGridViewAccTextBoxColumn
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        IDLabel = New System.Windows.Forms.Label
        InsertDateLabel = New System.Windows.Forms.Label
        UpdateDateLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        MeasureUnitLabel = New System.Windows.Forms.Label
        AccountingMethodHumanReadableLabel = New System.Windows.Forms.Label
        JournalEntryIDLabel = New System.Windows.Forms.Label
        JournalEntryDateLabel = New System.Windows.Forms.Label
        JournalEntryTypeHumanReadableLabel = New System.Windows.Forms.Label
        AccountGoodsGeneralLabel = New System.Windows.Forms.Label
        DocumentNumberLabel = New System.Windows.Forms.Label
        JournalEntryCorrespondenceLabel = New System.Windows.Forms.Label
        JournalEntryContentLabel = New System.Windows.Forms.Label
        NameLabel1 = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        AccountGoodsNetCostsLabel = New System.Windows.Forms.Label
        DescriptionLabel = New System.Windows.Forms.Label
        TotalValueChangeLabel = New System.Windows.Forms.Label
        TotalGoodsValueChangeLabel = New System.Windows.Forms.Label
        TotalNetValueChangeLabel = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        CType(Me.GoodsOperationDiscountBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.EditedBaner.SuspendLayout()
        CType(Me.ConsignmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConsignmentsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(101, 6)
        IDLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 5
        IDLabel.Text = "ID:"
        '
        'InsertDateLabel
        '
        InsertDateLabel.AutoSize = True
        InsertDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InsertDateLabel.Location = New System.Drawing.Point(162, 3)
        InsertDateLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        InsertDateLabel.Name = "InsertDateLabel"
        InsertDateLabel.Size = New System.Drawing.Size(55, 13)
        InsertDateLabel.TabIndex = 6
        InsertDateLabel.Text = "Įtraukta:"
        '
        'UpdateDateLabel
        '
        UpdateDateLabel.AutoSize = True
        UpdateDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UpdateDateLabel.Location = New System.Drawing.Point(406, 3)
        UpdateDateLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Size = New System.Drawing.Size(60, 13)
        UpdateDateLabel.TabIndex = 8
        UpdateDateLabel.Text = "Pakeista:"
        '
        'NameLabel
        '
        NameLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(75, 36)
        NameLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(50, 13)
        NameLabel.TabIndex = 10
        NameLabel.Text = "Prekės:"
        '
        'MeasureUnitLabel
        '
        MeasureUnitLabel.AutoSize = True
        MeasureUnitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        MeasureUnitLabel.Location = New System.Drawing.Point(380, 3)
        MeasureUnitLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        MeasureUnitLabel.Name = "MeasureUnitLabel"
        MeasureUnitLabel.Size = New System.Drawing.Size(66, 13)
        MeasureUnitLabel.TabIndex = 12
        MeasureUnitLabel.Text = "Mato Vnt.:"
        '
        'AccountingMethodHumanReadableLabel
        '
        AccountingMethodHumanReadableLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        AccountingMethodHumanReadableLabel.AutoSize = True
        AccountingMethodHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountingMethodHumanReadableLabel.Location = New System.Drawing.Point(7, 66)
        AccountingMethodHumanReadableLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        AccountingMethodHumanReadableLabel.Name = "AccountingMethodHumanReadableLabel"
        AccountingMethodHumanReadableLabel.Size = New System.Drawing.Size(118, 13)
        AccountingMethodHumanReadableLabel.TabIndex = 4
        AccountingMethodHumanReadableLabel.Text = "Apskaitos Metodas:"
        '
        'JournalEntryIDLabel
        '
        JournalEntryIDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        JournalEntryIDLabel.AutoSize = True
        JournalEntryIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryIDLabel.Location = New System.Drawing.Point(49, 96)
        JournalEntryIDLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        JournalEntryIDLabel.Name = "JournalEntryIDLabel"
        JournalEntryIDLabel.Size = New System.Drawing.Size(76, 13)
        JournalEntryIDLabel.TabIndex = 8
        JournalEntryIDLabel.Text = "BŽ Įrašo ID:"
        '
        'JournalEntryDateLabel
        '
        JournalEntryDateLabel.AutoSize = True
        JournalEntryDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryDateLabel.Location = New System.Drawing.Point(190, 3)
        JournalEntryDateLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        JournalEntryDateLabel.Name = "JournalEntryDateLabel"
        JournalEntryDateLabel.Size = New System.Drawing.Size(38, 13)
        JournalEntryDateLabel.TabIndex = 10
        JournalEntryDateLabel.Text = "Data:"
        '
        'JournalEntryTypeHumanReadableLabel
        '
        JournalEntryTypeHumanReadableLabel.AutoSize = True
        JournalEntryTypeHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryTypeHumanReadableLabel.Location = New System.Drawing.Point(420, 3)
        JournalEntryTypeHumanReadableLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        JournalEntryTypeHumanReadableLabel.Name = "JournalEntryTypeHumanReadableLabel"
        JournalEntryTypeHumanReadableLabel.Size = New System.Drawing.Size(42, 13)
        JournalEntryTypeHumanReadableLabel.TabIndex = 12
        JournalEntryTypeHumanReadableLabel.Text = "Tipas:"
        '
        'AccountGoodsGeneralLabel
        '
        AccountGoodsGeneralLabel.AutoSize = True
        AccountGoodsGeneralLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountGoodsGeneralLabel.Location = New System.Drawing.Point(375, 3)
        AccountGoodsGeneralLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        AccountGoodsGeneralLabel.Name = "AccountGoodsGeneralLabel"
        AccountGoodsGeneralLabel.Size = New System.Drawing.Size(102, 13)
        AccountGoodsGeneralLabel.TabIndex = 4
        AccountGoodsGeneralLabel.Text = "Apskaitos Sąsk.:"
        '
        'DocumentNumberLabel
        '
        DocumentNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DocumentNumberLabel.AutoSize = True
        DocumentNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocumentNumberLabel.Location = New System.Drawing.Point(46, 126)
        DocumentNumberLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        DocumentNumberLabel.Name = "DocumentNumberLabel"
        DocumentNumberLabel.Size = New System.Drawing.Size(79, 13)
        DocumentNumberLabel.TabIndex = 4
        DocumentNumberLabel.Text = "BŽ Dok. Nr.:"
        '
        'JournalEntryCorrespondenceLabel
        '
        JournalEntryCorrespondenceLabel.AutoSize = True
        JournalEntryCorrespondenceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryCorrespondenceLabel.Location = New System.Drawing.Point(196, 3)
        JournalEntryCorrespondenceLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        JournalEntryCorrespondenceLabel.Name = "JournalEntryCorrespondenceLabel"
        JournalEntryCorrespondenceLabel.Size = New System.Drawing.Size(111, 13)
        JournalEntryCorrespondenceLabel.TabIndex = 6
        JournalEntryCorrespondenceLabel.Text = "Korespondencijos:"
        '
        'JournalEntryContentLabel
        '
        JournalEntryContentLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        JournalEntryContentLabel.AutoSize = True
        JournalEntryContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryContentLabel.Location = New System.Drawing.Point(3, 156)
        JournalEntryContentLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        JournalEntryContentLabel.Name = "JournalEntryContentLabel"
        JournalEntryContentLabel.Size = New System.Drawing.Size(122, 13)
        JournalEntryContentLabel.TabIndex = 8
        JournalEntryContentLabel.Text = "BŽ Dok. Aprašymas:"
        '
        'NameLabel1
        '
        NameLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NameLabel1.AutoSize = True
        NameLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel1.Location = New System.Drawing.Point(66, 186)
        NameLabel1.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        NameLabel1.Name = "NameLabel1"
        NameLabel1.Size = New System.Drawing.Size(59, 13)
        NameLabel1.TabIndex = 4
        NameLabel1.Text = "Sandėlis:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(87, 216)
        DateLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(38, 13)
        DateLabel.TabIndex = 4
        DateLabel.Text = "Data:"
        '
        'AccountGoodsNetCostsLabel
        '
        AccountGoodsNetCostsLabel.AutoSize = True
        AccountGoodsNetCostsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountGoodsNetCostsLabel.Location = New System.Drawing.Point(178, 3)
        AccountGoodsNetCostsLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        AccountGoodsNetCostsLabel.Name = "AccountGoodsNetCostsLabel"
        AccountGoodsNetCostsLabel.Size = New System.Drawing.Size(97, 13)
        AccountGoodsNetCostsLabel.TabIndex = 6
        AccountGoodsNetCostsLabel.Text = "Sąnaudų Sąsk.:"
        '
        'DescriptionLabel
        '
        DescriptionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DescriptionLabel.Location = New System.Drawing.Point(19, 276)
        DescriptionLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(106, 13)
        DescriptionLabel.TabIndex = 3
        DescriptionLabel.Text = "Oper. Aprašymas:"
        '
        'TotalValueChangeLabel
        '
        TotalValueChangeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        TotalValueChangeLabel.AutoSize = True
        TotalValueChangeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TotalValueChangeLabel.Location = New System.Drawing.Point(45, 246)
        TotalValueChangeLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        TotalValueChangeLabel.Name = "TotalValueChangeLabel"
        TotalValueChangeLabel.Size = New System.Drawing.Size(80, 13)
        TotalValueChangeLabel.TabIndex = 3
        TotalValueChangeLabel.Text = "Viso Pokytis:"
        '
        'TotalGoodsValueChangeLabel
        '
        TotalGoodsValueChangeLabel.AutoSize = True
        TotalGoodsValueChangeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TotalGoodsValueChangeLabel.Location = New System.Drawing.Point(131, 3)
        TotalGoodsValueChangeLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        TotalGoodsValueChangeLabel.Name = "TotalGoodsValueChangeLabel"
        TotalGoodsValueChangeLabel.Size = New System.Drawing.Size(123, 13)
        TotalGoodsValueChangeLabel.TabIndex = 5
        TotalGoodsValueChangeLabel.Text = "Iš jo esamoms prek.:"
        '
        'TotalNetValueChangeLabel
        '
        TotalNetValueChangeLabel.AutoSize = True
        TotalNetValueChangeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TotalNetValueChangeLabel.Location = New System.Drawing.Point(388, 3)
        TotalNetValueChangeLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        TotalNetValueChangeLabel.Name = "TotalNetValueChangeLabel"
        TotalNetValueChangeLabel.Size = New System.Drawing.Size(135, 13)
        TotalNetValueChangeLabel.TabIndex = 7
        TotalNetValueChangeLabel.Text = "Iš jo perleistoms prek.:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.LimitationsButton, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel11, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(DescriptionLabel, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel10, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel8, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel9, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(TotalValueChangeLabel, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(JournalEntryContentLabel, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(NameLabel1, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel7, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(DocumentNumberLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(AccountingMethodHumanReadableLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(NameLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(JournalEntryIDLabel, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 11
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(782, 350)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RefreshJournalEntryInfoButton)
        Me.GroupBox1.Controls.Add(Me.JournalEntryInfoComboBox)
        Me.GroupBox1.Controls.Add(Me.AttachJournalEntryInfoButton)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(131, 303)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(648, 44)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Prijungti Bendrojo Žurnalo Įrašą"
        '
        'RefreshJournalEntryInfoButton
        '
        Me.RefreshJournalEntryInfoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshJournalEntryInfoButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshJournalEntryInfoButton.Location = New System.Drawing.Point(525, 11)
        Me.RefreshJournalEntryInfoButton.Name = "RefreshJournalEntryInfoButton"
        Me.RefreshJournalEntryInfoButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshJournalEntryInfoButton.TabIndex = 0
        Me.RefreshJournalEntryInfoButton.UseVisualStyleBackColor = True
        '
        'JournalEntryInfoComboBox
        '
        Me.JournalEntryInfoComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JournalEntryInfoComboBox.FormattingEnabled = True
        Me.JournalEntryInfoComboBox.Location = New System.Drawing.Point(6, 13)
        Me.JournalEntryInfoComboBox.Name = "JournalEntryInfoComboBox"
        Me.JournalEntryInfoComboBox.Size = New System.Drawing.Size(518, 21)
        Me.JournalEntryInfoComboBox.TabIndex = 1
        '
        'AttachJournalEntryInfoButton
        '
        Me.AttachJournalEntryInfoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AttachJournalEntryInfoButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AttachJournalEntryInfoButton.Location = New System.Drawing.Point(566, 11)
        Me.AttachJournalEntryInfoButton.Name = "AttachJournalEntryInfoButton"
        Me.AttachJournalEntryInfoButton.Size = New System.Drawing.Size(76, 23)
        Me.AttachJournalEntryInfoButton.TabIndex = 2
        Me.AttachJournalEntryInfoButton.Text = "Prijungti"
        Me.AttachJournalEntryInfoButton.UseVisualStyleBackColor = True
        '
        'LimitationsButton
        '
        Me.LimitationsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LimitationsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_lock_icon_32p
        Me.LimitationsButton.Location = New System.Drawing.Point(75, 303)
        Me.LimitationsButton.Name = "LimitationsButton"
        Me.LimitationsButton.Size = New System.Drawing.Size(50, 40)
        Me.LimitationsButton.TabIndex = 11
        Me.LimitationsButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.ColumnCount = 2
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.DescriptionTextBox, 0, 0)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(128, 273)
        Me.TableLayoutPanel11.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 1
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel11.TabIndex = 9
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "Description", True))
        Me.DescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DescriptionTextBox.Location = New System.Drawing.Point(2, 1)
        Me.DescriptionTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(630, 20)
        Me.DescriptionTextBox.TabIndex = 0
        '
        'GoodsOperationDiscountBindingSource
        '
        Me.GoodsOperationDiscountBindingSource.DataSource = GetType(ApskaitaObjects.Goods.GoodsOperationDiscount)
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TotalNetValueChangeAccTextBox, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(TotalNetValueChangeLabel, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TotalValueChangeAccTextBox, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(TotalGoodsValueChangeLabel, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TotalGoodsValueChangeAccTextBox, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(128, 243)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel2.TabIndex = 8
        '
        'TotalNetValueChangeAccTextBox
        '
        Me.TotalNetValueChangeAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.GoodsOperationDiscountBindingSource, "TotalNetValueChange", True))
        Me.TotalNetValueChangeAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalNetValueChangeAccTextBox.KeepBackColorWhenReadOnly = False
        Me.TotalNetValueChangeAccTextBox.Location = New System.Drawing.Point(528, 1)
        Me.TotalNetValueChangeAccTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.TotalNetValueChangeAccTextBox.Name = "TotalNetValueChangeAccTextBox"
        Me.TotalNetValueChangeAccTextBox.NegativeValue = False
        Me.TotalNetValueChangeAccTextBox.ReadOnly = True
        Me.TotalNetValueChangeAccTextBox.Size = New System.Drawing.Size(104, 20)
        Me.TotalNetValueChangeAccTextBox.TabIndex = 8
        Me.TotalNetValueChangeAccTextBox.TabStop = False
        Me.TotalNetValueChangeAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TotalValueChangeAccTextBox
        '
        Me.TotalValueChangeAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.GoodsOperationDiscountBindingSource, "TotalValueChange", True))
        Me.TotalValueChangeAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalValueChangeAccTextBox.KeepBackColorWhenReadOnly = False
        Me.TotalValueChangeAccTextBox.Location = New System.Drawing.Point(2, 1)
        Me.TotalValueChangeAccTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.TotalValueChangeAccTextBox.Name = "TotalValueChangeAccTextBox"
        Me.TotalValueChangeAccTextBox.NegativeValue = False
        Me.TotalValueChangeAccTextBox.Size = New System.Drawing.Size(104, 20)
        Me.TotalValueChangeAccTextBox.TabIndex = 0
        Me.TotalValueChangeAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TotalGoodsValueChangeAccTextBox
        '
        Me.TotalGoodsValueChangeAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.GoodsOperationDiscountBindingSource, "TotalGoodsValueChange", True))
        Me.TotalGoodsValueChangeAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalGoodsValueChangeAccTextBox.KeepBackColorWhenReadOnly = False
        Me.TotalGoodsValueChangeAccTextBox.Location = New System.Drawing.Point(259, 1)
        Me.TotalGoodsValueChangeAccTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.TotalGoodsValueChangeAccTextBox.Name = "TotalGoodsValueChangeAccTextBox"
        Me.TotalGoodsValueChangeAccTextBox.NegativeValue = False
        Me.TotalGoodsValueChangeAccTextBox.Size = New System.Drawing.Size(104, 20)
        Me.TotalGoodsValueChangeAccTextBox.TabIndex = 1
        Me.TotalGoodsValueChangeAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 7
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.AccountPurchasesIsClosedCheckBox, 5, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.DateDateTimePicker, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.AccountGoodsNetCostsAccGridComboBox, 3, 0)
        Me.TableLayoutPanel10.Controls.Add(AccountGoodsNetCostsLabel, 2, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(128, 213)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel10.TabIndex = 7
        '
        'AccountPurchasesIsClosedCheckBox
        '
        Me.AccountPurchasesIsClosedCheckBox.AutoSize = True
        Me.AccountPurchasesIsClosedCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.GoodsOperationDiscountBindingSource, "AccountPurchasesIsClosed", True))
        Me.AccountPurchasesIsClosedCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccountPurchasesIsClosedCheckBox.Location = New System.Drawing.Point(456, 3)
        Me.AccountPurchasesIsClosedCheckBox.Name = "AccountPurchasesIsClosedCheckBox"
        Me.AccountPurchasesIsClosedCheckBox.Size = New System.Drawing.Size(175, 17)
        Me.AccountPurchasesIsClosedCheckBox.TabIndex = 2
        Me.AccountPurchasesIsClosedCheckBox.Text = "Uždaryta Pardavimų Sąsk."
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.GoodsOperationDiscountBindingSource, "Date", True))
        Me.DateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDateTimePicker.Location = New System.Drawing.Point(2, 1)
        Me.DateDateTimePicker.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(151, 20)
        Me.DateDateTimePicker.TabIndex = 0
        '
        'AccountGoodsNetCostsAccGridComboBox
        '
        Me.AccountGoodsNetCostsAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.GoodsOperationDiscountBindingSource, "AccountGoodsNetCosts", True))
        Me.AccountGoodsNetCostsAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountGoodsNetCostsAccGridComboBox.FilterPropertyName = ""
        Me.AccountGoodsNetCostsAccGridComboBox.FormattingEnabled = True
        Me.AccountGoodsNetCostsAccGridComboBox.InstantBinding = True
        Me.AccountGoodsNetCostsAccGridComboBox.Location = New System.Drawing.Point(280, 1)
        Me.AccountGoodsNetCostsAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.AccountGoodsNetCostsAccGridComboBox.Name = "AccountGoodsNetCostsAccGridComboBox"
        Me.AccountGoodsNetCostsAccGridComboBox.Size = New System.Drawing.Size(151, 21)
        Me.AccountGoodsNetCostsAccGridComboBox.TabIndex = 1
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.JournalEntryContentTextBox, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(128, 153)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel8.TabIndex = 5
        '
        'JournalEntryContentTextBox
        '
        Me.JournalEntryContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "JournalEntryContent", True))
        Me.JournalEntryContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryContentTextBox.Location = New System.Drawing.Point(2, 1)
        Me.JournalEntryContentTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.JournalEntryContentTextBox.Name = "JournalEntryContentTextBox"
        Me.JournalEntryContentTextBox.ReadOnly = True
        Me.JournalEntryContentTextBox.Size = New System.Drawing.Size(630, 20)
        Me.JournalEntryContentTextBox.TabIndex = 9
        Me.JournalEntryContentTextBox.TabStop = False
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 4
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.WarehouseAccountTextBox, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.NameTextBox1, 2, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(128, 183)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel9.TabIndex = 6
        '
        'WarehouseAccountTextBox
        '
        Me.WarehouseAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "Warehouse.WarehouseAccount", True))
        Me.WarehouseAccountTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WarehouseAccountTextBox.Location = New System.Drawing.Point(2, 1)
        Me.WarehouseAccountTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.WarehouseAccountTextBox.Name = "WarehouseAccountTextBox"
        Me.WarehouseAccountTextBox.ReadOnly = True
        Me.WarehouseAccountTextBox.Size = New System.Drawing.Size(182, 20)
        Me.WarehouseAccountTextBox.TabIndex = 7
        Me.WarehouseAccountTextBox.TabStop = False
        Me.WarehouseAccountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NameTextBox1
        '
        Me.NameTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "Warehouse.Name", True))
        Me.NameTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NameTextBox1.Location = New System.Drawing.Point(198, 1)
        Me.NameTextBox1.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.NameTextBox1.Name = "NameTextBox1"
        Me.NameTextBox1.ReadOnly = True
        Me.NameTextBox1.Size = New System.Drawing.Size(432, 20)
        Me.NameTextBox1.TabIndex = 5
        Me.NameTextBox1.TabStop = False
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 5
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.DocumentNumberTextBox, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(JournalEntryCorrespondenceLabel, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.JournalEntryCorrespondenceTextBox, 3, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(128, 123)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel7.TabIndex = 4
        '
        'DocumentNumberTextBox
        '
        Me.DocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "DocumentNumber", True))
        Me.DocumentNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberTextBox.Location = New System.Drawing.Point(2, 1)
        Me.DocumentNumberTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DocumentNumberTextBox.Name = "DocumentNumberTextBox"
        Me.DocumentNumberTextBox.ReadOnly = True
        Me.DocumentNumberTextBox.Size = New System.Drawing.Size(169, 20)
        Me.DocumentNumberTextBox.TabIndex = 5
        Me.DocumentNumberTextBox.TabStop = False
        Me.DocumentNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'JournalEntryCorrespondenceTextBox
        '
        Me.JournalEntryCorrespondenceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "JournalEntryCorrespondence", True))
        Me.JournalEntryCorrespondenceTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryCorrespondenceTextBox.Location = New System.Drawing.Point(312, 1)
        Me.JournalEntryCorrespondenceTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.JournalEntryCorrespondenceTextBox.Name = "JournalEntryCorrespondenceTextBox"
        Me.JournalEntryCorrespondenceTextBox.ReadOnly = True
        Me.JournalEntryCorrespondenceTextBox.Size = New System.Drawing.Size(318, 20)
        Me.JournalEntryCorrespondenceTextBox.TabIndex = 7
        Me.JournalEntryCorrespondenceTextBox.TabStop = False
        Me.JournalEntryCorrespondenceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 9
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.ViewJournalEntryButton, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.JournalEntryIDTextBox, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.JournalEntryTypeHumanReadableTextBox, 7, 0)
        Me.TableLayoutPanel6.Controls.Add(JournalEntryTypeHumanReadableLabel, 6, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.JournalEntryDateTextBox, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(JournalEntryDateLabel, 3, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(128, 93)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel6.TabIndex = 3
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.ApskaitaWUI.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(163, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 53
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'JournalEntryIDTextBox
        '
        Me.JournalEntryIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "JournalEntryID", True))
        Me.JournalEntryIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryIDTextBox.Location = New System.Drawing.Point(2, 1)
        Me.JournalEntryIDTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.JournalEntryIDTextBox.Name = "JournalEntryIDTextBox"
        Me.JournalEntryIDTextBox.ReadOnly = True
        Me.JournalEntryIDTextBox.Size = New System.Drawing.Size(139, 20)
        Me.JournalEntryIDTextBox.TabIndex = 9
        Me.JournalEntryIDTextBox.TabStop = False
        Me.JournalEntryIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'JournalEntryTypeHumanReadableTextBox
        '
        Me.JournalEntryTypeHumanReadableTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "JournalEntryTypeHumanReadable", True))
        Me.JournalEntryTypeHumanReadableTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryTypeHumanReadableTextBox.Location = New System.Drawing.Point(467, 1)
        Me.JournalEntryTypeHumanReadableTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.JournalEntryTypeHumanReadableTextBox.Name = "JournalEntryTypeHumanReadableTextBox"
        Me.JournalEntryTypeHumanReadableTextBox.ReadOnly = True
        Me.JournalEntryTypeHumanReadableTextBox.Size = New System.Drawing.Size(162, 20)
        Me.JournalEntryTypeHumanReadableTextBox.TabIndex = 13
        Me.JournalEntryTypeHumanReadableTextBox.TabStop = False
        Me.JournalEntryTypeHumanReadableTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'JournalEntryDateTextBox
        '
        Me.JournalEntryDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "JournalEntryDate", True))
        Me.JournalEntryDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryDateTextBox.Location = New System.Drawing.Point(233, 1)
        Me.JournalEntryDateTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.JournalEntryDateTextBox.Name = "JournalEntryDateTextBox"
        Me.JournalEntryDateTextBox.ReadOnly = True
        Me.JournalEntryDateTextBox.Size = New System.Drawing.Size(162, 20)
        Me.JournalEntryDateTextBox.TabIndex = 11
        Me.JournalEntryDateTextBox.TabStop = False
        Me.JournalEntryDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 5
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.MeasureUnitTextBox, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(MeasureUnitLabel, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.NameTextBox, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(128, 33)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'MeasureUnitTextBox
        '
        Me.MeasureUnitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "GoodsInfo.MeasureUnit", True))
        Me.MeasureUnitTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MeasureUnitTextBox.Location = New System.Drawing.Point(451, 1)
        Me.MeasureUnitTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.MeasureUnitTextBox.Name = "MeasureUnitTextBox"
        Me.MeasureUnitTextBox.ReadOnly = True
        Me.MeasureUnitTextBox.Size = New System.Drawing.Size(179, 20)
        Me.MeasureUnitTextBox.TabIndex = 13
        Me.MeasureUnitTextBox.TabStop = False
        Me.MeasureUnitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "GoodsInfo.Name", True))
        Me.NameTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NameTextBox.Location = New System.Drawing.Point(2, 1)
        Me.NameTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ReadOnly = True
        Me.NameTextBox.Size = New System.Drawing.Size(353, 20)
        Me.NameTextBox.TabIndex = 11
        Me.NameTextBox.TabStop = False
        Me.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 6
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.AccountGoodsGeneralTextBox, 4, 0)
        Me.TableLayoutPanel5.Controls.Add(AccountGoodsGeneralLabel, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.AccountingMethodHumanReadableTextBox, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.ValuationMethodHumanReadableTextBox, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(128, 63)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'AccountGoodsGeneralTextBox
        '
        Me.AccountGoodsGeneralTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "AccountGoodsGeneral", True))
        Me.AccountGoodsGeneralTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountGoodsGeneralTextBox.Location = New System.Drawing.Point(482, 1)
        Me.AccountGoodsGeneralTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.AccountGoodsGeneralTextBox.Name = "AccountGoodsGeneralTextBox"
        Me.AccountGoodsGeneralTextBox.ReadOnly = True
        Me.AccountGoodsGeneralTextBox.Size = New System.Drawing.Size(147, 20)
        Me.AccountGoodsGeneralTextBox.TabIndex = 5
        Me.AccountGoodsGeneralTextBox.TabStop = False
        Me.AccountGoodsGeneralTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountingMethodHumanReadableTextBox
        '
        Me.AccountingMethodHumanReadableTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "GoodsInfo.AccountingMethodHumanReadable", True))
        Me.AccountingMethodHumanReadableTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountingMethodHumanReadableTextBox.Location = New System.Drawing.Point(2, 1)
        Me.AccountingMethodHumanReadableTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.AccountingMethodHumanReadableTextBox.Name = "AccountingMethodHumanReadableTextBox"
        Me.AccountingMethodHumanReadableTextBox.ReadOnly = True
        Me.AccountingMethodHumanReadableTextBox.Size = New System.Drawing.Size(172, 20)
        Me.AccountingMethodHumanReadableTextBox.TabIndex = 5
        Me.AccountingMethodHumanReadableTextBox.TabStop = False
        Me.AccountingMethodHumanReadableTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValuationMethodHumanReadableTextBox
        '
        Me.ValuationMethodHumanReadableTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "GoodsInfo.ValuationMethodHumanReadable", True))
        Me.ValuationMethodHumanReadableTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValuationMethodHumanReadableTextBox.Location = New System.Drawing.Point(178, 1)
        Me.ValuationMethodHumanReadableTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ValuationMethodHumanReadableTextBox.Name = "ValuationMethodHumanReadableTextBox"
        Me.ValuationMethodHumanReadableTextBox.ReadOnly = True
        Me.ValuationMethodHumanReadableTextBox.Size = New System.Drawing.Size(172, 20)
        Me.ValuationMethodHumanReadableTextBox.TabIndex = 7
        Me.ValuationMethodHumanReadableTextBox.TabStop = False
        Me.ValuationMethodHumanReadableTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 8
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(InsertDateLabel, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.InsertDateTextBox, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(UpdateDateLabel, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.UpdateDateTextBox, 6, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(128, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(654, 24)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(2, 1)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(135, 20)
        Me.IDTextBox.TabIndex = 6
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "InsertDate", True))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Location = New System.Drawing.Point(222, 1)
        Me.InsertDateTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = True
        Me.InsertDateTextBox.Size = New System.Drawing.Size(159, 20)
        Me.InsertDateTextBox.TabIndex = 7
        Me.InsertDateTextBox.TabStop = False
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UpdateDateTextBox
        '
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsOperationDiscountBindingSource, "UpdateDate", True))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(471, 1)
        Me.UpdateDateTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = True
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(159, 20)
        Me.UpdateDateTextBox.TabIndex = 9
        Me.UpdateDateTextBox.TabStop = False
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.EditedBaner)
        Me.Panel2.Controls.Add(Me.nCancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.nOkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 517)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel2.Size = New System.Drawing.Size(782, 37)
        Me.Panel2.TabIndex = 2
        '
        'EditedBaner
        '
        Me.EditedBaner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditedBaner.BackColor = System.Drawing.Color.Red
        Me.EditedBaner.Controls.Add(Me.Label4)
        Me.EditedBaner.Location = New System.Drawing.Point(431, 5)
        Me.EditedBaner.Name = "EditedBaner"
        Me.EditedBaner.Size = New System.Drawing.Size(83, 25)
        Me.EditedBaner.TabIndex = 51
        Me.EditedBaner.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "TAISOMA"
        '
        'nCancelButton
        '
        Me.nCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.nCancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nCancelButton.Location = New System.Drawing.Point(695, 7)
        Me.nCancelButton.Name = "nCancelButton"
        Me.nCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.nCancelButton.TabIndex = 2
        Me.nCancelButton.Text = "Atšaukti"
        Me.nCancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(614, 7)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 1
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'nOkButton
        '
        Me.nOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nOkButton.Location = New System.Drawing.Point(533, 7)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(75, 23)
        Me.nOkButton.TabIndex = 0
        Me.nOkButton.Text = "OK"
        Me.nOkButton.UseVisualStyleBackColor = True
        '
        'ConsignmentsBindingSource
        '
        Me.ConsignmentsBindingSource.DataMember = "Consignments"
        Me.ConsignmentsBindingSource.DataSource = Me.GoodsOperationDiscountBindingSource
        '
        'ConsignmentsDataGridView
        '
        Me.ConsignmentsDataGridView.AllowUserToAddRows = False
        Me.ConsignmentsDataGridView.AllowUserToDeleteRows = False
        Me.ConsignmentsDataGridView.AllowUserToOrderColumns = True
        Me.ConsignmentsDataGridView.AutoGenerateColumns = False
        Me.ConsignmentsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ConsignmentsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ConsignmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ConsignmentsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20})
        Me.ConsignmentsDataGridView.DataSource = Me.ConsignmentsBindingSource
        Me.ConsignmentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConsignmentsDataGridView.Location = New System.Drawing.Point(0, 350)
        Me.ConsignmentsDataGridView.Name = "ConsignmentsDataGridView"
        Me.ConsignmentsDataGridView.RowHeadersVisible = False
        Me.ConsignmentsDataGridView.RowHeadersWidth = 20
        Me.ConsignmentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ConsignmentsDataGridView.Size = New System.Drawing.Size(782, 167)
        Me.ConsignmentsDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ParentID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ParentID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "AcquisitionID"
        Me.DataGridViewTextBoxColumn3.HeaderText = "AcquisitionID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "UpdatedConsignmentID"
        Me.DataGridViewTextBoxColumn5.HeaderText = "UpdatedConsignmentID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ConsignmentDiscardID"
        Me.DataGridViewTextBoxColumn6.HeaderText = "ConsignmentDiscardID"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "AcquisitionDate"
        DataGridViewCellStyle2.Format = "d"
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn15.HeaderText = "Įsig. Data"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "AcquisitionDocNo"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Įsig. Dok. Nr."
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "AcquisitionDocTypeHumanReadable"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Įsig. Dok. Tipas"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Amount"
        DataGridViewCellStyle3.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn7.HeaderText = "Įsig. Kiekis"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "UnitValue"
        DataGridViewCellStyle4.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn8.HeaderText = "Įsig. Vnt. Kaina"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "TotalValue"
        DataGridViewCellStyle5.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn9.HeaderText = "Įsig. Viso Kaina"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "AmountWithdrawn"
        DataGridViewCellStyle6.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn10.HeaderText = "Perleista Kiekis"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "TotalValueWithdrawn"
        DataGridViewCellStyle7.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn11.HeaderText = "Perleista Vertė"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "AmountLeft"
        DataGridViewCellStyle8.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn12.HeaderText = "Likutis Kiekis"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "TotalValueLeft"
        DataGridViewCellStyle9.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn13.HeaderText = "Likutis Vertė"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "UnitValueChange"
        DataGridViewCellStyle10.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn19.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn19.HeaderText = "Nuolaida Vnt. Kaina"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AllowNegative = False
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "TotalValueChange"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn20.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn20.HeaderText = "Nuolaida Viso"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.GoodsOperationDiscountBindingSource
        '
        'F_GoodsOperationDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 554)
        Me.Controls.Add(Me.ConsignmentsDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_GoodsOperationDiscount"
        Me.ShowInTaskbar = False
        Me.Text = "Nuolaida Prekėms"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.TableLayoutPanel11.PerformLayout()
        CType(Me.GoodsOperationDiscountBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.EditedBaner.ResumeLayout(False)
        Me.EditedBaner.PerformLayout()
        CType(Me.ConsignmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConsignmentsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents MeasureUnitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GoodsOperationDiscountBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AccountingMethodHumanReadableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValuationMethodHumanReadableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryTypeHumanReadableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AccountGoodsGeneralTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents JournalEntryContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryCorrespondenceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents WarehouseAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents AccountGoodsNetCostsAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents AccountPurchasesIsClosedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TotalValueChangeAccTextBox As AccControls.AccTextBox
    Friend WithEvents TotalGoodsValueChangeAccTextBox As AccControls.AccTextBox
    Friend WithEvents TotalNetValueChangeAccTextBox As AccControls.AccTextBox
    Friend WithEvents LimitationsButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RefreshJournalEntryInfoButton As System.Windows.Forms.Button
    Friend WithEvents JournalEntryInfoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AttachJournalEntryInfoButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents EditedBaner As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nCancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents nOkButton As System.Windows.Forms.Button
    Friend WithEvents ConsignmentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ConsignmentsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
End Class
