namespace _2023._01._30
{
    class Hívás
    {
        public int óó1;
        public int pp1;
        public int mp1;
        public int óó2;
        public int pp2;
        public int mp2;
    }
    internal class Program
    {
        //1.
        static int mpbe(int o, int p, int mp)
        {
            return ((o * 3600) + (p * 60) + mp);
        }
        static void Main(string[] args)
        {
            //2.
            Hívás[] tömb = new Hívás[1000];
            for (int i = 0; i < 1000; i++)
                tömb[i] = new Hívás();
            string[] nyers = File.ReadAllLines("hivas.txt");
            for (int i = 0; i < nyers.Length; i++)
            {
                string[] splitted = nyers[i].Split(' ');
                tömb[i].óó1 = Convert.ToInt32(splitted[0]);
                tömb[i].pp1 = Convert.ToInt32(splitted[1]);
                tömb[i].mp1 = Convert.ToInt32(splitted[2]);
                tömb[i].óó2 = Convert.ToInt32(splitted[3]);
                tömb[i].pp2 = Convert.ToInt32(splitted[4]);
                tömb[i].mp2 = Convert.ToInt32(splitted[5]);
            }
            //3.
            Console.WriteLine("3. feladat");
            int db = 0;
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < nyers.Length; j++)
                {
                    if (tömb[j].óó1 == i)
                        db++;
                }
                if (db > 0)
                    Console.WriteLine("{0} óra {1} hívás", i, db);
                db = 0;
            }
            Console.WriteLine("");
            //4.
            Console.WriteLine("4. feladat");
            int maxind = 0;
            int maxért = mpbe(tömb[0].óó2, tömb[0].pp2, tömb[0].mp2) - mpbe(tömb[0].óó1, tömb[0].pp1, tömb[0].mp1);
            for (int i = 1; i < nyers.Length; i++)
            {
                if (maxért < mpbe(tömb[i].óó2, tömb[i].pp2, tömb[i].mp2) - mpbe(tömb[i].óó1, tömb[i].pp1, tömb[i].mp1))
                {
                    maxind = i;
                    maxért = mpbe(tömb[i].óó2, tömb[i].pp2, tömb[i].mp2) - mpbe(tömb[i].óó1, tömb[i].pp1, tömb[i].mp1);
                }
            }
            Console.WriteLine("A leghoszabb ideig vonalban lévő hívó {0}. sorban szerepel, a hívás hossza: {1} másodperc\n", maxind + 1, maxért);
            //5.
            Console.Write("Adjon meg egy időpontot! (óra perc másodperc)");
            int beóó = Convert.ToInt32(Console.ReadLine());
            int bepp = Convert.ToInt32(Console.ReadLine());
            int bemp = Convert.ToInt32(Console.ReadLine());
            int időpont = mpbe(beóó, bepp, bemp);
            int utolsó = -1;
            for (int i = 0; i < nyers.Length; i++)
            {
                if (mpbe(tömb[i].óó1, tömb[i].pp1, tömb[i].mp1) < időpont)
                    utolsó = i;
            }
            int első = nyers.Length;
            int aktívdb = 0;
            for (int i = utolsó; i >= 0; i--)
            {
                if (időpont < mpbe(tömb[i].óó2, tömb[i].pp2, tömb[i].mp2))
                {
                    aktívdb++;
                    első = i;
                }
            }
            if (aktívdb > 0)
                Console.WriteLine("A várakozók száma: {0} a beszélő a {1}. hívó", aktívdb - 1, utolsó + 1);
            else
                Console.WriteLine("Nem volt beszélő.");
            //6.
            int utind = 0;
            for (int i = 0; i < nyers.Length; i++)
            {
                if (tömb[i].óó1 < 12 && mpbe(tömb[i].óó2, tömb[i].pp2, tömb[i].mp2) > mpbe(tömb[utind].óó2, tömb[utind].pp2, tömb[utind].mp2))
                    utind = i;
            }
            int maxidő = 0;
            for (int i = 0; i < utind - 1; i++)
            {
                if (maxidő < mpbe(tömb[i].óó2, tömb[i].pp2, tömb[i].mp2))
                    maxidő = mpbe(tömb[i].óó2, tömb[i].pp2, tömb[i].mp2);
            }
            Console.WriteLine("Az utolsó telefonáló adatai a(z) {0}. sorban vannak, {1} másodpercig tart", utind + 1, maxidő - mpbe(tömb[utind].óó1, tömb[utind].pp1, tömb[utind].mp1));
            //7.
            int nyóc = nyers.Length;
            for (int i = nyers.Length - 1; i >= 0; i--)
            {
                if (tömb[i].óó2 == 8)
                    nyóc = i;
            }
            int előző = mpbe(tömb[nyóc].óó2, tömb[nyóc].pp2, tömb[nyóc].mp2);
            StreamWriter sw = new StreamWriter("sikeres.txt");
            sw.WriteLine(nyóc + 1 + " 8 0 0 " + tömb[nyóc].óó2 + " " + tömb[nyóc].pp2 + " " + tömb[nyóc].mp2);
            for (int i = nyóc; i < nyers.Length; i++)
            {
                if (mpbe(tömb[i].óó2, tömb[i].pp2, tömb[i].mp2) > előző && tömb[i].óó1 < 12)
                {
                    sw.WriteLine((i + 1) + " " + tömb[nyóc].óó2 + " " + tömb[nyóc].pp2 + " " + tömb[nyóc].mp2 + " " + tömb[i].óó2 + " " + tömb[i].pp2 + " " + tömb[i].mp2);
                    nyóc = i;
                    előző = mpbe(tömb[nyóc].óó2, tömb[nyóc].pp2, tömb[nyóc].mp2);
                }

            }
            sw.Close();
        }
    }
}