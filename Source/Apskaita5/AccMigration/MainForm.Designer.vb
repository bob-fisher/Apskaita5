<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Label1 = New System.Windows.Forms.Label
        Me.MigrateButton = New System.Windows.Forms.Button
        Me.HostTextBox = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label5 = New System.Windows.Forms.Label
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.DatabaseTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.MySqlPasswordTextBox = New System.Windows.Forms.TextBox
        Me.UserTextBox = New System.Windows.Forms.TextBox
        Me.MySqlPasswordLabel = New System.Windows.Forms.Label
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.PortTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.UserLabel = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.OpenSqliteFileButton = New System.Windows.Forms.Button
        Me.SqlitePasswordTextBox = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.FileTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ToMySqlRadioButton = New System.Windows.Forms.RadioButton
        Me.ToSqliteRadioButton = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serverio Adresas:"
        '
        'MigrateButton
        '
        Me.MigrateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MigrateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MigrateButton.Location = New System.Drawing.Point(734, 212)
        Me.MigrateButton.Name = "MigrateButton"
        Me.MigrateButton.Size = New System.Drawing.Size(75, 23)
        Me.MigrateButton.TabIndex = 1
        Me.MigrateButton.Text = "Migruoti"
        Me.MigrateButton.UseVisualStyleBackColor = True
        '
        'HostTextBox
        '
        Me.HostTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HostTextBox.Location = New System.Drawing.Point(3, 3)
        Me.HostTextBox.MaxLength = 255
        Me.HostTextBox.Name = "HostTextBox"
        Me.HostTextBox.Size = New System.Drawing.Size(513, 20)
        Me.HostTextBox.TabIndex = 2
        Me.HostTextBox.Text = "localhost"
        Me.HostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(821, 106)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MySql Prisijungimo Duomenys"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.UserLabel, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(815, 87)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 66)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Duomenų Bazė:"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.DatabaseTextBox, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(113, 60)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(702, 30)
        Me.TableLayoutPanel5.TabIndex = 8
        '
        'DatabaseTextBox
        '
        Me.DatabaseTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatabaseTextBox.Location = New System.Drawing.Point(3, 3)
        Me.DatabaseTextBox.MaxLength = 255
        Me.DatabaseTextBox.Name = "DatabaseTextBox"
        Me.DatabaseTextBox.Size = New System.Drawing.Size(285, 20)
        Me.DatabaseTextBox.TabIndex = 9
        Me.DatabaseTextBox.Text = "apskaita"
        Me.DatabaseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 5
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.MySqlPasswordTextBox, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.UserTextBox, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.MySqlPasswordLabel, 2, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(113, 30)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(702, 30)
        Me.TableLayoutPanel4.TabIndex = 7
        '
        'MySqlPasswordTextBox
        '
        Me.MySqlPasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MySqlPasswordTextBox.Location = New System.Drawing.Point(395, 3)
        Me.MySqlPasswordTextBox.MaxLength = 255
        Me.MySqlPasswordTextBox.Name = "MySqlPasswordTextBox"
        Me.MySqlPasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.MySqlPasswordTextBox.Size = New System.Drawing.Size(284, 20)
        Me.MySqlPasswordTextBox.TabIndex = 11
        Me.MySqlPasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UserTextBox
        '
        Me.UserTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserTextBox.Location = New System.Drawing.Point(3, 3)
        Me.UserTextBox.MaxLength = 255
        Me.UserTextBox.Name = "UserTextBox"
        Me.UserTextBox.Size = New System.Drawing.Size(284, 20)
        Me.UserTextBox.TabIndex = 12
        Me.UserTextBox.Text = "root"
        Me.UserTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MySqlPasswordLabel
        '
        Me.MySqlPasswordLabel.AutoSize = True
        Me.MySqlPasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MySqlPasswordLabel.Location = New System.Drawing.Point(313, 6)
        Me.MySqlPasswordLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.MySqlPasswordLabel.Name = "MySqlPasswordLabel"
        Me.MySqlPasswordLabel.Size = New System.Drawing.Size(76, 13)
        Me.MySqlPasswordLabel.TabIndex = 10
        Me.MySqlPasswordLabel.Text = "Slaptažodis:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.PortTextBox, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.HostTextBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(113, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(702, 30)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'PortTextBox
        '
        Me.PortTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PortTextBox.Location = New System.Drawing.Point(595, 3)
        Me.PortTextBox.Name = "PortTextBox"
        Me.PortTextBox.Size = New System.Drawing.Size(84, 20)
        Me.PortTextBox.TabIndex = 4
        Me.PortTextBox.Text = "3306"
        Me.PortTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(542, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Portas:"
        '
        'UserLabel
        '
        Me.UserLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UserLabel.AutoSize = True
        Me.UserLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel.Location = New System.Drawing.Point(42, 36)
        Me.UserLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(68, 13)
        Me.UserLabel.TabIndex = 9
        Me.UserLabel.Text = "Vartotojas:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.OpenSqliteFileButton)
        Me.GroupBox2.Controls.Add(Me.SqlitePasswordTextBox)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.FileTextBox)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(821, 78)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SQLite Prisijungimo Duomenys"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Failas:"
        '
        'OpenSqliteFileButton
        '
        Me.OpenSqliteFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenSqliteFileButton.Location = New System.Drawing.Point(769, 17)
        Me.OpenSqliteFileButton.Name = "OpenSqliteFileButton"
        Me.OpenSqliteFileButton.Size = New System.Drawing.Size(26, 23)
        Me.OpenSqliteFileButton.TabIndex = 7
        Me.OpenSqliteFileButton.Text = "..."
        Me.OpenSqliteFileButton.UseVisualStyleBackColor = True
        '
        'SqlitePasswordTextBox
        '
        Me.SqlitePasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SqlitePasswordTextBox.Location = New System.Drawing.Point(84, 45)
        Me.SqlitePasswordTextBox.MaxLength = 255
        Me.SqlitePasswordTextBox.Name = "SqlitePasswordTextBox"
        Me.SqlitePasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.SqlitePasswordTextBox.Size = New System.Drawing.Size(293, 20)
        Me.SqlitePasswordTextBox.TabIndex = 12
        Me.SqlitePasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 48)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Slaptažodis:"
        '
        'FileTextBox
        '
        Me.FileTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FileTextBox.Location = New System.Drawing.Point(84, 19)
        Me.FileTextBox.Name = "FileTextBox"
        Me.FileTextBox.ReadOnly = True
        Me.FileTextBox.Size = New System.Drawing.Size(684, 20)
        Me.FileTextBox.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(106, 22)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Failas:"
        '
        'ToMySqlRadioButton
        '
        Me.ToMySqlRadioButton.AutoSize = True
        Me.ToMySqlRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToMySqlRadioButton.Location = New System.Drawing.Point(12, 223)
        Me.ToMySqlRadioButton.Name = "ToMySqlRadioButton"
        Me.ToMySqlRadioButton.Size = New System.Drawing.Size(122, 17)
        Me.ToMySqlRadioButton.TabIndex = 7
        Me.ToMySqlRadioButton.Text = "SQLite -> MySQL"
        Me.ToMySqlRadioButton.UseVisualStyleBackColor = True
        '
        'ToSqliteRadioButton
        '
        Me.ToSqliteRadioButton.AutoSize = True
        Me.ToSqliteRadioButton.Checked = True
        Me.ToSqliteRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToSqliteRadioButton.Location = New System.Drawing.Point(12, 200)
        Me.ToSqliteRadioButton.Name = "ToSqliteRadioButton"
        Me.ToSqliteRadioButton.Size = New System.Drawing.Size(122, 17)
        Me.ToSqliteRadioButton.TabIndex = 8
        Me.ToSqliteRadioButton.TabStop = True
        Me.ToSqliteRadioButton.Text = "MySQL -> SQLite"
        Me.ToSqliteRadioButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 247)
        Me.Controls.Add(Me.ToSqliteRadioButton)
        Me.Controls.Add(Me.ToMySqlRadioButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MigrateButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.Text = "Apskaita5 Duomenų Migracija"
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MigrateButton As System.Windows.Forms.Button
    Friend WithEvents HostTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DatabaseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MySqlPasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UserTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MySqlPasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UserLabel As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents OpenSqliteFileButton As System.Windows.Forms.Button
    Friend WithEvents SqlitePasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToMySqlRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ToSqliteRadioButton As System.Windows.Forms.RadioButton

End Class
