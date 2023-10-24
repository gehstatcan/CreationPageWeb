# Lecture de Saison en cours.
# Il faur un DNS. J'ai cré SaisonEnCours. BD doit être dans : "F:\Users\MM\Documents\Git\GehStatcan_R\SaisonEnCours.mdb"

install.packages("RODBC")
library(RODBC)

conn <- odbcConnect("SaisonEnCours")
Équipes <- sqlFetch(conn, "tblÉquipes")
Parties <- sqlFetch(conn, "tblParties")
Joueurs <- sqlFetch(conn, "tblJoueurs")
RépondantsParJoueurs <- sqlFetch(conn, "tblRépondantsParJoueurs")

#Écrire en csv 
write.table(Équipes, "tblEquipes.csv", sep = ",", quote = FALSE, row.names = FALSE)
write.table(Parties, "tblParties.csv", sep = ",", quote = FALSE, row.names = FALSE)
write.table(Joueurs, "tblJoueurs.csv", sep = ",", quote = FALSE, row.names = FALSE)
write.table(RépondantsParJoueurs, "tblRépondantsParJoueurs.csv", sep = ",", quote = FALSE, row.names = FALSE)

odbcClose(conn)
