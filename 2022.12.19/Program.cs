namespace _2022._12._19
{
    internal class Program
    {
        class Forgalom
        {
            public int óó;
            public int pp;
            public int mp;
            public int seb;
            public string irány;
        }
        static void Main(string[] args)
        {
            Forgalom[] tömb = new Forgalom[2000];
            for (int i = 0; i < 2000; i++)
                tömb[i] = new Forgalom();
            string[] nyers = File.ReadAllLines("forgalom.txt");
            int hossz = Convert.ToInt32(nyers[0]); // első sor megkülönböztetése
            for (int i = 0; i < hossz; i++) // beolvasás
            {
                string[] sor = nyers[i + 1].Split(' ');
                tömb[i].óó = Convert.ToInt32(sor[0]);
                tömb[i].pp = Convert.ToInt32(sor[1]);
                tömb[i].mp = Convert.ToInt32(sor[2]);
                tömb[i].seb = Convert.ToInt32(sor[3]);
                tömb[i].irány = sor[4];
            }
            // 2. feladat
            Console.Write("2. feladat\tAdja meg a jármű sorszámát: ");
            int n = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("A jármű iránya: ");
            if (tömb[n].irány == "A")
                Console.Write("Alsó");
            else
                Console.Write("Felső");
            Console.WriteLine("\n");
            // 3. feladat
            Console.WriteLine("3. feladat");
            int ind1 = 0;
            int ind2 = 0;
            for (int i = 0; i < hossz; i++)
            {
                if (tömb[i].irány == "A")
                    ind1 = i;
            }
            for (int i = 0; i < ind1; i++)
            {
                if (tömb[i].irány == "A")
                    ind2 = i;
            }
            int mp1 = tömb[ind1].óó * 3600 + tömb[ind1].pp * 60 + tömb[ind1].mp;
            int mp2 = tömb[ind2].óó * 3600 + tömb[ind2].pp * 60 + tömb[ind2].mp;
            Console.WriteLine("Az utolsó két Felső felé közlekedő jármű között {0} másodperc telt el.\n", mp1 - mp2);
            // 4. feladat
            Console.WriteLine("4. feladat");
            for (int i = 0; i < 24; i++) // órákon megy végig
            {
                int alsó = 0;
                int felső = 0;
                for (int j = 0; j < hossz; j++) // tömbön megy végig
                {
                    if (tömb[j].óó == i)
                    {
                        if (tömb[j].irány == "A")
                            alsó++;
                        else
                            felső++;
                    }
                }
                if (alsó > 0 || felső > 0)
                {
                    Console.WriteLine("Óra: " + i);
                    Console.WriteLine("Alsó város: " + alsó);
                    Console.WriteLine("Felső város: {0}\n", felső);
                }
            }
        }
    }
}