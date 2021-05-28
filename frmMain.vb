Option Strict Off
Option Explicit On
Friend Class frmMain
	Inherits System.Windows.Forms.Form

	'Private Sub chkEquipes_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkEquipes.CheckStateChanged

	'	optEquipes(0).Enabled = (chkEquipes.CheckState = 1)
	'	optEquipes(1).Enabled = (chkEquipes.CheckState = 1)

	'End Sub

	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim rsTeams As OleDb.OleDbDataReader

		Dim strPath As String
		Dim strPathPageWeb As String

		strPath = My.Settings.FichierBaseDeDonnées
		strPathPageWeb = My.Settings.RépertoiresSiteweb

		lblAction.Text = "Connection à la base de données..."
		System.Windows.Forms.Application.DoEvents()
		Call ConnectToDatabase(strPath)
		
		If chkCompteurs.CheckState = 1 Then
			lblAction.Text = "Création de la page : Compteurs"
			System.Windows.Forms.Application.DoEvents()
			Call subOutputCompteurs("Compteurs " & YEAR_Renamed, strPathPageWeb & "\compteurs.htm")
		End If
		
		If chkHoraire.CheckState = 1 Then
			lblAction.Text = "Création de la page : Calendrier"
			System.Windows.Forms.Application.DoEvents()
			Call subOutputCalendrier(-1, "Calendrier " & YEAR_Renamed, strPathPageWeb & "\calendrier.htm")
		End If
		
		If chkClassement.CheckState = 1 Then
			lblAction.Text = "Création de la page : Classement"
			System.Windows.Forms.Application.DoEvents()
			Call subOutputClassement("Classement " & YEAR_Renamed, strPathPageWeb & "\classement.htm")
		End If
		
		If chkEquipes.CheckState = 1 Then
			If opt2Équipe.Checked Then 'Une équipe
				rsTeams = rsGetTeams(False)
				'rsTeams.MoveFirst()
				While rsTeams.Read()

					lblAction.Text = "Création de la page d'équipe : " & rsTeams(1).ToString
					System.Windows.Forms.Application.DoEvents()
					Call subOutputEquipe(rsTeams(0).ToString, rsTeams(1).ToString, strPathPageWeb & "\equipe_" & Trim(Str(rsTeams(0).ToString)) & ".htm")
					'**lblAction.Text = "Création de la page d'équipe : " & rsTeams.Fields(3).Value

					System.Windows.Forms.Application.DoEvents()
					'**Call subOutputEquipe(rsTeams.Fields(2).Value, rsTeams.Fields(3).Value, strPath & "\SiteWebTemp\equipe_" & Trim(Str(rsTeams.Fields(2).Value)) & ".htm")
				End While
			Else 'Toutes les équipes
				rsTeams = rsGetTeams(True)
				While rsTeams.Read()
					'rsTeams.MoveFirst()
					'While Not rsTeams.EOF
					lblAction.Text = "Création de la page d'équipe : " & rsTeams(1).ToString
					System.Windows.Forms.Application.DoEvents()
					Call subOutputEquipe(rsTeams(0).ToString, rsTeams(1).ToString, strPathPageWeb & "\equipe_" & Trim(Str(rsTeams(0).ToString)) & ".htm")
					'rsTeams.MoveNext()
				End While
			End If
		End If
		
		gcConn.Close()
		lblAction.Text = ""
		MsgBox("Terminé! Les fichiers sont prêts dans " & strPathPageWeb)

	End Sub
	
	
	Private Sub Command3_Click()
		MsgBox(My.Application.Info.DirectoryPath)
	End Sub
	
	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

		'Initialisation des valeurs à partir des "settings"
		txtBaseDedonnées.Text = My.Settings.FichierBaseDeDonnées
		txtRépertoireSiteWeb.Text = My.Settings.RépertoiresSiteweb


		chkHoraire.CheckState = System.Windows.Forms.CheckState.Checked
		chkClassement.CheckState = System.Windows.Forms.CheckState.Checked
		chkCompteurs.CheckState = System.Windows.Forms.CheckState.Checked
		chkEquipes.CheckState = System.Windows.Forms.CheckState.Checked
		optToutesLesÉquipes.Checked = True

	End Sub

	Private Sub _optEquipes_0_CheckedChanged(sender As Object, e As EventArgs)

	End Sub

	Private Sub txtBaseDedonnées_TextChanged(sender As Object, e As EventArgs) Handles txtBaseDedonnées.TextChanged
		'Sauvegardes des valeurs dans my.settings.
		My.Settings.FichierBaseDeDonnées = txtBaseDedonnées.Text
		My.Settings.Save()
	End Sub
End Class