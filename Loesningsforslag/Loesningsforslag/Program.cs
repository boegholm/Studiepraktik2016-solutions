using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loesningsforslag
{
    class Program
    {
        static void Main(string[] args)
        {
            MonteCarloPi();
        }

        static void MonteCarloPi()
        {
            Console.WriteLine("Angiv hvor mange tilfældige \"pile\" skal der kastes?");
            int iterations = ReadInt();

            Random r = new Random(); // tilfældighedsgenerator

            int hits = 0;
            int misses = 0;

            for (int i = 0; i < iterations; i++)
            {
                // r.NextDouble() giver et tal mellem [0.0 og 1.0)
                double x = (r.NextDouble() - 0.5) * 2.0; // tal mellem -1 og 1 (selvom det ikke er nødvendigt da det bliver ganget med sig selv!)
                double y = (r.NextDouble() - 0.5) * 2.0;

                if (x*x + y*y <= 1) // hvis vi er inden for enhedscirklen
                {
                    hits = hits + 1;
                }
                else // hvis vi er udenfor enhedscirklen
                {
                    misses = misses + 1;
                }
            }

            // vi bruger (double) for at lave et heltal om til et kommatal
            //  - vi skal fortælle computeren præcist hvad vi mener,
            //    ellers laver den heltals-division!
            double hitrate = (double)hits / (double)(hits + misses);
            double piApproximation = 4.0*hitrate;
            Console.WriteLine("Efter "+iterations+ " iterationer:");
            Console.WriteLine(" Approximation af pi: "+piApproximation);
            // Math.Abs er den absolutte værdi
            // Math.PI er en indbygget værdi af PI
            // Vi ganger med 100.0 for at få resultatet i %
            double nøjagtighed = (1.0 - Math.Abs(piApproximation/Math.PI - 1.0))*100.0;
            Console.WriteLine(" Præcision af pi-approximation: "+nøjagtighed);
            Console.ReadLine();
        }


        static int ReadInt()//Læser strenge indtil input er et tal
        {
            int resultat; // her gemmer vi resultatet 

            // så længe vi læser noget, hvor TryParse 
            // returnerer false, skriv en fejlmeddelelse
            while (!int.TryParse(Console.ReadLine(), out resultat))
            // out er en lidt speciel ting i c#
            {
                Console.WriteLine("Fejl: Det indtastede var ikke et tal!");
            }
            return resultat; // returnér resultatet!
        }

    }
}
