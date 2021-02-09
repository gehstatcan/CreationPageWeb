Option Strict Off
Option Explicit On
Module modOutput
	Sub subOutputCalendrier(ByVal iTeamNo As Short, ByRef strTitle As String, ByRef strFileName As String)
		
		FileOpen(1, strFileName, OpenMode.Output)
		PrintLine(1, "<HTML><HEAD><TITLE></TITLE></HEAD>")
		PrintLine(1, "<BODY TOPMARGIN=10 BGPROPERTIES=""FIXED"" BGCOLOR = " & DOC_BACKGROUND_COLOR & "><div id=Outline>")
		PrintLine(1, "<CENTER><FONT FACE=VERDANA COLOR = black SIZE=5><B>" & strTitle & "</FONT></CENTER>")
		PrintLine(1, "<BR>")
		PrintLine(1, "JT = Jean-Talon, 11ième, salle E")
		PrintLine(1, "<BR>")
		PrintLine(1, "RHC = Coats, 16ième, salle 3 (Ou RHC 11)")
		PrintLine(1, "<BR>")
		PrintLine(1, "<BR>")
		PrintLine(1, funGetCalendrier(iTeamNo))
		PrintLine(1, "<BR>")
		PrintLine(1, funGetScript())
		PrintLine(1, "</HTML>")
		FileClose(1)
		
	End Sub
	
	Sub subOutputClassement(ByRef strTitle As String, ByRef strFileName As String)
		
		Dim rsClassement As ADODB.Recordset
		Dim ColWidth(13) As Short
		Dim I As Short
		Dim strHREF As String
		
		ColWidth(1) = 30
		ColWidth(2) = 170
		ColWidth(3) = 50
		ColWidth(4) = 50
		ColWidth(5) = 50
		ColWidth(6) = 50
		ColWidth(7) = 50
		ColWidth(8) = 50
		ColWidth(9) = 50
		ColWidth(10) = 50
		ColWidth(11) = 70
		ColWidth(12) = 70
		ColWidth(13) = 70
		
		rsClassement = rsGetClassement()
		
		FileOpen(1, strFileName, OpenMode.Output)
		
		'début du document
		PrintLine(1, "<!DOCTYPE HTML PUBLIC -//W3C//DTD HTML 4.0 Transitional//EN><HTML><HEAD><TITLE></TITLE>")
		PrintLine(1, "<body TOPMARGIN=10 BGPROPERTIES=""FIXED"" BGCOLOR = " & DOC_BACKGROUND_COLOR & ">")
		PrintLine(1, "<CENTER>")
		PrintLine(1, "<FONT FACE=VERDANA COLOR = black SIZE=5><B>" & strTitle & "</FONT><BR><BR>")
		
		'entête du classement
		
		PrintLine(1, "<TABLE BORDER=0 CELLSPACING=1 CELLPADDING=3>")
		PrintLine(1, "<TR align=center bgcolor = " & COL_HEADER_COLOR & ">")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(1)) & " ROWSPAN=2 VALIGN=MIDDLE><FONT FACE=VERDANA SIZE=2 COLOR=white><B>Pos </B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(2)) & " ROWSPAN=2 VALIGN=middle ALIGN=LEFT><FONT FACE=VERDANA SIZE=2 COLOR=white><B>Équipes</B></FONT></TD>")
		PrintLine(1, "<TD COLSPAN=8 VALIGN=middle><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Parties</B></FONT></TD>")
		PrintLine(1, "<TD COLSPAN=3 VALIGN=middle><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pointage</B></FONT></TD>")
		PrintLine(1, "<TR BGCOLOR=darkcyan align=center>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(3)) & " BGCOLOR=darkcyan><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>PJ</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(4)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>G</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(5)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>GP</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(6)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>PN</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(7)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>PP</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(8)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>P</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(9)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pts</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(10)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>%*</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(11)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>PP</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(12)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>PC</B></FONT></TD>")
		PrintLine(1, "<TD WIDTH=" & Str(ColWidth(13)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Diff</B></FONT></TD>")
		PrintLine(1, "</TR></TABLE>")
		PrintLine(1, "")
		
		PrintLine(1, "<TABLE BORDER=0 CELLSPACING=1 CELLPADDING=3>")
		
		
		rsClassement.MoveFirst()
		I = 1
		While Not rsClassement.EOF
			System.Windows.Forms.Application.DoEvents()
			
			PrintLine(1, "<TR ALIGN=CENTER BGCOLOR = white>")
			PrintLine(1, "<TD WIDTH=30><FONT FACE=VERDANA SIZE=2 COLOR=Black>" & Trim(Str(I)) & "</FONT></TD>")
			strHREF = "<A HREF = """ & "equipe_" & Trim(Str(rsClassement.Fields(0).Value)) & ".htm" & """  > " & rsClassement.Fields(1).Value & "</A>"
			PrintLine(1, "<TD WIDTH=170 ALIGN=LEFT><FONT FACE=VERDANA SIZE=2 COLOR=black>" & strHREF & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=50><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(2).Value & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=50><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(3).Value & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=50><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(4).Value & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=50><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(5).Value & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=50><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(6).Value & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=50><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(7).Value & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=50><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(8).Value & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=50><FONT FACE=VERDANA SIZE=2 COLOR=black>" & System.Math.Round(rsClassement.Fields(9).Value, 2) & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=70><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(10).Value & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=70><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(11).Value & "</FONT></TD>")
			PrintLine(1, "<TD WIDTH=70><FONT FACE=VERDANA SIZE=2 COLOR=black>" & rsClassement.Fields(12).Value & "</FONT></TD>")
			PrintLine(1, "</TR>")
			
			rsClassement.MoveNext()
			I = I + 1
		End While
		PrintLine(1, "</TABLE>")
		PrintLine(1, "<TABLE WIDTH=850 BORDER=0>")
		PrintLine(1, "<TR><TD><FONT FACE=VERDANA SIZE=2>Trié par : 1-%, 2 -Diff. Ceci afin de tenir compte du nombre inégale de parties jouées.</TD></TR>")
		PrintLine(1, "<TR><TD>&nbsp</TD></TR>")
		PrintLine(1, "<TR><TD><FONT FACE=VERDANA SIZE=2><B>G</B> : Victoire par plus de 40 pts. (4 pts)</TD></TR>")
		PrintLine(1, "<TR><TD><FONT FACE=VERDANA SIZE=2><B>GP</B>: Victoire par 40 pts ou moins. (3 pts)</TD></TR>")
		PrintLine(1, "<TR><TD><FONT FACE=VERDANA SIZE=2><B>PN</B>: Partie Nulle. (2 pts)</TD></TR>")
		PrintLine(1, "<TR><TD><FONT FACE=VERDANA SIZE=2><B>PP</B>: Défaite par 40 pts ou moins. (1 pts)</TD></TR>")
		PrintLine(1, "<TR><TD><FONT FACE=VERDANA SIZE=2><B>P</B> : Défaite par plus de 40 pts. (0 pt)</TD></TR>")
		PrintLine(1, "<TR><TD><FONT FACE=VERDANA SIZE=2><B>%</B> : C'est le pourcentage des points acquis sur les points possibles</TD></TR>")
		PrintLine(1, "</TABLE>")
		
		FileClose(1)
		
		
		
		
	End Sub
	
	Sub subOutputCompteurs(ByRef strTitle As String, ByRef strFileName As String)
		
		FileOpen(1, strFileName, OpenMode.Output)
		
		'début du document
		PrintLine(1, "<!DOCTYPE HTML PUBLIC -//W3C//DTD HTML 4.0 Transitional//EN><HTML><HEAD><TITLE></TITLE>")
		PrintLine(1, "<body TOPMARGIN=10 BGPROPERTIES=""FIXED"" BGCOLOR = " & DOC_BACKGROUND_COLOR & ">")
		PrintLine(1, "<CENTER>")
		PrintLine(1, "<FONT FACE=VERDANA COLOR = black SIZE=5><B>" & strTitle & "</B></FONT><BR>")
		'Print #1, "(Minimum de 2 parties jouées)<BR><BR>"
		PrintLine(1, "<BR><BR>")
		
		PrintLine(1, funGetCompteurs(-1))
		PrintLine(1, "<TABLE WIDTH=850 BORDER=0>")
		PrintLine(1, "<TR><TD><FONT FACE=VERDANA SIZE=2><B>*</B>* % des points tot = Points du joueur / Nombre total de points atribués aux joueurs (pas équipes) durant les parties de ce joueur. Comme ça, on tient en compte que certains questionnaires seront plus difficiles que d'autres. Il est à noter que les points possible tiennent compte de tous les parties jouées avec un même questionnaire. 10 points sont ajoutés à ""Pts Poss."" si une question est réussie dans une des deux partie (ou les deux). Par exemple, pour la série 2, si la question 1 est répondue dans la partie 1 mais pas dans la partie 2, que la question 2 est répondue dans la partie 2 seulement et que la question 3 est réussie dans les deux parties, les points possible seront de 30.</TD></TR>")
		PrintLine(1, "<TR><TD><FONT FACE=VERDANA SIZE=2><B>Note:</B> Les questions s'adressant à l'équipe ne comptent pour aucun joueur</TD></TR>")
		PrintLine(1, "</TABLE>")
		
		FileClose(1)
		
	End Sub
	
	Function funGetCompteurs(ByVal iTeamNo As Short) As String
		
		Dim rsCompteurs As ADODB.Recordset
		Dim ColWidth(8) As Short
		Dim I As Short
		Dim S As String
		Dim strHREF As String
		Dim MaxLigne As Short
		
		ColWidth(1) = 30
		ColWidth(2) = 210
		ColWidth(3) = 170
		ColWidth(4) = 40
		ColWidth(5) = 50
		ColWidth(6) = 90
		ColWidth(7) = 90
		ColWidth(8) = 100
		
		rsCompteurs = rsGetCompteurs(iTeamNo)
		
		S = ""
		
		'entête des compteurs
		S = S & "<TABLE BORDER=0 CELLSPACING=1 CELLPADDING=3>"
		S = S & "<TR align=center bgcolor = " & COL_HEADER_COLOR & ">"
		S = S & "<TD WIDTH=" & Str(ColWidth(1)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pos</B></FONT></TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(2)) & " ALIGN=LEFT><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Nom</B></FONT></TD>"
		If iTeamNo = -1 Then
			S = S & "<TD WIDTH=" & Str(ColWidth(3)) & " ALIGN=LEFT><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Équipe</B></FONT></TD>"
		End If
		S = S & "<TD WIDTH=" & Str(ColWidth(4)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>PJ</B></FONT></TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(5)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pts</B></FONT></TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(6)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pts Poss.</B></FONT></TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(7)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pts par PJ</B></FONT></TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(8)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>% des Pts Tot. *</B></FONT></TD>"
		S = S & "</TR>"
		
		If Not rsCompteurs.EOF Then
			rsCompteurs.MoveFirst()
			I = 1
			While Not rsCompteurs.EOF
				System.Windows.Forms.Application.DoEvents()
				S = S & "<TR BGCOLOR = white ALIGN=CENTER>"
				S = S & "<TD><FONT FACE=VERDANA SIZE=2>" & Trim(Str(I)) & "</FONT></TD>"
				S = S & "<TD ALIGN=LEFT><FONT FACE=VERDANA SIZE=2>" & rsCompteurs.Fields(1).Value & " " & rsCompteurs.Fields(2).Value & "</FONT></TD>"
				If iTeamNo = -1 Then
					strHREF = "<A HREF = """ & "equipe_" & Trim(Str(rsCompteurs.Fields(0).Value)) & ".htm" & """  > " & rsCompteurs.Fields(3).Value & "</A>"
					S = S & "<TD ALIGN=LEFT><FONT FACE=VERDANA SIZE=2>" & strHREF & "</FONT></TD>"
				End If
				S = S & "<TD><FONT FACE=VERDANA SIZE=2>" & rsCompteurs.Fields(4).Value & "</FONT></TD>"
				S = S & "<TD><FONT FACE=VERDANA SIZE=2>" & rsCompteurs.Fields(5).Value & "</FONT></TD>"
				S = S & "<TD><FONT FACE=VERDANA SIZE=2>" & rsCompteurs.Fields(6).Value & "</FONT></TD>"
				S = S & "<TD><FONT FACE=VERDANA SIZE=2>" & System.Math.Round(rsCompteurs.Fields(7).Value, 2) & "</FONT></TD>"
				S = S & "<TD><FONT FACE=VERDANA SIZE=2>" & System.Math.Round(rsCompteurs.Fields(8).Value, 2) & "</FONT></TD>"
				S = S & "</TR>"
				rsCompteurs.MoveNext()
				I = I + 1
			End While
		Else
			'C'est le dubut de la saison. Mettre des lignes vides
			For I = 1 To 15
				S = S & "<TR BGCOLOR = white ALIGN=CENTER>"
				S = S & "<TD>&nbsp</TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD><TD></TD>"
				S = S & "</TR>"
			Next 
		End If
		S = S & "</TABLE>"
		
		funGetCompteurs = S
		
	End Function
	
	'Function funGetCompteurs_old(ByVal iTeamNo As Integer) As String
	'
	'   Dim rsCompteurs As ADODB.Recordset
	'   Dim ColWidth(8) As Integer
	'   Dim I As Integer
	'   Dim S As String
	'   Dim strHREF As String
	'
	'   ColWidth(1) = 30
	'   ColWidth(2) = 210
	'   ColWidth(3) = 170
	'   ColWidth(4) = 40
	'   ColWidth(5) = 50
	'   ColWidth(6) = 90
	'   ColWidth(7) = 90
	'   ColWidth(8) = 100
	'
	'   Set rsCompteurs = rsGetCompteurs(iTeamNo)
	'
	'   S = ""
	'
	'   'entête des compteurs
	'   S = S & "<TABLE BORDER=0 CELLSPACING=1 CELLPADDING=3>"
	'   S = S & "<TR align=center bgcolor = " & COL_HEADER_COLOR & ">"
	'   S = S & "<TD WIDTH=" & Str(ColWidth(1)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pos</B></FONT></TD>"
	'   S = S & "<TD WIDTH=" & Str(ColWidth(2)) & " ALIGN=LEFT><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Nom</B></FONT></TD>"
	'   If iTeamNo = -1 Then
	'      S = S & "<TD WIDTH=" & Str(ColWidth(3)) & " ALIGN=LEFT><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Équipe</B></FONT></TD>"
	'   End If
	'   S = S & "<TD WIDTH=" & Str(ColWidth(4)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>PJ</B></FONT></TD>"
	'   S = S & "<TD WIDTH=" & Str(ColWidth(5)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pts</B></FONT></TD>"
	'   S = S & "<TD WIDTH=" & Str(ColWidth(6)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pts Poss.</B></FONT></TD>"
	'   S = S & "<TD WIDTH=" & Str(ColWidth(7)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>Pts par PJ</B></FONT></TD>"
	'   S = S & "<TD WIDTH=" & Str(ColWidth(8)) & "><FONT FACE=VERDANA SIZE=2 COLOR='FFFFFF'><B>% des Pts Tot. *</B></FONT></TD>"
	'   S = S & "</TR></TABLE>"
	'   S = S & ""
	'
	'   S = S & "<TABLE BORDER=0 CELLSPACING=1 CELLPADDING=3>"
	'
	'   rsCompteurs.MoveFirst
	'   I = 1
	'   While Not rsCompteurs.EOF
	'      DoEvents
	'      S = S & "<TR BGCOLOR = white ALIGN=CENTER>"
	'      S = S & "<TD WIDTH=" & Str(ColWidth(1)) & "><FONT FACE=VERDANA SIZE=2>" & Trim(Str(I)) & "</FONT></TD>"
	'      S = S & "<TD WIDTH=" & Str(ColWidth(2)) & " ALIGN=LEFT><FONT FACE=VERDANA SIZE=2>" & rsCompteurs.Fields(1) & "</FONT></TD>"
	'      If iTeamNo = -1 Then
	'         strHREF = "<A HREF = """ & "equipe_" & Trim(Str(rsCompteurs.Fields(0))) & ".htm" & """  > " & rsCompteurs.Fields(2) & "</A>"
	'         S = S & "<TD WIDTH=" & Str(ColWidth(3)) & " ALIGN=LEFT><FONT FACE=VERDANA SIZE=2>" & strHREF & "</FONT></TD>"
	'      End If
	'      S = S & "<TD WIDTH=" & Str(ColWidth(4)) & "><FONT FACE=VERDANA SIZE=2>" & rsCompteurs.Fields(3) & "</FONT></TD>"
	'      S = S & "<TD WIDTH=" & Str(ColWidth(5)) & "><FONT FACE=VERDANA SIZE=2>" & rsCompteurs.Fields(4) & "</FONT></TD>"
	'      S = S & "<TD WIDTH=" & Str(ColWidth(6)) & "><FONT FACE=VERDANA SIZE=2>" & rsCompteurs.Fields(5) & "</FONT></TD>"
	'      S = S & "<TD WIDTH=" & Str(ColWidth(7)) & "><FONT FACE=VERDANA SIZE=2>" & Round(rsCompteurs.Fields(6), 2) & "</FONT></TD>"
	'      S = S & "<TD WIDTH=" & Str(ColWidth(8)) & "><FONT FACE=VERDANA SIZE=2>" & Round(rsCompteurs.Fields(7), 2) & "</FONT></TD>"
	'      S = S & "</TR>"
	'      rsCompteurs.MoveNext
	'      I = I + 1
	'   Wend
	'   S = S & "</TABLE>"
	'
	'   funGetCompteurs_old = S
	'
	'End Function
	
	
	Function funGetCalendrier(ByVal iTeamNo As Short) As String
		Dim strTeamBPts As Object
		Dim strTeamAPts As Object
		Dim rsGames As OleDb.OleDbDataReader
		Dim rsPlayersTeamAPts As ADODB.Recordset
		Dim rsPlayersTeamBPts As ADODB.Recordset
		Dim ColWidth(10) As Short
		Dim strTeamName As String
		Dim strLine As String
		Dim strDate As String
		Dim strPlayerPercent As String
		Dim strHREF As String
		Dim I As Short
		Dim S As String
		
		ColWidth(1) = 20
		ColWidth(2) = 30
		ColWidth(3) = 80
		ColWidth(4) = 50
		ColWidth(5) = 170
		ColWidth(6) = 70
		ColWidth(7) = 170
		ColWidth(8) = 70
		ColWidth(9) = 140
		ColWidth(10) = 170
		
		rsGames = rsGetCalendrier(iTeamNo)
		
		S = ""
		
		'entête du calendrier
		S = S & "<TABLE NOWRAP CELLPADDING=1 CELLSPACING=0>"
		S = S & "<TR BGCOLOR = " & COL_HEADER_COLOR & ">"
		S = S & "<TD WIDTH=" & Str(ColWidth(1)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2></TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(2)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2><B>#</TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(3)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2><B>Date</TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(4)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2><B>Lieu</TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(5)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2><B>Équipe A</TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(6)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2><B>Pts</TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(7)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2><B>Équipe B</TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(8)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2><B>Pts</TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(9)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2><B>Animateur</TD>"
		S = S & "<TD WIDTH=" & Str(ColWidth(10)) & ">" & "<FONT FACE=VERDANA COLOR = white SIZE=2><B>Questionnaire</TD>"
		S = S & "</TR></TABLE>"
		S = S & ""

		While rsGames.Read()


			System.Windows.Forms.Application.DoEvents()
			strLine = "<TABLE NOWRAP CELLPADDING=1 CELLSPACING=0><TR BGCOLOR = white>"
			'colonne 1 - symbole +
			'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If IsDBNull(rsGames(4).ToString) Then
				'la partie n'a pas encore eu lieu, ne pas mettre le symbole +
				strLine = strLine & "<TD WIDTH=" & Str(ColWidth(1)) & " ALIGN=center></TD>"
			Else
				'la partie a eu lieu, mettre le symbole +
				strLine = strLine & "<TD WIDTH=" & Str(ColWidth(1)) & " ALIGN=center><img src=""" & "plus.gif""" & " id=partie" & Trim(Str(rsGames(0).ToString)) & " style=""" & "cursor:hand""" & " class=Outline></TD>"
			End If
			'colonne 2 - numéro de la partie
			strLine = strLine & "<TD WIDTH=" & Str(ColWidth(2)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2>" & Trim(Str(rsGames(0).ToString)) & "</TD>"
			'colonne 3 - date
			'strDate = funFormatDate(rsGames.Fields(1).Value)
			'strLine = strLine & "<TD WIDTH=" & Str(ColWidth(3)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2>" & strDate & "</TD>"
			''colonne 4 - Lieu
			'strLine = strLine & "<TD WIDTH=" & Str(ColWidth(4)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2>" & Trim(rsGames.Fields(10).Value) & "</TD>"
			''      If rsGames.Fields(10) = "JT" Then
			''         strLine = strLine + "<TD WIDTH=" & Str(ColWidth(4)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2>JT</TD>"
			''      Else
			''         strLine = strLine + "<TD WIDTH=" & Str(ColWidth(4)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2>RHC</TD>"
			''      End If
			''colonne 5 - Nom equipe A
			''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'If IsDbNull(rsGames.Fields(2).Value) Then
			'	strTeamName = ""
			'	strHREF = ""
			'Else
			'	strTeamName = rsGames.Fields(2).Value
			'	strHREF = "<A HREF = """ & "equipe_" & Trim(Str(rsGames.Fields(3).Value)) & ".htm" & """  > " & strTeamName & "</A>"
			'End If
			'strLine = strLine & "<TD WIDTH=" & Str(ColWidth(5)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2>" & strHREF & "</TD>"
			''colonne 6 - Pts equipe A
			''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'If IsDbNull(rsGames.Fields(4).Value) Then
			'	'UPGRADE_WARNING: Couldn't resolve default property of object strTeamAPts. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'	strTeamAPts = ""
			'Else
			'	'UPGRADE_WARNING: Couldn't resolve default property of object strTeamAPts. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'	strTeamAPts = rsGames.Fields(4).Value
			'End If
			''UPGRADE_WARNING: Couldn't resolve default property of object strTeamAPts. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'strLine = strLine & "<TD WIDTH=" & Str(ColWidth(6)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2><B>" & strTeamAPts & "</TD>"
			''colonne 7 - Nom equipe B
			''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'If IsDbNull(rsGames.Fields(5).Value) Then
			'	strTeamName = ""
			'Else
			'	strTeamName = rsGames.Fields(5).Value
			'	strHREF = "<A HREF = """ & "equipe_" & Trim(Str(rsGames.Fields(6).Value)) & ".htm" & """  > " & strTeamName & "</A>"
			'End If
			'strLine = strLine & "<TD WIDTH=" & Str(ColWidth(7)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2>" & strHREF & "</TD>"
			''colonne 8 - Pts equipe B
			''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'If IsDbNull(rsGames.Fields(7).Value) Then
			'	'UPGRADE_WARNING: Couldn't resolve default property of object strTeamBPts. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'	strTeamBPts = ""
			'Else
			'	'UPGRADE_WARNING: Couldn't resolve default property of object strTeamBPts. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'	strTeamBPts = rsGames.Fields(7).Value
			'End If
			''UPGRADE_WARNING: Couldn't resolve default property of object strTeamBPts. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'strLine = strLine & "<TD WIDTH=" & Str(ColWidth(8)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2><B>" & strTeamBPts & "</TD>"
			''colonne 9 - Animateur
			'strLine = strLine & "<TD WIDTH=" & Str(ColWidth(9)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2>" & Trim(rsGames.Fields(8).Value) & "</TD>"
			''colonne 10 - equipe questionnaire
			''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'If IsDbNull(rsGames.Fields(9).Value) Then
			'	strTeamName = ""
			'Else
			'	strTeamName = rsGames.Fields(9).Value
			'	strHREF = "<A HREF = '" & F_DE_MATCH & Trim(Str(rsGames.Fields(0).Value)) & ".htm'><img src='sheet.gif' STYLE='cursor: hand' BORDER=0></A>"
			'End If
			''si la partie n'a pas eu lieu, ne pas montrer l'icone "sheet"
			'If strTeamAPts <= 0 Then
			'	strHREF = ""
			'End If
			'strLine = strLine & "<TD WIDTH=" & Str(ColWidth(10)) & ">" & "<FONT FACE=VERDANA COLOR = black SIZE=2>" & strHREF & "&nbsp" & strTeamName & "</TD>"
			'strLine = strLine & "</TR></TABLE>"
			'S = S & strLine

			''section detail de la partie
			'If (strTeamAPts > 0) And (strTeamBPts > 0) Then
			'	'la partie a eu lieu, afficher le détail
			'	'aller chercher le pointage de chaque joueurs de l'équipe A
			'	rsPlayersTeamAPts = rsGetPlayerPtsForAGame(rsGames.Fields(0).Value, rsGames.Fields(3).Value)
			'	rsPlayersTeamAPts.MoveFirst()
			'	'aller chercher le pointage de chaque joueurs de l'équipe B
			'	rsPlayersTeamBPts = rsGetPlayerPtsForAGame(rsGames.Fields(0).Value, rsGames.Fields(6).Value)
			'	rsPlayersTeamBPts.MoveFirst()
			'	strLine = "<div id=partie" & rsGames.Fields(0).Value & "d style=""" & "display:None" & """ > "
			'	strLine = strLine & "<TABLE NOWRAP CELLPADDING=1 CELLSPACING=0>"
			'	strLine = strLine & "<TR BGCOLOR = darkgray>"
			'	'il y a 5 joueurs possible, 4 joueurs plus l'équipe
			'	For I = 1 To 5
			'		strLine = strLine & "<TR BGCOLOR = whitesmoke>"
			'		strLine = strLine & "<TD WIDTH=" & Str(ColWidth(1)) & "></TD>"
			'		strLine = strLine & "<TD WIDTH=" & Str(ColWidth(2)) & "></TD>"
			'		strLine = strLine & "<TD WIDTH=" & Str(ColWidth(3)) & "></TD>"
			'		strLine = strLine & "<TD WIDTH=" & Str(ColWidth(4)) & "></TD>"
			'		If Not rsPlayersTeamAPts.EOF Then
			'			strLine = strLine & "<TD WIDTH=" & Str(ColWidth(5)) & " BGCOLOR = white><FONT FACE=VERDANA COLOR = black SIZE=1>" & rsPlayersTeamAPts.Fields(1).Value & "</TD>"
			'			strLine = strLine & "<TD WIDTH=" & Str(30) & " BGCOLOR = white><FONT FACE=VERDANA COLOR = black SIZE=1>" & rsPlayersTeamAPts.Fields(2).Value & "</TD>"
			'			strPlayerPercent = Str(System.Math.Round(rsPlayersTeamAPts.Fields(2).Value / rsGames.Fields(11).Value * 100, 1))
			'			strLine = strLine & "<TD WIDTH=" & Str(40) & " BGCOLOR = white><FONT FACE=VERDANA COLOR = black SIZE=1>" & strPlayerPercent & "%</TD>"
			'			rsPlayersTeamAPts.MoveNext()
			'		Else
			'			'le joueur n'a pas fait de pts, mettre des cellules vides
			'			strLine = strLine & "<TD BGCOLOR = white COLSPAN = 3></TD>"
			'		End If
			'		If Not rsPlayersTeamBPts.EOF Then
			'			strLine = strLine & "<TD WIDTH=" & Str(ColWidth(7)) & " BGCOLOR = white><FONT FACE=VERDANA COLOR = black SIZE=1>" & rsPlayersTeamBPts.Fields(1).Value & "</TD>"
			'			strLine = strLine & "<TD WIDTH=" & Str(30) & " BGCOLOR = white><FONT FACE=VERDANA COLOR = black SIZE=1>" & rsPlayersTeamBPts.Fields(2).Value & "</TD>"
			'			strPlayerPercent = Str(System.Math.Round(rsPlayersTeamBPts.Fields(2).Value / rsGames.Fields(11).Value * 100, 1))
			'			strLine = strLine & "<TD WIDTH=" & Str(40) & " BGCOLOR = white><FONT FACE=VERDANA COLOR = black SIZE=1>" & strPlayerPercent & "%</TD>"
			'			rsPlayersTeamBPts.MoveNext()
			'		Else
			'			'le joueur n'a pas fait de pts, mettre des cellules vides
			'			strLine = strLine & "<TD BGCOLOR = white COLSPAN = 3></TD>"
			'		End If
			'		strLine = strLine & "<TD WIDTH=" & Str(ColWidth(9)) & "></TD>"
			'		strLine = strLine & "<TD WIDTH=" & Str(ColWidth(10)) & "></TD>"
			'		strLine = strLine & "</TR>"
			'	Next
			'	strLine = strLine & "</TABLE></DIV>"
			'	S = S & strLine
			'	rsPlayersTeamAPts.Close()
			'	rsPlayersTeamBPts.Close()
			'End If
			'rsGames.MoveNext()
		End While
		
		funGetCalendrier = S
		rsGames.Close()
	End Function
	
	Sub subOutputEquipe(ByVal iTeamNo As Short, ByRef strTitle As String, ByRef strFileName As String)
		
		FileOpen(1, strFileName, OpenMode.Output)
		PrintLine(1, "<HTML><HEAD><TITLE></TITLE></HEAD>")
		PrintLine(1, "<BODY TOPMARGIN=10 BGPROPERTIES=""FIXED"" BGCOLOR = " & DOC_BACKGROUND_COLOR & "><div id=Outline>")
		PrintLine(1, "<CENTER><FONT FACE=VERDANA COLOR = black SIZE=5><B>" & strTitle & "</FONT></CENTER>")
		PrintLine(1, "<BR><BR>")
		PrintLine(1, "<FONT FACE=VERDANA COLOR = black SIZE=4><B>calendrier</FONT><BR>")
		PrintLine(1, "<BR>")
		PrintLine(1, funGetCalendrier(iTeamNo))
		PrintLine(1, "<BR><BR>")
		PrintLine(1, "<FONT FACE=VERDANA COLOR = black SIZE=4><B>joueurs</FONT><BR>")
		PrintLine(1, "<BR>")
		PrintLine(1, funGetCompteurs(iTeamNo))
		PrintLine(1, "<BR>")
		PrintLine(1, funGetScript())
		PrintLine(1, "</HTML>")
		FileClose(1)
	End Sub
	
	Private Function funGetScript() As Object
		Dim S As String
		
		S = ""
		S = "<script>" & vbCrLf
		S = S & "<!--" & vbCrLf
		S = S & "var img1, img2;" & vbCrLf
		S = S & "img1 = new Image();" & vbCrLf
		S = S & "img1.src = """ & "plus.gif" & """;" & vbCrLf
		S = S & "img2 = new Image();" & vbCrLf
		S = S & "img2.src = """ & "minus.gif" & """;" & vbCrLf
		S = S & "" & vbCrLf
		S = S & "function doOutline() {" & vbCrLf
		S = S & "  var targetId, srcElement, targetElement;" & vbCrLf
		S = S & "  srcElement = window.event.srcElement;" & vbCrLf
		S = S & "  if (srcElement.className == """ & "Outline" & """) {" & vbCrLf
		S = S & "     targetId = srcElement.id + """ & "d" & """;" & vbCrLf
		S = S & "     targetElement = document.all(targetId);" & vbCrLf
		S = S & "     if (targetElement.style.display == """ & "none" & """) {" & vbCrLf
		S = S & "        targetElement.style.display = """ & """;" & vbCrLf
		S = S & "        if (srcElement.tagName == """ & "IMG" & """) {" & vbCrLf
		S = S & "           srcElement.src = """ & "minus.gif" & """;" & vbCrLf
		S = S & "        }" & vbCrLf
		S = S & "     } else {" & vbCrLf
		S = S & "        targetElement.style.display = """ & "none" & """;" & vbCrLf
		S = S & "        if (srcElement.tagName == """ & "IMG" & """) {" & vbCrLf
		S = S & "            srcElement.src = """ & "plus.gif" & """;" & vbCrLf
		S = S & "        }" & vbCrLf
		S = S & "     }" & vbCrLf
		S = S & "  }" & vbCrLf
		S = S & "}" & vbCrLf
		S = S & "" & vbCrLf
		S = S & "Outline.onclick = doOutline;" & vbCrLf
		S = S & "-->" & vbCrLf
		S = S & "</script>"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object funGetScript. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		funGetScript = S
	End Function
	
	Private Function funGetDayOfWeek(ByVal strD As String) As String
		'Retourne le jour de la semaine de la date strD
		Dim strJour As String
		
		strJour = Mid(VB6.Format(strD, "dddd, mmmm dd, yyyy"), 1, InStr(1, VB6.Format(strD, "dddd, mmmm dd, yyyy"), ",") - 1)
		
		Select Case strJour
			Case "Monday"
				strJour = "lun"
			Case "Tuesday"
				strJour = "mar"
			Case "Wednesday"
				strJour = "mer"
			Case "Thursday"
				strJour = "jeu"
			Case "Friday"
				strJour = "ven"
			Case "Saturday"
				strJour = "sam"
			Case "Sunday"
				strJour = "dim"
		End Select
		
		funGetDayOfWeek = strJour
		
	End Function
	
	Private Function funFormatDate(ByVal strD As String) As String
		'change le format de la date de : YYYY-MM-DD à DD-sept-YY
		Dim strDate As String
		
		strDate = Mid(strD, 9, 2)
		
		Select Case Mid(strD, 6, 2)
			Case "01"
				strDate = strDate & " jan "
			Case "02"
				strDate = strDate & " fev "
			Case "03"
				strDate = strDate & " mar "
			Case "04"
				strDate = strDate & " avr "
			Case "05"
				strDate = strDate & " mai "
			Case "06"
				strDate = strDate & " jun "
			Case "07"
				strDate = strDate & " jui "
			Case "08"
				strDate = strDate & " aou "
			Case "09"
				strDate = strDate & " sep "
			Case "10"
				strDate = strDate & " oct "
			Case "11"
				strDate = strDate & " nov "
			Case "12"
				strDate = strDate & " dec "
		End Select
		
		strDate = strDate & Mid(strD, 3, 2)
		funFormatDate = strDate
		
	End Function
	
	Sub subOutputQuestionnaire(ByRef intQuestNo As Short, ByRef strFileName As String)
		
		Dim rsQuest As ADODB.Recordset
		Dim I As Short
		
		rsQuest = rsGetQuest(intQuestNo)
		
		FileOpen(1, strFileName, OpenMode.Output)
		
		'début du document
		PrintLine(1, "<!DOCTYPE HTML PUBLIC -//W3C//DTD HTML 4.0 Transitional//EN><HTML><HEAD><TITLE></TITLE>")
		PrintLine(1, "<body TOPMARGIN=10 BGPROPERTIES=""FIXED"" BGCOLOR = " & DOC_BACKGROUND_COLOR & ">")
		PrintLine(1, "<CENTER>")
		PrintLine(1, "<FONT FACE=VERDANA COLOR = black SIZE=5></FONT><BR>test<BR>")
		PrintLine(1, "</CENTER>")
		
		rsQuest.MoveFirst()
		I = 1
		While Not rsQuest.EOF
			System.Windows.Forms.Application.DoEvents()
			
			'entête de la série
			PrintLine(1, "<TABLE BORDER=0 CELLSPACING=1 CELLPADING=3>")
			PrintLine(1, "<TR BGCOLOR=darkCyan><TD COLSPAN=2><FONT FACE=VERDANA SIZE=4 COLOR=White><B><I>Série " & rsQuest.Fields(8).Value & "</I></B></TD>")
			PrintLine(1, "<TD COLSPAN=1><FONT FACE=VERDANA SIZE=3 COLOR=White><B><I>" & rsQuest.Fields(9).Value & "</I></B></TD></TR>")
			PrintLine(1, "<TR BGCOLOR=darkCyan><TD COLSPAN=2><FONT FACE=VERDANA SIZE=2 COLOR=White><B></B></TD>")
			PrintLine(1, "<TD COLSPAN=1><FONT FACE=VERDANA SIZE=2 COLOR=White><B>" & rsQuest.Fields(10).Value & "</B></TD></TR>")
			PrintLine(1, "</TABLE>")
			PrintLine(1, "<BR>")
			
			I = I + 1
			rsQuest.MoveNext()
		End While
		
		'Print #1, "</TABLE>"
		
		FileClose(1)
		
	End Sub
End Module