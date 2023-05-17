class Sorozat
{
    public string adás;
    public string cím;
    public int évad;
    public int epizód;
    public int hossz;
    public bool megtekintve;
}
class sorozatok
{
    static DateTime dátum(string input)
    {
        string[] be = input.Split('.');
        int év = Convert.ToInt32(be[0]);
        int hónap = Convert.ToInt32(be[1]);
        int nap = Convert.ToInt32(be[2]);
        DateTime dátum = new DateTime(év, hónap, nap);
        return dátum;
    }
    static string Hetnapja(int ev, int ho, int nap)
    {
        string[] napok = {"v", "h", "k", "sze", "cs", "p", "szo"};
        int[] honapok = {0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4};
        if (ho < 3)
            ev -= 1;
        return napok[(ev + (ev / 4) - (ev / 100) + (ev / 400) + honapok[ho - 1] + nap) % 7];
    }
    static void Main()
    {
        Sorozat[] tömb = new Sorozat[400];
        for (int i = 0; i < 400; i++)
            tömb[i] = new Sorozat();
        string[] be = File.ReadAllLines("lista.txt");
        for (int i = 0; i < (be.Length / 5); i++)
        {
            string[] split = new string[5];
            for (int j = 0; j < 5; j++)
                split[j] = be[5*i + j];
            if (split[0] != "NI")
                tömb[i].adás = split[0];
            if (split[0] == "NI")
                tömb[i].adás = "0";
            tömb[i].cím = split[1];
            string[] x = split[2].Split("x");
            tömb[i].évad = Convert.ToInt32(x[0]);
            tömb[i].epizód = Convert.ToInt32(x[1]);
            tömb[i].hossz = Convert.ToInt32(split[3]);
            if (split[4] == "0")
                tömb[i].megtekintve = false;
            if (split[4] == "1")
                tömb[i].megtekintve = true;
        }
        //2.
        Console.WriteLine("2.feladat");
        int hossz = be.Length / 5;
        int db = 0;
        for (int i = 0; i < hossz; i++)
        {
            if (tömb[i].adás != "0")
                db++;
        }
        Console.WriteLine("A listában {0} db vetítési dátummal rendelkező epizód van.\n", db);
        //3.
        Console.WriteLine("3. feladat");
        db = 0;
        for (int i = 0; i < hossz; i++)
        {
            if (tömb[i].megtekintve == true)
                db++;
        }
        Console.WriteLine("A listában lévő epizódok {0}%-át látta.\n", Math.Round((double)db / hossz * 100, 2));
        //4.
        Console.WriteLine("4. feladat");
        int összidő = 0;
        for (int i = 0; i < hossz; i++)
        {
            if (tömb[i].megtekintve == true)
            {
                összidő += tömb[i].hossz;
            }
        }
        int nap = összidő / 60 / 24;
        int óra = összidő / 60 - (nap * 24);
        int perc = összidő % 60;
        Console.WriteLine("Sorozatnézéssel {0} napot {1} órát és {2} percet töltött.\n", nap, óra, perc);
        //5.
        Console.WriteLine("5. feladat");
        Console.Write("Adjon meg egy dátumot! Dátum = ");
        DateTime date = dátum(Console.ReadLine());
        for (int i = 0; i < hossz; i++)
        {
            if (tömb[i].adás != "0" && dátum(tömb[i].adás) <= date && tömb[i].megtekintve == false)
            {
                Console.WriteLine("{0}x{1}\t{2}", tömb[i].évad, tömb[i].epizód, tömb[i].cím);
            }
        }
        Console.WriteLine();
        //7.
        Console.WriteLine("7. feladat");
        Console.Write("Adja meg a hét egy napját (például cs)! Nap = ");
        string hét = Console.ReadLine();
        bool vane = false;
        List<string> cím = new List<string>();
        for(int i = 0; i < hossz; i++)
        {
            if (tömb[i].adás != "0" && Hetnapja(dátum(tömb[i].adás).Year, dátum(tömb[i].adás).Month, dátum(tömb[i].adás).Day) == hét)
            {
                for (int j = 0; j < cím.Count; j++)
                {
                    if (cím[j] == tömb[i].cím)
                        vane = true;
                }
                if (vane == false)
                    cím.Add(tömb[i].cím);
                vane = false;
            }
        }
        for (int i = 0; i < cím.Count; i++)
            Console.WriteLine(cím[i]);
        Console.WriteLine();
        //8.
        StreamWriter sum = new StreamWriter("summa.txt");
        cím.Clear();
        for (int i = 0; i < hossz; i++)
        {
            vane = false;
            for (int j = 0; j < cím.Count; j++)
            {
                if (tömb[i].cím == cím[j])
                    vane = true;
            }
            if (vane == false)
                cím.Add(tömb[i].cím);
        }
        int y = 0;
        int hossz2 = 0;
        for (int i = 0; i < cím.Count; i++)
        {
            for (int j = 0; j < hossz; j++)
            {
                if (tömb[j].cím == cím[i])
                {
                    y++;
                    hossz2 += tömb[i].hossz;
                }
            }
            sum.WriteLine("{0} {1} {2}", cím[i], hossz2, y);
            y = 0;
            hossz2 = 0;
        }
        sum.Close();
    }
}