# Création de la liste des compteurs. Le DS joueur doit déjà exister.


# Fusionne les DataFrames joueurs et équipes, ajoute le suffixe "(Équipe)" au nom du joueur s'il est identique au nom de l'équipe.
joueurs <- merge(joueurs, équipes, by = "NoÉquipe") %>%
  select(NoÉquipe, NoJoueur, NomÉquipe, PrénomJoueur, NomJoueur) %>%
  mutate(
    NomComplet = ifelse(NomJoueur == NomÉquipe, paste(PrénomJoueur, NomJoueur, "(Équipe)", sep = " "), paste(PrénomJoueur, NomJoueur, sep = " "))
  )

# Agrège les points par équipe et joueur, puis ordonne par NoJoueur.
ptsParJoueur <- aggregate(Points ~ NoÉquipe + NoJoueur, data = RépondantsParJoueurs, FUN = sum) %>% arrange(NoJoueur)

# Fusionne les informations des joueurs avec les points agrégés.
compteurs <- merge(joueurs, ptsParJoueur) 

# Calcule le nombre de parties jouées (PJ) par combinaison de NoÉquipe et NoJoueur.
PJ <- RépondantsParJoueurs %>%
  group_by(NoÉquipe, NoJoueur) %>%
  summarize(PJ = n()) %>%
  select(NoÉquipe, NoJoueur, PJ)

# Fusionne les informations de PJ avec le DataFrame compteurs, calcule PointsParPJ et ordonne par PointsParPJ.
compteurs <- merge(compteurs, PJ) %>%
  mutate(PointsParPJ = round(Points / PJ, 2))


# Trie les données par ordre décroissant de PointsParPJ et attribue des positions aux joueurs en cas d'égalité.
compteurs0 <- compteurs %>%
  mutate(ConcatenationPts = as.numeric(sprintf("%.4f", PointsParPJ + Points/10000))) %>%  # ajout du champs pour trier par PointsParPJ + Points 
  mutate(Position = rank(desc(ConcatenationPts), ties.method = "min")) %>% #Création de la position en fontion de PointsParPJ + Points
  select(Position,NomComplet, NomÉquipe, PJ, Points, PointsParPJ) %>% # Sélection des champs
  arrange(Position) # Tri par desc PointsParPJ puis desc Points.

#TODO Ajouter le reactable. Mettre un détail avec les parties du joueurs.
# exemple détail possible : nopartie, date, équipe A, ptsA, équipe B, pts B, pts du joueur, % du total de la partie.
# fusion entre calendrier et RépondantsParJoueurs


