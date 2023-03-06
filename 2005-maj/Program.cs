namespace _2023._03._02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] tömb = new int[52,5];
            string[] be = File.ReadAllLines("lottosz.dat");
            for (int i = 0; i < be.Length; i++)
            {
                string[] splitted = be[i].Split(' ');
                for (int j = 0; j < splitted.Length; j++)
                    tömb[i, j] = Convert.ToInt32(splitted[j]);
            }
            int hossz = 52;
            //1. feladat
            int[] ö = new int[5];
            Console.WriteLine("1. feladat");
            Console.WriteLine("Adja meg az 52. heti nyerőszámokat:");
            ö[0] = Convert.ToInt32(Console.ReadLine());
            ö[1] = Convert.ToInt32(Console.ReadLine());
            ö[2] = Convert.ToInt32(Console.ReadLine());
            ö[3] = Convert.ToInt32(Console.ReadLine());
            ö[4] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            //2. feladat
            Console.WriteLine("2. feladat");
            int temp = 91;
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (temp > ö[j])
                    {
                        temp = ö[j];
                        index = j;
                    }
                }
                tömb[51, i] = temp;
                temp = 91;
                ö[index] = 92;
            }
            Console.WriteLine("{0} {1} {2} {3} {4}\n", tömb[51, 0], tömb[51, 1], tömb[51, 2], tömb[51, 3], tömb[51, 4]);
            //3. feladat
            Console.WriteLine("3. feladat");
            Console.Write("Adjon meg egy egész számot 1 és 51 között! ");
            int f3 = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("");
            //4. feladat
            Console.WriteLine("4. feladat");
            Console.Write("{0} {1} {2} {3} ", tömb[f3, 0], tömb[f3, 1], tömb[f3, 2], tömb[f3, 3]);
            Console.WriteLine("{0}\n", tömb[f3, 4]);
            //5. feladat
            Console.WriteLine("5. feladat");
            bool van = false;
            bool vane = false;
            for (int i = 1; i <= 90; i++)
            {
                for (int j = 0; j < 51; j++)
                {
                    if (tömb[j, 0] == i)
                        van = true;
                    else if (tömb[j, 1] == i)
                        van = true;
                    else if (tömb[j, 2] == i)
                        van = true;
                    else if (tömb[j, 3] == i)
                        van = true;
                    else if (tömb[j, 4] == i)
                        van = true;
                }
                if (van == false)
                    vane = true;
                van = false;
            }
            if (vane == true)
                Console.WriteLine("Van\n");
            else
                Console.WriteLine("Nincs\n");
            //6. feladat
            Console.WriteLine("6. feladat");
            int ptlan = 0;
            for (int i = 0; i < hossz; i++)
            {
                if (tömb[i, 0] % 2 == 1)
                    ptlan++;
                if (tömb[i, 1] % 2 == 1)
                    ptlan++;
                if (tömb[i, 2] % 2 == 1)
                    ptlan++;
                if (tömb[i, 3] % 2 == 1)
                    ptlan++;
                if (tömb[i, 4] % 2 == 1)
                    ptlan++;
            }
            Console.WriteLine("{0} darab páratlan szám volt a kihúzottak között.\n", ptlan);
            //7. feladat
            int[] x = new int[5];
            StreamWriter sw = new StreamWriter("lotto52.ki");
            for (int i = 0; i < 51; i++)
            {
                sw.Write("{0} ", tömb[i, 0]);
                sw.Write("{0} ", tömb[i, 1]);
                sw.Write("{0} ", tömb[i, 2]);
                sw.Write("{0} ", tömb[i, 3]);
                sw.Write("{0}\n", tömb[i, 4]);
            }
            for (int i = 0; i < 5; i++)
            {
                if (i != 4)
                    sw.Write("{0} ", x[i]);
                else
                    sw.Write(x[i]);
            }
            sw.Close();
            //8. feladat
            Console.WriteLine("8. feladat");
            ptlan = 0;
            for (int i = 1; i <= 90; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (tömb[j, 0] == i)
                        ptlan++;
                    if (tömb[j, 1] == i)
                        ptlan++;
                    if (tömb[j, 2] == i)
                        ptlan++;
                    if (tömb[j, 3] == i)
                        ptlan++;
                    if (tömb[j, 4] == i)
                        ptlan++;
                }
                if (i % 90 == 0)
                    Console.Write("{0}", ptlan);
                else if (i % 10 == 0)
                    Console.WriteLine("{0}", ptlan);
                else
                    Console.Write("{0} ", ptlan);
                ptlan = 0;
            }
            //9. feladat
            Console.WriteLine("\n\n9. feladat");
            for (int i = 1; i <=90; i++)
            {
                if (i == 2 || i == 3 || i == 5 || i == 7 || i == 11 || i == 13 || i == 17 || i == 19 || i == 23 || i == 29 || i == 31 || i == 37 || i == 41 || i == 43 || i == 47 || i == 53 || i == 59 || i == 61 || i == 67 || i == 71 || i == 73 || i == 79 || i == 83 || i == 89)
                {
                    for (int j = 0; j < 52; j++)
                    {
                        if (tömb[j, 0] == i)
                            van = true;
                        if (tömb[j, 1] == i)
                            van = true;
                        if (tömb[j, 2] == i)
                            van = true;
                        if (tömb[j, 3] == i)
                            van = true;
                        if (tömb[j, 4] == i)
                            van = true;
                    }
                    if (van == false)
                        Console.Write("{0} ", i);
                    van = false;
                }
            }
        }
    }
}