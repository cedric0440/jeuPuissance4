using System;
using jeuPuissance4.Modele;


namespace jeuPuissance4.Controleur
{
    /// <summary>
    /// Controleur de la vue 
    /// </summary>
    public class ControleurPuissance4
    {
        private int compteurTour;
        private Plateau plateau;
        private Joueur joueur1;
        private Joueur joueur2;

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="nomJoueur1"> Joueur1</param>
        /// <param name="nomJoueur2"> Joueur2</param>
        public ControleurPuissance4(string nomJoueur1, string nomJoueur2)
        {
            compteurTour = 1;
            plateau = new Plateau();

            joueur1 = new Joueur(nomJoueur1, Jeton.JETON_X, Jeton.POINTS_1);
            joueur2 = new Joueur(nomJoueur2, Jeton.JETON_O, Jeton.POINTS_2);
        }
        /// <summary>
        /// Methode qui permettre de jouer 
        /// </summary>
        /// <param name="joueur"> </param>
        /// <param name="indiceColonne"> colonne du plateau</param>
        public void JouerTour(int joueur, int indiceColonne)
        {
            
            Joueur joueurActuel = (joueur == 1) ? joueur1 : joueur2;

            int rangee = plateau.GetIndiceRangee(indiceColonne);
            if (rangee >= 0)
            {
                joueurActuel.ProcederChoix(ref plateau, indiceColonne, rangee);
                DeterminerGagnant(); 
                compteurTour++;
            }
        }
        /// <summary>
        /// Methode permettant d'obtenir l'affichage du plateau 
        /// </summary>
        /// <returns></returns>
        public string ObtenirPlateau()
        {
            string result = "";
            for (int ligne = 0; ligne < Plateau.NOMBRE_RANGEES; ligne++) 
            {
                for (int col = 0; col < Plateau.NOMBRE_COLONNES; col++)
                {
                    Jeton j = plateau.GetJeton(col, ligne);
                    result += (j != null ? j.Symbole : ".") + " ";
                }
                result += "\n";
            }
            return result;
        }
        /// <summary>
        /// Methode qui renvoie le message a la fin du jeu 
        /// </summary>
        /// <returns></returns>
        public string ObtenirMessageGagnant()
        {
            if (IsTermine())
            {
            if (joueur1.Gagnant) return $"Le gagnant est joueur1";
            if (joueur2.Gagnant) return $"Le gagnant est joueur2";
            
            }
            return "Aucun gagnant pour l'instant.";
        }
        /// <summary>
        /// Methode qui designe si il y'a un gagnant
        /// </summary>
        /// <returns></returns>
        public bool IsGagnant()
        {
            return plateau.DeterminerGagnant(4);
        }

        /// <summary>
        /// Methode qui determine le nombre de tour qui a ete jouer
        /// </summary>
        /// <returns></returns>
        public int GetCompteurTour()
        {
            return compteurTour;
        }
        /// <summary>
        /// Methode qui determine le symbole du joueur 
        /// </summary>
        /// <param name="numeroJoueur"> le numero du joueur</param>
        /// <returns></returns>
        public string GetSymbole(int numeroJoueur)
        {
            if (numeroJoueur == 1)
            {
                return joueur1.GetJeton().Symbole;
            }
            else
            {
                return joueur2.GetJeton().Symbole;
            }
        }
        /// <summary>
        /// Methode qui determine si il y'a les cases disponibles 
        /// </summary>
        /// <param name="colonne"> nombre de colonne </param>
        /// <returns></returns>
        public bool IsCaseDisponible(int colonne)
        {
            return plateau.IsCaseDisponible(colonne);
        }
        /// <summary>
        /// Methode qui determine le gagnant 
        /// </summary>
        public void DeterminerGagnant()
        {
            if (plateau.DeterminerGagnant(4))
            {
               
                if (compteurTour % 2 == 0)
                    joueur2.Gagnant = true;
                else
                    joueur1.Gagnant = true;
            }
        }




        /// <summary>
        /// Methode qui dit si le jeu est terminé 
        /// </summary>
        /// <returns></returns>
        public bool IsTermine()
        {
            return (compteurTour >= Plateau.NOMBRE_CASES) || IsGagnant();
        }

  
    }
}