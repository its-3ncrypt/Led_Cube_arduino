using System;

namespace test_code_converter
{
    class Program
    {
        public int[,] test = new int[20, 512];
        public int[,] converted = new int[20, 512];
        void Main(string[] args)
        {


            //code genereren
            for (int i = 0; i < 20; i++)
            {
                for (int y = 0; y < 512; y++)
                {
                    if (y % 2 != 0)
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
         void ConverterFor20()
        {
            for (int n = 0; n < 20; n++)
            {
                for (int p = 0; p < 512; p++)
                {
                    converted[n,p] = ConverterToArduinoCode(test, n);
                }
            }
        }
        private int[] ConverterToArduinoCode(int[,] tested, int choise)
        {
            //temp split variables
            int[] fixeda = new int[512];
            int[] Chosen = new int[512];

            int[] The512 = new int[512];
            //temp split variables right order

            int[] Xed1 = new int[8];
            int[] Xed2 = new int[8];
            int[] Xed3 = new int[8];
            int[] Xed4 = new int[8];
            int[] Xed5 = new int[8];
            int[] Xed6 = new int[8];
            int[] Xed7 = new int[8];
            int[] Xed8 = new int[8];
            int[] Xed9 = new int[8];
            int[] Xed10 = new int[8];
            int[] Xed11 = new int[8];
            int[] Xed12 = new int[8];
            int[] Xed13 = new int[8];
            int[] Xed14 = new int[8];
            int[] Xed15 = new int[8];
            int[] Xed16 = new int[8];
            int[] Xed17 = new int[8];
            int[] Xed18 = new int[8];
            int[] Xed19 = new int[8];
            int[] Xed20 = new int[8];
            int[] Xed21 = new int[8];
            int[] Xed22 = new int[8];
            int[] Xed23 = new int[8];
            int[] Xed24 = new int[8];
            int[] Xed25 = new int[8];
            int[] Xed26 = new int[8];
            int[] Xed27 = new int[8];
            int[] Xed28 = new int[8];
            int[] Xed29 = new int[8];
            int[] Xed30 = new int[8];
            int[] Xed31 = new int[8];
            int[] Xed32 = new int[8];
            int[] Xed33 = new int[8];
            int[] Xed34 = new int[8];
            int[] Xed35 = new int[8];
            int[] Xed36 = new int[8];
            int[] Xed37 = new int[8];
            int[] Xed38 = new int[8];
            int[] Xed39 = new int[8];
            int[] Xed40 = new int[8];
            int[] Xed41 = new int[8];
            int[] Xed42 = new int[8];
            int[] Xed43 = new int[8];
            int[] Xed44 = new int[8];
            int[] Xed45 = new int[8];
            int[] Xed46 = new int[8];
            int[] Xed47 = new int[8];
            int[] Xed48 = new int[8];
            int[] Xed49 = new int[8];
            int[] Xed50 = new int[8];
            int[] Xed51 = new int[8];
            int[] Xed52 = new int[8];
            int[] Xed53 = new int[8];
            int[] Xed54 = new int[8];
            int[] Xed55 = new int[8];
            int[] Xed56 = new int[8];
            int[] Xed57 = new int[8];
            int[] Xed58 = new int[8];
            int[] Xed59 = new int[8];
            int[] Xed60 = new int[8];
            int[] Xed61 = new int[8];
            int[] Xed62 = new int[8];
            int[] Xed63 = new int[8];
            int[] Xed64 = new int[8];

            //splitting tweedimensionale int
            for (int y = 0; y < 512; y++)
            {
                The512[y] = tested[choise, y];
            }

            //Xed Codes maken (Y as van code verzetten in X as voor arduino)
            int counted = 0;
            //eerste rooster
            for (int i = 0; i < 8; i++)
            {
                Xed1[i] = The512[i * 8 +counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed2[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed3[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed4[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed5[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed6[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed7[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed8[i] = The512[i * 8 + counted];
            }
            counted++;
            //2e rooster
            for (int i = 0; i < 8; i++)
            {
                Xed9[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed10[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed11[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed12[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed13[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed14[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed15[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed16[i] = The512[i * 8 + counted];
            }
            counted++;
            //3e rooster
            for (int i = 0; i < 8; i++)
            {
                Xed17[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed18[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed19[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed20[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed21[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed22[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed23[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed24[i] = The512[i * 8 + counted];
            }
            counted++;
            //4e rooster
            for (int i = 0; i < 8; i++)
            {
                Xed25[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed26[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed27[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed28[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed29[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed30[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed31[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed32[i] = The512[i * 8 + counted];
            }
            counted++;
            //5e rooster
            for (int i = 0; i < 8; i++)
            {
                Xed33[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed34[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed35[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed36[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed37[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed38[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed39[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed40[i] = The512[i * 8 + counted];
            }
            counted++;
            //6e rooster
            for (int i = 0; i < 8; i++)
            {
                Xed41[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed42[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed43[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed44[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed45[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed46[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed47[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed48[i] = The512[i * 8 + counted];
            }
            counted++;
            //7e rooster
            for (int i = 0; i < 8; i++)
            {
                Xed49[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed50[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed51[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed52[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed53[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed54[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed55[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed56[i] = The512[i * 8 + counted];
            }
            //8e rooster
            for (int i = 0; i < 8; i++)
            {
                Xed57[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed58[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed59[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed60[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed61[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed62[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed63[i] = The512[i * 8 + counted];
            }
            counted++;
            for (int i = 0; i < 8; i++)
            {
                Xed64[i] = The512[i * 8 + counted];
            }


            //code terug volledig maken naar 512 (Alle Xed's samenvoegen)
            int countsamen = 0;
            for(int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed1[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed2[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed3[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed4[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed5[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed6[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed7[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed8 [i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed9[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed10[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed11[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed12[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed13[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed14[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed15[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed16[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed17[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed18[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed19[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed20[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed21[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed22[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed23[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed24[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed25[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed26[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed27[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed28[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed29[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed30[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed31[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed32[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed33[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed34[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed35[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed36[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed37[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed38[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed39[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed40[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed41[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed42[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed43[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed44[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed45[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed46[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed47[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed48[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed49[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed50[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed51[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed52[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed53[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed54[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed55[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed56[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed57[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed58[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed59[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed60[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed61[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed62[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed63[i];
            }
            countsamen++;
            for (int i = 0; i < 8; i++)
            {
                fixeda[countsamen * 8 + i] = Xed64[i];
            }
            countsamen++;

            return fixeda;

        }
        //resultaten uitprinten
        private static string Printout(int[,] tested)
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
                for (int y = 0; y < 512; y++)
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

            return (testString1 + testString2 + testString3 + testString4 + testString5 + testString6 + testString7 + testString8 + testString9 + testString10 + testString11 + testString12 + testString13 + testString14 + testString15 + testString16 + testString17 + testString18 + testString19 + testString20);
        }
    }
}
