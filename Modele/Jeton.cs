using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeuPuissance4.Modele
{
    /// <summary>
    /// Classe Jeton
    /// </summary>
    public class Jeton
    {
        public const string JETON_X = "X";
        public const string JETON_O = "O";
        public const int POINTS_1 = 1;
        public const int POINTS_2 = -1;
        public const int CHECK_POINT_1 = 4;
        public const int CHECK_POINT_2 = -4;
        private string symbole;

        /// <summary>
        /// Attribut symbole 
        /// </summary>
        public string Symbole
        {
            get { return symbole; }
            set { symbole = value; }
        }
        /// <summary>
        /// Attribut point
        /// </summary>
        private int point { get; set; }
        public int Point
        {
            get { return point; }
            set { point = value; }
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="symbole"> symbole </param>
        /// <param name="point">point</param>
        public Jeton(string symbole, int point)
        {
            this.symbole = symbole;
            this.point = point;
        }



    }
}
