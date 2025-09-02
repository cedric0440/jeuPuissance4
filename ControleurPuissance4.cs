using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace jeuPuissance4
{
    public class ControleurPuissance4
    {
        private int compteurTour;
        private Plateau plateau;
        private Joueur joueur1;
        private Joueur joueur2;

        // Constructeur
        public ControleurPuissance4(string nomJoueur1, string nomJoueur2)
        {
            compteurTour = 0;
            plateau = new Plateau();

            // joueur1 avec "X" et points = 1
            joueur1 = new Joueur(nomJoueur1, Jeton.JETON_X, Jeton.POINTS_1);

            // joueur2 avec "O" et points = -1
            joueur2 = new Joueur(nomJoueur2, Jeton.JETON_O, Jeton.POINTS_2);
        }


        public void JouerTour(int joueur, int indiceColonne)
        {
            Joueur Joueur = (joueur == 1) ? joueur1 : joueur2;

            int rangee = plateau.GetIndiceRangee(indiceColonne);
            if (rangee != -1)
            {
                plateau.PlacerJeton(indiceColonne, rangee, Joueur.GetJeton());
                compteurTour++;
            }
        }
        public string ObtenirPlateau()
        {
            return plateau.ToString();
        }
        public string ObtenirMessageGagnant()
        {
            if (IsGagnant())
            {
                if (compteurTour % 2 == 0)
                {
                    Joueur gagnant = joueur2;
                    return "Joueur2 gagnant";
                }
                else
                {
                    Joueur gagnant = joueur1;
                    return "Joueur1 gagnant";
                }
            }
            return "match nul";

        }
        public bool IsGagnant()
        {
            return true;
        }
        public int GetCompteurTour()
        {
            return 1;
        }
        public string GetSymbole(int numeroJoueur)
        {
            return "aaa";
        }
        public bool IsCaseDisponible(int colonne)
        {
            return true;
        }
        public void DeterminerGagnant(int joueur)
        {

        }
        public bool IsTermine()
        {
            return true;
        }
    }
}
