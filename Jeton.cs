using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeuPuissance4
{
    public class Jeton
    {
        public const string JETON_X ="X";
        public const string JETON_O = "O";
        public const int POINTS_1 = 1;
        public const int POINTS_2 = -1;
        public const int CHECK_POINT_1 = 4;
        public const int CHECK_POINT_2 = -4;
        private string symbole;

        public string Symbole
        {
            get { return symbole; }
            set { symbole = value; }
        }

        private int point { get; set; }
    

        public Jeton(string Symbole,int Point)
        {
            Symbole =  symbole;
            Point = point;
      

        }

     
    }
}
