using System;

namespace test_code_converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] test = new int[20, 512];

            //code genereren
            for (int i = 0;i<20;i++)
            {
                for (int y = 0; y < 512; y++)
                {
                    if(y %2 != 0)
                    {
                        test[i, y] = 1;
                    }
                    else
                    {
                        test[i, y] = 0;
                    }
                }
            }
        }
        //resultaten uitprinten
        public void Printout()
        {
            int[] test1 = new int[512];
            int[] test2 = new int[512];
            int[] test3 = new int[512];
            int[] test4 = new int[512];
            int[] test5 = new int[512];
            int[] test6 = new int[512];
            int[] test7 = new int[512];
            int[] test8 = new int[512];
            int[] test9 = new int[512];
            int[] test10 = new int[512];
            int[] test11 = new int[512];
            int[] test12 = new int[512];
            int[] test13 = new int[512];
            int[] test14 = new int[512];
            int[] test15 = new int[512];
            int[] test16 = new int[512];
            int[] test17 = new int[512];
            int[] test18 = new int[512];
            int[] test19 = new int[512];
            int[] test20 = new int[512];
            for (int i = 0; i < 20; i++)
            {
                for (int y = 0; y < 512; y++)
                {
                    string.Join("", test);
                }
            }
        }
    }
}
