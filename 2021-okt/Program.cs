class Lépés
{
    public int szám;
    public int sor;
    public int oszlop;
}
internal class sudoku
{
    static int Résztáblázat(int sor, int oszlop)
    {
        int tábla;
        if (sor <= 3)
        {
            if (oszlop <= 3)
                tábla = 1;
            else if (oszlop >= 4 && oszlop <= 6)
                tábla = 2;
            else
                tábla = 3;
        }
        else if (sor >= 4 && sor <= 6)
        {
            if (oszlop <= 3)
                tábla = 4;
            else if (oszlop >= 4 && oszlop <= 6)
                tábla = 5;
            else
                tábla = 6;
        }
        else
        {
            if (oszlop <= 3)
                tábla = 7;
            else if (oszlop >= 4 && oszlop <= 6)
                tábla = 8;
            else
                tábla = 9;
        }
        return tábla;
    }
    static void Main()
    {
        //1.
        Console.WriteLine("1. feladat");
        Console.Write("Adja meg a bemeneti fájl nevét! ");
        string source = Console.ReadLine();
        Console.Write("Adja meg egy sor számát! ");
        int sor = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.Write("Adja meg egy oszlop számát! ");
        int oszlop = Convert.ToInt32(Console.ReadLine()) - 1;
        //2.
        string[] be = File.ReadAllLines(source);
        int[,] tábla = new int[9, 9];
        for (int i = 0; i < 9; i++) //soronként elválasztás
        {
            string[] split = be[i].Split(' ');
            for (int j = 0; j < 9; j++)
            {
                tábla[i, j] = Convert.ToInt32(split[j]);
            }
        }
        //3.
        Console.WriteLine("\n3. feladat");
        if (tábla[sor, oszlop] == 0)
            Console.WriteLine("Az adott helyet még nem töltötték ki.");
        else
            Console.WriteLine("Az adott helyen szereplő szám: {0}", tábla[sor, oszlop]);
        Console.WriteLine("A hely a(z) {0} résztáblázathoz tartozik.\n", Résztáblázat(sor + 1, oszlop + 1));
        //4.
        Console.WriteLine("4. feladat");
        int kitöltött = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (tábla[i, j] == 0)
                {
                    kitöltött++;
                }
            }
        }
        double százalék = kitöltött * 100 / 81;
        Console.WriteLine("Az üres helyek aránya: {0}%\n", százalék);
        //5.
        Lépés[] lépés = new Lépés[be.Length - 9];
        for (int i = 0; i < be.Length - 9; i++)
        {
            lépés[i] = new Lépés();
        }
        for (int i = 9; i < be.Length - 1; i++)
        {
            string[] split = be[i].Split(' ');
            lépés[i - 9].szám = Convert.ToInt32(split[0]);
            lépés[i - 9].sor = Convert.ToInt32(split[1]);
            lépés[i - 9].oszlop = Convert.ToInt32(split[2]);
        }
        bool sore = false;
        bool oszlope = false;
        bool résztábla = false;
        for (int i = 0; i < lépés.Length; i++)
        {
            Console.WriteLine("A kiválasztott sor: {0} oszlop: {1} a szám: {2}", lépés[i].sor, lépés[i].oszlop, lépés[i].szám);
            if (tábla[lépés[i].sor, lépés[i].oszlop] != 0)
                Console.WriteLine("A helyet már kitöltötték\n");
            else
            {
                for (int j = 0; j < 9; j++) //a sorban/oszlopban van-e már ilyen
                {
                    if (tábla[lépés[i].sor, j] == lépés[i].szám)
                    {
                        sore = true;
                        Console.WriteLine("Az adott sorban már szerepel a szám");
                    }
                    if (tábla[j, lépés[i].oszlop] == lépés[i].szám)
                    {
                        Console.WriteLine("Az adott oszlopban már szerepel a szám");
                        oszlope = true;
                    }
                }
                if (sore == false && oszlope == false && résztábla == false)
                    Console.WriteLine("A lépés megtehető");
            }
        }
    }
}