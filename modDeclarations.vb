Option Strict Off
Option Explicit On
Module modDeclarations
	Public Const DOC_BACKGROUND_COLOR As String = "whitesmoke"
	Public Const COL_HEADER_COLOR As String = "darkcyan"
	Public Const F_DE_MATCH As String = "Questionnaires\match"
	'UPGRADE_NOTE: YEAR was upgraded to YEAR_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Const YEAR_Renamed As String = "2023-2024"

	'Public gcConn As ADODB.Connection
	Public gcConn As OleDb.OleDbConnection
End Module