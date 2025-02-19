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
                new Állat("Ödön" ,"Oroszlán"),
                new Állat("Ziga", "Zebra"),
                new Állat("Cheetos","Krokodil"),
                new Állat("Trianon","Elefánt"),
                new Állat("Nigusz", "Csiga"),
                new Állat("Alejandro", "Majom"),
                new Állat("T-rex", "Capibara")
            };

            List<Gondozó> gondozós = new List<Gondozó>()
            {
                new Gondozó("János"),
                new Gondozó("Miklós")
            };

            List<Ketrec> ketrecs = new List<Ketrec>()
            {
                new Ketrec("Oroszlán ketrecét", new List<Állat>() { állatok[0] }),
                new Ketrec("Zebra ketrecét", new List<Állat>() { állatok[1] }),
                new Ketrec("Krokodil ketrecét", new List<Állat>() { állatok[2] }),
                new Ketrec("Elefánt ketrecét", new List<Állat>() { állatok[3] }),
                new Ketrec("Csiga ketrecét", new List<Állat>() { állatok[4] }),
                new Ketrec("Majom ketrecét", new List<Állat>() { állatok[5] }),
                new Ketrec("Capibara ketrecét", new List<Állat>() { állatok[6] })
            };

            Random random = new Random();
            List<Látogató> látogatók = new List<Látogató>
            {
                new Látogató("Anasztázia", random.Next(0,2) == 0),
                new Látogató("Béla", random.Next(0,2) == 0),
                new Látogató("Csilla", random.Next(0,2) == 0),
                new Látogató("Emil", random.Next(0,2) == 0),
                new Látogató("Cigusz", random.Next(0,2) == 0),
                new Látogató("Horthy", random.Next(0,2) == 0),
                new Látogató("Viktor", random.Next(0,2) == 0),
                new Látogató("Tamáß", random.Next(0,2) == 0)
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
                        // Új állat 
                        Console.Write("Állat neve: ");
                        string állatNév = Console.ReadLine();
                        Console.Write("Állat faja: ");
                        string állatFajta = Console.ReadLine();
                        állatok.Add(new Állat(állatNév, állatFajta));
                        ketrecs.Add(new Ketrec(állatNév + " ketrecét", new List<Állat> { new Állat(állatNév, állatFajta) }));
                        Console.WriteLine("Új állat hozzáadva!");
                        Console.ReadLine();
                        break;

                    case "2":
                        // Új gondozó 
                        Console.Write("Gondozó neve: ");
                        string gondozóNév = Console.ReadLine();
                        gondozós.Add(new Gondozó(gondozóNév));
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

                            // Szökés
                            int szokhet = random.Next(0, 10);
                            if (szokhet == 4) 
                            {
                                int index = random.Next(0, állatok.Count);
                                Állat szökőÁllat = állatok[index];
                                állatok.Remove(szökőÁllat);
                                Console.WriteLine($"Figyelem! {szökőÁllat.Név}, a {szökőÁllat.Fajta} elszökött!");
                            }

                            Console.WriteLine("\nÁllatok tevékenységei:");
                            Velemeny(állatok, állat => Kiírás(állat.Eszik(), ConsoleColor.Yellow));
                            Velemeny(állatok, állat => Kiírás(állat.Mozog(), ConsoleColor.Cyan));


                            Console.WriteLine("\nGondozó tevékenysége:");
                            foreach (var ketrec in ketrecs)
                            {
                                int randomGondozó = random.Next(0, gondozós.Count);
                                Kiírás(gondozós[randomGondozó].Etet(ketrec), ConsoleColor.Green);
                                Kiírás(gondozós[randomGondozó].Tisztít(ketrec), ConsoleColor.Magenta);
                            }


                            Console.WriteLine("\nLátogatók tevékenysége:");
                            int latogatok_szama = 0;
                            foreach (var látogató in látogatók)
                            {
                                if (random.Next(0, 2) == 0)
                                {
                                    Kiírás(látogató.Nézelődik(), ConsoleColor.White);
                                    napiBevetel += látogató.Belépő();
                                    latogatok_szama++;
                                }
                            }

                            Console.WriteLine($"\n--- {nap}. nap vége ---");
                            Console.WriteLine($"\nLátogatók száma: {latogatok_szama}");
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
            int szám = random.Next(1, állatok.Count);
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
