using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCoins
{
    class Program
    {
        public static int ChangeCoins(int amount)
        {
            return CC(amount, 5);
        }

        private static int CC(int amount, int kindOfCoins)
        {
            if(amount == 0)
            {
                return 1;
            }
            else if(amount < 0 || kindOfCoins == 0)
            {
                return 0;
            }
            else
            {
                var value1 = CC(amount, kindOfCoins - 1);
                var temp = amount - FirstDenomination(kindOfCoins);
                var value2 = CC(temp, kindOfCoins);
                return value1 + value2;
            }
        }

        private static int FirstDenomination(int kindOfCoins)
        {
            switch(kindOfCoins)
            {
                case 1: return 1;
                case 2: return 5;
                case 3: return 10;
                case 4: return 25;
                case 5: return 50;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            //CC(100, 5) = CC(100,4) + CC(50, 5)
                //CC(100, 4)  = CC(100,3) + CC(75, 4)
                    //CC(100, 3) = CC(100, 2) + (90, 3)
                        //CC(100, 2) = (100, 1) + (95, 2)
                        //CC(90, 3)   = (90, 2)  + (80, 3)
                    //CC(75, 4)   = CC(75, 3) + CC(50, 4)
                        //CC(75, 3)   = (75, 2) + (65, 3)
                        //CC(50, 4)   =(50, 3 ) +(25, 4)
                //CC(50, 5)
                        

            //CC(100,2)
            //CC(100,1)  CC(100,0) + CC(99,5)
            //
            Console.WriteLine(ChangeCoins(100));
            int count = 0;
            for(int a = 0; a <= 100; a++)
            {
                for(int b = 0; b <= 20; b++)
                {
                    for(int c = 0; c <= 10; c++)
                    {
                        for (int d = 0; d <= 4;d++ )
                        {
                            for(int e = 0; e <=2; e++)
                            {
                                if(a+b*5+c*10 + d*25 + e*50 == 100)
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
