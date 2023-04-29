class utca
{
    public int oldal;
    public int hossz;
    public string kerítés;
}
class program
{
    static int szám(int házszám, int oldal)
    {
        if (oldal % 2 == 1)
            return (1 + (házszám * 2));
        else
            return (2 + (házszám * 2));
    }
    static void Main()
    {
        //1. feladat
        utca[] tömb = new utca[125];
        for (int i = 0; i < 125; i++)
            tömb[i] = new utca();
        string[] be = File.ReadAllLines("kerites.txt");
        for (int i = 0; i < be.Length; i++)
        {
            string[] split = be[i].Split(' ');
            tömb[i].oldal = Convert.ToInt32(split[0]);
            tömb[i].hossz = Convert.ToInt32(split[1]);
            tömb[i].kerítés = split[2];
        }
        //2. feladat
        Console.WriteLine("2. feladat");
        Console.WriteLine("Az eladott telkek száma: {0}\n", be.Length);
        //3.
        Console.WriteLine("3. feladat");
        bool házszám = false;
        if (tömb[be.Length - 1].oldal == 0)
            Console.WriteLine("A páros oldalon adták el az utolsó telket.");
        if (tömb[be.Length - 1].oldal == 1)
            Console.WriteLine("A páratlan oldalon adták el az utolsó telket.");
        int oldal = 0;
        int ház = 0;
        for (int i = 0; i < be.Length - 1; i++)
        {
            if (tömb[i].oldal == tömb[be.Length - 1].oldal)
                oldal++;
        }
        ház = szám(oldal, tömb[be.Length - 1].oldal);
        Console.WriteLine("Az utolsó telek házszáma: {0}\n", ház);
        //4.
        string szín = tömb[0].kerítés;
        oldal = 0;
        for (int i = 0; i < be.Length; i++)
        {
            if ((tömb[i].kerítés != ";" && tömb[i].kerítés != "#") && tömb[i].kerítés == szín && tömb[i].oldal == 1)
            {
                oldal++;
                break;
            }
            else if (tömb[i].oldal == 1)
            {
                oldal++;
                szín = tömb[i].kerítés;
            }
        }
        ház = szám(oldal, 1);
        Console.WriteLine("{0} {1}", ház, oldal);
        //5.
        //todo
        //6.
        ház = 1;
        StreamWriter sw = new StreamWriter("utcakep.txt");
        for (int i = 0; i < be.Length; i++)
        {
            if (tömb[i].oldal == 1)
            {
                for (int j = 0; j < tömb[i].hossz; j++)
                    sw.Write(tömb[i].kerítés);
            }
        }
        sw.Write("\n");
        for (int i = 0; i < be.Length; i++)
        {
            if (tömb[i].oldal == 1)
            {
                sw.Write(ház);
                if (ház < 10)
                {
                    for (int j = 1; j < tömb[i].hossz; j++)
                        sw.Write(" ");
                }
                if (ház >= 10 && ház < 100)
                {
                    for (int j = 2; j < tömb[i].hossz; j++)
                        sw.Write(" ");
                }
                if (ház >= 100)
                {
                    for (int j = 3; j < tömb[i].hossz; j++)
                        sw.Write(" ");
                }
                ház += 2;
            }
        }
        sw.Close();
    }
}