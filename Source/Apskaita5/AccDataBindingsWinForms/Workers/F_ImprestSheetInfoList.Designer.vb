<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_ImprestSheetInfoList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_ImprestSheetInfoList))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.NewButton = New System.Windows.Forms.Button
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ImprestSheetInfoListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprestSheetInfoListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn4 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn5 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn6 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn7 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn8 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.DateFromAccDatePicker = New AccControlsWinForms.AccDatePicker
        Me.DateToAccDatePicker = New AccControlsWinForms.AccDatePicker
        CType(Me.ImprestSheetInfoListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ImprestSheetInfoListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(733, 6)
        Me.Panel1.TabIndex = 1
        '
        'NewButton
        '
        Me.NewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NewButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Action_file_new_icon_24p
        Me.NewButton.Location = New System.Drawing.Point(472, 15)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(33, 33)
        Me.NewButton.TabIndex = 2
        Me.NewButton.UseVisualStyleBackColor = True
        '
        'RefreshButton
        '
        Me.RefreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RefreshButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(413, 15)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(33, 33)
        Me.RefreshButton.TabIndex = 1
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(199, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(25, 18)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Iki:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label10.Size = New System.Drawing.Size(34, 18)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Nuo:"
        '
        'ImprestSheetInfoListBindingSource
        '
        Me.ImprestSheetInfoListBindingSource.DataSource = GetType(ApskaitaObjects.ActiveReports.ImprestSheetInfo)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateFromAccDatePicker, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateToAccDatePicker, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(383, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro kriterijai"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.NewButton, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.RefreshButton, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 6)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(733, 51)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeItem_MenuItem, Me.DeleteItem_MenuItem, Me.NewItem_MenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(111, 70)
        '
        'ChangeItem_MenuItem
        '
        Me.ChangeItem_MenuItem.Name = "ChangeItem_MenuItem"
        Me.ChangeItem_MenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ChangeItem_MenuItem.Text = "Keisti"
        '
        'DeleteItem_MenuItem
        '
        Me.DeleteItem_MenuItem.Name = "DeleteItem_MenuItem"
        Me.DeleteItem_MenuItem.Size = New System.Drawing.Size(110, 22)
        Me.DeleteItem_MenuItem.Text = "Ištrinti"
        '
        'NewItem_MenuItem
        '
        Me.NewItem_MenuItem.Name = "NewItem_MenuItem"
        Me.NewItem_MenuItem.Size = New System.Drawing.Size(110, 22)
        Me.NewItem_MenuItem.Text = "Naujas"
        '
        'ImprestSheetInfoListDataListView
        '
        Me.ImprestSheetInfoListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.ImprestSheetInfoListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.ImprestSheetInfoListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.ImprestSheetInfoListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.ImprestSheetInfoListDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.ImprestSheetInfoListDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.ImprestSheetInfoListDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.ImprestSheetInfoListDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.ImprestSheetInfoListDataListView.AllowColumnReorder = True
        Me.ImprestSheetInfoListDataListView.AutoGenerateColumns = False
        Me.ImprestSheetInfoListDataListView.CausesValidation = False
        Me.ImprestSheetInfoListDataListView.CellEditUseWholeCell = False
        Me.ImprestSheetInfoListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn8})
        Me.ImprestSheetInfoListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ImprestSheetInfoListDataListView.DataSource = Me.ImprestSheetInfoListBindingSource
        Me.ImprestSheetInfoListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImprestSheetInfoListDataListView.FullRowSelect = True
        Me.ImprestSheetInfoListDataListView.HasCollapsibleGroups = False
        Me.ImprestSheetInfoListDataListView.HeaderWordWrap = True
        Me.ImprestSheetInfoListDataListView.HideSelection = False
        Me.ImprestSheetInfoListDataListView.IncludeColumnHeadersInCopy = True
        Me.ImprestSheetInfoListDataListView.Location = New System.Drawing.Point(0, 57)
        Me.ImprestSheetInfoListDataListView.Name = "ImprestSheetInfoListDataListView"
        Me.ImprestSheetInfoListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.ImprestSheetInfoListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.ImprestSheetInfoListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ImprestSheetInfoListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.ImprestSheetInfoListDataListView.ShowCommandMenuOnRightClick = True
        Me.ImprestSheetInfoListDataListView.ShowGroups = False
        Me.ImprestSheetInfoListDataListView.ShowImagesOnSubItems = True
        Me.ImprestSheetInfoListDataListView.ShowItemCountOnGroups = True
        Me.ImprestSheetInfoListDataListView.ShowItemToolTips = True
        Me.ImprestSheetInfoListDataListView.Size = New System.Drawing.Size(733, 385)
        Me.ImprestSheetInfoListDataListView.TabIndex = 4
        Me.ImprestSheetInfoListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ImprestSheetInfoListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.ImprestSheetInfoListDataListView.UseCellFormatEvents = True
        Me.ImprestSheetInfoListDataListView.UseCompatibleStateImageBehavior = False
        Me.ImprestSheetInfoListDataListView.UseFilterIndicator = True
        Me.ImprestSheetInfoListDataListView.UseFiltering = True
        Me.ImprestSheetInfoListDataListView.UseHotItem = True
        Me.ImprestSheetInfoListDataListView.UseNotifyPropertyChanged = True
        Me.ImprestSheetInfoListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Date"
        Me.OlvColumn2.AspectToStringFormat = "{0:d}"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Data"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 110
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "ID"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.DisplayIndex = 1
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.IsVisible = False
        Me.OlvColumn1.Text = "ID"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 45
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "Number"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.Text = "Nr."
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 91
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "Year"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.Text = "Metai"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 63
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "Month"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = False
        Me.OlvColumn5.Text = "Mėnuo"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 70
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "WorkersCount"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = False
        Me.OlvColumn6.Text = "Darb. sk."
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 84
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "TotalSum"
        Me.OlvColumn7.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = False
        Me.OlvColumn7.Text = "Suma"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 128
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "TotalSumPayedOut"
        Me.OlvColumn8.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.Text = "Suma išmok."
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 335
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(155, 76)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(146, 65)
        Me.ProgressFiller1.TabIndex = 5
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(325, 78)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(202, 63)
        Me.ProgressFiller2.TabIndex = 6
        Me.ProgressFiller2.Visible = False
        '
        'DateFromAccDatePicker
        '
        Me.DateFromAccDatePicker.BoldedDates = Nothing
        Me.DateFromAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateFromAccDatePicker.Location = New System.Drawing.Point(43, 3)
        Me.DateFromAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateFromAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateFromAccDatePicker.Name = "DateFromAccDatePicker"
        Me.DateFromAccDatePicker.ReadOnly = False
        Me.DateFromAccDatePicker.ShowWeekNumbers = True
        Me.DateFromAccDatePicker.Size = New System.Drawing.Size(150, 23)
        Me.DateFromAccDatePicker.TabIndex = 0
        '
        'DateToAccDatePicker
        '
        Me.DateToAccDatePicker.BoldedDates = Nothing
        Me.DateToAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateToAccDatePicker.Location = New System.Drawing.Point(230, 3)
        Me.DateToAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateToAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateToAccDatePicker.Name = "DateToAccDatePicker"
        Me.DateToAccDatePicker.ReadOnly = False
        Me.DateToAccDatePicker.ShowWeekNumbers = True
        Me.DateToAccDatePicker.Size = New System.Drawing.Size(150, 23)
        Me.DateToAccDatePicker.TabIndex = 1
        '
        'F_ImprestSheetInfoList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 442)
        Me.Controls.Add(Me.ImprestSheetInfoListDataListView)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_ImprestSheetInfoList"
        Me.ShowInTaskbar = False
        Me.Text = "Avanso žiniaraščių suvestinė"
        CType(Me.ImprestSheetInfoListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ImprestSheetInfoListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NewButton As System.Windows.Forms.Button
    Friend WithEvents ImprestSheetInfoListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangeItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprestSheetInfoListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn7 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn8 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents DateFromAccDatePicker As AccControlsWinForms.AccDatePicker
    Friend WithEvents DateToAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
