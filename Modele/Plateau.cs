using jeuPuissance4.Modele;

public class Plateau
{
    public const int NOMBRE_CASES = 42;
    public const int NOMBRE_COLONNES = 7;
    public const int NOMBRE_RANGEES = 6;

    private Jeton[,] plateau;

    public Plateau()
    {
        plateau = new Jeton[NOMBRE_RANGEES, NOMBRE_COLONNES];
    }

    public Jeton GetJeton(int colonne, int ligne)
    {
        if (colonne < 0 || colonne >= NOMBRE_COLONNES || ligne < 0 || ligne >= NOMBRE_RANGEES)
            return null;

        return plateau[ligne, colonne];
    }

    public void PlacerJeton(int colonne, int ligne, Jeton jeton)
    {
        if (colonne >= 0 && colonne < NOMBRE_COLONNES &&
            ligne >= 0 && ligne < NOMBRE_RANGEES)
        {
            plateau[ligne, colonne] = jeton;
        }
    }

    public int GetNombreCase()
    {
        return NOMBRE_CASES;
    }

    public bool DeterminerGagnant(int checkPoints)
    {
        // Parcourir tout le plateau
        for (int ligne = 0; ligne < NOMBRE_RANGEES; ligne++)
        {
            for (int colonne = 0; colonne < NOMBRE_COLONNES; colonne++)
            {
                Jeton jeton = plateau[ligne, colonne];

                // Correction: ne vérifier que si le jeton existe
                if (jeton != null)
                {
                    // Vérifier horizontal (→)
                    int countHorizontal = 0;
                    for (int i = 0; i < checkPoints && colonne + i < NOMBRE_COLONNES; i++)
                    {
                        Jeton j = plateau[ligne, colonne + i];
                        if (j != null && j.Symbole == jeton.Symbole)
                            countHorizontal++;
                        else
                            break;
                    }
                    if (countHorizontal >= checkPoints) return true;

                    // Vérifier vertical (↓)
                    int countVertical = 0;
                    for (int i = 0; i < checkPoints && ligne + i < NOMBRE_RANGEES; i++)
                    {
                        Jeton j = plateau[ligne + i, colonne];
                        if (j != null && j.Symbole == jeton.Symbole)
                            countVertical++;
                        else
                            break;
                    }
                    if (countVertical >= checkPoints) return true;

                    // Vérifier diagonal descendante (↘)
                    int countDiagDesc = 0;
                    for (int i = 0; i < checkPoints && ligne + i < NOMBRE_RANGEES && colonne + i < NOMBRE_COLONNES; i++)
                    {
                        Jeton j = plateau[ligne + i, colonne + i];
                        if (j != null && j.Symbole == jeton.Symbole)
                            countDiagDesc++;
                        else
                            break;
                    }
                    if (countDiagDesc >= checkPoints) return true;

                    // Vérifier diagonal montante (↗)
                    int countDiagMont = 0;
                    for (int i = 0; i < checkPoints && ligne - i >= 0 && colonne + i < NOMBRE_COLONNES; i++)
                    {
                        Jeton j = plateau[ligne - i, colonne + i];
                        if (j != null && j.Symbole == jeton.Symbole)
                            countDiagMont++;
                        else
                            break;
                    }
                    if (countDiagMont >= checkPoints) return true;
                }
            }
        }
        return false;
    }


public bool IsCaseDisponible(int colonne)
    {
        if (colonne < 0 || colonne >= NOMBRE_COLONNES)
            return false;

        // Vérifier si la case du haut de la colonne est libre
        return plateau[0, colonne] == null;
    }

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