<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_AdvanceReport
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
        Dim AccountLabel As System.Windows.Forms.Label
        Dim CommentsLabel As System.Windows.Forms.Label
        Dim CommentsInternalLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim CurrencyCodeLabel As System.Windows.Forms.Label
        Dim CurrencyRateLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DocumentNumberLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim PersonLabel As System.Windows.Forms.Label
        Dim SumLabel As System.Windows.Forms.Label
        Dim SumTotalLabel As System.Windows.Forms.Label
        Dim SumVatLabel As System.Windows.Forms.Label
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_AdvanceReport))
        Me.AccountAccGridComboBox = New AccControls.AccGridComboBox
        Me.AdvanceReportBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CommentsTextBox = New System.Windows.Forms.TextBox
        Me.CommentsInternalTextBox = New System.Windows.Forms.TextBox
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.CurrencyCodeComboBox = New System.Windows.Forms.ComboBox
        Me.CurrencyRateAccTextBox = New AccControls.AccTextBox
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.DocumentNumberTextBox = New System.Windows.Forms.TextBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.PersonAccGridComboBox = New AccControls.AccGridComboBox
        Me.SumAccTextBox = New AccControls.AccTextBox
        Me.SumTotalAccTextBox = New AccControls.AccTextBox
        Me.SumVatAccTextBox = New AccControls.AccTextBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.CurrencyCodeLabel2 = New System.Windows.Forms.Label
        Me.GetCurrencyRatesButton = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.LimitationsButton = New System.Windows.Forms.Button
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel
        Me.DateToDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.DateFromDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.InvoicesMadeCheckBox = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PersonInfoAccGridComboBox = New AccControls.AccGridComboBox
        Me.InvoiceInfoListComboBox = New System.Windows.Forms.ComboBox
        Me.AddAdvanceReportItemButton = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.RefreshInvoiceInfoListButton = New System.Windows.Forms.Button
        Me.ReportItemsSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportItemsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New AccControls.CalendarColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn6 = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.DataGridViewTextBoxColumn7 = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.DataGridViewTextBoxColumn8 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New AccControls.DataGridViewNumericUpDownColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New AccControls.DataGridViewNumericUpDownColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New AccControls.DataGridViewNumericUpDownColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurrencyRateChangeEffect = New AccControls.DataGridViewAccTextBoxColumn
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDateAndNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        AccountLabel = New System.Windows.Forms.Label
        CommentsLabel = New System.Windows.Forms.Label
        CommentsInternalLabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        CurrencyCodeLabel = New System.Windows.Forms.Label
        CurrencyRateLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        DocumentNumberLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        PersonLabel = New System.Windows.Forms.Label
        SumLabel = New System.Windows.Forms.Label
        SumTotalLabel = New System.Windows.Forms.Label
        SumVatLabel = New System.Windows.Forms.Label
        CType(Me.AdvanceReportBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.ReportItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountLabel
        '
        AccountLabel.AutoSize = True
        AccountLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountLabel.Location = New System.Drawing.Point(3, 60)
        AccountLabel.Name = "AccountLabel"
        AccountLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        AccountLabel.Size = New System.Drawing.Size(120, 30)
        AccountLabel.TabIndex = 1
        AccountLabel.Text = "Atskaitingo sąsk.:"
        AccountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CommentsLabel
        '
        CommentsLabel.AutoSize = True
        CommentsLabel.Dock = System.Windows.Forms.DockStyle.Fill
        CommentsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CommentsLabel.Location = New System.Drawing.Point(3, 120)
        CommentsLabel.Name = "CommentsLabel"
        CommentsLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        CommentsLabel.Size = New System.Drawing.Size(120, 30)
        CommentsLabel.TabIndex = 3
        CommentsLabel.Text = "Komentarai:"
        CommentsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CommentsInternalLabel
        '
        CommentsInternalLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CommentsInternalLabel.AutoSize = True
        CommentsInternalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CommentsInternalLabel.Location = New System.Drawing.Point(5, 150)
        CommentsInternalLabel.Name = "CommentsInternalLabel"
        CommentsInternalLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        CommentsInternalLabel.Size = New System.Drawing.Size(118, 19)
        CommentsInternalLabel.TabIndex = 5
        CommentsInternalLabel.Text = "Vidiniai komentarai:"
        CommentsInternalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ContentLabel
        '
        ContentLabel.AutoSize = True
        ContentLabel.Dock = System.Windows.Forms.DockStyle.Fill
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(3, 90)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        ContentLabel.Size = New System.Drawing.Size(120, 30)
        ContentLabel.TabIndex = 7
        ContentLabel.Text = "Turinys:"
        ContentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CurrencyCodeLabel
        '
        CurrencyCodeLabel.AutoSize = True
        CurrencyCodeLabel.Dock = System.Windows.Forms.DockStyle.Fill
        CurrencyCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyCodeLabel.Location = New System.Drawing.Point(163, 0)
        CurrencyCodeLabel.Name = "CurrencyCodeLabel"
        CurrencyCodeLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        CurrencyCodeLabel.Size = New System.Drawing.Size(50, 30)
        CurrencyCodeLabel.TabIndex = 9
        CurrencyCodeLabel.Text = "Valiuta:"
        CurrencyCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CurrencyRateLabel
        '
        CurrencyRateLabel.AutoSize = True
        CurrencyRateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        CurrencyRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateLabel.Location = New System.Drawing.Point(339, 0)
        CurrencyRateLabel.Name = "CurrencyRateLabel"
        CurrencyRateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        CurrencyRateLabel.Size = New System.Drawing.Size(49, 30)
        CurrencyRateLabel.TabIndex = 11
        CurrencyRateLabel.Text = "Kursas:"
        CurrencyRateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(134, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        DateLabel.Size = New System.Drawing.Size(38, 30)
        DateLabel.TabIndex = 13
        DateLabel.Text = "Data:"
        DateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DocumentNumberLabel
        '
        DocumentNumberLabel.AutoSize = True
        DocumentNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill
        DocumentNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocumentNumberLabel.Location = New System.Drawing.Point(348, 0)
        DocumentNumberLabel.Name = "DocumentNumberLabel"
        DocumentNumberLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        DocumentNumberLabel.Size = New System.Drawing.Size(28, 30)
        DocumentNumberLabel.TabIndex = 15
        DocumentNumberLabel.Text = "Nr.:"
        DocumentNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Dock = System.Windows.Forms.DockStyle.Fill
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(3, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        IDLabel.Size = New System.Drawing.Size(120, 30)
        IDLabel.TabIndex = 17
        IDLabel.Text = "ID:"
        IDLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PersonLabel
        '
        PersonLabel.AutoSize = True
        PersonLabel.Dock = System.Windows.Forms.DockStyle.Fill
        PersonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PersonLabel.Location = New System.Drawing.Point(3, 30)
        PersonLabel.Name = "PersonLabel"
        PersonLabel.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        PersonLabel.Size = New System.Drawing.Size(120, 30)
        PersonLabel.TabIndex = 19
        PersonLabel.Text = "Atskaitingas asmuo:"
        PersonLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SumLabel
        '
        SumLabel.AutoSize = True
        SumLabel.Dock = System.Windows.Forms.DockStyle.Fill
        SumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLabel.Location = New System.Drawing.Point(11, 33)
        SumLabel.Name = "SumLabel"
        SumLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        SumLabel.Size = New System.Drawing.Size(42, 27)
        SumLabel.TabIndex = 21
        SumLabel.Text = "Suma:"
        SumLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SumTotalLabel
        '
        SumTotalLabel.AutoSize = True
        SumTotalLabel.Dock = System.Windows.Forms.DockStyle.Fill
        SumTotalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumTotalLabel.Location = New System.Drawing.Point(11, 87)
        SumTotalLabel.Name = "SumTotalLabel"
        SumTotalLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        SumTotalLabel.Size = New System.Drawing.Size(42, 27)
        SumTotalLabel.TabIndex = 25
        SumTotalLabel.Text = "Viso:"
        SumTotalLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SumVatLabel
        '
        SumVatLabel.AutoSize = True
        SumVatLabel.Dock = System.Windows.Forms.DockStyle.Fill
        SumVatLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumVatLabel.Location = New System.Drawing.Point(11, 60)
        SumVatLabel.Name = "SumVatLabel"
        SumVatLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        SumVatLabel.Size = New System.Drawing.Size(42, 27)
        SumVatLabel.TabIndex = 29
        SumVatLabel.Text = "PVM:"
        SumVatLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AccountAccGridComboBox
        '
        Me.AccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.AdvanceReportBindingSource, "Account", True))
        Me.AccountAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountAccGridComboBox.FilterPropertyName = ""
        Me.AccountAccGridComboBox.FormattingEnabled = True
        Me.AccountAccGridComboBox.InstantBinding = True
        Me.AccountAccGridComboBox.Location = New System.Drawing.Point(0, 3)
        Me.AccountAccGridComboBox.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.AccountAccGridComboBox.Name = "AccountAccGridComboBox"
        Me.AccountAccGridComboBox.Size = New System.Drawing.Size(137, 21)
        Me.AccountAccGridComboBox.TabIndex = 0
        '
        'AdvanceReportBindingSource
        '
        Me.AdvanceReportBindingSource.DataSource = GetType(ApskaitaObjects.Documents.AdvanceReport)
        '
        'CommentsTextBox
        '
        Me.CommentsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdvanceReportBindingSource, "Comments", True))
        Me.CommentsTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommentsTextBox.Location = New System.Drawing.Point(3, 3)
        Me.CommentsTextBox.MaxLength = 255
        Me.CommentsTextBox.Name = "CommentsTextBox"
        Me.CommentsTextBox.Size = New System.Drawing.Size(547, 20)
        Me.CommentsTextBox.TabIndex = 0
        '
        'CommentsInternalTextBox
        '
        Me.CommentsInternalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdvanceReportBindingSource, "CommentsInternal", True))
        Me.CommentsInternalTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommentsInternalTextBox.Location = New System.Drawing.Point(3, 3)
        Me.CommentsInternalTextBox.MaxLength = 255
        Me.CommentsInternalTextBox.Multiline = True
        Me.CommentsInternalTextBox.Name = "CommentsInternalTextBox"
        Me.CommentsInternalTextBox.Size = New System.Drawing.Size(547, 24)
        Me.CommentsInternalTextBox.TabIndex = 0
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdvanceReportBindingSource, "Content", True))
        Me.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTextBox.Location = New System.Drawing.Point(3, 3)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(547, 20)
        Me.ContentTextBox.TabIndex = 0
        '
        'CurrencyCodeComboBox
        '
        Me.CurrencyCodeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdvanceReportBindingSource, "CurrencyCode", True))
        Me.CurrencyCodeComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyCodeComboBox.FormattingEnabled = True
        Me.CurrencyCodeComboBox.Location = New System.Drawing.Point(219, 3)
        Me.CurrencyCodeComboBox.Name = "CurrencyCodeComboBox"
        Me.CurrencyCodeComboBox.Size = New System.Drawing.Size(94, 21)
        Me.CurrencyCodeComboBox.TabIndex = 1
        '
        'CurrencyRateAccTextBox
        '
        Me.CurrencyRateAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.AdvanceReportBindingSource, "CurrencyRate", True))
        Me.CurrencyRateAccTextBox.DecimalLength = 6
        Me.CurrencyRateAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyRateAccTextBox.KeepBackColorWhenReadOnly = False
        Me.CurrencyRateAccTextBox.Location = New System.Drawing.Point(394, 3)
        Me.CurrencyRateAccTextBox.Name = "CurrencyRateAccTextBox"
        Me.CurrencyRateAccTextBox.NegativeValue = False
        Me.CurrencyRateAccTextBox.Size = New System.Drawing.Size(154, 20)
        Me.CurrencyRateAccTextBox.TabIndex = 2
        Me.CurrencyRateAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.AdvanceReportBindingSource, "Date", True))
        Me.DateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDateTimePicker.Location = New System.Drawing.Point(178, 3)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(144, 20)
        Me.DateDateTimePicker.TabIndex = 0
        '
        'DocumentNumberTextBox
        '
        Me.DocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdvanceReportBindingSource, "DocumentNumber", True))
        Me.DocumentNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberTextBox.Location = New System.Drawing.Point(382, 3)
        Me.DocumentNumberTextBox.MaxLength = 50
        Me.DocumentNumberTextBox.Name = "DocumentNumberTextBox"
        Me.DocumentNumberTextBox.Size = New System.Drawing.Size(165, 20)
        Me.DocumentNumberTextBox.TabIndex = 1
        Me.DocumentNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdvanceReportBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(3, 3)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(101, 20)
        Me.IDTextBox.TabIndex = 18
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PersonAccGridComboBox
        '
        Me.PersonAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.AdvanceReportBindingSource, "Person", True))
        Me.PersonAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonAccGridComboBox.FilterPropertyName = ""
        Me.PersonAccGridComboBox.FormattingEnabled = True
        Me.PersonAccGridComboBox.InstantBinding = True
        Me.PersonAccGridComboBox.Location = New System.Drawing.Point(3, 3)
        Me.PersonAccGridComboBox.Name = "PersonAccGridComboBox"
        Me.PersonAccGridComboBox.Size = New System.Drawing.Size(547, 21)
        Me.PersonAccGridComboBox.TabIndex = 0
        '
        'SumAccTextBox
        '
        Me.SumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.AdvanceReportBindingSource, "Sum", True))
        Me.SumAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumAccTextBox.Location = New System.Drawing.Point(59, 36)
        Me.SumAccTextBox.Name = "SumAccTextBox"
        Me.SumAccTextBox.ReadOnly = True
        Me.SumAccTextBox.Size = New System.Drawing.Size(107, 20)
        Me.SumAccTextBox.TabIndex = 22
        Me.SumAccTextBox.TabStop = False
        Me.SumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumTotalAccTextBox
        '
        Me.SumTotalAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.AdvanceReportBindingSource, "SumTotal", True))
        Me.SumTotalAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumTotalAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumTotalAccTextBox.Location = New System.Drawing.Point(59, 90)
        Me.SumTotalAccTextBox.Name = "SumTotalAccTextBox"
        Me.SumTotalAccTextBox.ReadOnly = True
        Me.SumTotalAccTextBox.Size = New System.Drawing.Size(107, 20)
        Me.SumTotalAccTextBox.TabIndex = 26
        Me.SumTotalAccTextBox.TabStop = False
        Me.SumTotalAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumVatAccTextBox
        '
        Me.SumVatAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.AdvanceReportBindingSource, "SumVat", True))
        Me.SumVatAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumVatAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumVatAccTextBox.Location = New System.Drawing.Point(59, 63)
        Me.SumVatAccTextBox.Name = "SumVatAccTextBox"
        Me.SumVatAccTextBox.ReadOnly = True
        Me.SumVatAccTextBox.Size = New System.Drawing.Size(107, 20)
        Me.SumVatAccTextBox.TabIndex = 30
        Me.SumVatAccTextBox.TabStop = False
        Me.SumVatAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel1.Controls.Add(SumLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(SumVatLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(SumTotalLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrencyCodeLabel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.SumAccTextBox, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.SumTotalAccTextBox, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.SumVatAccTextBox, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.GetCurrencyRatesButton, 1, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(708, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(186, 163)
        Me.TableLayoutPanel1.TabIndex = 33
        '
        'CurrencyCodeLabel2
        '
        Me.CurrencyCodeLabel2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdvanceReportBindingSource, "CurrencyCode", True))
        Me.CurrencyCodeLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyCodeLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrencyCodeLabel2.Location = New System.Drawing.Point(59, 0)
        Me.CurrencyCodeLabel2.Name = "CurrencyCodeLabel2"
        Me.CurrencyCodeLabel2.Size = New System.Drawing.Size(107, 23)
        Me.CurrencyCodeLabel2.TabIndex = 35
        Me.CurrencyCodeLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GetCurrencyRatesButton
        '
        Me.GetCurrencyRatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetCurrencyRatesButton.Location = New System.Drawing.Point(59, 137)
        Me.GetCurrencyRatesButton.Name = "GetCurrencyRatesButton"
        Me.GetCurrencyRatesButton.Size = New System.Drawing.Size(63, 23)
        Me.GetCurrencyRatesButton.TabIndex = 0
        Me.GetCurrencyRatesButton.Text = "$->LTL"
        Me.GetCurrencyRatesButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.63145!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.36855!))
        Me.TableLayoutPanel2.Controls.Add(Me.LimitationsButton, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(897, 303)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'LimitationsButton
        '
        Me.LimitationsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LimitationsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_lock_icon_32p
        Me.LimitationsButton.Location = New System.Drawing.Point(844, 260)
        Me.LimitationsButton.Name = "LimitationsButton"
        Me.LimitationsButton.Size = New System.Drawing.Size(50, 40)
        Me.LimitationsButton.TabIndex = 2
        Me.LimitationsButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel11, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel5, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel9, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel10, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel8, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(AccountLabel, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(PersonLabel, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(CommentsInternalLabel, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(CommentsLabel, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(ContentLabel, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(699, 180)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.ColumnCount = 2
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.CommentsInternalTextBox, 0, 0)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(126, 150)
        Me.TableLayoutPanel11.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 1
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(573, 30)
        Me.TableLayoutPanel11.TabIndex = 5
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 8
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.AccountAccGridComboBox, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(CurrencyCodeLabel, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.CurrencyCodeComboBox, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(CurrencyRateLabel, 5, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.CurrencyRateAccTextBox, 6, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(126, 60)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(573, 30)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.CommentsTextBox, 0, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(126, 120)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(573, 30)
        Me.TableLayoutPanel9.TabIndex = 4
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 2
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.ContentTextBox, 0, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(126, 90)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(573, 30)
        Me.TableLayoutPanel10.TabIndex = 3
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.PersonAccGridComboBox, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(126, 30)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(573, 30)
        Me.TableLayoutPanel8.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 8
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.ViewJournalEntryButton, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(DateLabel, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DateDateTimePicker, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(DocumentNumberLabel, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DocumentNumberTextBox, 6, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(126, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(573, 30)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.ApskaitaWUI.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(107, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 89
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 183)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(699, 117)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pridėti eilutę su sąskaita faktūra"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel7, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.PersonInfoAccGridComboBox, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.InvoiceInfoListComboBox, 1, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.AddAdvanceReportItemButton, 2, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.RefreshInvoiceInfoListButton, 2, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(693, 98)
        Me.TableLayoutPanel6.TabIndex = 35
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 5
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel7.Controls.Add(Me.DateToDateTimePicker, 3, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.DateFromDateTimePicker, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.InvoicesMadeCheckBox, 4, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(125, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(524, 29)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'DateToDateTimePicker
        '
        Me.DateToDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateToDateTimePicker.Location = New System.Drawing.Point(246, 3)
        Me.DateToDateTimePicker.Name = "DateToDateTimePicker"
        Me.DateToDateTimePicker.Size = New System.Drawing.Size(192, 20)
        Me.DateToDateTimePicker.TabIndex = 1
        '
        'DateFromDateTimePicker
        '
        Me.DateFromDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFromDateTimePicker.Location = New System.Drawing.Point(3, 3)
        Me.DateFromDateTimePicker.Name = "DateFromDateTimePicker"
        Me.DateFromDateTimePicker.Size = New System.Drawing.Size(192, 20)
        Me.DateFromDateTimePicker.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(216, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(24, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "iki:"
        '
        'InvoicesMadeCheckBox
        '
        Me.InvoicesMadeCheckBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.InvoicesMadeCheckBox.AutoSize = True
        Me.InvoicesMadeCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvoicesMadeCheckBox.Location = New System.Drawing.Point(444, 3)
        Me.InvoicesMadeCheckBox.Name = "InvoicesMadeCheckBox"
        Me.InvoicesMadeCheckBox.Size = New System.Drawing.Size(76, 23)
        Me.InvoicesMadeCheckBox.TabIndex = 2
        Me.InvoicesMadeCheckBox.Text = "Išrašytos"
        Me.InvoicesMadeCheckBox.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(86, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kontrahentas:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(63, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Data nuo:"
        '
        'PersonInfoAccGridComboBox
        '
        Me.PersonInfoAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonInfoAccGridComboBox.FilterPropertyName = ""
        Me.PersonInfoAccGridComboBox.FormattingEnabled = True
        Me.PersonInfoAccGridComboBox.InstantBinding = True
        Me.PersonInfoAccGridComboBox.Location = New System.Drawing.Point(125, 41)
        Me.PersonInfoAccGridComboBox.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.PersonInfoAccGridComboBox.Name = "PersonInfoAccGridComboBox"
        Me.PersonInfoAccGridComboBox.Size = New System.Drawing.Size(524, 21)
        Me.PersonInfoAccGridComboBox.TabIndex = 0
        '
        'InvoiceInfoListComboBox
        '
        Me.InvoiceInfoListComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InvoiceInfoListComboBox.FormattingEnabled = True
        Me.InvoiceInfoListComboBox.Location = New System.Drawing.Point(125, 68)
        Me.InvoiceInfoListComboBox.Name = "InvoiceInfoListComboBox"
        Me.InvoiceInfoListComboBox.Size = New System.Drawing.Size(524, 21)
        Me.InvoiceInfoListComboBox.TabIndex = 1
        '
        'AddAdvanceReportItemButton
        '
        Me.AddAdvanceReportItemButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddAdvanceReportItemButton.Location = New System.Drawing.Point(660, 65)
        Me.AddAdvanceReportItemButton.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.AddAdvanceReportItemButton.Name = "AddAdvanceReportItemButton"
        Me.AddAdvanceReportItemButton.Size = New System.Drawing.Size(33, 31)
        Me.AddAdvanceReportItemButton.TabIndex = 2
        Me.AddAdvanceReportItemButton.Text = "+"
        Me.AddAdvanceReportItemButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(116, 16)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Sąskaitos faktūros:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'RefreshInvoiceInfoListButton
        '
        Me.RefreshInvoiceInfoListButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshInvoiceInfoListButton.Location = New System.Drawing.Point(660, 0)
        Me.RefreshInvoiceInfoListButton.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.RefreshInvoiceInfoListButton.Name = "RefreshInvoiceInfoListButton"
        Me.RefreshInvoiceInfoListButton.Size = New System.Drawing.Size(33, 33)
        Me.RefreshInvoiceInfoListButton.TabIndex = 1
        Me.RefreshInvoiceInfoListButton.UseVisualStyleBackColor = True
        '
        'ReportItemsSortedBindingSource
        '
        Me.ReportItemsSortedBindingSource.DataMember = "ReportItemsSorted"
        Me.ReportItemsSortedBindingSource.DataSource = Me.AdvanceReportBindingSource
        '
        'ReportItemsDataGridView
        '
        Me.ReportItemsDataGridView.AllowUserToOrderColumns = True
        Me.ReportItemsDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReportItemsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ReportItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReportItemsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.CurrencyRateChangeEffect, Me.AccountCurrencyRateChangeEffectDataGridViewColumn, Me.DataGridViewTextBoxColumn18, Me.InvoiceDateAndNumber, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28})
        Me.ReportItemsDataGridView.DataSource = Me.ReportItemsSortedBindingSource
        Me.ReportItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportItemsDataGridView.Location = New System.Drawing.Point(0, 303)
        Me.ReportItemsDataGridView.Name = "ReportItemsDataGridView"
        Me.ReportItemsDataGridView.Size = New System.Drawing.Size(897, 201)
        Me.ReportItemsDataGridView.TabIndex = 1
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Date"
        DataGridViewCellStyle2.Format = "d"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "Data"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DocumentNumber"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Dok. Nr."
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.CloseOnSingleClick = True
        Me.DataGridViewTextBoxColumn4.ComboDataGridView = Nothing
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Person"
        Me.DataGridViewTextBoxColumn4.FilterPropertyName = ""
        Me.DataGridViewTextBoxColumn4.HeaderText = "Kontrahentas"
        Me.DataGridViewTextBoxColumn4.InstantBinding = True
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.ValueMember = ""
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Content"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Turinys"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "Income"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Pajamos"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "Expenses"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Išlaidos"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.CloseOnSingleClick = True
        Me.DataGridViewTextBoxColumn6.ComboDataGridView = Nothing
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Account"
        Me.DataGridViewTextBoxColumn6.FilterPropertyName = ""
        Me.DataGridViewTextBoxColumn6.HeaderText = "Koresp. sąsk."
        Me.DataGridViewTextBoxColumn6.InstantBinding = True
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.ValueMember = ""
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.CloseOnSingleClick = True
        Me.DataGridViewTextBoxColumn7.ComboDataGridView = Nothing
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "AccountVat"
        Me.DataGridViewTextBoxColumn7.FilterPropertyName = ""
        Me.DataGridViewTextBoxColumn7.HeaderText = "Koresp. PVM sąsk."
        Me.DataGridViewTextBoxColumn7.InstantBinding = True
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.ValueMember = ""
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AllowNegative = False
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Sum"
        DataGridViewCellStyle3.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn8.HeaderText = "Suma"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "VatRate"
        Me.DataGridViewTextBoxColumn9.HeaderText = "PVM tarifas"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "SumVat"
        DataGridViewCellStyle4.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn10.HeaderText = "Suma PVM"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "SumVatCorrection"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Sumos PVM korekc."
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "SumTotal"
        DataGridViewCellStyle5.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn12.HeaderText = "Suma viso"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "SumLTL"
        DataGridViewCellStyle6.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn13.HeaderText = "Suma LTL"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "SumCorrectionLTL"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Sumos LTL korekc."
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "SumVatLTL"
        DataGridViewCellStyle7.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn15.HeaderText = "Suma PVM LTL"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "SumVatCorrectionLTL"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Sumos PVM LTL korekc."
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "SumTotalLTL"
        DataGridViewCellStyle8.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn17.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn17.HeaderText = "Suma viso LTL"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'CurrencyRateChangeEffect
        '
        Me.CurrencyRateChangeEffect.DataPropertyName = "CurrencyRateChangeEffect"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "##,0.00"
        Me.CurrencyRateChangeEffect.DefaultCellStyle = DataGridViewCellStyle9
        Me.CurrencyRateChangeEffect.HeaderText = "Kurso pasik. įtaka"
        Me.CurrencyRateChangeEffect.MaxInputLength = 15
        Me.CurrencyRateChangeEffect.Name = "CurrencyRateChangeEffect"
        Me.CurrencyRateChangeEffect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CurrencyRateChangeEffect.Visible = False
        '
        'AccountCurrencyRateChangeEffectDataGridViewColumn
        '
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.CloseOnSingleClick = True
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.ComboDataGridView = Nothing
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.DataPropertyName = "AccountCurrencyRateChangeEffect"
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.FilterPropertyName = ""
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.HeaderText = "Kurso pasik. įtakos sąsk."
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.InstantBinding = True
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.Name = "AccountCurrencyRateChangeEffectDataGridViewColumn"
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.ValueMember = ""
        Me.AccountCurrencyRateChangeEffectDataGridViewColumn.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "InvoiceID"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Sąskaitos ID"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Visible = False
        '
        'InvoiceDateAndNumber
        '
        Me.InvoiceDateAndNumber.DataPropertyName = "InvoiceDateAndNumber"
        Me.InvoiceDateAndNumber.HeaderText = "Sąskaitos data ir Nr."
        Me.InvoiceDateAndNumber.Name = "InvoiceDateAndNumber"
        Me.InvoiceDateAndNumber.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "InvoiceContent"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Sąskaitos turinys"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Visible = False
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "InvoiceCurrencyCode"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Sąskaitos valiuta"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "InvoiceCurrencyRate"
        DataGridViewCellStyle10.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn21.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn21.HeaderText = "Sąskaitos kursas"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Visible = False
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "InvoiceSumOriginal"
        DataGridViewCellStyle11.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn22.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn22.HeaderText = "Sąskaitos suma"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Visible = False
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "InvoiceSumVatOriginal"
        DataGridViewCellStyle12.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn23.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn23.HeaderText = "Sąskaitos PVM suma"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Visible = False
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "InvoiceSumTotalOriginal"
        DataGridViewCellStyle13.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn24.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn24.HeaderText = "Sąskaitos suma viso"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Visible = False
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "InvoiceSumLTL"
        DataGridViewCellStyle14.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn25.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn25.HeaderText = "Sąskaitos suma LTL"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Visible = False
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "InvoiceSumVatLTL"
        DataGridViewCellStyle15.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn26.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn26.HeaderText = "Sąskaitos PVM suma LTL"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Visible = False
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "InvoiceSumTotalLTL"
        DataGridViewCellStyle16.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn27.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn27.HeaderText = "Sąskaitos suma viso LTL"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Visible = False
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "InvoiceSumTotal"
        DataGridViewCellStyle17.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn28.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn28.HeaderText = "Sąskaitos suma apyskaitoje"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 504)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(897, 32)
        Me.Panel2.TabIndex = 2
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(796, 6)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(89, 23)
        Me.ICancelButton.TabIndex = 14
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(590, 6)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(89, 23)
        Me.IOkButton.TabIndex = 13
        Me.IOkButton.Text = "Ok"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(694, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 12
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.AdvanceReportBindingSource
        '
        'F_AdvanceReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 536)
        Me.Controls.Add(Me.ReportItemsDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_AdvanceReport"
        Me.ShowInTaskbar = False
        Me.Text = "Avanso apyskaita"
        CType(Me.AdvanceReportBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.TableLayoutPanel11.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        CType(Me.ReportItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AdvanceReportBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents CommentsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentsInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyCodeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CurrencyRateAccTextBox As AccControls.AccTextBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PersonAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents SumAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumTotalAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumVatAccTextBox As AccControls.AccTextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CurrencyCodeLabel2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DateToDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFromDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RefreshInvoiceInfoListButton As System.Windows.Forms.Button
    Friend WithEvents AddAdvanceReportItemButton As System.Windows.Forms.Button
    Friend WithEvents ReportItemsSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportItemsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents GetCurrencyRatesButton As System.Windows.Forms.Button
    Friend WithEvents InvoiceInfoListComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents InvoicesMadeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PersonInfoAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As AccControls.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As AccControls.DataGridViewNumericUpDownColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As AccControls.DataGridViewNumericUpDownColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As AccControls.DataGridViewNumericUpDownColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencyRateChangeEffect As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents AccountCurrencyRateChangeEffectDataGridViewColumn As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDateAndNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LimitationsButton As System.Windows.Forms.Button
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
End Class
