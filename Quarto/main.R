### Important, éviter les accent dans les noms de fichiers et les nom de champs. ex: noÉquipe = problème. Utiliser noEquipe

# install.packages("dplyr", repos = "https://svc-ins-rpug:cmVmdGtuOjAxOjAwMDAwMDAwMDA6U2NaQTVJRjFKRlV2amNQY3dRVzdqdEZWVUNN@artifactory.cloud.statcan.ca/artifactory/cran-remote/", type = "binary")
# install.packages("Rtools", repos = "https://svc-ins-rpug:cmVmdGtuOjAxOjAwMDAwMDAwMDA6U2NaQTVJRjFKRlV2amNQY3dRVzdqdEZWVUNN@artifactory.cloud.statcan.ca/artifactory/cran-remote/", type = "binary")

#install.packages("dplyr")
#install.packages("reactable")
#
#install.packages("Rtools")

#Installation des packages
    
  if (!require("Rtools", character.only = TRUE)) {
    # Si le package n'est pas installé, l'installer
    install.packages("Rtools")
  }
  # Charger le package "dplyr"
  library(Rtools)

  # Vérifier si le package "dplyr" est installé
  if (!require("dplyr", character.only = TRUE)) {
    # Si le package n'est pas installé, l'installer
    install.packages("dplyr")
  }
  # Charger le package "dplyr"
  library(dplyr)
  
  # Vérifier si le package "dplyr" est installé
  if (!require("reactable", character.only = TRUE)) {
    # Si le package n'est pas installé, l'installer
    install.packages("reactable")
  }
  # Charger le package "dplyr"
  library(reactable)
  
  if (!require("readr", character.only = TRUE)) {
    # Si le package n'est pas installé, l'installer
    install.packages("readr")
  }
  # Charger le package "dplyr"
  library(readr)

  if (!require("reactable", character.only = TRUE)) {
    # If tidyr is not installed, install it
    install.packages("tidyr")
  }
  library("tidyr")
  

  

# Définition des variables
année_courante <- "2023-2024"
écartPoints <- 40
répertoire_données <- "F:/Users/MM/Documents/Git/Quarto/"
répertoire_code <- "F:/Users/MM/Documents/Git/Quarto/"
#répertoire_données <- "C:/Git/Gehstatcan_R/Quarto/"
#répertoire_code <- "C:/Git/Gehstatcan_R/Quarto/"

setwd(répertoire_code)


# Set the time zone to your desired value
Sys.setenv(TZ="Canada/Eastern")
# Check the current time zone
Sys.getenv("TZ")

# Construction des noms de fichiers à charger (les tables)
file_path_équipes <- paste0(répertoire_données, "tblEquipes.csv")
file_path_parties <- paste0(répertoire_données, "tblParties.csv") 
file_path_joueurs <- paste0(répertoire_données, "tblJoueurs.csv") 
file_path_RépondantsParJoueurs <- paste0(répertoire_données, "tblRépondantsParJoueurs.csv")

# Lecture des CSV (tables)
équipes               <- read.csv(file_path_équipes, header = TRUE, sep = ",") %>% arrange(NoÉquipe)
parties               <- read.csv(file_path_parties, header = TRUE, sep = ",") %>% arrange(NoPartie)
joueurs               <- read.csv(file_path_joueurs, header = TRUE, sep = ",") %>% arrange(NoÉquipe,NoJoueur)
RépondantsParJoueurs  <- read.csv(file_path_RépondantsParJoueurs, header = TRUE, sep = ",") %>% arrange(NoPartie, NoÉquipe)


#Calendrier fait ici car requis pour le classement.

  # Création du calendrier
  calendrier <- merge(parties, équipes, by.x = "NoÉquipeA", by.y = "NoÉquipe")
  calendrier <- merge(calendrier, équipes, by.x = "NoÉquipeB", by.y = "NoÉquipe", suffixes = c("A", "B"))


#Ajout des points des équipes
# Calculate the sum of points per NoPartie and noEquipe
ptsParPartieÉquipe <- aggregate(Points ~ NoPartie + NoÉquipe, data = RépondantsParJoueurs[1:369, ], FUN = sum) %>% arrange(NoPartie, NoÉquipe)
# calendrier <- merge(calendrier,ptsParPartieÉquipe,  by = c("NoPartie","noEquipe"))
calendrier <- merge(calendrier,ptsParPartieÉquipe, by.x = c("NoPartie", "NoÉquipeA"), by.y = c("NoPartie", "NoÉquipe"), all.x = TRUE) %>% rename("PointsA" = "Points")
calendrier <- merge(calendrier, ptsParPartieÉquipe, by.x = c("NoPartie", "NoÉquipeB"), by.y = c("NoPartie", "NoÉquipe"),all.x = TRUE) %>% 
  rename("PointsB" = "Points") %>%
  arrange(NoPartie)  

#Élimine les vides ***TODO faire plus tard car change en chr (vs int)
#calendrier[is.na(calendrier)] <- ""

# Conserve seulement les colonnes pertinentes et les réorganise
calendrier <- calendrier[, c("NoPartie", "Date", "NomÉquipeA","PointsA", "NoÉquipeA", "NomÉquipeB","PointsB","NoÉquipeB", "NomAnimateur","LienReunion","LienConsole","LienBouton")] %>%
  arrange(NoPartie)


### Call CLASSEMENT ###
  
### Call Calendrier ###


