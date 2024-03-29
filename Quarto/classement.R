
# Classement --------------------------------------------------------------


  ## Librairies --------------------------------------------------------------


    ## Création de la table ----------------------------------------------------

  # Ajouter la colonne "Gagnant" en fonction des conditions
  # Ajout de l'équipe Bidon pour que les colonnes restent même s'il n'y pas d'équipe avec cette condition (ex: pas de partie nulle.)
  NomColonneAExclure1 <- c("LienConsole", "LienReunion", "LienBouton", "NomAnimateur")
  calendrierPourClassement <- calendrier[!is.na(calendrier$PointsA), !(names(calendrier) %in% NomColonneAExclure1)] #exclusion des colonnes de liens
  
  Classement1 <- calendrierPourClassement %>%
    mutate(
      DifferencePoints = abs(PointsA - PointsB),
      "4pts" = ifelse(PointsA > PointsB & DifferencePoints > écartPoints, NomÉquipeA, ifelse(PointsA < PointsB & DifferencePoints > écartPoints, NomÉquipeB, "Bidon")),
      "3pts" = ifelse(PointsA > PointsB & DifferencePoints <= écartPoints, NomÉquipeA, ifelse(PointsA < PointsB & DifferencePoints <= écartPoints, NomÉquipeB, "Bidon")),
      "2ptsA" = ifelse(PointsA == PointsB, NomÉquipeA,"Bidon"),
      "2ptsB" = ifelse(PointsA == PointsB, NomÉquipeB,"Bidon"),    
      "1pt" = ifelse(PointsA > PointsB & DifferencePoints <= écartPoints, NomÉquipeB, ifelse(PointsA < PointsB & DifferencePoints <= écartPoints, NomÉquipeA, "Bidon")),
      "0pt" = ifelse(PointsA > PointsB & DifferencePoints > écartPoints, NomÉquipeB, ifelse(PointsA < PointsB & DifferencePoints > écartPoints, NomÉquipeA, "Bidon")),
      #Perdant =ifelse(PointsA < PointsB, NomÉquipeA, ifelse(PointsA > PointsB, NomÉquipeB, ""))
    )
  
  # **Agréger les données par équipe et faire le compte des parite gagnées/perdues
  all_pts_types <- c("4pts", "3pts", "2ptsA", "2ptsB", "1pt", "0pt") #Colonnes à conserver même s'il n'y pas de valeur.
  
  Classement_pts <- Classement1 %>%
    pivot_longer(cols = all_of(all_pts_types), names_to = "pts_type", values_to = "NomÉquipe") %>%
    filter(!is.na(NomÉquipe) & NomÉquipe != "") %>%
    group_by(NomÉquipe, pts_type) %>%
    summarise(Count = n()) %>%
    pivot_wider(names_from = pts_type, values_from = Count, values_fill = 0)
  
  #Création d'une seule colonne pourles nulle et ajout des parties jouées PJ
  Classement_pts <- Classement_pts %>%
    mutate(`2pts` = `2ptsA` + `2ptsB`) %>%
    select(-`2ptsA`, -`2ptsB`)  %>%
    filter(!NomÉquipe %in% "Bidon") %>%
    rowwise() %>%
    mutate(PJ = sum(c_across(contains("pt")), na.rm = TRUE))
  
  #calcul des points 
  Classement_pts <- Classement_pts %>%
    mutate("ptsTot" = (`4pts` * 4) +
             (`3pts` * 3) +
             (`2pts` * 2) +
             `1pt` ) %>%
    mutate("pctPoints" = ptsTot/(PJ*4)*100)
  
  #Calcule des pour et contre
    pointsPour <- RépondantsParJoueurs %>%
      group_by(NoPartie, NoÉquipe) %>%
      summarise(PointsPour = sum(Points))
  
    # Jointure pour obtenir les pointsContre
    pointsPourContre <- pointsPour %>%
      left_join(pointsPour, by = "NoPartie") %>%
      filter(NoÉquipe.x != NoÉquipe.y) %>%
      group_by(NoPartie, NoÉquipe.x, PointsPour.x) %>%
      summarise(
        PointsContre = sum(PointsPour.y)
      )
    
    # Grouper par NoÉquipe.x
    pointsPourContre <- pointsPourContre %>% 
      group_by(NoÉquipe.x) %>% 
      summarise(PointsPour = sum(PointsPour.x), PointsContre = sum(PointsContre))
    
    #J'ai besoin du nom pour le merge
    pointsPourContre <- pointsPourContre %>%
      left_join(équipes, by = c("NoÉquipe.x" = "NoÉquipe")) %>%
      select( NoÉquipe = NoÉquipe.x, NomÉquipe, PointsPour, PointsContre)
    
  #Fusion avec les parties jouées
    Classement_pts <- merge(Classement_pts, pointsPourContre, by.x = "NomÉquipe", by.y = "NomÉquipe")
  
  #Ajouter les équipes qui n'ont pas encore joué avec des 0 partout.
    
    #***** EN COURS ********
    Classement_pts <- équipes %>%
      left_join(Classement_pts, by = c("NomÉquipe" = "NomÉquipe", "NoÉquipe" = "NoÉquipe")) %>%
      mutate_all(~ifelse(is.na(.), 0, .))    
    
    #création du tableau
    
    # 1. Création de la différence de points et trie par pctPoints puis Diff.
    Classement_pts <- Classement_pts %>%
      mutate(Diff = PointsPour-PointsContre) %>% 
      mutate(DiffTri = sprintf("%06d", Diff+10000)) %>% 
      mutate(ConcatenationTri = paste(ceiling(pctPoints),DiffTri,sep="."))  %>%   # ajout du champs pour trier par PointsParPJ + Points 
      mutate(ConcatenationTriNum = as.numeric(ConcatenationTri)) %>% 
      mutate(Position = rank(desc(ConcatenationTriNum), ties.method = "min")) %>% 
      #Selection des variable et assignation des noms 
      select(Position, NomÉquipe, PJ,"4pts","3pts","2pts","1pt","0pt",ptsTot,pctPoints,PointsPour,PointsContre,Diff) %>% 
      rename(G="4pts",GP="3pts",PN="2pts",PP="1pt",P="0pt",Pts=ptsTot,"%"=pctPoints,Pour="PointsPour",Contre="PointsContre") %>% 
      arrange(Position)
    


    ## Affichage via reactable -------------------------------------------------

  # 2. affichage
  reactable(
    Classement_pts,
    defaultColDef = colDef(
      header = function(value) gsub(".", " ", value, fixed = TRUE),
      cell = function(value) format(value, nsmall = 0),
      align = "center",
      #cell = function(value) format(value, nsmall = 0),
      maxWidth = 40,
      headerStyle = list(background = "#f7f7f8")
    ),
    columns = list(
      "Position" = colDef(name="Pos",
                          maxWidth =  40,
                          align="center"),
      "NomÉquipe" =  colDef(name = "Équipe", 
                            maxWidth =270,
                            align = "left")  ,
      "Pour" =  colDef(name = "Pour", 
                            maxWidth =60,
                            align = "center") ,
      "Contre" =  colDef(name = "Contre",
                         maxWidth =65,
                       align = "center") , 
                      cellStyle = function(value) list(border = "1px solid black"),
      "Diff" =  colDef(name = "Diff",
                       maxWidth =60,
                       align = "center") ,
                cellStyle = function(value) {
                  if (value > 40) {
                    list(background = "yellow")
                  } else {
                    list()
                  }
                },
        "%" =  colDef( maxWidth =50,
                       cell = function(value) format(value, nsmall = 0)),
        "Pts" =  colDef(name = "Pts",
                               header = function(value) htmltools::strong(htmltools::em("Pts")),
                               cell = function(value) htmltools::strong(format(value, nsmall = 0)))
    ),
    bordered = TRUE,
    highlight = TRUE
  )
  
  #TODO : Ajouter le détail des équipe avec les joueurs de cette équipe (comme dans compteurs). 
  # Ajouter aussi l'horaire du calendrier... ?
  

write.table(Classement_pts, "Classement_pts.csv", sep = ",", quote = FALSE, row.names = FALSE)
write.table(équipes, "équipes.csv", sep = ",", quote = FALSE, row.names = FALSE)  



# Expérimentation ---------------------------------------------------------


##Version intéressante qui n'utilise pas Bidon:
###*# **Agréger les données par équipe et faire le compte des parite gagnées/perdues
# all_pts_types <- c("4pts", "3pts", "2ptsA", "2ptsB", "1pt", "0pt") #Colonnes à conserver même s'il n'y pas de valeur.
# 
# Classement_pts <- Classement1 %>%
#   pivot_longer(cols = all_pts_types, names_to = "pts_type", values_to = "Name") %>%
#   filter(!is.na(Name) & Name != "") %>%
#   group_by(Name, pts_type) %>%
#   summarise(Count = n()) %>%
#   pivot_wider(names_from = pts_type, values_from = Count, values_fill = 0)
# 
# # Recherchez les colonnes manquantes dans Classement_pts
# colonnes_absentes <- setdiff(all_pts_types, colnames(Classement_pts))
# 
# # Créez un dataframe vide avec les colonnes manquantes (si nécessaire)
# if (length(colonnes_absentes) > 0) {
#   colonnes_vides <- as.data.frame(matrix(0, nrow = nrow(Classement_pts), ncol = length(colonnes_absentes)))
#   colnames(colonnes_vides) <- colonnes_absentes
#   Classement_pts <- cbind(Classement_pts, colonnes_vides)
# }
# 
# #Création d'une seule colonne pourles nulle et ajout des parties jouées PJ
# Classement_pts <- Classement_pts %>%
#   mutate(`2pts` = `2ptsA` + `2ptsB`) %>%
#   select(-`2ptsA`, -`2ptsB`)  %>%
#   filter(!Name %in% "Bidon") %>%
#   rowwise() %>%
#   mutate(PJ = sum(c_across(contains("pt")), na.rm = TRUE))
# 
# #calcul des points
# Classement_pts <- Classement_pts %>%
#   mutate("ptsTot" = (`4pts` * 4) +
#            (`3pts` * 3) +
#            (`2pts` * 2) +
#            `1pt` ) %>%
#   mutate("pctPoints" = ptsTot/(PJ*4)) %>%
#   arrange(desc(pctPoints)) %>%
#   mutate(Position = row_number())