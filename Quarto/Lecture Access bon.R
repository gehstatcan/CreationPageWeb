# Charger la bibliothèque RODBC
install.packages("odbc")

# Charger la bibliothèque odbc
library(odbc)

# Spécifier le chemin vers la base de données MDB
mdb_file <- "F:/Users/MM/Documents/Git/SaisonEnCours/SaisonEnCours.mdb"

# Établir une connexion à la base de données
con <- dbConnect(odbc::odbc(), Driver = "{Microsoft Access Driver (*.mdb, *.accdb)}", 
                 DBQ = mdb_file)

# Exécuter une requête SQL (par exemple, pour lire une table nommée "MaTable")
sql_query <- "SELECT * FROM tblÉquipes" 
Équipes <- dbGetQuery(con, sql_query)

sql_query <- "SELECT * FROM tblJoueurs" 
Joueurs <- dbGetQuery(con, sql_query)

sql_query <- "SELECT * FROM tblParties" 
Parties <- dbGetQuery(con, sql_query)

sql_query <- "SELECT * FROM tblRépondantsParJoueurs" 
RépondantsParJoueurs <- dbGetQuery(con, sql_query)

# Fermer la connexion
dbDisconnect(con)

#Création des CSV
write.table(Équipes, "tblEquipes.csv", sep = ",", quote = FALSE, row.names = FALSE)
write.table(Parties, "tblParties.csv", sep = ",", quote = FALSE, row.names = FALSE)
write.table(Joueurs, "tblJoueurs.csv", sep = ",", quote = FALSE, row.names = FALSE)
write.table(RépondantsParJoueurs, "tblRépondantsParJoueurs.csv", sep = ",", quote = FALSE, row.names = FALSE)




