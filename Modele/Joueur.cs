using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeuPuissance4.Modele
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
            gagnant = false;
            checkPoints = 0;
            jeton = new Jeton(" ", 0);

        }

        public Joueur(string nom, string symbole, int points)
        {
            this.nom = nom;
            gagnant = false;
            checkPoints = points;
            jeton = new Jeton(symbole, points);
        }

        public bool Gagnant
        {
            get { return gagnant; }
            set { gagnant = value; }
        }
        public int CheckPoint
        {
            get { return checkPoints; }
            set { checkPoints = value; }
        }
        public Jeton GetJeton()
        {
            return jeton;

        }

        public void setJeton(string symbole, int points)
        {
            jeton = new Jeton(symbole, points);
        }

        public void ProcederChoix(ref Plateau leplateau, int colonne, int rangee)
        {
            Jeton jeton = GetJeton();
            leplateau.PlacerJeton(colonne, rangee, GetJeton());

        }
    }



}

