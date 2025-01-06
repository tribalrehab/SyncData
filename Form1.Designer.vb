<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        GroupBox1 = New GroupBox()
        ComboBox1 = New ComboBox()
        Label2 = New Label()
        TextBox1 = New TextBox()
        Label1 = New Label()
        GroupBox2 = New GroupBox()
        TextBox2 = New TextBox()
        Button1 = New Button()
        NotifyIcon1 = New NotifyIcon(components)
        ContextMenuStrip1 = New ContextMenuStrip(components)
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        ManualSyncToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        Timer1 = New Timer(components)
        ProgressBar1 = New ProgressBar()
        Button2 = New Button()
        Label3 = New Label()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(886, 203)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Configuration"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(6, 136)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(298, 33)
        ComboBox1.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 108)
        Label2.Name = "Label2"
        Label2.Size = New Size(198, 25)
        Label2.TabIndex = 3
        Label2.Text = "Automatic Sync Interval"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(6, 55)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(874, 31)
        TextBox1.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(145, 25)
        Label1.TabIndex = 1
        Label1.Text = "Backup Location:"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(TextBox2)
        GroupBox2.Location = New Point(12, 221)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(886, 278)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "Folder Paths"
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(6, 30)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(874, 240)
        TextBox2.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(786, 505)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 2
        Button1.Text = "Done"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' NotifyIcon1
        ' 
        NotifyIcon1.ContextMenuStrip = ContextMenuStrip1
        NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), Icon)
        NotifyIcon1.Text = "SyncData"
        NotifyIcon1.Visible = True
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(24, 24)
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {SettingsToolStripMenuItem, ManualSyncToolStripMenuItem, ExitToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(184, 100)
        ' 
        ' SettingsToolStripMenuItem
        ' 
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Size = New Size(183, 32)
        SettingsToolStripMenuItem.Text = "Settings"
        ' 
        ' ManualSyncToolStripMenuItem
        ' 
        ManualSyncToolStripMenuItem.Name = "ManualSyncToolStripMenuItem"
        ManualSyncToolStripMenuItem.Size = New Size(183, 32)
        ManualSyncToolStripMenuItem.Text = "Manual Sync"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(183, 32)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' Timer1
        ' 
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(389, 505)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(391, 34)
        ProgressBar1.TabIndex = 3
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(18, 505)
        Button2.Name = "Button2"
        Button2.Size = New Size(169, 34)
        Button2.TabIndex = 4
        Button2.Text = "Manual Sync"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(210, 505)
        Label3.Name = "Label3"
        Label3.RightToLeft = RightToLeft.Yes
        Label3.Size = New Size(173, 30)
        Label3.TabIndex = 5
        Label3.Text = "Progress"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(910, 549)
        Controls.Add(Label3)
        Controls.Add(Button2)
        Controls.Add(ProgressBar1)
        Controls.Add(Button1)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SyncData"
        WindowState = FormWindowState.Minimized
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ManualSyncToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
End Class
