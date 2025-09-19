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
                int probalkozas, kitalaltbetukszam;
                string kitalalando, modositottkitalalando;
                char[] eltalaltbetuk;
                char[] eddigibetuk;
                int currentPoint = 0;
                do
                {
                    bool selected = false;
                    do
                    {
                        ShowMenu(currentPoint);
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.Enter:
                                selected = true;
                                break;

                            case ConsoleKey.UpArrow:
                                if (currentPoint > 0)
                                    currentPoint--;
                                break;
                            case ConsoleKey.DownArrow:
                                if (currentPoint < 2)
                                    currentPoint++;
                                break;

                            default:
                                Console.Beep();
                                break;
                        }
                    } while (!selected);
                    switch (currentPoint)
                    {
                        case 0:     //Játék kezdése
                            Console.Clear();
                            Alapadatok(out probalkozas, out kitalalando, out modositottkitalalando, out kitalaltbetukszam, out eltalaltbetuk, out eddigibetuk);
                            Játék(ref probalkozas, ref kitalaltbetukszam, kitalalando, ref modositottkitalalando, eltalaltbetuk, ref eddigibetuk);
                            break;
                        case 1: //szín beállítások menü
                            HáttérszínÁllító(currentPoint);
                            break;
                        case 2:     //kilepes
                            Console.Clear();
                            Console.Write("Biztosan ki szeretnél lépni?(i/n): ");
                            if (Console.ReadKey().Key != ConsoleKey.I)
                                currentPoint = 0;
                            break;
                    }
                } while (currentPoint != 2);
            
            }

            private static void HáttérszínÁllító(int currentPoint)
            {
                Console.Clear();
                int valasztas = 0;
                Console.WriteLine("Milyen legyen a háttér színe?");
                Console.WriteLine("1. Fekete");
                Console.WriteLine("2. Kék");
                Console.WriteLine("3. Zöld");
                Console.WriteLine("4. Cián");
                Console.WriteLine("5. Piros");
                do
                {
                    Console.Write("Választás: ");
                } while (!int.TryParse(Console.ReadLine(), out valasztas));
                switch (valasztas)
                {
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case 2:
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 3:
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 4:
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        break;
                    case 5:
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        break;
                    default:
                        Console.Beep();
                        break;
                }
                currentPoint = 0;
            }

            private static void Játék(ref int probalkozas, ref int kitalaltbetukszam, string kitalalando, ref string modositottkitalalando, char[] eltalaltbetuk, ref char[] eddigibetuk)
            {
                do
                {
                    Console.WriteLine($"A szó hossza: {kitalalando.Length}db betü");
                    Console.WriteLine(eltalaltbetuk);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Tippeljen egy betüt: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string betustring = Console.ReadLine();
                    betustring = betustring.ToLower().Trim();
                    if (betustring.Length != 1)
                    {
                        do
                        {
                            Console.Write("Nem adott meg csak egy betüt. Kérem adjon meg egy betüt: ");
                            betustring = Console.ReadLine();
                            betustring = betustring.ToLower().Trim();
                        } while (betustring.Length != 1);
                    }
                    char betu = Convert.ToChar(betustring);
                    if (eddigibetuk.Contains(betu))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ezt a betüt már használta, kérem adjon meg egy másikat.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    else
                    {
                        Array.Resize(ref eddigibetuk, eddigibetuk.Length + 1);
                        eddigibetuk[eddigibetuk.Length - 1] = betu;
                    }
                    if (modositottkitalalando.Contains(betu))
                    {
                        for (int i = 0; i < modositottkitalalando.Length; i++)
                        {
                            if (modositottkitalalando[i] == betu)
                            {
                                kitalaltbetukszam++;
                                eltalaltbetuk[i] = betu;
                            }
                        }
                        modositottkitalalando = modositottkitalalando.Replace(betu, '*');
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"A szóban van {betu} betü.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        probalkozas--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Nincs benne a szóban a {betu} betü. Maradt {probalkozas} probalkozas.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (kitalaltbetukszam == kitalalando.Length)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Kitaláltad a szót ami {kitalalando} volt.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enterre tovább.....");
                        Console.ReadLine();
                        break;
                    }
                } while (probalkozas > 0);
                if (probalkozas < 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Elfogytak a próbálkozásaid, a kitalálandó szó a {kitalalando} volt.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Enterre tovább.....");
                    Console.ReadLine();
                }
            }

            private static void Alapadatok(out int probalkozas, out string kitalalando, out string modositottkitalalando, out int kitalaltbetukszam, out char[] eltalaltbetuk, out char[] eddigibetuk)
            {
                string[] szavak = { "Első", "Alma", "Vizibicikli", "Ferenc", "Torony", "Szomszéd", "Bánya", "Hegy", "Kolbász", "Ló", "Ház", "Város", "Dél", "Ország", "Nemzet", "Béke", "Háború", "Gépjármű", "Autó", "Busz", "Barack", "Fa", "Krumpli", "Hagyma", "Fehér", "Fekete", "Repülő", "Kastély", "Vár", "eltöredezettségmentesítőtleníttethetetlenségtelenítőtlenkedhetnétek" };
                probalkozas = 10;
                Random rnd = new Random();
                kitalalando = szavak[rnd.Next(szavak.Length)];
                kitalalando = kitalalando.ToLower();
                modositottkitalalando = kitalalando;
                kitalaltbetukszam = 0;
                eltalaltbetuk = new char[kitalalando.Length];
                eddigibetuk = new char[0];
                for (int i = 0; i < eltalaltbetuk.Length; i++)
                {
                    eltalaltbetuk[i] = '_';
                }
            }

            static void ShowMenu(int cPoint)
            {
                Console.Clear();
                Console.WriteLine("*** SZÓKITALÁLÓ ***");
                if (cPoint == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Start");
                if (cPoint == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Háttérszín állítás");
                if (cPoint == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("Kilépés");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
