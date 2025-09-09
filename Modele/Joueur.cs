using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeuPuissance4.Modele
{
    /// <summary>
    /// Classe joueur
    /// </summary>
    public class Joueur

    {
        private string nom { get; set; }
        private bool gagnant { get; set; }
        private int checkPoints { get; set; }
        private Jeton jeton { get; set; }
       
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom"></param>
        public Joueur(string nom)
        {
            this.nom = nom;
            gagnant = false;
            checkPoints = 0;
           

        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="symbole"></param>
        /// <param name="points"></param>
        public Joueur(string nom, string symbole, int points)
        {
            this.nom = nom;
            gagnant = false;
            checkPoints = points;
            jeton = new Jeton(symbole, points);
        }
        /// <summary>
        /// Attribut gagnant
        /// </summary>
        public bool Gagnant
        {
            get { return gagnant; }
            set { gagnant = value; }
        }
        /// <summary>
        /// Attribut Checkpoint
        /// </summary>
        public int CheckPoint
        {
            get { return checkPoints; }
            set { checkPoints = value; }
        }
        /// <summary>
        /// Methode pour obtenir les jetons 
        /// </summary>
        /// <returns></returns>
        public Jeton GetJeton()
        {
            return new Jeton(jeton.Symbole, jeton.Point);
        }

        /// <summary>
        /// Methode qui permet de donner les jetons
        /// </summary>
        /// <param name="symbole"></param>
        /// <param name="points"></param>
        public void setJeton(string symbole, int points)
        {
            jeton = new Jeton(symbole, points);
        }
        /// <summary>
        /// Methode qui permet de faire le choix 
        /// </summary>
        /// <param name="leplateau"></param>
        /// <param name="colonne"></param>
        /// <param name="rangee"></param>
        public void ProcederChoix(ref Plateau leplateau, int colonne, int rangee)
        {
            Jeton jeton = GetJeton();
            leplateau.PlacerJeton(colonne, rangee, GetJeton());

        }
    }



}

