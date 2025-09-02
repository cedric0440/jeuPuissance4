using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeuPuissance4
{

    public class CJoueur

    {
        private string nom { get; set; }
        private bool gagnant{  get; set; }
         private int checkPoints { get; set; }
        private Jeton monJeton {get; set; }

        public Jeton GetJeton()
        {
            return monJeton;
           
        }

        public void setJeton(string symbole, int points)
        {
            monJeton = new Jeton();
            monJeton.Symbole = symbole;
            monJeton.Points = points;

        }

        public void ProcederChoix(ref Plateau leplateau, int colonne, int ligne)
        {
            Jeton jeton = GetJeton();
            leplateau.PlacerJeton(colonne, ligne, jeton);
           
        }
    }



}

