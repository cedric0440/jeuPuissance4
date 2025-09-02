using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeuPuissance4
{

    public class Joueur

    {
        private string nom { get; set; }
        private bool gagnant { get; set; }
         private int checkPoints { get; set; }
        private Jeton jeton { get; set; }
        // Constructeur
        public Joueur(string nom)
        {
            this.nom = nom;
            this.gagnant = false;
            this.checkPoints = 0;
            this.jeton = new Jeton(" ", 0);

        }

        public Joueur(string nom, string symbole, int points)
        {
            this.nom = nom;
            this.gagnant = false;
            this.checkPoints = points;
            this.jeton = new Jeton(symbole, points);
        }

        public Jeton GetJeton()
        {
            return jeton;
           
        }

        public void setJeton(string symbole, int points)
        {
            jeton = new Jeton(symbole, points);
        }

        public void ProcederChoix(ref Plateau leplateau, int colonne, int ligne)
        {
            Jeton jeton = GetJeton();
            leplateau.PlacerJeton(colonne, ligne, jeton);
           
        }
    }



}

