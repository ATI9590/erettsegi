class tánc
{
    public string bemutató;
    public string lány;
    public string fiú;
}
class tanciskola
{
    static void Main()
    {
        string[] be = File.ReadAllLines("tancrend.txt");
        tánc[] tömb = new tánc[140];
        for (int i = 0; i < 140; i++)
            tömb[i] = new tánc();
        for (int i = 0; i < be.Length / 3; i++)
        {
            tömb[i].bemutató = be[i*3];
            tömb[i].lány = be[i*3+1];
            tömb[i].fiú = be[i*3+2];
        }
        //2.
        int hossz = be.Length / 3 - 1;
        Console.WriteLine("2. feladat");
        Console.WriteLine("Az elsőnek bemutatott tánc: {0}. Az utolsónak bemutatott tánc: {1}.\n", tömb[0].bemutató, tömb[hossz].bemutató);
        //3.
        Console.WriteLine("3. feladat");
        int db = 0;
        for (int i = 0; i < hossz; i++)
        {
            if (tömb[i].bemutató == "samba")
                db++;
        }
        Console.WriteLine("{0} pár mutatta be a sambát.\n", db);
        //4.
        Console.WriteLine("4. feladat");
        Console.WriteLine("Vilma a következő táncokban vett részt:");
        for (int i = 0; i < hossz; i++)
        {
            if (tömb[i].lány == "Vilma")
                Console.WriteLine(tömb[i].bemutató);
        }
        Console.WriteLine("");
        //5.
        Console.WriteLine("5. feladat");
        Console.Write("Adjon meg egy táncot: ");
        string bemutató = Console.ReadLine();
        bool szerepelt = false;
        int szám = 0;
        for (int i = 0; i < hossz; i++)
        {
            if (tömb[i].bemutató == bemutató && tömb[i].lány == "Vilma")
            {
                szerepelt = true;
                szám = i;
            }
        }
        if (szerepelt == true)
            Console.WriteLine("A {0} bemutatóján Vilma párja {1} volt.\n", bemutató, tömb[szám].fiú);
        else
            Console.WriteLine("Vilma nem táncolt {0}-t.\n", bemutató);
        //6.
        string[] fiú = new string[20];
        string[] lány = new string[20];
        bool fiúe = false;
        bool lánye = false;
        int id = 0;
        for (int i = 0; i < hossz; i++)
        {
            id = 0;
            fiúe = false;
            for (int j = 0; j < 20; j++)
            {
                if (fiú[j] == tömb[i].fiú)
                {
                    fiúe = true;
                    break;
                }
            }
            if (fiúe == false)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (fiú[j] == null)
                    {
                        id = j;
                        break;
                    }
                }
                fiú[id] = tömb[i].fiú;
            }
            lánye = false;
            for (int j = 0; j < 20; j++)
            {
                if (lány[j] == tömb[i].lány)
                {
                    lánye = true;
                    break;
                }
            }
            if (lánye == false)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (lány[j] == null)
                    {
                        id = j;
                        break;
                    }
                }
                lány[id] = tömb[i].lány;
            }
        }
        StreamWriter sw = new StreamWriter("szereplok.txt");
        sw.Write("Lányok: ");
        for (int i = 0; i < 19; i++)
        {
            if (lány[i + 1] != null)
            {
                sw.Write("{0}, ", lány[i]);
            }
            if (lány[i + 1] == null)
            {
                sw.WriteLine("{0}", lány[i]);
                break;
            }
        }
        sw.Write("Fiúk: ");
        for (int i = 0; i < 19; i++)
        {
            if (fiú[i + 1] != null)
            {
                sw.Write("{0}, ", fiú[i]);
            }
            if (fiú[i + 1] == null)
            {
                sw.Write("{0}", fiú[i]);
                break;
            }
        }        
        sw.Close();
        //7.
        Console.WriteLine("7. feladat");
        Dictionary<string, int> fiúmegjelenés = new Dictionary<string, int>();
        Dictionary<string, int> lánymegjelenés = new Dictionary<string, int>();
        for (int i = 0; i < 20; i++)
        {
            if (fiú[i] != null)
            {
                fiúmegjelenés.Add(fiú[i], 0);
            }
            if (lány[i] != null)
            {
                lánymegjelenés.Add(lány[i], 0);
            }
        }
        for (int i = 0; i < fiúmegjelenés.Count; i++)
        {
            db = 0;
            for (int j = 0; j < hossz; j++)
            {
                if (tömb[j].fiú == fiú[i])
                {
                    db++;
                }
            }
            fiúmegjelenés[fiú[i]] = db;
        }
        for (int i = 0; i < lánymegjelenés.Count; i++)
        {
            db = 0;
            for (int j = 0; j < hossz; j++)
            {
                if (tömb[j].lány == lány[i])
                {
                    db++;
                }
            }
            lánymegjelenés[lány[i]] = db;
        }
        int fiúmax = 0;
        int lánymax = 0;
        for (int i = 0; i < fiúmegjelenés.Count; i++)
        {
            if (fiúmax < fiúmegjelenés[fiú[i]])
            {
                fiúmax = fiúmegjelenés[fiú[i]];
            }
        }
        for (int i = 0; i < lánymegjelenés.Count; i++)
        {
            if (lánymax < lánymegjelenés[lány[i]])
            {
                lánymax = lánymegjelenés[lány[i]];
            }
        }
        Console.WriteLine("A következő fiú(k) szerepelt(ek) a legtöbbször:");
        for (int i = 0; i < fiúmegjelenés.Count; i++)
        {
            if (fiúmegjelenés[fiú[i]] == fiúmax)
                Console.WriteLine(fiú[i]);
        }
        Console.WriteLine("A következő lány(ok) szerepelt(ek) a legtöbbször:");
        for (int i = 0; i < lánymegjelenés.Count; i++)
        {
            if (lánymegjelenés[lány[i]] == lánymax)
                Console.WriteLine(lány[i]);
        }
    }
}