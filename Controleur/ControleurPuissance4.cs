using System;
using jeuPuissance4.Modele;

namespace jeuPuissance4.Controleur
{
    public class ControleurPuissance4
    {
        private int compteurTour;
        private Plateau plateau;
        private Joueur joueur1;
        private Joueur joueur2;

        public ControleurPuissance4(string nomJoueur1, string nomJoueur2)
        {
            compteurTour = 0;
            plateau = new Plateau();

            joueur1 = new Joueur(nomJoueur1, Jeton.JETON_X, Jeton.POINTS_1);
            joueur2 = new Joueur(nomJoueur2, Jeton.JETON_O, Jeton.POINTS_2);
        }

        public void JouerTour(int joueur, int indiceColonne)
        {
            // Utiliser le paramètre joueur pour déterminer le joueur actuel
            Joueur joueurActuel = (joueur == 1) ? joueur1 : joueur2;

            int rangee = plateau.GetIndiceRangee(indiceColonne);
            if (rangee >= 0)
            {
                joueurActuel.ProcederChoix(ref plateau, indiceColonne, rangee);
                DeterminerGagnant(); // Pas besoin de paramètre
                compteurTour++;
            }
        }

        public string ObtenirPlateau()
        {
            string result = "";
            for (int ligne = 0; ligne < Plateau.NOMBRE_RANGEES; ligne++) // ou NOMBRE_RANGEE selon votre classe Plateau
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

        public string ObtenirMessageGagnant()
        {
            if (IsTermine())
            {
            if (joueur1.Gagnant) return $"Le gagnant est joueur1";
            if (joueur2.Gagnant) return $"Le gagnant est joueur2";
            
            }
            return "Aucun gagnant pour l'instant.";
        }

        public bool IsGagnant()
        {
            return plateau.DeterminerGagnant(4);
        }


        public int GetCompteurTour()
        {
            return compteurTour;
        }

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

        public bool IsCaseDisponible(int colonne)
        {
            return plateau.IsCaseDisponible(colonne);
        }

        public void DeterminerGagnant()
        {
            if (plateau.DeterminerGagnant(4))
            {
                // Vérifier quel joueur a placé le dernier coup
                // Ici on part du principe que le compteurTour te dit qui a joué
                if (compteurTour % 2 == 0)
                    joueur1.Gagnant = true;
                else
                    joueur2.Gagnant = true;
            }
        }





        public bool IsTermine()
        {
            return (compteurTour >= Plateau.NOMBRE_CASES) || IsGagnant();
        }

  
    }
}