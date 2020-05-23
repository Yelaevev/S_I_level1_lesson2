using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static int odometer(int[] oksana)
        {
            int rez = 0;
            int length;
            bool testControl = true;
            ////////////////////////////////////////////////
            //////proverka ysloviy
            length = oksana.Length;
            Console.WriteLine($"length= { length}");
            if (length < 2)
            {
               // testControl = false;
                Console.WriteLine("dlina massiva dolzhna byt'>=2");
                return 0;
            }
            if (length % 2 != 0)
            {
               // testControl = false;
                Console.WriteLine("elementov v massive dolzhna byt' chetnoe kolichestvo ");
                return 0;
            }
            for (int i = 0; i <= (length-1); i++)
            {
                if (oksana[i] < 0)
                {
                    testControl = false;
                    Console.WriteLine(" skalyarnye velichiny dolzhny byt' >0");
                    return 0;
                }
            }

            for (int i = 0; i <= (length - 3); i = i + 2)
            {
                //int a = oksana[i];
                //int b = oksana[i + 2];
                // if (a > b)
                if (oksana[i] >= oksana[i + 2])
               
                {
                   // testControl = false;
                    Console.WriteLine("obshee vremya puti ne mochet ne yvelichevatsya");
                    return 0;
                }
            }

           
///////////////////////////////////////
///////// rashet puti
            if (testControl)
            {
                rez = oksana[0] * oksana[1];

                for (int i = 2; i <= length - 2; i = i + 2)
                {
                    int a = oksana[i];
                    int b = oksana[i + 1];
                    int c = oksana[i - 2];
                    int tempControl = oksana[i + 1] * (oksana[i] - oksana[i - 2]);
                    if (tempControl < 0)   /// proverka perepolneniy diapazona int (yslovie men'che 0 tak kak pri prevychenii)
                                           /// max znacheniy (2147483647) pereskakivaet na (-2147483648)
                    {
                        Console.WriteLine("prevycheno maksimalnoe znachenie puti");
                        return 0;
                    }

                    rez = rez + oksana[i+1] * (oksana[i ] - oksana[i - 2]);
                    if (rez < 0)  ///analogichnay proverka^ diapozona znacheniy int
                    {
                        Console.WriteLine("prevycheno maksimalnoe znachenie puti");
                       return 0;
                    }
                }

            }
            else rez = 0;
            return rez;
        }

        static void Main(string[] args)
        {

            //int[] pasha = { 1, 2147483647, 3, 1073741825,5,0};
            int[] pasha = { 2, 10, 5, 30, 6, 40,5,69 };
            int rezultat = odometer(pasha);


            Console.WriteLine($"rezultat={rezultat}");
        }
    }
}