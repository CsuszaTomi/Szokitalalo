using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szókitaláló
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] szavak = { "Első", "Alma", "Vizibicikli", "Ferenc", "Torony", };
            int probalkozas = 10;
            Random rnd = new Random();
            string kitalalando = szavak[rnd.Next(szavak.Length)];
            kitalalando = kitalalando.ToLower();
            string modositottkitalalando = kitalalando;
            int kitalaltbetukszam = 0;
            char[] talalatok = new char[kitalalando.Length];
            for (int i = 0; i < talalatok.Length; i++)
            {
                talalatok[i] = '_';
            }
            do
            {
                Console.WriteLine($"A szó hossza: {kitalalando.Length}db betü");
                Console.WriteLine(talalatok);
                Console.Write("Tippeljen egy betüt: ");
                string betustring = Console.ReadLine();
                betustring = betustring.ToLower().Trim();
                if (betustring.Length > 1)
                {
                    do
                    {
                        Console.Write("Nem adott meg csak egy betüt. Kérem adjon meg egy betüt: ");
                        betustring = Console.ReadLine();
                        betustring = betustring.ToLower().Trim();
                    } while (betustring.Length > 1);
                }
                char betu = Convert.ToChar(betustring);
                if (modositottkitalalando.Contains(betu))
                {
                    for (int i = 0; i < modositottkitalalando.Length; i++)
                    {
                        if (modositottkitalalando[i] == betu)
                        {
                            kitalaltbetukszam++;
                            talalatok[i] = betu;
                        }
                    }
                    modositottkitalalando = modositottkitalalando.Replace(betu, '*');
                    Console.WriteLine($"A szóban van {betu} betü.");
                }
                else
                {
                    probalkozas--;
                    Console.WriteLine($"Nincs benne a szóban a {betu} betü. Maradt {probalkozas} probalkozas.");
                }
                if (kitalaltbetukszam == kitalalando.Length)
                {
                    Console.WriteLine($"Kitaláltad a szót ami {kitalalando} volt.");
                    break;
                }
            } while (probalkozas > 0);
        }
    }
}
