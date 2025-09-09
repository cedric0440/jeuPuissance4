using jeuPuissance4.Modele;
namespace jeuPuissance4.Modele
{
    /// <summary>
    /// Classe plateau 
    /// </summary>
public class Plateau
{   
        /// <summary>
        /// Constante Nombre Cases
        /// </summary>
    public const int NOMBRE_CASES = 42;
        /// <summary>
        /// Constante Nombre colonnes 
        /// </summary>
    public const int NOMBRE_COLONNES = 7;
        /// <summary>
        /// Constante noombre rangees
        /// </summary>
    public const int NOMBRE_RANGEES = 6;
        /// <summary>
        /// Attribut jeton
        /// </summary>
    private Jeton[,] plateau;
        /// <summary>
        /// Constructeur
        /// </summary>
    public Plateau()
    {
        plateau = new Jeton[NOMBRE_RANGEES, NOMBRE_COLONNES];
    }
        /// <summary>
        /// Methode qui permet d'obtenir les jetons
        /// </summary>
        /// <param name="colonne"></param>
        /// <param name="ligne"></param>
        /// <returns></returns>
    public Jeton GetJeton(int colonne, int ligne)
    {
        if (colonne < 0 || colonne >= NOMBRE_COLONNES || ligne < 0 || ligne >= NOMBRE_RANGEES)
            return null;

        return plateau[ligne, colonne];
    }
        /// <summary>
        /// Methode qui permet de placer les jetons
        /// </summary>
        /// <param name="colonne"></param>
        /// <param name="ligne"></param>
        /// <param name="jeton"></param>
    public void PlacerJeton(int colonne, int ligne, Jeton jeton)
    {
        if (colonne >= 0 && colonne < NOMBRE_COLONNES &&
            ligne >= 0 && ligne < NOMBRE_RANGEES)
        {
            plateau[ligne, colonne] = jeton;
        }
    }
        /// <summary>
        /// Methode qui permet d'obtenir le nombre de cases
        /// </summary>
        /// <returns></returns>
    public int GetNombreCase()
    {
        return NOMBRE_CASES;
    }
        /// <summary>
        /// Methode qui permet de derterminer gagnant
        /// </summary>
        /// <param name="checkPoint"></param>
        /// <returns></returns>
    public bool DeterminerGagnant(int checkPoint)
    {
        const int JETONS_ALIGNES_POUR_GAGNER = 4;

        for (int ligne = 0; ligne < NOMBRE_RANGEES; ligne++)
        {
            for (int colonne = 0; colonne < NOMBRE_COLONNES; colonne++)
            {
                Jeton jeton = plateau[ligne, colonne];

                if (jeton != null)
                {
                    // Horizontal (→)
                    int countHorizontal = 0;
                    for (int i = 0; i < JETONS_ALIGNES_POUR_GAGNER && colonne + i < NOMBRE_COLONNES; i++)
                    {
                        Jeton j = plateau[ligne, colonne + i];
                        if (j != null && j.Symbole == jeton.Symbole)
                            countHorizontal++;
                        else
                            break;
                    }
                    if (countHorizontal >= JETONS_ALIGNES_POUR_GAGNER) return true;

                    // Vertical (↓)
                    int countVertical = 0;
                    for (int i = 0; i < JETONS_ALIGNES_POUR_GAGNER && ligne + i < NOMBRE_RANGEES; i++)
                    {
                        Jeton j = plateau[ligne + i, colonne];
                        if (j != null && j.Symbole == jeton.Symbole)
                            countVertical++;
                        else
                            break;
                    }
                    if (countVertical >= JETONS_ALIGNES_POUR_GAGNER) return true;

                    // Diagonale descendante (↘)
                    int countDiagDesc = 0;
                    for (int i = 0; i < JETONS_ALIGNES_POUR_GAGNER && ligne + i < NOMBRE_RANGEES && colonne + i < NOMBRE_COLONNES; i++)
                    {
                        Jeton j = plateau[ligne + i, colonne + i];
                        if (j != null && j.Symbole == jeton.Symbole)
                            countDiagDesc++;
                        else
                            break;
                    }
                    if (countDiagDesc >= JETONS_ALIGNES_POUR_GAGNER) return true;

                    // Diagonale montante (↗)
                    int countDiagMont = 0;
                    for (int i = 0; i < JETONS_ALIGNES_POUR_GAGNER && ligne - i >= 0 && colonne + i < NOMBRE_COLONNES; i++)
                    {
                        Jeton j = plateau[ligne - i, colonne + i];
                        if (j != null && j.Symbole == jeton.Symbole)
                            countDiagMont++;
                        else
                            break;
                    }
                    if (countDiagMont >= JETONS_ALIGNES_POUR_GAGNER) return true;
                }
            }
        }
        return false;
    }


        /// <summary>
        /// Methode qui permer de determiner si il y'a lesw cases disponibles 
        /// </summary>
        /// <param name="colonne"></param>
        /// <returns></returns>
    public bool IsCaseDisponible(int colonne)
    {
        if (colonne < 0 || colonne >= NOMBRE_COLONNES)
            return false;

        // Vérifier si la case du haut de la colonne est libre
        return plateau[0, colonne] == null;
    }
        /// <summary>
        /// Permet de determiner la rangee
        /// </summary>
        /// <param name="colonne"></param>
        /// <returns></returns>
    public int GetIndiceRangee(int colonne)
    {
        if (colonne < 0 || colonne >= NOMBRE_COLONNES)
            return -1;

        // Chercher la première case libre en partant du bas
        for (int ligne = NOMBRE_RANGEES - 1; ligne >= 0; ligne--)
        {
            if (plateau[ligne, colonne] == null)
            {
                return ligne;
            }
        }

        // Colonne pleine
        return -1;
    }
}
}