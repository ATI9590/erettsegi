class bérlet
{
    public int megálló;
    public string idő;
    public int id;
    public string típus;
    public string érvényesség;
}
class eutazas
{
    static int napokszama(int e1, int h1, int n1, int e2, int h2, int n2)
    {
        h1 = (h1 + 9) % 12;
        e1 = e1 - h1/10;
        int d1 = 365*e1 + e1/4 - e1/100 + e1/400 + (h1*306 + 5)/10 + n1 - 1;
        h2 = (h2 + 9) % 12;
        e2 = e2 - h2/10;
        int d2 = 365*e2 + e2/4 - e2/100 + e2/400 + (h2*306 + 5)/10 + n2 - 1;
        return d2 - d1;
    }
    static DateTime idő(string input)
    {
        int év = Convert.ToInt32(input[0..4]);
        int hó = Convert.ToInt32(input[4..6]);
        int nap = Convert.ToInt32(input[6..8]);
        DateTime x = new DateTime(év, hó, nap);
        return x;
    }
    static void Main()
    {
        bérlet[] tömb = new bérlet[2000];
        for (int i = 0; i < 2000; i++)
            tömb[i] = new bérlet();
        string[] be = File.ReadAllLines("utasadat.txt");
        int hossz = be.Length;
        for (int i = 0; i < hossz; i++)
        {
            string[] split = be[i].Split(' ');
            tömb[i].megálló = Convert.ToInt32(split[0]);
            tömb[i].idő = split[1];
            tömb[i].id = Convert.ToInt32(split[2]);
            tömb[i].típus = split[3];
            tömb[i].érvényesség = split[4];
        }
        Console.WriteLine(tömb[0].idő);
        //2.
        Console.WriteLine("2. feladat");
        Console.WriteLine("A buszra {0} utas akart felszállni\n", hossz);
        //3.
        Console.WriteLine("3. feladat");
        int db = 0;
        for (int i = 0; i < hossz; i++)
        {
            if (tömb[i].érvényesség == "0" || (Convert.ToInt32(tömb[i].érvényesség) > 11 && idő(tömb[i].idő) >= idő(tömb[i].érvényesség)))
            {
                db++;
            }
        }
        Console.WriteLine("A buszra {0} utas nem szállhatott fel.\n", db);
        //4.
        Console.WriteLine("4. feladat");
        int max = 0;
        Dictionary<int, int> megállók = new Dictionary<int, int>();
        for (int i = 0; i < 30; i++)
        {
            db = 0;
            for (int j = 0; j < hossz; j++)
            {
                if (tömb[j].megálló == i)
                    db++;
            }
            if (max < db)
                max = db;
                megállók.Add(i, db);
        }
        for (int i = 0; i < 30; i++)
        {
            if (max == megállók[i])
            {
                Console.WriteLine("A legtöbb utas ({0} fő) a {1}. megállóban próbált felszállni.\n", max, i);
                break;
            }
        }
        //5.
        Console.WriteLine("5. feladat");
        int kedvezményes = 0;
        int ingyenes = 0;
        for (int i = 0; i < hossz; i++)
        {
            if ((Convert.ToInt32(tömb[i].érvényesség) > 0 && Convert.ToInt32(tömb[i].érvényesség) < 11) || (Convert.ToInt32(tömb[i].érvényesség) > 11 && idő(tömb[i].idő) <= idő(tömb[i].érvényesség)))
            {
                if (tömb[i].típus == "TAB" || tömb[i].típus == "NYB")
                    kedvezményes++;
                if (tömb[i].típus == "NYP" || tömb[i].típus == "RVS" || tömb[i].típus == "GYK")
                    ingyenes++;
            }
        }
        Console.WriteLine("Ingyenesen utazók száma: {0} fő", ingyenes);
        Console.WriteLine("A kedvezményesen utazók száma: {0} fő\n", kedvezményes);
        //7.
        StreamWriter figyelmeztetés = new StreamWriter("figyelmeztetes.txt");
        for (int i = 0; i < hossz; i++)
        {
            if (Convert.ToInt32(tömb[i].érvényesség) > 11 && napokszama(idő(tömb[i].idő).Year, idő(tömb[i].idő).Month, idő(tömb[i].idő).Day, idő(tömb[i].érvényesség).Year, idő(tömb[i].érvényesség).Month, idő(tömb[i].érvényesség).Day) <= 3)
            {
                figyelmeztetés.WriteLine("{0} {1}-{2}-{3}", tömb[i].id, idő(tömb[i].érvényesség).Year, idő(tömb[i].érvényesség).Month, idő(tömb[i].érvényesség).Day);
            }
        }
        figyelmeztetés.Close();
    }
}