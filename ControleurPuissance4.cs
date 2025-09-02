using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace jeuPuissance4
{
    public class ControleurPuissance4(string nomJoueur1, string nomJoueur2)
    {
        private int compteurTour;

        public void JouerTour(int joueur, int indiceColonne)
        {

        }
        public string ObtenirPlateau()
        {
            return "aaa";
        }
        public string ObtenirMessageGagnant()
        {
            return "aaa";
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
