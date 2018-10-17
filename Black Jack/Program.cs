using System;
using System.Threading;

namespace Black_Jack
{
    class Program
    {
        enum Sorte
        {
            None = 0,
            Coeur = 1,
            Pique = 2,
            Carreau = 3,
            Trefle = 4,
        }



        static void Main(string[] args)
        {


            Random card = new Random();
            Sorte carteJoueur1 = Sorte.None;
            Sorte carteJoueur2 = Sorte.None;
            Sorte carteJoueur3 = Sorte.None;
            int valeurJoueur1 = 0;
            int valeurJoueur2 = 0;
            int valeurJoueur3 = 0;

            Sorte carteIA1 = Sorte.None;
            Sorte carteIA2 = Sorte.None;
            Sorte carteIA3 = Sorte.None;

            int valeurIA1 = 0;
            int valeurIA2 = 0;
            int valeurIA3 = 0;

            int jeton = 100;
            int mise = 0;

            Sorte GenererSorte()
            {
                int Sorte = card.Next(1, 5);
                return (Sorte)Sorte;
            }

            void GenererMainJoueur()
            {
                carteJoueur1 = GenererSorte();
                carteJoueur2 = GenererSorte();
                carteJoueur3 = GenererSorte();

                valeurJoueur1 = card.Next(1, 14);
                valeurJoueur2 = card.Next(1, 14);
                valeurJoueur3 = 0;
            }

            void GenererMainIA()
            {
                carteIA1 = GenererSorte();
                carteIA2 = GenererSorte();
                carteIA3 = GenererSorte();

                valeurIA1 = card.Next(1, 14);
                valeurIA2 = card.Next(1, 14);
                valeurIA3 = 0;
            }

            void AfficherCarte(Sorte _sorte, int _valeur)
            {
                string sorteCarte = "";
                string nomCarte = "";

                switch (_sorte)
                {
                    case Sorte.Coeur:
                        sorteCarte = "coeur";
                        break;
                    case Sorte.Pique:
                        sorteCarte = "pique";
                        break;
                    case Sorte.Carreau:
                        sorteCarte = "carreau";
                        break;
                    case Sorte.Trefle:
                        sorteCarte = "trèfle";
                        break;
                }
                if (_valeur == 1)
                    nomCarte = "As";
                else if (_valeur < 11)
                    nomCarte = _valeur.ToString();
                else if (_valeur == 11)
                    nomCarte = "Valet";
                else if (_valeur == 12)
                    nomCarte = "Reine";
                else if (_valeur == 13)
                    nomCarte = "Roi";
                Console.WriteLine(nomCarte + " de " + sorteCarte);
            }

            int CalculScoreJoueur()
            {
                int res = CalculValeurCarte(valeurJoueur1) + CalculValeurCarte(valeurJoueur2) + CalculValeurCarte(valeurJoueur3);

                return res;
            }

            int CalculScoreIA()
            {
                int res = CalculValeurCarte(valeurIA1) + CalculValeurCarte(valeurIA2) + CalculValeurCarte(valeurIA3);

                return res;
            }

            int CalculValeurCarte(int _valeur)
            {
                if (_valeur >= 10)
                    return 10;
                else if (_valeur == 1)
                {
                    return 11;
                }


                return _valeur;
            }

            void QuiGagne()
            {
                int scoreJoueur = CalculScoreJoueur();
                int scoreIA = CalculScoreIA();

                Console.WriteLine("Le score du joueur est de " + scoreJoueur);
                Console.WriteLine("Le score de l'IA est de " + scoreIA);

                if (scoreJoueur <= 21 && scoreIA <= 21)
                {
                    if (scoreJoueur > scoreIA)
                        jeton += mise;
                    Console.WriteLine("Tu gagnes cette bataille, mais pas la guerre !");
                }
                else if (scoreIA > scoreJoueur && scoreIA <= 21)
                {
                    jeton -= mise;
                    Console.WriteLine("l'IA gagne... Pour cette fois.");
                }


                else if (scoreJoueur >= 22 && scoreIA >= 22)
                {
                    Console.WriteLine("Vous perdez les deux.");
                }

                else if (scoreJoueur > 21)
                {
                    jeton -= mise;
                    Console.WriteLine("l'IA a gagné parce que tu as visé trop haut ! Il te reste " + jeton + " jetons");
                }
                else
                {
                    jeton += mise;
                    Console.WriteLine("Tu as gagné, good job my friend ! Tu as désormais " + jeton + " jetons");
                }

            }


            //LE JEU COMMENCE ENFIN//

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                              BIENVENUE DANS BLACK JACK'O LANTERN !");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                              B           B       ");
            Console.WriteLine("                              L     B     L     B");
            Console.WriteLine("                              A     L     A     L");
            Console.WriteLine("                              C     A     C     A");
            Console.WriteLine("                              K     C     K     ");
            Console.WriteLine("                                    K           K");
            Console.WriteLine("                              J           J      ");
            Console.WriteLine("                              A     J     A     J");
            Console.WriteLine("                              C     A     C     A");
            Console.WriteLine("                              K     C     K     C");
            Console.WriteLine("                                    K           K");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Appuyer sur une touche pour commencer !");
            Console.ReadKey();

            
            bool endGame = false;
            while (!endGame)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Vous avez " + jeton + " combien souhaitez vous miser ?");
                bool miseOK = false;
                while (!miseOK)
                {
                    mise = Convert.ToInt32(Console.ReadLine());

                    if (mise < jeton)
                    {
                        GenererMainJoueur();
                        GenererMainIA();
                    }
                    if (mise < jeton)
                    {
                        miseOK = true;
                    }
                }
                
                Console.WriteLine("Voici les cartes que tu as");
                Console.WriteLine("");
                AfficherCarte(carteJoueur1, valeurJoueur1);
                Console.WriteLine("");
                AfficherCarte(carteJoueur2, valeurJoueur2);
                Console.WriteLine("");

                Console.WriteLine("Ton adversaire possède ces cartes");
                Console.WriteLine("");
                AfficherCarte(carteIA1, valeurIA1);
                Console.WriteLine("");
                AfficherCarte(carteIA1, valeurIA2);
                Console.WriteLine("");

                Console.WriteLine("Que voulez vous faire maintenant ?");
                Console.WriteLine("Demander une nouvelle carte (1)");
                Console.WriteLine("Garder cette main (2)");
                int choix = Convert.ToInt32(Console.ReadLine());

                if (choix == 1)
                {
                    carteJoueur3 = GenererSorte();
                    valeurJoueur3 = card.Next(1, 14);
                    AfficherCarte(carteJoueur3, valeurJoueur3);             
                }

                if (CalculScoreIA() < 15 || (CalculScoreIA() < CalculScoreJoueur() || CalculScoreJoueur() <= 21))
                {
                    carteIA3 = GenererSorte();
                    valeurIA3 = card.Next(1, 14);                    
                }                

                QuiGagne();
                

           

                


                Console.ReadKey();
            }










        }


    }
}


