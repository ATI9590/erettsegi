namespace _2022._11._28
{
    internal class Program
    {
        class Meccs
        {
            public int ford;
            public int hazai_v;
            public int vendeg_v;
            public int hazai_f;
            public int vendeg_f;
            public string hazai;
            public string vendeg;
        }
        static void Main(string[] args)
        {
            Meccs[] tömb = new Meccs[400];
            for (int i = 0; i < 400; i++)
                tömb[i] = new Meccs();
            string[] nyers = File.ReadAllLines("meccs.txt");
            int hossz = Convert.ToInt32(nyers[0]);
            for (int i = 1; i <= hossz; i++)
            {
                string[] splitted = nyers[i].Split(' ');
                tömb[i - 1].ford = Convert.ToInt32(splitted[0]);
                tömb[i - 1].hazai_v = Convert.ToInt32(splitted[1]);
                tömb[i - 1].vendeg_v = Convert.ToInt32(splitted[2]);
                tömb[i - 1].hazai_f = Convert.ToInt32(splitted[3]);
                tömb[i - 1].vendeg_f = Convert.ToInt32(splitted[4]);
                tömb[i - 1].hazai = splitted[5];
                tömb[i - 1].vendeg = splitted[6];
            }
            // 2. feladat
            Console.WriteLine("2. feladat:");
            Console.Write("Forduló száma: ");
            int forduló = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < hossz; i++)
            {
                if (tömb[i].ford == forduló)
                {
                    Console.WriteLine("{0}-{1}: {2}-{3} ({4}-{5})", tömb[i].hazai, tömb[i].vendeg, tömb[i].hazai_v, tömb[i].vendeg_v, tömb[i].hazai_f, tömb[i].vendeg_f);
                }
            }
            Console.Write("\n");
            // 3. feladat
            Console.WriteLine("3. feladat");
            for (int i = 0; i < hossz; i++)
            {
                if (tömb[i].hazai_f > tömb[i].vendeg_f && tömb[i].hazai_v < tömb[i].vendeg_v)
                {
                    Console.WriteLine(tömb[i].ford + ". forduló, " + "a győztes: " + tömb[i].hazai);
                }
                if (tömb[i].hazai_f < tömb[i].vendeg_f && tömb[i].hazai_v > tömb[i].vendeg_v)
                {
                    Console.WriteLine(tömb[i].ford + ". forduló, " + "a győztes: " + tömb[i].vendeg);
                }
            }
            Console.Write("\n");
            // 4. feladat
            Console.WriteLine("4. feladat");
            Console.Write("Csapatnév: ");
            string csapat = Console.ReadLine();
            Console.Write("\n");
            // 5. feladat
            Console.WriteLine("5. feladat");
            int lőtt = 0;
            int kapott = 0;
            for (int i = 0; i < hossz; i++)
            {
                if (tömb[i].hazai == csapat)
                {
                    lőtt = lőtt + tömb[i].hazai_v;
                    kapott = kapott + tömb[i].vendeg_v;
                }
                if (tömb[i].vendeg == csapat)
                {
                    lőtt = lőtt + tömb[i].vendeg_v;
                    kapott = kapott + tömb[i].hazai_v;
                }
            }
            Console.WriteLine("Lőtt: " + lőtt + ", Kapott: " + kapott + "\n");
        }
    }
}