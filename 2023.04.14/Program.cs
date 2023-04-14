class fejvagyiras
{
    static string pénzdobás()
    {
        Random rnd = new Random();
        int be = rnd.Next(2);
        string eredmény = "";
        if (be == 1)
            eredmény = "I";
        if (be == 0)
            eredmény = "F";
        return eredmény;
    }
    static void Main()
    {
        int hossz = File.ReadAllLines("kiserlet.txt").Length;
        //1.
        Console.WriteLine("1. feladat");
        Console.WriteLine("A pénzfeldobás eredménye: {0}\n", pénzdobás());
        //2.
        Console.Write("2. feladat\nTippeljen! (F/I)= ");
        string tipp = Console.ReadLine();
        string eredmény = pénzdobás();
        Console.WriteLine("A tipp {0}, a dobás eredménye {1} volt.", tipp, eredmény);
        if (tipp == eredmény)
            Console.WriteLine("Ön eltalálta.\n");
        else
            Console.WriteLine("Ön nem találta el.\n");
        //3.
        Console.WriteLine("3. feladat\nA kísérlet {0} dobásból áll.\n", hossz);
        //4.
        Console.WriteLine("4. feladat");
        int db = 0;
        foreach (string a in File.ReadAllLines("kiserlet.txt"))
        {
            if (a == "F")
                db++;
        }
        Console.WriteLine("A kísérlet során a fej relatív gyakorisága {0}% volt.\n", Math.Round((double)db / (double)hossz * 100, 2));
        db = 0;
        //5.
        Console.WriteLine("5. feladat");
        for (int i = 0; i < hossz - 3; i++)
        {
            if (File.ReadAllLines("kiserlet.txt")[i] == "I" && File.ReadAllLines("kiserlet.txt")[i + 1] == "F" && File.ReadAllLines("kiserlet.txt")[i + 2] == "F" && File.ReadAllLines("kiserlet.txt")[i + 3] == "I")
            {
                db++;
            }
        }
        if (File.ReadAllLines("kiserlet.txt")[0] == "F" && File.ReadAllLines("kiserlet.txt")[1] == "F" && File.ReadAllLines("kiserlet.txt")[2] == "I")
            db++;
        if (File.ReadAllLines("kiserlet.txt")[hossz - 1] == "F" && File.ReadAllLines("kiserlet.txt")[hossz - 2] == "F" && File.ReadAllLines("kiserlet.txt")[hossz - 3] == "I")
            db++;
        Console.WriteLine("A kísérlet során {0} alkalommal dobtak pontosan két fejet egymás után.\n", db);
        //6.
        Console.WriteLine("6. feladat");
        int kezdet = 0;
        db = 0;
        int maxkezdet = 0;
        int max = -1;
        bool talált = false;
        for (int i = 0; i < hossz; i++)
        {
            if (talált == false && File.ReadAllLines("kiserlet.txt")[i] == "F") //egy F sorozat elejének megkeresése
            {
                talált = true;
                kezdet = i;
                db = 0;
            }
            if (talált == true && File.ReadAllLines("kiserlet.txt")[i] == "F")
                db++;
            if (talált == true && File.ReadAllLines("kiserlet.txt")[i] == "I")
            {
                talált = false;
                if (max < db)
                {
                    max = db;
                    maxkezdet = kezdet;
                }
            }
        }
        Console.WriteLine("A leghosszabb tisztafej sorozat {0} tagból áll, kezdete a(z) {1}. dobás.", max, maxkezdet + 1);
    }
}