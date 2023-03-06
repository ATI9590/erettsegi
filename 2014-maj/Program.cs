namespace _2023._02._13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tömb = File.ReadAllLines("ip.txt");
            int hossz = tömb.Length;    //#lustaság
            //2.: Hossz
            Console.WriteLine("2. feladat:");
            Console.WriteLine("Az állományban {0} darab adatsor van\n", hossz);
            //3.: Legalacsonyabb IP-cím
            Console.WriteLine("3. feladat:");
            string min = tömb[0];
            for (int i = 1; i < hossz; i++)
            {
                if (min.CompareTo(tömb[i]) > 0)
                    min = tömb[i];
            }
            Console.WriteLine("A legalacsonyabb tárolt IP-cím:\n{0}\n", min);
            //4.: Faji megkülönböztetés
            Console.WriteLine("4. feladat:");
            int dok = 0;
            int glo = 0;
            int loc = 0;
            for (int i = 0; i < hossz; i++)
            {
                string[] split = tömb[i].Split(':');
                if (split[0].CompareTo("2001") == 0 && split[1].CompareTo("0db8") == 0)
                    dok++;
                if (split[0].CompareTo("2001") == 0 && split[1][0] == '0' && split[1][1] == 'e')
                    glo++;
                if (split[0][0] == 'f' && (split[0][1] == 'c' || split[0][1] == 'd'))
                    loc++;
            }
            Console.WriteLine("Dokumentációs cím: {0}", dok);
            Console.WriteLine("Globális egyedi cím: {0}", glo);
            Console.WriteLine("Helyi egyedi cím: {0}\n", loc);
            //5.: .txt
            StreamWriter sw = new StreamWriter("sok.txt");
            for (int i = 0; i < hossz; i++)
            {
                int db = 0;
                for (int j = 0; j < tömb[i].Length; j++)
                {
                    if (tömb[i][j] == '0')
                        db++;
                }
                if (db >= 18)
                    sw.WriteLine(tömb[i]);
            }
            sw.Close();
            //6.: ReadLine go brr
            Console.WriteLine("6. feladat:");
            Console.Write("Kérek egy sorszámot: ");
            int sorszám = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine(tömb[sorszám]);
            string[] split2 = tömb[sorszám].Split(':');
            string megoldás = "";
            for (int i = 0; i < split2.Length; i++)
            {
                if (split2[i][0] == '0')
                {
                    int j = 0;
                    while (split2[i][j] == '0' && j < 3)
                        j++;
                    for (int k = j; k < 4; k++)
                    {
                        megoldás = megoldás + split2[i][k];
                    }
                    if (i != 7)
                        megoldás = megoldás + ":";
                } else
                {
                    if (i != 7)
                        megoldás = megoldás + split2[i] + ":";
                    else
                        megoldás = megoldás + split2[i];
                }
            }
            Console.WriteLine(megoldás);
        }
    }
}