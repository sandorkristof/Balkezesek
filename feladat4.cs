using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    internal class _4feladat
    {
        static void Main()
        {
            int evszam;
            bool ervenyesEvszam = false;

            while (!ervenyesEvszam)
            {
                Console.Write("Kérem, adjon meg egy évszámot (1990 és 1999 között): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out evszam))
                {
                    if (evszam >= 1990 && evszam <= 1999)
                    {
                        ervenyesEvszam = true;
                    }
                    else
                    {
                        Console.WriteLine("Hibás adat! Kérek egy 1990 és 1999 közötti évszámot.");
                    }
                }
                else
                {
                    Console.WriteLine("Hibás adat! Kérem, egy érvényes számot adjon meg.");
                }
            }

            Console.WriteLine($"Az elfogadott évszám: {evszam}");
        }
    }
}
