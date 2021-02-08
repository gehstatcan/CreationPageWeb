<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents chkEquipes As System.Windows.Forms.CheckBox
	Public WithEvents chkCompteurs As System.Windows.Forms.CheckBox
	Public WithEvents _optEquipes_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optEquipes_0 As System.Windows.Forms.RadioButton
	Public WithEvents chkHoraire As System.Windows.Forms.CheckBox
	Public WithEvents chkClassement As System.Windows.Forms.CheckBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents lblAction As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents optEquipes As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.chkEquipes = New System.Windows.Forms.CheckBox
		Me.chkCompteurs = New System.Windows.Forms.CheckBox
		Me._optEquipes_1 = New System.Windows.Forms.RadioButton
		Me._optEquipes_0 = New System.Windows.Forms.RadioButton
		Me.chkHoraire = New System.Windows.Forms.CheckBox
		Me.chkClassement = New System.Windows.Forms.CheckBox
		Me.Command1 = New System.Windows.Forms.Button
		Me.lblAction = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.optEquipes = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.optEquipes, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Geh Version 1.3"
		Me.ClientSize = New System.Drawing.Size(370, 239)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMain"
		Me.Frame1.Text = "Options"
		Me.Frame1.Size = New System.Drawing.Size(361, 164)
		Me.Frame1.Location = New System.Drawing.Point(5, 6)
		Me.Frame1.TabIndex = 3
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.chkEquipes.Text = "Mettre à jour les pages d'équipe"
		Me.chkEquipes.Size = New System.Drawing.Size(216, 24)
		Me.chkEquipes.Location = New System.Drawing.Point(12, 89)
		Me.chkEquipes.TabIndex = 9
		Me.chkEquipes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkEquipes.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkEquipes.BackColor = System.Drawing.SystemColors.Control
		Me.chkEquipes.CausesValidation = True
		Me.chkEquipes.Enabled = True
		Me.chkEquipes.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkEquipes.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkEquipes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkEquipes.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkEquipes.TabStop = True
		Me.chkEquipes.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkEquipes.Visible = True
		Me.chkEquipes.Name = "chkEquipes"
		Me.chkCompteurs.Text = "Mettre à jour les compteurs"
		Me.chkCompteurs.Size = New System.Drawing.Size(258, 13)
		Me.chkCompteurs.Location = New System.Drawing.Point(12, 70)
		Me.chkCompteurs.TabIndex = 8
		Me.chkCompteurs.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkCompteurs.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkCompteurs.BackColor = System.Drawing.SystemColors.Control
		Me.chkCompteurs.CausesValidation = True
		Me.chkCompteurs.Enabled = True
		Me.chkCompteurs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkCompteurs.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkCompteurs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkCompteurs.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkCompteurs.TabStop = True
		Me.chkCompteurs.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkCompteurs.Visible = True
		Me.chkCompteurs.Name = "chkCompteurs"
		Me._optEquipes_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optEquipes_1.Text = "Toutes les pages d'équipes"
		Me._optEquipes_1.Size = New System.Drawing.Size(247, 31)
		Me._optEquipes_1.Location = New System.Drawing.Point(26, 131)
		Me._optEquipes_1.TabIndex = 7
		Me._optEquipes_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optEquipes_1.BackColor = System.Drawing.SystemColors.Control
		Me._optEquipes_1.CausesValidation = True
		Me._optEquipes_1.Enabled = True
		Me._optEquipes_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optEquipes_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optEquipes_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optEquipes_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optEquipes_1.TabStop = True
		Me._optEquipes_1.Checked = False
		Me._optEquipes_1.Visible = True
		Me._optEquipes_1.Name = "_optEquipes_1"
		Me._optEquipes_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optEquipes_0.Text = "Seulement les 2 dernières équipes qui ont joué"
		Me._optEquipes_0.Size = New System.Drawing.Size(255, 28)
		Me._optEquipes_0.Location = New System.Drawing.Point(26, 111)
		Me._optEquipes_0.TabIndex = 6
		Me._optEquipes_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optEquipes_0.BackColor = System.Drawing.SystemColors.Control
		Me._optEquipes_0.CausesValidation = True
		Me._optEquipes_0.Enabled = True
		Me._optEquipes_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optEquipes_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optEquipes_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optEquipes_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optEquipes_0.TabStop = True
		Me._optEquipes_0.Checked = False
		Me._optEquipes_0.Visible = True
		Me._optEquipes_0.Name = "_optEquipes_0"
		Me.chkHoraire.Text = "Mettre à jour le calendrier"
		Me.chkHoraire.Size = New System.Drawing.Size(211, 30)
		Me.chkHoraire.Location = New System.Drawing.Point(12, 38)
		Me.chkHoraire.TabIndex = 5
		Me.chkHoraire.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkHoraire.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkHoraire.BackColor = System.Drawing.SystemColors.Control
		Me.chkHoraire.CausesValidation = True
		Me.chkHoraire.Enabled = True
		Me.chkHoraire.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkHoraire.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkHoraire.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkHoraire.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkHoraire.TabStop = True
		Me.chkHoraire.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkHoraire.Visible = True
		Me.chkHoraire.Name = "chkHoraire"
		Me.chkClassement.Text = "Mettre à jour le classement"
		Me.chkClassement.Size = New System.Drawing.Size(196, 23)
		Me.chkClassement.Location = New System.Drawing.Point(12, 18)
		Me.chkClassement.TabIndex = 4
		Me.chkClassement.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkClassement.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkClassement.BackColor = System.Drawing.SystemColors.Control
		Me.chkClassement.CausesValidation = True
		Me.chkClassement.Enabled = True
		Me.chkClassement.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkClassement.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkClassement.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkClassement.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkClassement.TabStop = True
		Me.chkClassement.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkClassement.Visible = True
		Me.chkClassement.Name = "chkClassement"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Générer Pages Web"
		Me.Command1.Size = New System.Drawing.Size(144, 27)
		Me.Command1.Location = New System.Drawing.Point(113, 206)
		Me.Command1.TabIndex = 0
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.lblAction.Size = New System.Drawing.Size(283, 16)
		Me.lblAction.Location = New System.Drawing.Point(70, 177)
		Me.lblAction.TabIndex = 2
		Me.lblAction.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblAction.BackColor = System.Drawing.SystemColors.Control
		Me.lblAction.Enabled = True
		Me.lblAction.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblAction.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAction.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAction.UseMnemonic = True
		Me.lblAction.Visible = True
		Me.lblAction.AutoSize = False
		Me.lblAction.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAction.Name = "lblAction"
		Me.Label1.Text = "Action :"
		Me.Label1.Size = New System.Drawing.Size(49, 16)
		Me.Label1.Location = New System.Drawing.Point(16, 177)
		Me.Label1.TabIndex = 1
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(Frame1)
		Me.Controls.Add(Command1)
		Me.Controls.Add(lblAction)
		Me.Controls.Add(Label1)
		Me.Frame1.Controls.Add(chkEquipes)
		Me.Frame1.Controls.Add(chkCompteurs)
		Me.Frame1.Controls.Add(_optEquipes_1)
		Me.Frame1.Controls.Add(_optEquipes_0)
		Me.Frame1.Controls.Add(chkHoraire)
		Me.Frame1.Controls.Add(chkClassement)
		Me.optEquipes.SetIndex(_optEquipes_1, CType(1, Short))
		Me.optEquipes.SetIndex(_optEquipes_0, CType(0, Short))
		CType(Me.optEquipes, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class