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

            Opgave1();
            Opgave2();
            Opgave3();
            Opgave4();
            Opgave5();
            Opgave6();
            Opgave7();
            Opgave8();
            Opgave9();
            Opgave10();
            Opgave11();
            Opgave12();
            Opgave13og14();
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

            // Arealet af firkanten omkring enhedscirklen er 4
            // hitrate er den statistiske sandsynlighed for at ramme
            // inden for cirklen (se evt. slides)
            double piApproximation = 4.0*hitrate; 
            Console.WriteLine("Efter "+iterations+ " iterationer:");
            Console.WriteLine(" Approximation af pi: "+piApproximation);
            
            // Math.Abs er den absolutte værdi
            // Math.PI er en indbygget værdi af PI
            // Vi ganger med 100.0 for at få resultatet i %
            double nøjagtighed = (1.0 - Math.Abs(piApproximation/Math.PI - 1.0))*100.0;

            // Nedenstående notation bruges til at fortælle hvor mange
            // decimaler jeg vil have på mit tal
            Console.WriteLine($" Præcision af pi-approximation: {nøjagtighed:.0000}%");
            Console.ReadLine();
        }

        static void Opgave1()
        {
            Console.WriteLine("Hvad er dit navn?");
            string navn = Console.ReadLine();
            Console.WriteLine("Hej " + navn + ", velkommen til studiepraktik!");
            Console.ReadLine();
        }

        static void Opgave2()
        {
            Console.WriteLine("Indtast tal1: ");
            int tal1 = ReadInt();
            Console.WriteLine("Indtast tal2: ");
            int tal2 = ReadInt();

            int resultat = tal1 + tal2;
            Console.WriteLine("tal1 + tal2 er: " + resultat);
            resultat = tal1 / tal2;
            Console.WriteLine("tal1 / tal2 er: " + resultat);


            resultat = (int)Math.Pow(tal1, tal2);
            //double dres = Math.Pow(tal1, tal2);
            Console.WriteLine("tal1 opløftet i tal2 er: " + resultat);
            Console.ReadLine();
        }

        static void Opgave3()
        {
            Console.WriteLine("skriv a");
            double a = ReadInt();
            Console.WriteLine("skriv b");
            double b = ReadInt();

            double c = Math.Sqrt(a * a + b * b);
            Console.WriteLine("C er : " + c);

            if (a > b)
            {
                Console.WriteLine("A er større end b");
            }
            else
            {
                Console.WriteLine("B er større end a");
            }

            Console.ReadLine();
        }


        static void Opgave4()
        {
            Console.WriteLine("Indtast navn : ");
            string navn = Console.ReadLine();
            Console.WriteLine("Indtast alder: ");
            int alder = ReadInt();

            if(alder <3)
                Console.WriteLine(navn + " du må gå med ble!");
            else if(alder < 15)
                Console.WriteLine(navn + " du må ikke noget...");
            else if(alder <18)
                Console.WriteLine(navn + " du må drikke øl");
            else Console.WriteLine(navn + " du må stemme og køre bil");
            Console.ReadLine();
        }

        static void Opgave5()
        {
            Random r = new Random();

            int hemmeligtTal = r.Next(1, 100);

            Console.WriteLine("Gæt hvilket tal jeg tænker på!");
            bool rigtigt = false;
            int antalGæt = 0;

            while (rigtigt == false)
            {
                int gæt = ReadInt();
                antalGæt = antalGæt + 1;
                if (gæt > hemmeligtTal)
                {
                    Console.WriteLine("Det er for stort!");
                }
                else if (gæt < hemmeligtTal)
                {
                    Console.WriteLine("Det er ikke stort nok!");
                }
                else
                {
                    Console.WriteLine("Det er rigtigt!");
                    rigtigt = true;
                }
                Console.WriteLine("Du har brugt " + antalGæt + " gæt!");
            }
            Console.ReadLine();
        }


        static void Opgave6()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        static void Opgave7()
        {
            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        static void Opgave8()
        {
            Console.WriteLine("Indtast et tal:");
            int tal = ReadInt();
            Console.WriteLine();
            Console.WriteLine(tal+"-tabellen:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(tal*i);
            }
            Console.ReadLine();
        }

        static void Opgave9()
        {
            Console.WriteLine("Indtast et tal:");
            int øvreGrænse = ReadInt();
            int sum = 0;
            for (int i = 0; i <= øvreGrænse; i++)
            {
                sum = sum + i;

            }
            Console.WriteLine("Summen af tallene fra 0 til "+øvreGrænse + " er: "+sum);
            Console.ReadLine();
        }

        static void Opgave10()
        {
        // primtal
        // - et primtal er et tal hvor kun 1 og tallet selv går op i
            Console.WriteLine("Indtast øvre grænse for primtal:");
            int max = ReadInt();

            // 0 og 1 er ikke primtal, så vi starter ved 2
            for (int i = 2; i <= max; i++)
            {
                bool primtal = true; // vi antager først det er et primtal
                for (int j = 2; j < i-1; j++)
                {
                    if (i%j == 0)   // i mod j er 0 hvis j går op i i                    
                    {
                        // er det tilfældet, er det ikke et primtal
                        primtal = false;
                    }
                }
                if (primtal)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }

        static void Opgave11()
        {
            // vi laver først et array af mønter/sedler
            //  - lav til stor
            //  - i en alternativ løsning kunne vi bruge 'break' i 
            //    vores forløkke, og lade enheder gå fra stor->lav

            int[] enheder = { 1,2,5,10,20,50,100,200,500,1000};

            Console.WriteLine("Indtast beløb: ");
            int beløb = ReadInt();
            int restbeløb = beløb;
            while (restbeløb > 0) // så længe restbeløbet er over 0, udbetal
            {
                int udbetaling = 0;
                // længden af enheder-arrayet kan fås ved enheder.Length
                for (int i = 0; i < enheder.Length; i++)
                {
                    if (restbeløb >= enheder[i])
                        udbetaling = enheder[i];
                }
                Console.WriteLine(udbetaling+"kr");
                restbeløb = restbeløb - udbetaling;
            }
            Console.ReadLine();
        }

        static void Opgave12()
        {
            int[] intArray = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Indtast tal nr. "+(i+1));
                intArray[i] = ReadInt();
            }

            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum = sum + intArray[i];
            }
            Console.WriteLine("Summen af tallene: "+sum);
            Console.ReadLine();
        }

        static void Opgave13og14()
        {
            Random r = new Random();  
            int[] lottoTal = new int[7];

            for (int i = 0; i < lottoTal.Length; i++)
            {
                lottoTal[i] = r.Next(1, 37);
            }

            Console.WriteLine("Resten af opgaven kan du sagtens selv læse, hvis ud er kommet så langt her!");
            Console.ReadLine();
        }


        // funktionen fra slides
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
