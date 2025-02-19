namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 40);

            // Állatok listája
            List<Állat> állatok = new List<Állat>
        {
            new Állat("Oroszlán", "Felis leo"),
            new Állat("Zebra", "Equus quagga"),
            new Állat("Krokodil", "Crocodylus niloticus"),
            new Állat("Elefánt", "Loxodonta africana")
        };

            Gondozó gondozó = new Gondozó("János");
            Gondozó gondozó2 = new Gondozó("Miklós");

            Ketrec oroszlánKetrec = new Ketrec("Oroszlán ketrec", new List<Állat>() { állatok[0] });
            Ketrec zebraKetrec = new Ketrec("Zebra ketrec", new List<Állat>() { állatok[1] });
            Ketrec krokodilKetrec = new Ketrec("Krokodil ketrec", new List<Állat>() { állatok[2] });
            Ketrec elefántKetrec = new Ketrec("Elefánt ketrec", new List<Állat>() { állatok[3] });

            List<Látogató> látogatók = new List<Látogató>
        {
            new Látogató("Anna"),
            new Látogató("Béla"),
            new Látogató("Csilla"),
            new Látogató("Dávid")
        };

            Console.WriteLine("Hány napot szeretne szimulálni?");
            int napokSzáma = int.Parse(Console.ReadLine()!);

            // Állatkert menü és események
            Console.WriteLine("Üdvözöljük az Állatkert Szimulációban!");

            for (int nap = 1; nap <= napokSzáma; nap++)
            {
                Console.Clear();
                Console.WriteLine($"--- {nap}. nap ---");

                // Állatok tevékenységei
                Console.WriteLine("\nÁllatok tevékenységei:");
                Velemeny(állatok, "etetik", állat => Kiírás(állat.Eszik(), ConsoleColor.Yellow));
                Velemeny(állatok, "mozognak", állat => Kiírás(állat.Mozog(), ConsoleColor.Cyan));

                // Gondozó tevékenysége:
                Console.WriteLine("\nGondozó tevékenysége:");
                foreach (var ketrec in new List<Ketrec> { oroszlánKetrec, zebraKetrec, krokodilKetrec, elefántKetrec })
                {
                    Random random = new Random();
                    int randomGondozó = random.Next(0, 2); // Randomly select a gondozó to clean and feed
                    if (randomGondozó == 0)
                    {
                        Kiírás(gondozó.Etet(ketrec), ConsoleColor.Green);
                    }
                    else
                    {
                        // If the other gondozó, do the same
                        Kiírás(gondozó2.Etet(ketrec), ConsoleColor.Green);
                    }

                    // Cleaning cages
                    if (randomGondozó == 0)
                    {
                        Kiírás(gondozó.Tisztít(ketrec), ConsoleColor.Magenta);
                    }
                    else
                    {
                        // Alternate the other gondozó for cleaning
                        Kiírás(gondozó2.Tisztít(ketrec), ConsoleColor.Magenta);
                    }
                }

                // Látogatók tevékenysége:
                Console.WriteLine("\nLátogatók tevékenysége:");
                Random rand = new Random();

                Kiírás(látogatók[rand.Next(0, 4)].Nézelődik(), ConsoleColor.White);

                // Nap végi összegzés
                Console.WriteLine($"\n--- {nap}. nap vége ---");
                Console.WriteLine($"Látogatók száma: {látogatók.Count}");

                // Véletlenszerűen megjelenő állatok és látogatók száma:
                foreach (var ketrec in new List<Ketrec> { oroszlánKetrec, zebraKetrec, krokodilKetrec, elefántKetrec })
                {
                    int viewedCount = rand.Next(1, 5);  // Random number of visitors for each animal

                    foreach ( var Állat in ketrec.Állat)
                        Console.WriteLine($"{Állat.Név} ({Állat.Fajta}) - {viewedCount} látogató nézte meg.");
                }

                Console.WriteLine("A nap eseményei sikeresen megtörténtek.\n");

                // Várakozás a következő naphoz
                Console.WriteLine("Nyomjon Enter-t a következő naphoz...");
                Console.ReadLine();
            }

            Console.WriteLine("A szimuláció befejeződött.");
        }

        static void Velemeny(List<Állat> állatok, string tevékenység, Action<Állat> tevékenységVégrehajtás)
        {
            // Véletlenszerűen kiválasztunk 1-2 állatot
            Random random = new Random();
            int szám = random.Next(1, 3); // Véletlen szám 1 és 2 között
            var véletlenszerűÁllatok = állatok.OrderBy(a => random.Next()).Take(szám).ToList();

            // Véletlenszerűen kiválasztott állatok tevékenysége
            foreach (var állat in véletlenszerűÁllatok)
            {
                tevékenységVégrehajtás(állat);
                Console.WriteLine($"{állat.Név}, a {állat.Fajta} most {tevékenység}.");
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