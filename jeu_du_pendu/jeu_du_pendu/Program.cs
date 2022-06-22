using System;
using System.Collections.Generic;
using AsciiArt;
using System.IO;
namespace jeu_du_pendu
{
    class Program
    {

        static void AfficherMot(string mot, List<char> lettres)
        {
            // E L E _ _ _ _ _

            for (int i = 0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if (lettres.Contains(lettre))
                {
                    Console.Write(lettre + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();

        }
        static bool ToutesLettresDevinees(string mot, List<char> lettres)
        {
            foreach (var lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }
            if (mot.Length == 0)
            {
                return true;
            }
            return false;

        }

        static char DemanderUneLettre(string message = "Rentrez une lettre : ")
        {
            while (true)
            {
                Console.Write(message);
                string lettre = Console.ReadLine();
                if (lettre.Length == 1)
                {
                    lettre = lettre.ToUpper();
                    return lettre[0];
                }
                Console.WriteLine("Erreur vous devez introduire une seule lettre");
            }
        }


        static void DevinerMot(string mot)
        {
            var lettresDevinees = new List<char>();
            var lettresExclues = new List<char>();
            const int NB_VIES = 6;
            int viesRestantes = NB_VIES;
            while (viesRestantes > 0)
            {
                Console.WriteLine(Ascii.PENDU[NB_VIES - viesRestantes]);
                AfficherMot(mot, lettresDevinees);
                Console.WriteLine();
                var lettre = DemanderUneLettre();
                Console.Clear();
                if (mot.Contains(lettre))
                {

                    Console.WriteLine("Vies restantes : " + NB_VIES);
                    lettresDevinees.Add(lettre);
                    if (ToutesLettresDevinees(mot, lettresDevinees))
                    {
                        break;
                    }
                }
                else
                {
                    if (!lettresExclues.Contains(lettre))
                    {
                        lettresExclues.Add(lettre);
                        viesRestantes--;
                    }

                }
                if (lettresExclues.Count > 0)
                {
                    Console.WriteLine("Ce mot ne contient pas les lettres: " + string.Join(", ", lettresExclues));
                }


            }
            Console.WriteLine(Ascii.PENDU[NB_VIES - viesRestantes]);
            if (viesRestantes == 0)
            {
                Console.WriteLine("PERDU! le mot était: " + mot);
            }
            else
            {
                AfficherMot(mot, lettresDevinees);
                Console.WriteLine();
                Console.WriteLine("GAGNE !");
            }

        }

        static string[] ChargerLesMots(string nomFichier)
        {
            try
            {
                return File.ReadAllLines(nomFichier);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur de lecture du fichier : " + nomFichier + " (" + ex.Message + " )");
            }
            return null;
        }

        static bool Rejouer()
        {

            char response = DemanderUneLettre("Voulez vous rejouer? (o/n) : ");
            if ((response == 'o') || (response == 'O'))
            {
                return true;
            }
            else if ((response == 'n') || (response == 'N'))
            {
                return false;
            }
            else
            {
                Console.WriteLine("Entrez une la lettre o ou n");
                return Rejouer();
            }
        }
        static void Main(string[] args)
        {
            var mots = ChargerLesMots("mots.txt");
            if ((mots == null || mots.Length == 0))
            {
                Console.WriteLine("La liste de mots est vide");
            }
            else
            {
                while (true)
                {
                    var random = new Random();
                    int index = random.Next(mots.Length);
                    string mot = mots[index].Trim();
                    DevinerMot(mot);
                    if (!Rejouer())
                    {
                        break;
                    }
                    Console.WriteLine("Merci et a bientot ! ");
                }
            }
        }
    }
}
