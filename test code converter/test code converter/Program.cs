using System;

namespace test_code_converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] test = new int[20, 512];
            int[,] converted = new int[20, 512];

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
            Console.WriteLine(Printout(test));
            Console.ReadLine();
        }
        //resultaten uitprinten
        static string Printout(int[,] tested)
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
            string testString1;
            string testString2;
            string testString3;
            string testString4;
            string testString5;
            string testString6;
            string testString7;
            string testString8;
            string testString9;
            string testString10;
            string testString11;
            string testString12;
            string testString13;
            string testString14;
            string testString15;
            string testString16;
            string testString17;
            string testString18;
            string testString19;
            string testString20;
            for (int i = 0; i < 20; i++)
            {
                for(int y = 0; y < 512; y++)
                {
                    switch (i)
                    {
                        case 0:
                            test1[y] = tested[i, y];
                            break;
                        case 1:
                            test2[y] = tested[i, y];
                            break;
                        case 2:
                            test3[y] = tested[i, y];
                            break;
                        case 3:
                            test4[y] = tested[i, y];
                            break;
                        case 4:
                            test5[y] = tested[i, y];
                            break;
                        case 5:
                            test6[y] = tested[i, y];
                            break;
                        case 6:
                            test7[y] = tested[i, y];
                            break;
                        case 7:
                            test8[y] = tested[i, y];
                            break;
                        case 8:
                            test9[y] = tested[i, y];
                            break;
                        case 9:
                            test10[y] = tested[i, y];
                            break;
                        case 10:
                            test11[y] = tested[i, y];
                            break;
                        case 11:
                            test12[y] = tested[i, y];
                            break;
                        case 12:
                            test13[y] = tested[i, y];
                            break;
                        case 13:
                            test14[y] = tested[i, y];
                            break;
                        case 14:
                            test15[y] = tested[i, y];
                            break;
                        case 15:
                            test16[y] = tested[i, y];
                            break;
                        case 16:
                            test17[y] = tested[i, y];
                            break;
                        case 17:
                            test18[y] = tested[i, y];
                            break;
                        case 18:
                            test19[y] = tested[i, y];
                            break;
                        case 19:
                            test20[y] = tested[i, y];
                            break;
                    }
                }
            }
            testString1 = String.Join("", test1);
            testString2 = String.Join("", test2);
            testString3 = String.Join("", test3);
            testString4 = String.Join("", test4);
            testString5 = String.Join("", test5);
            testString6 = String.Join("", test6);
            testString7 = String.Join("", test7);
            testString8 = String.Join("", test8);
            testString9 = String.Join("", test9);
            testString10 = String.Join("", test10);
            testString11 = String.Join("", test11);
            testString12 = String.Join("", test12);
            testString13 = String.Join("", test13);
            testString14 = String.Join("", test14);
            testString15 = String.Join("", test15);
            testString16 = String.Join("", test16);
            testString17 = String.Join("", test17);
            testString18 = String.Join("", test18);
            testString19 = String.Join("", test19);
            testString20 = String.Join("", test20);

            return(testString1+testString2+testString3+testString4+testString5+testString6+testString7+testString8+testString9+testString10+testString11+testString12+testString13+testString14+testString15+testString16+testString17+testString18+testString19+testString20) ;
        }
    }
}
