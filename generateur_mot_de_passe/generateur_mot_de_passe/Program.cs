using FormationCS;
using System;



namespace generateur_mot_de_passe

{
    class Program
    {
        
        static void Main(string[] args)
        {
            const int NB_MOTS_DE_PASSE = 5;
            int longeurMotDePasse = outils.DemanderNombrePositifNonNul("Introduit la longueur souhaiter de ton mot de passe: ");
            Console.WriteLine();
            int choixDeAlphabet = outils.DemanderNombreEntre("Vous voulez un mot de passe avec: \n" +
                "1 - Uniquement des caracteres en minuscule\n" +
                "2 - Des caracteres minuscules et majuscules\n" +
                "3 - Des caracteres et des chiffres\n" +
                "4 - Caracteres, chiffres et caracteres speciaux\n" +
                "Votre choix: ", 1, 4);
            string caractereSpeciaux = "*/_.!@";
            string chiffres = "0123456789";
            string minuscules = "abcdefghijklmnopqrstuvwxyz";
            string majuscules = minuscules.ToUpper();
            string alphabet;
            string motDePasse = "";
            Random random = new Random();

            if (choixDeAlphabet == 1)
            {
                alphabet = minuscules;
            }
            else if(choixDeAlphabet == 2)
            {
                alphabet = minuscules+majuscules;
            }
            else if(choixDeAlphabet == 3)
            {
                alphabet = minuscules + minuscules + caractereSpeciaux;
            }
            else
            {
                alphabet = minuscules + majuscules + caractereSpeciaux + chiffres;
            }
            int longeurAlphabet = alphabet.Length;


            // int index = random.Next(longeurAlphabet);
            for (int e = 0; e < NB_MOTS_DE_PASSE; e++)
            {
                motDePasse ="";
                for (int i = 0; i < longeurMotDePasse; i++)
                {
                    int index = random.Next(0, longeurAlphabet);
                    motDePasse += alphabet[index];
                }
                Console.WriteLine("Mot de passe: " + motDePasse);

            }



        }
    }
}