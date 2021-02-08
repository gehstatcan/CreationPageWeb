Option Strict Off
Option Explicit On
Module ModDatabase
	Sub ConnectToDatabase(ByRef strPath As String)
		'Connect to database
		gcConn = New ADODB.Connection
		gcConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & strPath & "\SaisonEnCours.mdb;" & "Persist Security Info=False"
		gcConn.Open()
	End Sub
	
	Public Function rsGetCalendrier(ByVal iTeamNo As Short) As ADODB.Recordset
		Dim strSQL As String
		Dim rs As ADODB.Recordset
		
		strSQL = "SELECT * FROM qry_intranet_calendrier "
		If iTeamNo > -1 Then
			strSQL = strSQL & "WHERE tbl…quipes.No…quipe = " & Str(iTeamNo) & " OR tbl…quipes_1.No…quipe = " & Str(iTeamNo) & " "
		End If
		strSQL = strSQL & "ORDER BY NoPartie"
		
		rs = New ADODB.Recordset
		rs = gcConn.Execute(strSQL)
		rsGetCalendrier = rs
		
	End Function
	
	Public Function rsGetTeamPtsPerGame(ByRef iGameNo As Short, ByRef iTeamNo As Short) As ADODB.Recordset
		Dim strSQL As String
		Dim rs As ADODB.Recordset
		
		strSQL = "SELECT tblRÈpondants.NoPartie, tblRÈpondants.No…quipe,  Sum(IIf(tblRÈpondants!PtsAlternatifs=0,tblSÈries!Points,tblSÈries!PtsAlternatifs)) AS SumOfPoints " & "FROM tblRÈpondants INNER JOIN tblSÈries ON (tblRÈpondants.NoSÈrie = tblSÈries.NoSÈrie) AND (tblRÈpondants.NoQuestion = tblSÈries.NoQuestion) " & "GROUP BY tblRÈpondants.NoPartie, tblRÈpondants.No…quipe " & "HAVING tblRÈpondants.NoPartie = " & Str(iGameNo) & "AND tblRÈpondants.No…quipe = " & Str(iTeamNo) & " " & "ORDER BY tblRÈpondants.NoPartie, tblRÈpondants.No…quipe"
		
		rs = New ADODB.Recordset
		rs = gcConn.Execute(strSQL)
		rsGetTeamPtsPerGame = rs
		
	End Function
	
	Public Function rsGetPlayerPtsForAGame(ByRef iGameNo As Short, ByRef iTeamNo As Short) As ADODB.Recordset
		Dim strSQL As String
		Dim rs As ADODB.Recordset
		
		strSQL = "SELECT tblRÈpondants.NoPartie, IIf([tblJoueurs.PrÈnomJoueur] Is Null,[tblJoueurs.NomJoueur],[tblJoueurs.PrÈnomJoueur]+' '+[tblJoueurs.NomJoueur]) AS Nom, Sum(IIf(tblRÈpondants!PtsAlternatifs=0,tblSÈries!Points,tblSÈries!PtsAlternatifs)) AS SumOfPoints " & "FROM tblJoueurs INNER JOIN (tblRÈpondants INNER JOIN tblSÈries ON (tblRÈpondants.NoQuestion = tblSÈries.NoQuestion) AND (tblRÈpondants.NoSÈrie = tblSÈries.NoSÈrie)) ON (tblJoueurs.NoJoueur = tblRÈpondants.NoJoueur) AND (tblJoueurs.No…quipe = tblRÈpondants.No…quipe) " & "GROUP BY tblRÈpondants.NoPartie, IIf([tblJoueurs.PrÈnomJoueur] Is Null,[tblJoueurs.NomJoueur],[tblJoueurs.PrÈnomJoueur]+' '+[tblJoueurs.NomJoueur]), tblJoueurs.No…quipe " & "HAVING (((tblRÈpondants.NoPartie)=" & Str(iGameNo) & ") AND ((tblJoueurs.No…quipe)=" & Str(iTeamNo) & ")) " & "ORDER BY Sum(IIf(tblRÈpondants!PtsAlternatifs=0,tblSÈries!Points,tblSÈries!PtsAlternatifs)) DESC"
		
		rs = New ADODB.Recordset
		rs = gcConn.Execute(strSQL)
		rsGetPlayerPtsForAGame = rs
		
	End Function
	
	Public Function rsGetPossiblePtsForAGame(ByRef iGameNo As Short) As ADODB.Recordset
		Dim strSQL As String
		Dim rs As ADODB.Recordset
		
		strSQL = "SELECT tblRÈpondants.NoPartie, Sum(tblSÈries.Points) AS PtsPossJoueurs " & "FROM tblRÈpondants INNER JOIN tblSÈries ON (tblRÈpondants.NoQuestion = tblSÈries.NoQuestion) AND (tblRÈpondants.NoSÈrie = tblSÈries.NoSÈrie) " & "Where (((tblRÈpondants.NoJoueur) <> 99)) " & "GROUP BY tblRÈpondants.NoPartie " & "HAVING (((tblRÈpondants.NoPartie)=" & Str(iGameNo) & "))"
		
		rs = New ADODB.Recordset
		rs = gcConn.Execute(strSQL)
		rsGetPossiblePtsForAGame = rs
		
	End Function
	
	Public Function rsGetTeams(ByRef blnAllTeams As Boolean) As ADODB.Recordset
		Dim strSQL As String
		Dim rs As ADODB.Recordset
		
		If blnAllTeams Then
			strSQL = "SELECT tbl…quipes.No…quipe, tbl…quipes.Nom…quipe From tbl…quipes order by tbl…quipes.No…quipe ASC"
		Else
			strSQL = "SELECT TOP 1 tblParties.No…quipeA, tbl…quipes.Nom…quipe, tblParties.No…quipeB, tbl…quipes_1.Nom…quipe " & "FROM tbl…quipes AS tbl…quipes_1 INNER JOIN (tbl…quipes INNER JOIN tblParties ON tbl…quipes.No…quipe = tblParties.No…quipeA) ON tbl…quipes_1.No…quipe = tblParties.No…quipeB " & "Where (((tblParties.No…quipeA) Is Not Null)) " & "ORDER BY tblParties.NoPartie DESC; "
		End If
		
		rs = New ADODB.Recordset
		rs = gcConn.Execute(strSQL)
		rsGetTeams = rs
		
	End Function
	
	Public Function rsGetClassement() As ADODB.Recordset
		Dim strSQL As String
		Dim rs As ADODB.Recordset
		
		strSQL = "SELECT * FROM qryRapClassement_final"
		
		rs = New ADODB.Recordset
		rs = gcConn.Execute(strSQL)
		rsGetClassement = rs
		
	End Function
	
	
	Public Function rsGetCompteurs(ByVal iTeamNo As Short) As ADODB.Recordset
		Dim strSQL As String
		Dim rs As ADODB.Recordset
		
		If iTeamNo > -1 Then
			strSQL = "SELECT * " & "FROM qryStatsPtsTotJoueurs_Tous_Final " & "WHERE qryStatsPtsTotJoueurs_Tous_Final.No…quipe = " & Str(iTeamNo)
			
		Else
			strSQL = "SELECT tbl…quipes.No…quipe, qryStatPtsTotJoueurs.* " & "FROM qryStatPtsTotJoueurs " & "INNER JOIN tbl…quipes ON qryStatPtsTotJoueurs.Nom…quipe = tbl…quipes.Nom…quipe "
		End If
		strSQL = strSQL & " ORDER BY Pourcentage DESC"
		
		rs = New ADODB.Recordset
		rs = gcConn.Execute(strSQL)
		rsGetCompteurs = rs
		
	End Function
	
	Public Function rsGetCompteurs_Old(ByVal iTeamNo As Short) As ADODB.Recordset
		Dim strSQL As String
		Dim rs As ADODB.Recordset
		
		If iTeamNo > -1 Then
			strSQL = "SELECT tbl…quipes.No…quipe, qryStatPtsTotJoueurs_tous.* " & "FROM qryStatPtsTotJoueurs_tous " & "INNER JOIN tbl…quipes ON qryStatPtsTotJoueurs_tous.Nom…quipe = tbl…quipes.Nom…quipe " & "WHERE tbl…quipes.No…quipe = " & Str(iTeamNo)
		Else
			strSQL = "SELECT tbl…quipes.No…quipe, qryStatPtsTotJoueurs.* " & "FROM qryStatPtsTotJoueurs " & "INNER JOIN tbl…quipes ON qryStatPtsTotJoueurs.Nom…quipe = tbl…quipes.Nom…quipe "
		End If
		strSQL = strSQL & " ORDER BY qryStatPtsTotJoueurs_1.Pourcentage DESC"
		
		rs = New ADODB.Recordset
		rs = gcConn.Execute(strSQL)
		rsGetCompteurs_Old = rs
		
	End Function
	
	'Public Function rsGetSalles() As ADODB.Recordset
	'Dim strSQL As String
	'Dim rs As ADODB.Recordset
	'
	'strSQL = "SELECT distinct tblParties.Salle " & _
	''         "FROM tblParties " & _
	''         "WHERE tbParties.Salle <> 'JT 11 E'"
	'
	'Set rs = New ADODB.Recordset
	'Set rs = gcConn.Execute(strSQL)
	'Set rsGetSalles = rs
	'
	'End Function
	
	Public Function rsGetQuest(ByRef intQuestNo As Short) As ADODB.Recordset
		Dim strSQL As String
		Dim rs As ADODB.Recordset
		
		strSQL = "SELECT qryRapFeuilleDeMatch.* FROM qryRapFeuilleDeMatch "
		
		rs = New ADODB.Recordset
		rs = gcConn.Execute(strSQL)
		rsGetQuest = rs
		
	End Function
End Module