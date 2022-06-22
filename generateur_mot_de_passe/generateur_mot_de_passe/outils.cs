using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS

{
    static internal class outils
    {
        public static int DemanderNombrePositifNonNul(string question)
        {  
            return DemanderNombreEntre(question, 1, int.MaxValue);
        }
        public static int DemanderNombreEntre(string question, int min, int max)
        {
            int nombre = DemanderNombre(question);
            if ((nombre >= min) && (nombre <= max))
            {
                return nombre;
            }
            Console.WriteLine("ERREUR : Le nombre doit être compris entre " + min + " et " + max);
            return DemanderNombreEntre(question, min, max);
        }
        static int DemanderNombre(string question)
        {
            Console.Write(question);
            string reponse = Console.ReadLine();
            try
            {
                int reponseInt = Convert.ToInt32(reponse);
                return reponseInt;
            }
            catch
            {
                Console.WriteLine("Erreur : vous devez rentrer un nombre valide");
            }
            return DemanderNombre(question);
        }
    }
}
