using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Joueur Joueur = joueur == 1 ? joueur1 : joueur2;

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
            return plateau.DeterminerGagnant(joueur1.CheckPoint) || plateau.DeterminerGagnant(joueur2.CheckPoint);
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
            else{ 
                return joueur2.GetJeton().Symbole;
            }
        }
        public bool IsCaseDisponible(int colonne)
        {
            return plateau.IsCaseDisponible(colonne);
        }
        public void DeterminerGagnant(int joueur)
        {
            if (plateau.DeterminerGagnant(Jeton.CHECK_POINT_1))
            {
                joueur1.Gagnant = true;
            }
            else if (plateau.DeterminerGagnant(Jeton.CHECK_POINT_2))
            {
                joueur2.Gagnant = true;
            }
        }
        public bool IsTermine()
        {
            return true;
        }
    }
}
