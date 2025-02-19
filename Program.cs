namespace Project
{
    namespace Project
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.CursorVisible = false;
                Console.SetWindowSize(120, 40);

                List<Állat> állatok = new List<Állat>
            {
                new Állat("Oroszlán", "Felis leo"),
                new Állat("Zebra", "Equus quagga"),
                new Állat("Krokodil", "Crocodylus niloticus"),
                new Állat("Elefánt", "Loxodonta africana")
            };

                Gondozó gondozó = new Gondozó("János");
                Gondozó gondozó2 = new Gondozó("Miklós");

                Ketrec oroszlánKetrec = new Ketrec("Oroszlán ketrecét", new List<Állat>() { állatok[0] });
                Ketrec zebraKetrec = new Ketrec("Zebra ketrecét", new List<Állat>() { állatok[1] });
                Ketrec krokodilKetrec = new Ketrec("Krokodil ketrecét", new List<Állat>() { állatok[2] });
                Ketrec elefántKetrec = new Ketrec("Elefánt ketrecét", new List<Állat>() { állatok[3] });

                Random random = new Random();
                List<Látogató> látogatók = new List<Látogató>
            {
                new Látogató("Anna", random.Next(0,2) == 0),
                new Látogató("Béla", random.Next(0,2) == 0),
                new Látogató("Csilla", random.Next(0,2) == 0),
                new Látogató("Dávid", random.Next(0,2) == 0)
            };

                double napiBevetel = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Állatkert Szimuláció");
                    Console.WriteLine("1. Új állat hozzáadása");
                    Console.WriteLine("2. Új gondozó felvétele");
                    Console.WriteLine("3. Szimuláció futtatása");
                    Console.WriteLine("4. Kilépés");
                    Console.Write("Válasszon egy lehetőséget: ");
                    string választás = Console.ReadLine();

                    switch (választás)
                    {
                        case "1":
                            // Új állat hozzáadása
                            Console.Write("Állat neve: ");
                            string állatNév = Console.ReadLine();
                            Console.Write("Állat faja: ");
                            string állatFajta = Console.ReadLine();
                            állatok.Add(new Állat(állatNév, állatFajta));
                            Console.WriteLine("Új állat hozzáadva!");
                            Console.ReadLine();
                            break;

                        case "2":
                            // Új gondozó felvétele
                            Console.Write("Gondozó neve: ");
                            string gondozóNév = Console.ReadLine();
                            gondozó2 = new Gondozó(gondozóNév);
                            Console.WriteLine("Új gondozó felvéve!");
                            Console.ReadLine();
                            break;

                        case "3":

                            Console.WriteLine("Hány napot szeretne szimulálni?");
                            int napokSzáma = int.Parse(Console.ReadLine()!);

                            for (int nap = 1; nap <= napokSzáma; nap++)
                            {
                                foreach (var látogató in látogatók)
                                    látogató.Diák = random.Next(0, 2) == 0;

                                Console.Clear();
                                Console.WriteLine($"--- {nap}. nap ---");

                                // Állatok tevékenységei
                                Console.WriteLine("\nÁllatok tevékenységei:");
                                Velemeny(állatok, állat => Kiírás(állat.Eszik(), ConsoleColor.Yellow));
                                Velemeny(állatok, állat => Kiírás(állat.Mozog(), ConsoleColor.Cyan));

                                // Gondozó tevékenysége
                                Console.WriteLine("\nGondozó tevékenysége:");
                                foreach (var ketrec in new List<Ketrec> { oroszlánKetrec, zebraKetrec, krokodilKetrec, elefántKetrec })
                                {
                                    int randomGondozó = random.Next(0, 2);
                                    if (randomGondozó == 0)
                                    {
                                        Kiírás(gondozó.Etet(ketrec), ConsoleColor.Green);
                                    }
                                    else
                                    {
                                        Kiírás(gondozó2.Etet(ketrec), ConsoleColor.Green);
                                    }

                                    if (randomGondozó == 0)
                                    {
                                        Kiírás(gondozó.Tisztít(ketrec), ConsoleColor.Magenta);
                                    }
                                    else
                                    {
                                        Kiírás(gondozó2.Tisztít(ketrec), ConsoleColor.Magenta);
                                    }
                                }

                                // Látogatók tevékenysége és belépő
                                Console.WriteLine("\nLátogatók tevékenysége:");
                                Random rand = new Random();
                                foreach (var látogató in látogatók)
                                {
                                    Kiírás(látogató.Nézelődik(), ConsoleColor.White);
                                    napiBevetel += látogató.Belépő();
                                }

                                Console.WriteLine($"\n--- {nap}. nap vége ---");
                                Console.WriteLine($"\nLátogatók száma: {látogatók.Count}");
                                Console.WriteLine($"A szimulációban összesen {napiBevetel} Ft-ot keresett az állatkert.");
                                Console.WriteLine("A nap eseményei sikeresen megtörténtek.\n");

                                Console.WriteLine("Nyomjon Enter-t a következő naphoz...");
                                Console.ReadLine();
                            }

                            Console.WriteLine("A szimuláció befejeződött.");
                            break;

                        case "4":
                            return;

                        default:
                            Console.WriteLine("Érvénytelen választás. Próbálja újra.");
                            break;
                    }
                }
            }

            static void Velemeny(List<Állat> állatok, Action<Állat> tevékenységVégrehajtás)
            {
                Random random = new Random();
                int szám = random.Next(1, 3);
                var véletlenszerűÁllatok = állatok.OrderBy(a => random.Next()).Take(szám).ToList();

                foreach (var állat in véletlenszerűÁllatok)
                {
                    tevékenységVégrehajtás(állat);
                }
            }

            static void Kiírás(string üzenet, ConsoleColor szín)
            {
                Console.ForegroundColor = szín;
                Console.WriteLine(üzenet);
                Console.ResetColor();
            }
        }

    }
}