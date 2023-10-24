#Création du calendrier. Juste en R mais éventuellement en qmd


#Création des points par parties par joueurs
calendrierDetailJoueurs <- merge(RépondantsParJoueurs,joueurs, by = c("NoEquipe", "NoJoueur") )   
calendrierDetailJoueurs <- merge(calendrierDetailJoueurs,équipes, by = c("NoEquipe")) 
calendrierDetailJoueurs <- calendrierDetailJoueurs[,c("NoPartie", "PrénomJoueur","NomJoueur","NomEquipe","Points")] 
calendrierDetailJoueurs <- calendrierDetailJoueurs %>% 
  arrange(NoPartie, desc(Points)) %>% 
  mutate(
    NomComplet = ifelse(NomJoueur == NomEquipe, paste(PrénomJoueur, NomJoueur, "(Équipe)", sep = " "), paste(PrénomJoueur, NomJoueur, sep = " "))
  ) %>% 
  select(NoPartie ,NomComplet,NomEquipe,Points)

#Création des colonnes Calendrier:

# Création d'une colonne pour combiner l'animateur et le lien de la console.
AnimateurConsole <- colDef(
  name = "Animateur (lien vers la console)",
  cell = function(value, index, column_name) {
    # Obtenez l'URL correspondant dans la colonne "URL"
    url <- calendrier[index, "LienConsole"]
    
    # Créez un lien hypertexte avec le texte de la colonne "Texte"
    #link <- paste0('<a href="', url, '" target="_blank">', value, '</a>')
    
    # Renvoyez le HTML du lien
    # htmltools::HTML(link)
    htmltools::tags$a(href = url, target = "_blank", value)
  }
)




#V2.2, C'est bon!
NomColonneAExclure <- c("LienConsole", "NoEquipeA", "NoEquipeB")

reactable(
  calendrier[, !(names(calendrier) %in% NomColonneAExclure)], #exclusion de la colonne LienConsole
  
  bordered = TRUE,
  highlight = TRUE,
  pagination = FALSE,
  
  #valeurs par défaut pour les colonnes
  defaultColDef = colDef(
    header = function(value) gsub(".", " ", value, fixed = TRUE),
    # cell = function(value) format(value, nsmall = 1),
    align = "left",
    minWidth = 10,
    headerStyle = list(background = "#f7f7f8")
  ),
  columns = list(
    # overrides the default
    "NoPartie" = colDef(name = "#", maxWidth =  50),
    "NomEquipeA" =  colDef(name = "Équipe A",maxWidth = 200),
    "NomEquipeB" =  colDef(name = "Équipe B"),
    "Points A" =   colDef(name = "Pts",align = "center",maxWidth = 50),
    "Points B" =   colDef(name = "Pts",align = "center",maxWidth = 50),
    "LienReunion" = colDef(cell = function(value, index) {
      # Render as a link
      Texte <- sprintf("%s%s",  "Lien Teams #", index)
      htmltools::tags$a(href = value, target = "_blank", Texte)
    },name = "Lien Réunion"),
    NomAnimateur = AnimateurConsole,      
    LienBouton = colDef(cell = function(value, index) {
      # Render as a link
      Texte <- sprintf("%s%s",  "Lien joueur #", index)
      htmltools::tags$a(href = value, target = "_blank", Texte)
    })
  ),
  
  #Définition de la fonction details pour fournir un contenu personnalisé
  details = function(index) {
    detailcalendrier <- calendrierDetailJoueurs[calendrierDetailJoueurs$NoPartie == calendrier$NoPartie[index], ]
    if (nrow(detailcalendrier) > 0) {
      
      # Exclure la colonne "NoPartie" de la section "details"
      detailcalendrier <- detailcalendrier[, !(names(detailcalendrier) %in% "NoPartie")]
      
      htmltools::div(style = "padding: 1rem",
                     reactable(detailcalendrier, 
                               outlined = TRUE,
                               #fullWidth = FALSE,
                               columns = list(
                                 # "NoPartie" = colDef(name = "#", maxWidth =  40),
                                 "NomComplet" = colDef(name = "Joueur", maxWidth =  270),
                                 "NomEquipe" = colDef(name = "Équipe", maxWidth =  200),
                                 "Points" = colDef(name = "Pts", maxWidth =  50)
                               )
                               )
      )
    } else {
      ""  # Si aucun détail n'est disponible, renvoyer une chaîne vide
    }
  }
)





# EXPÉRIMENTATION AVEC REACTABLE

#Ajouter des valeurs par defaut
#V1, pas de détail, lien laid.
reactable(
  calendrier,
  defaultColDef = colDef(
    header = function(value) gsub(".", " ", value, fixed = TRUE),
    cell = function(value) format(value, nsmall = 1),
    align = "left",
    minWidth = 10,
    headerStyle = list(background = "#f7f7f8")
  ),
  columns = list(
    "NomÉquipe A" =  colDef(align = "center"),  # overrides the default
    "NoPartie" = colDef( maxWidth =  25, minWidth =  25,name = "#"),  # overrides the default
    LienReunion = colDef(cell = function(value, index) {
      # Render as a link
      url <- sprintf("https://wikipedia.org/wiki/%s_%s",  "LienReunion", value)
      htmltools::tags$a(href = url, target = "_blank", as.character(value))
    })
  ),
  bordered = TRUE,
  highlight = TRUE
)

# NomJoueurAffichage <- coldef (
#   name = "Joueur",
#   cell = function(value, index, column_name) {
#     
#     nom <- calendrierDetailJoueurs[index, "NomJoueur"]
#     équipe <- calendrierDetailJoueurs[index, "NomÉquipe"]
#     paste0(nom, équipe, value)
#   }
# )

# reactable(
#   iris[1:30, ],
#   searchable = TRUE,
#   striped = TRUE,
#   highlight = TRUE,
#   bordered = TRUE,
#   theme = reactableTheme(
#     borderColor = "#dfe2e5",
#     stripedColor = "#f6f8fa",
#     highlightColor = "#f0f5f9",
#     cellPadding = "8px 12px",
#     style = list(fontFamily = "-apple-system, BlinkMacSystemFont, Segoe UI, Helvetica, Arial, sans-serif"),
#     searchInputStyle = list(width = "100%")
#   )
# )