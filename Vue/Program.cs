using System;
using jeuPuissance4.Controleur;

/// <summary>
/// Namepspace de l'application.
/// </summary>
namespace jeuPuissance4.Vue
{
    /// <summary>
    /// Classe représentant le programme principale de l'application.
    /// </summary>
    public class Program
    {
        /// <param name="args">Tabeau d'arguments passés lors du lancement de l'application.</param>
        static void Main(string[] args)
        {
            //Affichage de l'entête du jeu.
            AfficherEntete();

            //Initialisation des joueurs.
            string nomJoueur1, nomJoueur2;
            Console.WriteLine("");
            Console.WriteLine("Veuillez entrer le nom du joueur 1...");
            Console.WriteLine("");
            nomJoueur1 = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Veuillez entrer le nom du joueur 2...");
            Console.WriteLine("");
            nomJoueur2 = Console.ReadLine();

            //Affichage de l'entête du jeu.
            Console.Clear();
            AfficherEntete();

            //Initialisation du controleur de jeu.

            ControleurPuissance4 monJeu = new ControleurPuissance4(nomJoueur1, nomJoueur2);

            //Début du jeu...
            //Tant que le jeu n'est pas terminé...
            while (!monJeu.IsTermine())
            {
                //Afficher le plateau de jeu...
                Console.Write(monJeu.ObtenirPlateau());
                int choix;
                //Demander au joueur en cours de sélectionner un emplacement
                if (IsPaire(monJeu.GetCompteurTour())) //Si tour du joueur 2...
                {
                    //Le joueur 2 procède au choix...
                    do
                        choix = DemanderChoix(nomJoueur2);
                    while (!monJeu.IsCaseDisponible(choix));
                    monJeu.JouerTour(2, choix);
                }
                else //sinon tour du joueur 1...
                {
                    //Le joueur1 procède au choix...
                    do
                        choix = DemanderChoix(nomJoueur1);
                    while (!monJeu.IsCaseDisponible(choix));
                    monJeu.JouerTour(1, choix);
                }
                Console.Clear();
                AfficherEntete();
            }

            //Afficher le plateau de jeu
            Console.Write(monJeu.ObtenirPlateau());

            //Afficher le gagnant.
            Console.WriteLine(monJeu.ObtenirMessageGagnant());

            //Attendre une touche avant de fermer l'application.
            Console.ReadKey();
        }

        /// <summary>
        /// Cette méthode de classe (STATIC) permet d'afficher l'en-tête du programme.
        /// </summary>
        static void AfficherEntete()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Bienvenue au jeu Puissance 4 !!!");
            Console.WriteLine("------------------------------------------------------");
        }

        /// <summary>
        /// Méthode permettant de demander le choix à un joueur.
        /// </summary>
        /// <param name="nomJoueur">Paramètre contenant une chaine de caractère représentant le nom du joueur.</param>
        /// <returns>Retourne le choix du joueur (l'indice de la case désirée).</returns>
        static int DemanderChoix(string nomJoueur)
        {
            int choix = 0;
            do
            {
                Console.WriteLine("\n" + nomJoueur + " : Veuillez sélectionner un emplacement disponible");
                int.TryParse(Console.ReadLine(), out choix);
                choix--;

            }
            while (choix < 0 || choix > 8);
            return choix;
        }

        /// <summary>
        /// Cette méthode de classe (STATIC) permet de déterminer si un nombre est paire ou non.
        /// </summary>
        /// <param name="nombre">La référence du nombre à valider</param>
        /// <returns>TRUE Si nombre est paire, FALSE Si le nombre est impaire</returns>
        static bool IsPaire(int nombre)
        {
            return nombre % 2 == 0;
        }
    }
}
