using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace Aansturingsprogramma
{

    public partial class Form1 : Form
    {
        //main codes
        bool isConnected = false;
        String[] ports;
        SerialPort port;
        bool Ledraster1 = true;
        bool Ledraster2 = false;
        bool Ledraster3 = false;
        bool Ledraster4 = false;
        bool Ledraster5 = false;
        bool Ledraster6 = false;
        bool Ledraster7 = false;
        bool IsFrozen = false;
        string sentCode;
        int[,] ledGen = new int[20,512];
        int EffectNumber = 0;
        int Snelheid = 2;
        int Para1 = 0;
        int Para2 = 0;
        int Slide = 1;
        int Frame = 0;
        bool ThereArePorts = false;
        bool[] IsSet = new bool[19];

        public Form1()
        {
            InitializeComponent();
            //disableControls();
            getAvailableComPorts();
            EmptyCode(0);
            //poorten zichtbaar maken
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                    ThereArePorts = true;
                }
                else
                {
                    ThereArePorts = false;
                }
            }
        }
        //calculate how many frames
        private void SetIsSet()
        {
            for(int i = 1; i <= 19; i++)
            {
                IsSet[i] = false;
            }
        }
        //alle poorten opzoeken
        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        //code leeg genereren voor 2dimensionale array
        private void EmptyCode(int slida)
        {
            for(int i = 0; i < 512; i++)
            {
                ledGen[slida, i] = 0;
            }
        }

        //lock zetten op alle knoppen voor het verbinden
        private void disableControls()
        {
            //alle boxes disabelen
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox7.Enabled = false;
            checkBox6.Enabled = false;
            checkBox8.Enabled = false;
            checkBox9.Enabled = false;
            checkBox10.Enabled = false;
            checkBox11.Enabled = false;
            checkBox13.Enabled = false;
            checkBox14.Enabled = false;
            checkBox15.Enabled = false;
            checkBox16.Enabled = false;
            checkBox17.Enabled = false;
            checkBox18.Enabled = false;
            checkBox19.Enabled = false;
            checkBox20.Enabled = false;
            checkBox21.Enabled = false;
            checkBox22.Enabled = false;
            checkBox23.Enabled = false;
            checkBox24.Enabled = false;
            checkBox25.Enabled = false;
            checkBox26.Enabled = false;
            checkBox27.Enabled = false;
            checkBox28.Enabled = false;
            checkBox29.Enabled = false;
            checkBox30.Enabled = false;
            checkBox31.Enabled = false;
            checkBox32.Enabled = false;
            checkBox33.Enabled = false;
            checkBox34.Enabled = false;
            checkBox35.Enabled = false;
            checkBox36.Enabled = false;
            checkBox37.Enabled = false;
            checkBox38.Enabled = false;
            checkBox39.Enabled = false;
            checkBox40.Enabled = false;
            checkBox43.Enabled = false;
            checkBox44.Enabled = false;
            checkBox45.Enabled = false;
            checkBox46.Enabled = false;
            checkBox47.Enabled = false;
            checkBox48.Enabled = false;
            checkBox49.Enabled = false;
            checkBox50.Enabled = false;
            checkBox73.Enabled = false;
            checkBox74.Enabled = false;
            checkBox75.Enabled = false;
            checkBox76.Enabled = false;
            checkBox77.Enabled = false;
            checkBox78.Enabled = false;
            checkBox79.Enabled = false;
            checkBox80.Enabled = false;
            checkBox83.Enabled = false;
            checkBox84.Enabled = false;
            checkBox85.Enabled = false;
            checkBox86.Enabled = false;
            checkBox87.Enabled = false;
            checkBox88.Enabled = false;
            checkBox89.Enabled = false;
            checkBox90.Enabled = false;
            checkBox93.Enabled = false;
            checkBox94.Enabled = false;
            checkBox95.Enabled = false;
            checkBox96.Enabled = false;
            checkBox97.Enabled = false;
            checkBox98.Enabled = false;
            checkBox99.Enabled = false;
            checkBox12.Enabled = false;
            checkBox8.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            checkBox100.Enabled = false;
        }

        //unlock zetten op alle knoppen voor het verbinden
        private void enableControls()
        {
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;
            checkBox5.Enabled = true;
            checkBox6.Enabled = true;
            checkBox8.Enabled = true;
            checkBox9.Enabled = true;
            checkBox10.Enabled = true;
            checkBox12.Enabled = true;
            checkBox11.Enabled = true;
            checkBox13.Enabled = true;
            checkBox14.Enabled = true;
            checkBox15.Enabled = true;
            checkBox16.Enabled = true;
            checkBox17.Enabled = true;
            checkBox18.Enabled = true;
            checkBox19.Enabled = true;
            checkBox20.Enabled = true;
            checkBox21.Enabled = true;
            checkBox22.Enabled = true;
            checkBox23.Enabled = true;
            checkBox24.Enabled = true;
            checkBox25.Enabled = true;
            checkBox26.Enabled = true;
            checkBox27.Enabled = true;
            checkBox28.Enabled = true;
            checkBox29.Enabled = true;
            checkBox30.Enabled = true;
            checkBox31.Enabled = true;
            checkBox32.Enabled = true;
            checkBox33.Enabled = true;
            checkBox34.Enabled = true;
            checkBox35.Enabled = true;
            checkBox36.Enabled = true;
            checkBox37.Enabled = true;
            checkBox38.Enabled = true;
            checkBox39.Enabled = true;
            checkBox40.Enabled = true;
            checkBox43.Enabled = true;
            checkBox44.Enabled = true;
            checkBox45.Enabled = true;
            checkBox46.Enabled = true;
            checkBox47.Enabled = true;
            checkBox48.Enabled = true;
            checkBox49.Enabled = true;
            checkBox50.Enabled = true;
            checkBox73.Enabled = true;
            checkBox74.Enabled = true;
            checkBox75.Enabled = true;
            checkBox76.Enabled = true;
            checkBox77.Enabled = true;
            checkBox78.Enabled = true;
            checkBox79.Enabled = true;
            checkBox80.Enabled = true;
            checkBox83.Enabled = true;
            checkBox84.Enabled = true;
            checkBox85.Enabled = true;
            checkBox86.Enabled = true;
            checkBox87.Enabled = true;
            checkBox88.Enabled = true;
            checkBox89.Enabled = true;
            checkBox90.Enabled = true;
            checkBox93.Enabled = true;
            checkBox94.Enabled = true;
            checkBox95.Enabled = true;
            checkBox96.Enabled = true;
            checkBox97.Enabled = true;
            checkBox98.Enabled = true;
            checkBox99.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown4.Enabled = true;
            numericUpDown5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            checkBox7.Enabled = true;
            checkBox100.Enabled = true;
        }

        private void connectToArduino()
        {
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (ThereArePorts == true)
            {
                isConnected = true;
                port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.Write("#STAR\n");
                button3.Text = "Disconnect";
                enableControls();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /////////////////////////////////////////////////////////////////////////////////
        //eerst verbinding maken
        //dan code uploaden
        /////////////////////////////////////////////////////////////////////////////////
 

        //Effecten
        private void Effecten_Click(object sender, EventArgs e)
        {
            //leeg laten
        }
        //Generator
        private void Generator_Click(object sender, EventArgs e)
        {
            //leeg laten
        }
        //Simpele naam Effecten
        private void label1_Click(object sender, EventArgs e)
        {
            //leeg laten
        }        
        //effect 1
        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox32.Checked)
            {
                if (checkBox31.Checked)
                {
                    checkBox31.Checked = false;
                }
                if (checkBox22.Checked)
                {
                    checkBox22.Checked = false;
                }
                if (checkBox21.Checked)
                {
                    checkBox21.Checked = false;
                }
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
            }
            set_Effect_Status();
        }
        //effect 2
        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked)
            {
                if (checkBox32.Checked)
                {
                    checkBox32.Checked = false;
                }
                if (checkBox22.Checked)
                {
                    checkBox22.Checked = false;
                }
                if (checkBox21.Checked)
                {
                    checkBox21.Checked = false;
                }
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
            }
            set_Effect_Status();
        }
        //effect 3
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
            {
                if (checkBox31.Checked)
                {
                    checkBox31.Checked = false;
                }
                if (checkBox32.Checked)
                {
                    checkBox32.Checked = false;
                }
                if (checkBox21.Checked)
                {
                    checkBox21.Checked = false;
                }
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
            }
            set_Effect_Status();
        }
        //effect 4
        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
            {
                if (checkBox31.Checked)
                {
                    checkBox31.Checked = false;
                }
                if (checkBox22.Checked)
                {
                    checkBox22.Checked = false;
                }
                if (checkBox32.Checked)
                {
                    checkBox32.Checked = false;
                }
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
            }
            set_Effect_Status();
        }
        //effect 5
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                if (checkBox31.Checked)
                {
                    checkBox31.Checked = false;
                }
                if (checkBox22.Checked)
                {
                    checkBox22.Checked = false;
                }
                if (checkBox21.Checked)
                {
                    checkBox21.Checked = false;
                }
                if (checkBox32.Checked)
                {
                    checkBox32.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
            }
            set_Effect_Status();
        }
        //Effect 6
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                if (checkBox31.Checked)
                {
                    checkBox31.Checked = false;
                }
                if (checkBox22.Checked)
                {
                    checkBox22.Checked = false;
                }
                if (checkBox21.Checked)
                {
                    checkBox21.Checked = false;
                }
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox32.Checked)
                {
                    checkBox32.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
            }
            set_Effect_Status();
        }
        //Effect 7
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                if (checkBox31.Checked)
                {
                    checkBox31.Checked = false;
                }
                if (checkBox22.Checked)
                {
                    checkBox22.Checked = false;
                }
                if (checkBox21.Checked)
                {
                    checkBox21.Checked = false;
                }
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox32.Checked)
                {
                    checkBox32.Checked = false;
                }
                if (checkBox7.Checked)
                {
                    checkBox7.Checked = false;
                }
            }
            set_Effect_Status();

        }
        //effect 8
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                if (checkBox31.Checked)
                {
                    checkBox31.Checked = false;
                }
                if (checkBox22.Checked)
                {
                    checkBox22.Checked = false;
                }
                if (checkBox21.Checked)
                {
                    checkBox21.Checked = false;
                }
                if (checkBox12.Checked)
                {
                    checkBox12.Checked = false;
                }
                if (checkBox11.Checked)
                {
                    checkBox11.Checked = false;
                }
                if (checkBox8.Checked)
                {
                    checkBox8.Checked = false;
                }
                if (checkBox32.Checked)
                {
                    checkBox32.Checked = false;
                }
            }
            set_Effect_Status();

        }
        //effect nummer genereren
        private void set_Effect_Status()
        {
            if (checkBox7.Checked)
            {
                EffectNumber = 1;
            }
            if (checkBox31.Checked)
            {
                EffectNumber = 2;
            }
            if (checkBox22.Checked)
            {
                EffectNumber = 3;
            }
            if (checkBox21.Checked)
            {
                EffectNumber = 4;
            }
            if (checkBox12.Checked)
            {
                EffectNumber = 5;
            }
            if (checkBox11.Checked)
            {
                EffectNumber = 6;
            }
            if (checkBox8.Checked)
            {
                EffectNumber = 7;
            }
            if (checkBox32.Checked)
            {
                EffectNumber = 8;
            }
            else
            {
                EffectNumber = 0;
            }

        }
        //snelheid naam
        private void label2_Click(object sender, EventArgs e)
        {
            //leeg laten
        }
        //snelheid nummer
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Snelheid = Convert.ToInt32(numericUpDown1.Value);
        }
        //effect parameter 1
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Para1 = Convert.ToInt32(numericUpDown2.Value);
        }
        //effect parameter 2
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Para2 = Convert.ToInt32(numericUpDown3.Value);
        }
        //upload button effecten
        private void button1_Click(object sender, EventArgs e)
        {
            Upload();
        }


        //Upload algoritme
        private void Upload()
        {
            if (isConnected)
            {
                if(EffectNumber==0)
                {
                    port.Write(Convert.ToString(Snelheid));
                    port.Write(Convert.ToString(EffectNumber));
                    for (int i = 0; i <= 19; i++)
                    {
                        if (IsSet[i] == false)
                        {
                            break;
                        }
                        else
                        {
                            for (int y = 0; y < 512; y++)
                            {
                                sentCode += Convert.ToString(ledGen[i, y]);
                            }
                        }
                    }
                    port.Write(sentCode);
                    
                }
                else
                {
                    port.Write(Convert.ToString(Snelheid));
                    port.Write(Convert.ToString(EffectNumber));
                }
                port.Write("\n");
            }
        }

        ///effect generators
        //frame parameters
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Frame = Convert.ToInt32(numericUpDown4.Value);
            GeneratorShowBox();
            switch (Frame)
            {
                case 0:
                    if (IsSet[0] == false)
                    {
                        EmptyCode(0);
                        IsSet[0] = true;
                    }
                    break;
                case 1:
                    if (IsSet[1] == false)
                    {
                        EmptyCode(1);
                        IsSet[1] = true;
                    }
                    break;
                case 2:
                    if (IsSet[2] == false)
                    {
                        EmptyCode(2);
                        IsSet[2] = true;
                    }
                    break;
                case 3:
                    if (IsSet[3] == false)
                    {
                        EmptyCode(3);
                        IsSet[3] = true;
                    }
                    break;
                case 4:
                    if (IsSet[4] == false)
                    {
                        EmptyCode(4);
                        IsSet[4] = true;
                    }
                    break;
                case 5:
                    if (IsSet[5] == false)
                    {
                        EmptyCode(5);
                        IsSet[5] = true;
                    }
                    break;
                case 6:
                    if (IsSet[6] == false)
                    {
                        EmptyCode(6);
                        IsSet[6] = true;
                    }
                    break;
                case 7:
                    if (IsSet[7] == false)
                    {
                        EmptyCode(7);
                        IsSet[7] = true;
                    }
                    break;
                case 8:
                    if (IsSet[8] == false)
                    {
                        EmptyCode(8);
                        IsSet[8] = true;
                    }
                    break;
                case 9:
                    if (IsSet[9] == false)
                    {
                        EmptyCode(9);
                        IsSet[9] = true;
                    }
                    break;
                case 10:
                    if (IsSet[10] == false)
                    {
                        EmptyCode(10);
                        IsSet[10] = true;
                    }
                    break;
                case 11:
                    if (IsSet[11] == false)
                    {
                        EmptyCode(11);
                        IsSet[11] = true;
                    }
                    break;
                case 12:
                    if (IsSet[12] == false)
                    {
                        EmptyCode(12);
                        IsSet[12] = true;
                    }
                    break;
                case 13:
                    if (IsSet[13] == false)
                    {
                        EmptyCode(13);
                        IsSet[13] = true;
                    }
                    break;
                case 14:
                    if (IsSet[14] == false)
                    {
                        EmptyCode(14);
                        IsSet[14] = true;
                    }
                    break;
                case 15:
                    if (IsSet[15] == false)
                    {
                        EmptyCode(15);
                        IsSet[15] = true;
                    }
                    break;
                case 16:
                    if (IsSet[16] == false)
                    {
                        EmptyCode(16);
                        IsSet[16] = true;
                    }
                    break;
                case 17:
                    if (IsSet[17] == false)
                    {
                        EmptyCode(17);
                        IsSet[17] = true;
                    }
                    break;
                case 18:
                    if (IsSet[18] == false)
                    {
                        EmptyCode(18);
                        IsSet[18] = true;
                    }
                    break;
                case 19:
                    if (IsSet[19] == false)
                    {
                        EmptyCode(19);
                        IsSet[19] = true;
                    }
                    break;
            }

        }



        //LEEEEDS////////////
        //led 1
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox1.Checked==true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame,0] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame,64] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame,128] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame,192] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame,256] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 320] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 384] = 1;
                }
                else
                {
                    ledGen[Frame, 448] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 0] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 64] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 128] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 192] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 256] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 320] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 384] = 0;
                }
                else
                {
                    ledGen[Frame, 448] = 0;
                }
            }
        }
        //led 2
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox2.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 1] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 65] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 129] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 193] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 257] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 321] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 385] = 1;
                }
                else
                {
                    ledGen[Frame, 449] = 1;
                }
            }
            else
            {
                if (checkBox2.Checked == false)
                {
                    if (Ledraster1 == true)
                    {
                        ledGen[Frame, 1] = 0;
                    }
                    else if (Ledraster2 == true)
                    {
                        ledGen[Frame, 65] = 0;
                    }
                    else if (Ledraster3 == true)
                    {
                        ledGen[Frame, 129] = 0;
                    }
                    else if (Ledraster4 == true)
                    {
                        ledGen[Frame, 193] = 0;
                    }
                    else if (Ledraster5 == true)
                    {
                        ledGen[Frame, 257] = 0;
                    }
                    else if (Ledraster6 == true)
                    {
                        ledGen[Frame, 321] = 0;
                    }
                    else if (Ledraster7 == true)
                    {
                        ledGen[Frame, 385] = 0;
                    }
                    else
                    {
                        ledGen[Frame, 449] = 0;
                    }
                }
            }
        }
        //led 3
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox4.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 2] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 66] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 130] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 194] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 258] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 322] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 386] = 1;
                }
                else
                {
                    ledGen[Frame, 450] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 2] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 66] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 130] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 194] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 258] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 322] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 386] = 0;
                }
                else
                {
                    ledGen[Frame, 450] = 0;
                }
            }
        }
        //led 4
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox3.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 3] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 67] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 131] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 195] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 259] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 323] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 387] = 1;
                }
                else
                {
                    ledGen[Frame, 451] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 3] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 67] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 131] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 195] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 259] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 323] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 387] = 0;
                }
                else
                {
                    ledGen[Frame, 451] = 0;
                }
            }
        }
        //led 5
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox6.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 4] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 68] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 132] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 196] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 260] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 324] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 388] = 1;
                }
                else
                {
                    ledGen[Frame, 452] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 4] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 68] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 132] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 196] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 260] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 324] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 388] = 0;
                }
                else
                {
                    ledGen[Frame, 452] = 0;
                }
            }
        }
        //led 6
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox5.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 5] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 69] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 133] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 197] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 261] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 325] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 389] = 1;
                }
                else
                {
                    ledGen[Frame, 453] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 5] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 69] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 133] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 197] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 261] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 325] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 389] = 0;
                }
                else
                {
                    ledGen[Frame, 453] = 0;
                }
            }
        }
        //led 7
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox10.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 6] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 70] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 134] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 198] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 262] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 326] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 390] = 1;
                }
                else
                {
                    ledGen[Frame, 454] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 6] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 70] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 134] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 198] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 262] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 326] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 390] = 0;
                }
                else
                {
                    ledGen[Frame, 454] = 0;
                }
            }
        }
        //led 8
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox9.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 7] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 71] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 135] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 199] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 263] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 327] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 391] = 1;
                }
                else
                {
                    ledGen[Frame, 455] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 7] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 71] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 135] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 199] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 263] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 327] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 391] = 0;
                }
                else
                {
                    ledGen[Frame, 455] = 0;
                }
            }
        }
        //led 9
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox20.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 8] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 72] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 136] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 200] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 264] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 328] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 392] = 1;
                }
                else
                {
                    ledGen[Frame, 456] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 8] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 72] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 136] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 200] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 264] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 328] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 392] = 0;
                }
                else
                {
                    ledGen[Frame, 456] = 0;
                }
            }

        }
        //led 10
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox19.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 9] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 73] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 137] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 201] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 265] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 329] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 393] = 1;
                }
                else
                {
                    ledGen[Frame, 457] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 9] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 73] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 137] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 201] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 265] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 329] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 393] = 0;
                }
                else
                {
                    ledGen[Frame, 457] = 0;
                }
            }
        }
        //led 11
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox18.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 10] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 74] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 138] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 202] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 266] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 330] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 394] = 1;
                }
                else
                {
                    ledGen[Frame, 458] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 10] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 74] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 138] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 202] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 266] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 330] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 394] = 0;
                }
                else
                {
                    ledGen[Frame, 458] = 0;
                }
            }
        }
        //led 12
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox17.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 11] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 75] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 139] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 203] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 267] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 331] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 395] = 1;
                }
                else
                {
                    ledGen[Frame, 459] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 11] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 75] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 139] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 203] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 267] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 331] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 395] = 0;
                }
                else
                {
                    ledGen[Frame, 459] = 0;
                }
            }
        }
        //led 13
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox16.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 12] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 76] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 140] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 204] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 268] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 332] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 396] = 1;
                }
                else
                {
                    ledGen[Frame, 460] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 12] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 76] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 140] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 204] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 268] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 332] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 396] = 0;
                }
                else
                {
                    ledGen[Frame, 460] = 0;
                }
            }
        }
        //led 14
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox15.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 13] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 77] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 141] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 205] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 269] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 333] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 397] = 1;
                }
                else
                {
                    ledGen[Frame, 461] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 13] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 77] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 141] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 205] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 269] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 333] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 397] = 0;
                }
                else
                {
                    ledGen[Frame, 461] = 0;
                }
            }
        }
        //led 15
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox14.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 14] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 78] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 142] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 206] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 270] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 334] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 398] = 1;
                }
                else
                {
                    ledGen[Frame, 462] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 14] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 78] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 142] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 206] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 270] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 334] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 398] = 0;
                }
                else
                {
                    ledGen[Frame, 462] = 0;
                }
            }
        }
        //led 16
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox13.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 15] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 79] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 143] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 207] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 271] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 335] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 399] = 1;
                }
                else
                {
                    ledGen[Frame, 463] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 15] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 79] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 143] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 207] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 271] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 335] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 399] = 0;
                }
                else
                {
                    ledGen[Frame, 463] = 0;
                }
            }
        }
        //led 17
        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox30.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 16] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 80] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 144] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 208] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 272] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 336] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 400] = 1;
                }
                else
                {
                    ledGen[Frame, 464] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 16] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 80] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 144] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 208] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 272] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 336] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 400] = 0;
                }
                else
                {
                    ledGen[Frame, 464] = 0;
                }
            }
        }
        //led 18
        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox29.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 17] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 81] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 145] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 209] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 273] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 337] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 401] = 1;
                }
                else
                {
                    ledGen[Frame, 465] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 17] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 81] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 145] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 209] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 273] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 337] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 401] = 0;
                }
                else
                {
                    ledGen[Frame, 465] = 0;
                }
            }
        }
        //led 19
        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox28.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 18] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 82] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 146] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 210] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 274] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 338] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 402] = 1;
                }
                else
                {
                    ledGen[Frame, 466] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 18] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 82] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 146] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 210] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 274] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 338] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 402] = 0;
                }
                else
                {
                    ledGen[Frame, 466] = 0;
                }
            }
        }
        //led 20
        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox27.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 19] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 83] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 147] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 211] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 275] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 339] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 403] = 1;
                }
                else
                {
                    ledGen[Frame, 467] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 19] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 83] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 147] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 211] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 275] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 339] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 403] = 0;
                }
                else
                {
                    ledGen[Frame, 467] = 0;
                }
            }
        }
        //led 21
        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox26.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 20] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 84] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 148] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 212] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 276] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 340] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 404] = 1;
                }
                else
                {
                    ledGen[Frame, 468] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 20] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 84] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 148] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 212] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 276] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 340] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 404] = 0;
                }
                else
                {
                    ledGen[Frame, 467] = 0;
                }
            }
        }
        //led 22
        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox25.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 21] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 85] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 149] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 213] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 277] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 341] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 405] = 1;
                }
                else
                {
                    ledGen[Frame, 469] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 21] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 85] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 149] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 213] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 277] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 341] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 405] = 0;
                }
                else
                {
                    ledGen[Frame, 469] = 0;
                }
            }
        }
        //led 23
        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox24.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 22] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 86] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 150] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 214] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 278] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 342] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 406] = 1;
                }
                else
                {
                    ledGen[Frame, 470] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 22] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 86] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 150] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 214] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 278] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 342] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 406] = 0;
                }
                else
                {
                    ledGen[Frame, 470] = 0;
                }
            }
        }
        //led 24
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox23.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 23] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 87] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 151] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 215] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 279] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 343] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 407] = 1;
                }
                else
                {
                    ledGen[Frame, 471] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 23] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 87] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 151] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 215] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 279] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 343] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 407] = 0;
                }
                else
                {
                    ledGen[Frame, 471] = 0;
                }
            }
        }
        //led 25
        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox40.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 24] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 88] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 152] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 216] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 280] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 344] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 408] = 1;
                }
                else
                {
                    ledGen[Frame, 472] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 24] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 88] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 152] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 216] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 280] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 344] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 408] = 0;
                }
                else
                {
                    ledGen[Frame, 472] = 0;
                }
            }
        }
        //led 26
        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox39.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 25] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 89] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 153] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 217] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 281] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 345] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 409] = 1;
                }
                else
                {
                    ledGen[Frame, 473] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 25] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 89] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 153] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 217] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 281] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 345] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 409] = 0;
                }
                else
                {
                    ledGen[Frame, 473] = 0;
                }
            }
        }
        //led 27
        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox38.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 26] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 90] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 154] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 218] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 282] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 346] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 410] = 1;
                }
                else
                {
                    ledGen[Frame, 474] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 26] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 90] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 154] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 218] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 282] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 346] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 410] = 0;
                }
                else
                {
                    ledGen[Frame, 474] = 0;
                }
            }
        }
        //led 28
        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox37.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 27] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 91] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 155] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 219] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 283] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 347] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 411] = 1;
                }
                else
                {
                    ledGen[Frame, 475] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 27] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 91] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 155] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 219] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 283] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 347] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 411] = 0;
                }
                else
                {
                    ledGen[Frame, 475] = 0;
                }
            }
        }
        //led 29
        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox36.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 28] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 92] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 156] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 220] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 284] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 348] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 412] = 1;
                }
                else
                {
                    ledGen[Frame, 476] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 28] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 92] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 156] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 220] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 284] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 348] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 412] = 0;
                }
                else
                {
                    ledGen[Frame, 476] = 0;
                }
            }
        }
        //led 30
        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox35.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 29] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 93] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 157] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 221] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 285] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 349] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 413] = 1;
                }
                else
                {
                    ledGen[Frame, 477] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 29] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 93] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 157] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 221] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 285] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 349] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 413] = 0;
                }
                else
                {
                    ledGen[Frame, 477] = 0;
                }
            }
        }
        //led 31
        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox34.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 30] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 94] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 158] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 222] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 286] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 350] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 414] = 1;
                }
                else
                {
                    ledGen[Frame, 478] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 30] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 94] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 158] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 222] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 286] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 350] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 414] = 0;
                }
                else
                {
                    ledGen[Frame, 478] = 0;
                }
            }
        }
        //led 32
        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox33.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 31] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 95] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 159] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 223] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 287] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 351] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 415] = 1;
                }
                else
                {
                    ledGen[Frame, 479] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 31] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 95] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 159] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 223] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 287] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 351] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 415] = 0;
                }
                else
                {
                    ledGen[Frame, 479] = 0;
                }
            }
        }
        //led 33
        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox50.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 32] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 96] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 160] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 224] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 288] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 352] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 416] = 1;
                }
                else
                {
                    ledGen[Frame, 480] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 32] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 96] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 160] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 224] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 288] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 352] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 416] = 0;
                }
                else
                {
                    ledGen[Frame, 480] = 0;
                }
            }
        }
        //led 34
        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox49.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 33] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 97] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 161] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 225] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 289] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 353] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 417] = 1;
                }
                else
                {
                    ledGen[Frame, 481] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 33] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 97] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 161] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 225] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 289] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 353] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 417] = 0;
                }
                else
                {
                    ledGen[Frame, 481] = 0;
                }
            }
        }
        //led 35
        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox48.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 34] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 98] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 162] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 226] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 290] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 354] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 418] = 1;
                }
                else
                {
                    ledGen[Frame, 482] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 34] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 98] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 162] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 226] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 290] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 354] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 418] = 0;
                }
                else
                {
                    ledGen[Frame, 482] = 0;
                }
            }
        }
        //led 36
        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox47.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 35] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 99] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 163] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 227] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 291] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 355] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 419] = 1;
                }
                else
                {
                    ledGen[Frame, 483] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 35] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 99] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 163] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 227] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 291] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 355] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 419] = 0;
                }
                else
                {
                    ledGen[Frame, 483] = 0;
                }
            }
        }
        //led 37
        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox46.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 36] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 100] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 164] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 228] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 292] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 356] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 420] = 1;
                }
                else
                {
                    ledGen[Frame, 484] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 36] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 100] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 164] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 228] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 292] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 356] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 420] = 0;
                }
                else
                {
                    ledGen[Frame, 484] = 0;
                }
            }
        }
        //led 38
        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox45.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 37] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 101] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 165] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 229] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 293] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 357] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 421] = 1;
                }
                else
                {
                    ledGen[Frame, 485] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 37] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 101] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 165] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 229] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 293] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 357] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 421] = 0;
                }
                else
                {
                    ledGen[Frame, 485] = 0;
                }
            }
        }
        //led 39
        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox44.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 38] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 102] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 166] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 230] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 294] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 358] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 422] = 1;
                }
                else
                {
                    ledGen[Frame, 486] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 38] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 102] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 166] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 230] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 294] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 358] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 422] = 0;
                }
                else
                {
                    ledGen[Frame, 486] = 0;
                }
            }
        }
        //led 40
        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox43.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 39] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 103] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 167] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 231] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 295] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 359] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 423] = 1;
                }
                else
                {
                    ledGen[Frame, 487] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 39] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 103] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 167] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 231] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 295] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 359] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 423] = 0;
                }
                else
                {
                    ledGen[Frame, 487] = 0;
                }
            }
        }
        //led 41
        private void checkBox100_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox100.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 40] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 104] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 168] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 232] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 296] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 360] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 424] = 1;
                }
                else
                {
                    ledGen[Frame, 488] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 40] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 104] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 168] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 232] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 296] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 360] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 424] = 0;
                }
                else
                {
                    ledGen[Frame, 488] = 0;
                }
            }
        }
        //led 42
        private void checkBox99_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox99.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 41] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 105] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 169] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 233] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 297] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 361] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 425] = 1;
                }
                else
                {
                    ledGen[Frame, 489] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 41] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 105] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 169] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 233] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 297] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 361] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 425] = 0;
                }
                else
                {
                    ledGen[Frame, 489] = 0;
                }
            }
        }
        //led 43
        private void checkBox98_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox98.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 42] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 106] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 170] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 234] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 298] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 362] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 426] = 1;
                }
                else
                {
                    ledGen[Frame, 490] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 42] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 106] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 170] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 234] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 298] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 362] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 426] = 0;
                }
                else
                {
                    ledGen[Frame, 490] = 0;
                }
            }
        }
        //led 44
        private void checkBox97_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox97.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 43] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 107] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 171] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 235] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 299] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 363] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 427] = 1;
                }
                else
                {
                    ledGen[Frame, 491] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 43] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 107] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 171] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 235] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 299] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 363] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 427] = 0;
                }
                else
                {
                    ledGen[Frame, 491] = 0;
                }
            }
        }
        //led 45
        private void checkBox96_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox96.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 44] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 108] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 172] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 236] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 300] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 364] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 428] = 1;
                }
                else
                {
                    ledGen[Frame, 492] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 44] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 108] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 172] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 236] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 300] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 364] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 428] = 0;
                }
                else
                {
                    ledGen[Frame, 492] = 0;
                }
            }
        }
        //led 46
        private void checkBox95_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox95.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 45] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 109] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 173] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 237] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 301] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 365] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 429] = 1;
                }
                else
                {
                    ledGen[Frame, 493] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 45] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 109] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 173] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 237] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 301] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 365] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 429] = 0;
                }
                else
                {
                    ledGen[Frame, 493] = 0;
                }
            }
        }
        //led 47
        private void checkBox94_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox94.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 46] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 110] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 174] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 238] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 302] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 366] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 430] = 1;
                }
                else
                {
                    ledGen[Frame, 494] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 46] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 110] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 174] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 238] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 302] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 366] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 430] = 0;
                }
                else
                {
                    ledGen[Frame, 494] = 0;
                }
            }
        }
        //led 48
        private void checkBox93_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox93.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 47] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 111] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 175] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 239] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 303] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 367] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 431] = 1;
                }
                else
                {
                    ledGen[Frame, 495] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 47] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 111] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 175] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 239] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 303] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 367] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 431] = 0;
                }
                else
                {
                    ledGen[Frame, 495] = 0;
                }
            }
        }
        //led 49
        private void checkBox90_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox90.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 48] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 112] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 176] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 240] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 304] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 368] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 432] = 1;
                }
                else
                {
                    ledGen[Frame, 496] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 48] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 112] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 176] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 240] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 304] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 368] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 432] = 0;
                }
                else
                {
                    ledGen[Frame, 496] = 0;
                }
            }
        }
        //led 50
        private void checkBox89_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox89.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 49] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 113] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 177] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 241] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 305] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 369] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 433] = 1;
                }
                else
                {
                    ledGen[Frame, 497] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 49] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 113] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 177] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 241] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 305] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 369] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 433] = 0;
                }
                else
                {
                    ledGen[Frame, 497] = 0;
                }
            }
        }
        //led 51
        private void checkBox88_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox88.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 50] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 114] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 178] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 242] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 306] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 370] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 434] = 1;
                }
                else
                {
                    ledGen[Frame, 498] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 50] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 114] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 178] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 242] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 306] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 370] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 434] = 0;
                }
                else
                {
                    ledGen[Frame, 498] = 0;
                }
            }
        }
        //led 52
        private void checkBox87_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox87.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 51] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 115] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 179] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 243] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 307] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 371] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 435] = 1;
                }
                else
                {
                    ledGen[Frame, 499] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 51] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 115] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 179] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 243] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 307] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 371] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 435] = 0;
                }
                else
                {
                    ledGen[Frame, 499] = 0;
                }
            }
        }
        //led 53
        private void checkBox86_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox86.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 52] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 116] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 180] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 244] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 308] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 372] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 436] = 1;
                }
                else
                {
                    ledGen[Frame, 500] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 52] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 116] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 180] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 244] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 308] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 372] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 436] = 0;
                }
                else
                {
                    ledGen[Frame, 500] = 0;
                }
            }
        }
        //led 54
        private void checkBox85_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox85.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 53] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 117] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 181] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 245] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 309] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 373] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 437] = 1;
                }
                else
                {
                    ledGen[Frame, 501] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 53] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 117] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 181] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 245] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 309] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 373] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 437] = 0;
                }
                else
                {
                    ledGen[Frame, 501] = 0;
                }
            }
        }
        //led 55
        private void checkBox84_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox84.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 54] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 118] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 182] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 246] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 310] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 374] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 438] = 1;
                }
                else
                {
                    ledGen[Frame, 502] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 54] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 118] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 182] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 246] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 310] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 374] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 438] = 0;
                }
                else
                {
                    ledGen[Frame, 502] = 0;
                }
            }
        }
        //led 56
        private void checkBox83_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox83.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 55] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 119] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 183] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 247] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 311] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 375] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 439] = 1;
                }
                else
                {
                    ledGen[Frame, 503] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 55] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 119] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 183] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 247] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 311] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 375] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 439] = 0;
                }
                else
                {
                    ledGen[Frame, 503] = 0;
                }
            }
        }
        //led 57
        private void checkBox80_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox80.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 56] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 120] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 184] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 248] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 312] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 376] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 440] = 1;
                }
                else
                {
                    ledGen[Frame, 504] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 56] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 120] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 184] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 248] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 312] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 376] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 440] = 0;
                }
                else
                {
                    ledGen[Frame, 504] = 0;
                }
            }
        }
        //led 58
        private void checkBox79_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox79.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 57] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 121] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 185] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 249] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 313] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 377] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 441] = 1;
                }
                else
                {
                    ledGen[Frame, 505] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 57] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 121] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 185] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 249] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 313] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 377] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 441] = 0;
                }
                else
                {
                    ledGen[Frame, 505] = 0;
                }
            }
        }
        //led 59
        private void checkBox78_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox78.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 58] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 122] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 186] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 250] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 314] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 378] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 442] = 1;
                }
                else
                {
                    ledGen[Frame, 506] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 58] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 122] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 186] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 250] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 314] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 378] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 442] = 0;
                }
                else
                {
                    ledGen[Frame, 506] = 0;
                }
            }
        }
        //led 60
        private void checkBox77_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox77.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 59] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 123] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 187] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 251] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 315] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 379] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 443] = 1;
                }
                else
                {
                    ledGen[Frame, 507] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 59] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 123] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 187] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 251] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 315] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 379] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 443] = 0;
                }
                else
                {
                    ledGen[Frame, 507] = 0;
                }
            }
        }
        //led 61
        private void checkBox76_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox76.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 60] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 124] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 188] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 252] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 316] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 380] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 444] = 1;
                }
                else
                {
                    ledGen[Frame, 508] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 60] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 124] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 188] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 252] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 316] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 380] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 444] = 0;
                }
                else
                {
                    ledGen[Frame, 508] = 0;
                }
            }
        }
        //led 62
        private void checkBox75_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox75.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 61] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 125] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 189] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 253] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 317] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 381] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 445] = 1;
                }
                else
                {
                    ledGen[Frame, 509] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 61] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 125] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 189] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 253] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 317] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 381] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 445] = 0;
                }
                else
                {
                    ledGen[Frame, 509] = 0;
                }
            }
        }
        //led 63
        private void checkBox74_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox74.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 62] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 126] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 190] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 254] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 318] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 382] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 446] = 1;
                }
                else
                {
                    ledGen[Frame, 510] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 62] = 0;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 126] = 0;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 190] = 0;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 254] = 0;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 318] = 0;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 382] = 0;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 446] = 0;
                }
                else
                {
                    ledGen[Frame, 510] = 0;
                }
            }
        }
        //led 64
        private void checkBox73_CheckedChanged(object sender, EventArgs e)
        {
            if (IsFrozen)
            {
                return;
            }
            if (checkBox73.Checked == true)
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 63] = 1;
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 127] = 1;
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 191] = 1;
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 255] = 1;
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 319] = 1;
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 383] = 1;
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 447] = 1;
                }
                else
                {
                    ledGen[Frame, 511] = 1;
                }
            }
            else
            {
                if (Ledraster1 == true)
                {
                    ledGen[Frame, 63] = 0;//juist
                }
                else if (Ledraster2 == true)
                {
                    ledGen[Frame, 127] = 0;//juist
                }
                else if (Ledraster3 == true)
                {
                    ledGen[Frame, 191] = 0;//juist
                }
                else if (Ledraster4 == true)
                {
                    ledGen[Frame, 255] = 0;//juist
                }
                else if (Ledraster5 == true)
                {
                    ledGen[Frame, 319] = 0;//juist
                }
                else if (Ledraster6 == true)
                {
                    ledGen[Frame, 383] = 0;//juist
                }
                else if (Ledraster7 == true)
                {
                    ledGen[Frame, 447] = 0;//juist
                }
                else
                {
                    ledGen[Frame, 511] = 0;//juist
                }
            }
        }
        //effecten generator upload
        private void button2_Click(object sender, EventArgs e)
        {
            Upload();
        }   
        //de connectie protocol keuze
       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //leeg laten
        }
        //led selector slide
        public void numericUpDown5_ValueChanged_1(object sender, EventArgs e)
        {
           Slide = Convert.ToInt32(numericUpDown5.Value);
            switch (Slide)
            {
                case 1:
                    Ledraster1 = true;
                    Ledraster2 = false;
                    Ledraster3 = false;
                    Ledraster4 = false;
                    Ledraster5 = false;
                    Ledraster6 = false;
                    Ledraster7 = false;
                    break;
                case 2:
                    Ledraster1 = false;
                    Ledraster2 = true;
                    Ledraster3 = false;
                    Ledraster4 = false;
                    Ledraster5 = false;
                    Ledraster6 = false;
                    Ledraster7 = false;
                    break;
                case 3:
                    Ledraster1 = false;
                    Ledraster2 = false;
                    Ledraster3 = true;
                    Ledraster4 = false;
                    Ledraster5 = false;
                    Ledraster6 = false;
                    Ledraster7 = false;
                    break;
                case 4:
                    Ledraster1 = false;
                    Ledraster2 = false;
                    Ledraster3 = false;
                    Ledraster4 = true;
                    Ledraster5 = false;
                    Ledraster6 = false;
                    Ledraster7 = false;
                    break;
                case 5:
                    Ledraster1 = false;
                    Ledraster2 = false;
                    Ledraster3 = false;
                    Ledraster4 = false;
                    Ledraster5 = true;
                    Ledraster6 = false;
                    Ledraster7 = false;
                    break;
                case 6:
                    Ledraster1 = false;
                    Ledraster2 = false;
                    Ledraster3 = false;
                    Ledraster4 = false;
                    Ledraster5 = false;
                    Ledraster6 = true;
                    Ledraster7 = false;
                    break;
                case 7:
                    Ledraster1 = false;
                    Ledraster2 = false;
                    Ledraster3 = false;
                    Ledraster4 = false;
                    Ledraster5 = false;
                    Ledraster6 = false;
                    Ledraster7 = true;
                    break;
                case 8:
                    Ledraster1 = false;
                    Ledraster2 = false;
                    Ledraster3 = false;
                    Ledraster4 = false;
                    Ledraster5 = false;
                    Ledraster6 = false;
                    Ledraster7 = false;
                    break;


            }
            GeneratorShowBox();
        }
        //code vinkjes terugzetten in alle vakjes
        private void GeneratorShowBox()
        {
            IsFrozen = true;
            switch (Slide)
            {
                case 1:
                    for (int i = 0; i < 64; i++)
                    {
                        if (1 == ledGen[Frame, i])
                        {
                            switch(i)
                            {
                                case 0:
                                    checkBox1.Checked = true;
                                    break;
                                case 1:
                                    checkBox2.Checked = true;
                                    break;
                                case 2:
                                    checkBox4.Checked = true;
                                    break;
                                case 3:
                                    checkBox3.Checked = true;
                                    break;
                                case 4:
                                    checkBox6.Checked = true;
                                    break;
                                case 5:
                                    checkBox5.Checked = true;
                                    break;
                                case 6:
                                    checkBox10.Checked = true;
                                    break;
                                case 7:
                                    checkBox9.Checked = true;
                                    break;
                                case 8:
                                    checkBox20.Checked = true;
                                    break;
                                case 9:
                                    checkBox19.Checked = true;
                                    break;
                                case 10:
                                    checkBox18.Checked = true;
                                    break;
                                case 11:
                                    checkBox17.Checked = true;
                                    break;
                                case 12:
                                    checkBox16.Checked = true;
                                    break;
                                case 13:
                                    checkBox15.Checked = true;
                                    break;
                                case 14:
                                    checkBox14.Checked = true;
                                    break;
                                case 15:
                                    checkBox13.Checked = true;
                                    break;
                                case 16:
                                    checkBox30.Checked = true;
                                    break;
                                case 17:
                                    checkBox29.Checked = true;
                                    break;
                                case 18:
                                    checkBox28.Checked = true;
                                    break;
                                case 19:
                                    checkBox27.Checked = true;
                                    break;
                                case 20:
                                    checkBox26.Checked = true;
                                    break;
                                case 21:
                                    checkBox25.Checked = true;
                                    break;
                                case 22:
                                    checkBox24.Checked = true;
                                    break;
                                case 23:
                                    checkBox23.Checked = true;
                                    break;
                                case 24:
                                    checkBox40.Checked = true;
                                    break;
                                case 25:
                                    checkBox39.Checked = true;
                                    break;
                                case 26:
                                    checkBox38.Checked = true;
                                    break;
                                case 27:
                                    checkBox37.Checked = true;
                                    break;
                                case 28:
                                    checkBox36.Checked = true;
                                    break;
                                case 29:
                                    checkBox35.Checked = true;
                                    break;
                                case 30:
                                    checkBox34.Checked = true;
                                    break;
                                case 31:
                                    checkBox33.Checked = true;
                                    break;
                                case 32:
                                    checkBox50.Checked = true;
                                    break;
                                case 33:
                                    checkBox49.Checked = true;
                                    break;
                                case 34:
                                    checkBox48.Checked = true;
                                    break;
                                case 35:
                                    checkBox47.Checked = true;
                                    break;
                                case 36:
                                    checkBox46.Checked = true;
                                    break;
                                case 37:
                                    checkBox45.Checked = true;
                                    break;
                                case 38:
                                    checkBox44.Checked = true;
                                    break;
                                case 39:
                                    checkBox43.Checked = true;
                                    break;
                                case 40:
                                    checkBox100.Checked = true;
                                    break;
                                case 41:
                                    checkBox99.Checked = true;
                                    break;
                                case 42:
                                    checkBox98.Checked = true;
                                    break;
                                case 43:
                                    checkBox97.Checked = true;
                                    break;
                                case 44:
                                    checkBox96.Checked = true;
                                    break;
                                case 45:
                                    checkBox95.Checked = true;
                                    break;
                                case 46:
                                    checkBox94.Checked = true;
                                    break;
                                case 47:
                                    checkBox93.Checked = true;
                                    break;
                                case 48:
                                    checkBox90.Checked = true;
                                    break;
                                case 49:
                                    checkBox89.Checked = true;
                                    break;
                                case 50:
                                    checkBox88.Checked = true;
                                    break;
                                case 51:
                                    checkBox87.Checked = true;
                                    break;
                                case 52:
                                    checkBox86.Checked = true;
                                    break;
                                case 53:
                                    checkBox85.Checked = true;
                                    break;
                                case 54:
                                    checkBox84.Checked = true;
                                    break;
                                case 55:
                                    checkBox83.Checked = true;
                                    break;
                                case 56:
                                    checkBox80.Checked = true;
                                    break;
                                case 57:
                                    checkBox79.Checked = true;
                                    break;
                                case 58:
                                    checkBox78.Checked = true;
                                    break;
                                case 59:
                                    checkBox77.Checked = true;
                                    break;
                                case 60:
                                    checkBox76.Checked = true;
                                    break;
                                case 61:
                                    checkBox75.Checked = true;
                                    break;
                                case 62:
                                    checkBox74.Checked = true;
                                    break;
                                case 63:
                                    checkBox73.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (i)
                            {
                                case 0:
                                    checkBox1.Checked = false;
                                    break;
                                case 1:
                                    checkBox2.Checked = false;
                                    break;
                                case 2:
                                    checkBox4.Checked = false;
                                    break;
                                case 3:
                                    checkBox3.Checked = false;
                                    break;
                                case 4:
                                    checkBox6.Checked = false;
                                    break;
                                case 5:
                                    checkBox5.Checked = false;
                                    break;
                                case 6:
                                    checkBox10.Checked = false;
                                    break;
                                case 7:
                                    checkBox9.Checked = false;
                                    break;
                                case 8:
                                    checkBox20.Checked = false;
                                    break;
                                case 9:
                                    checkBox19.Checked = false;
                                    break;
                                case 10:
                                    checkBox18.Checked = false;
                                    break;
                                case 11:
                                    checkBox17.Checked = false;
                                    break;
                                case 12:
                                    checkBox16.Checked = false;
                                    break;
                                case 13:
                                    checkBox15.Checked = false;
                                    break;
                                case 14:
                                    checkBox14.Checked = false;
                                    break;
                                case 15:
                                    checkBox13.Checked = false;
                                    break;
                                case 16:
                                    checkBox30.Checked = false;
                                    break;
                                case 17:
                                    checkBox29.Checked = false;
                                    break;
                                case 18:
                                    checkBox28.Checked = false;
                                    break;
                                case 19:
                                    checkBox27.Checked = false;
                                    break;
                                case 20:
                                    checkBox26.Checked = false;
                                    break;
                                case 21:
                                    checkBox25.Checked = false;
                                    break;
                                case 22:
                                    checkBox24.Checked = false;
                                    break;
                                case 23:
                                    checkBox23.Checked = false;
                                    break;
                                case 24:
                                    checkBox40.Checked = false;
                                    break;
                                case 25:
                                    checkBox39.Checked = false;
                                    break;
                                case 26:
                                    checkBox38.Checked = false;
                                    break;
                                case 27:
                                    checkBox37.Checked = false;
                                    break;
                                case 28:
                                    checkBox36.Checked = false;
                                    break;
                                case 29:
                                    checkBox35.Checked = false;
                                    break;
                                case 30:
                                    checkBox34.Checked = false;
                                    break;
                                case 31:
                                    checkBox33.Checked = false;
                                    break;
                                case 32:
                                    checkBox50.Checked = false;
                                    break;
                                case 33:
                                    checkBox49.Checked = false;
                                    break;
                                case 34:
                                    checkBox48.Checked = false;
                                    break;
                                case 35:
                                    checkBox47.Checked = false;
                                    break;
                                case 36:
                                    checkBox46.Checked = false;
                                    break;
                                case 37:
                                    checkBox45.Checked = false;
                                    break;
                                case 38:
                                    checkBox44.Checked = false;
                                    break;
                                case 39:
                                    checkBox43.Checked = false;
                                    break;
                                case 40:
                                    checkBox100.Checked = false;
                                    break;
                                case 41:
                                    checkBox99.Checked = false;
                                    break;
                                case 42:
                                    checkBox98.Checked = false;
                                    break;
                                case 43:
                                    checkBox97.Checked = false;
                                    break;
                                case 44:
                                    checkBox96.Checked = false;
                                    break;
                                case 45:
                                    checkBox95.Checked = false;
                                    break;
                                case 46:
                                    checkBox94.Checked = false;
                                    break;
                                case 47:
                                    checkBox93.Checked = false;
                                    break;
                                case 48:
                                    checkBox90.Checked = false;
                                    break;
                                case 49:
                                    checkBox89.Checked = false;
                                    break;
                                case 50:
                                    checkBox88.Checked = false;
                                    break;
                                case 51:
                                    checkBox87.Checked = false;
                                    break;
                                case 52:
                                    checkBox86.Checked = false;
                                    break;
                                case 53:
                                    checkBox85.Checked = false;
                                    break;
                                case 54:
                                    checkBox84.Checked = false;
                                    break;
                                case 55:
                                    checkBox83.Checked = false;
                                    break;
                                case 56:
                                    checkBox80.Checked = false;
                                    break;
                                case 57:
                                    checkBox79.Checked = false;
                                    break;
                                case 58:
                                    checkBox78.Checked = false;
                                    break;
                                case 59:
                                    checkBox77.Checked = false;
                                    break;
                                case 60:
                                    checkBox76.Checked = false;
                                    break;
                                case 61:
                                    checkBox75.Checked = false;
                                    break;
                                case 62:
                                    checkBox74.Checked = false;
                                    break;
                                case 63:
                                    checkBox73.Checked = false;
                                    break;
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 64; i < 128; i++)
                    {
                        if (1 == ledGen[Frame, i])
                        {
                            switch (i-64)
                            {
                                case 0:
                                    checkBox1.Checked = true;
                                    break;
                                case 1:
                                    checkBox2.Checked = true;
                                    break;
                                case 2:
                                    checkBox4.Checked = true;
                                    break;
                                case 3:
                                    checkBox3.Checked = true;
                                    break;
                                case 4:
                                    checkBox6.Checked = true;
                                    break;
                                case 5:
                                    checkBox5.Checked = true;
                                    break;
                                case 6:
                                    checkBox10.Checked = true;
                                    break;
                                case 7:
                                    checkBox9.Checked = true;
                                    break;
                                case 8:
                                    checkBox20.Checked = true;
                                    break;
                                case 9:
                                    checkBox19.Checked = true;
                                    break;
                                case 10:
                                    checkBox18.Checked = true;
                                    break;
                                case 11:
                                    checkBox17.Checked = true;
                                    break;
                                case 12:
                                    checkBox16.Checked = true;
                                    break;
                                case 13:
                                    checkBox15.Checked = true;
                                    break;
                                case 14:
                                    checkBox14.Checked = true;
                                    break;
                                case 15:
                                    checkBox13.Checked = true;
                                    break;
                                case 16:
                                    checkBox30.Checked = true;
                                    break;
                                case 17:
                                    checkBox29.Checked = true;
                                    break;
                                case 18:
                                    checkBox28.Checked = true;
                                    break;
                                case 19:
                                    checkBox27.Checked = true;
                                    break;
                                case 20:
                                    checkBox26.Checked = true;
                                    break;
                                case 21:
                                    checkBox25.Checked = true;
                                    break;
                                case 22:
                                    checkBox24.Checked = true;
                                    break;
                                case 23:
                                    checkBox23.Checked = true;
                                    break;
                                case 24:
                                    checkBox40.Checked = true;
                                    break;
                                case 25:
                                    checkBox39.Checked = true;
                                    break;
                                case 26:
                                    checkBox38.Checked = true;
                                    break;
                                case 27:
                                    checkBox37.Checked = true;
                                    break;
                                case 28:
                                    checkBox36.Checked = true;
                                    break;
                                case 29:
                                    checkBox35.Checked = true;
                                    break;
                                case 30:
                                    checkBox34.Checked = true;
                                    break;
                                case 31:
                                    checkBox33.Checked = true;
                                    break;
                                case 32:
                                    checkBox50.Checked = true;
                                    break;
                                case 33:
                                    checkBox49.Checked = true;
                                    break;
                                case 34:
                                    checkBox48.Checked = true;
                                    break;
                                case 35:
                                    checkBox47.Checked = true;
                                    break;
                                case 36:
                                    checkBox46.Checked = true;
                                    break;
                                case 37:
                                    checkBox45.Checked = true;
                                    break;
                                case 38:
                                    checkBox44.Checked = true;
                                    break;
                                case 39:
                                    checkBox43.Checked = true;
                                    break;
                                case 40:
                                    checkBox100.Checked = true;
                                    break;
                                case 41:
                                    checkBox99.Checked = true;
                                    break;
                                case 42:
                                    checkBox98.Checked = true;
                                    break;
                                case 43:
                                    checkBox97.Checked = true;
                                    break;
                                case 44:
                                    checkBox96.Checked = true;
                                    break;
                                case 45:
                                    checkBox95.Checked = true;
                                    break;
                                case 46:
                                    checkBox94.Checked = true;
                                    break;
                                case 47:
                                    checkBox93.Checked = true;
                                    break;
                                case 48:
                                    checkBox90.Checked = true;
                                    break;
                                case 49:
                                    checkBox89.Checked = true;
                                    break;
                                case 50:
                                    checkBox88.Checked = true;
                                    break;
                                case 51:
                                    checkBox87.Checked = true;
                                    break;
                                case 52:
                                    checkBox86.Checked = true;
                                    break;
                                case 53:
                                    checkBox85.Checked = true;
                                    break;
                                case 54:
                                    checkBox84.Checked = true;
                                    break;
                                case 55:
                                    checkBox83.Checked = true;
                                    break;
                                case 56:
                                    checkBox80.Checked = true;
                                    break;
                                case 57:
                                    checkBox79.Checked = true;
                                    break;
                                case 58:
                                    checkBox78.Checked = true;
                                    break;
                                case 59:
                                    checkBox77.Checked = true;
                                    break;
                                case 60:
                                    checkBox76.Checked = true;
                                    break;
                                case 61:
                                    checkBox75.Checked = true;
                                    break;
                                case 62:
                                    checkBox74.Checked = true;
                                    break;
                                case 63:
                                    checkBox73.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (i-64)
                            {
                                case 0:
                                    checkBox1.Checked = false;
                                    break;
                                case 1:
                                    checkBox2.Checked = false;
                                    break;
                                case 2:
                                    checkBox4.Checked = false;
                                    break;
                                case 3:
                                    checkBox3.Checked = false;
                                    break;
                                case 4:
                                    checkBox6.Checked = false;
                                    break;
                                case 5:
                                    checkBox5.Checked = false;
                                    break;
                                case 6:
                                    checkBox10.Checked = false;
                                    break;
                                case 7:
                                    checkBox9.Checked = false;
                                    break;
                                case 8:
                                    checkBox20.Checked = false;
                                    break;
                                case 9:
                                    checkBox19.Checked = false;
                                    break;
                                case 10:
                                    checkBox18.Checked = false;
                                    break;
                                case 11:
                                    checkBox17.Checked = false;
                                    break;
                                case 12:
                                    checkBox16.Checked = false;
                                    break;
                                case 13:
                                    checkBox15.Checked = false;
                                    break;
                                case 14:
                                    checkBox14.Checked = false;
                                    break;
                                case 15:
                                    checkBox13.Checked = false;
                                    break;
                                case 16:
                                    checkBox30.Checked = false;
                                    break;
                                case 17:
                                    checkBox29.Checked = false;
                                    break;
                                case 18:
                                    checkBox28.Checked = false;
                                    break;
                                case 19:
                                    checkBox27.Checked = false;
                                    break;
                                case 20:
                                    checkBox26.Checked = false;
                                    break;
                                case 21:
                                    checkBox25.Checked = false;
                                    break;
                                case 22:
                                    checkBox24.Checked = false;
                                    break;
                                case 23:
                                    checkBox23.Checked = false;
                                    break;
                                case 24:
                                    checkBox40.Checked = false;
                                    break;
                                case 25:
                                    checkBox39.Checked = false;
                                    break;
                                case 26:
                                    checkBox38.Checked = false;
                                    break;
                                case 27:
                                    checkBox37.Checked = false;
                                    break;
                                case 28:
                                    checkBox36.Checked = false;
                                    break;
                                case 29:
                                    checkBox35.Checked = false;
                                    break;
                                case 30:
                                    checkBox34.Checked = false;
                                    break;
                                case 31:
                                    checkBox33.Checked = false;
                                    break;
                                case 32:
                                    checkBox50.Checked = false;
                                    break;
                                case 33:
                                    checkBox49.Checked = false;
                                    break;
                                case 34:
                                    checkBox48.Checked = false;
                                    break;
                                case 35:
                                    checkBox47.Checked = false;
                                    break;
                                case 36:
                                    checkBox46.Checked = false;
                                    break;
                                case 37:
                                    checkBox45.Checked = false;
                                    break;
                                case 38:
                                    checkBox44.Checked = false;
                                    break;
                                case 39:
                                    checkBox43.Checked = false;
                                    break;
                                case 40:
                                    checkBox100.Checked = false;
                                    break;
                                case 41:
                                    checkBox99.Checked = false;
                                    break;
                                case 42:
                                    checkBox98.Checked = false;
                                    break;
                                case 43:
                                    checkBox97.Checked = false;
                                    break;
                                case 44:
                                    checkBox96.Checked = false;
                                    break;
                                case 45:
                                    checkBox95.Checked = false;
                                    break;
                                case 46:
                                    checkBox94.Checked = false;
                                    break;
                                case 47:
                                    checkBox93.Checked = false;
                                    break;
                                case 48:
                                    checkBox90.Checked = false;
                                    break;
                                case 49:
                                    checkBox89.Checked = false;
                                    break;
                                case 50:
                                    checkBox88.Checked = false;
                                    break;
                                case 51:
                                    checkBox87.Checked = false;
                                    break;
                                case 52:
                                    checkBox86.Checked = false;
                                    break;
                                case 53:
                                    checkBox85.Checked = false;
                                    break;
                                case 54:
                                    checkBox84.Checked = false;
                                    break;
                                case 55:
                                    checkBox83.Checked = false;
                                    break;
                                case 56:
                                    checkBox80.Checked = false;
                                    break;
                                case 57:
                                    checkBox79.Checked = false;
                                    break;
                                case 58:
                                    checkBox78.Checked = false;
                                    break;
                                case 59:
                                    checkBox77.Checked = false;
                                    break;
                                case 60:
                                    checkBox76.Checked = false;
                                    break;
                                case 61:
                                    checkBox75.Checked = false;
                                    break;
                                case 62:
                                    checkBox74.Checked = false;
                                    break;
                                case 63:
                                    checkBox73.Checked = false;
                                    break;
                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 128; i < 192; i++)
                    {
                        if (1 == ledGen[Frame, i])
                        {
                            switch (i - 128)
                            {
                                case 0:
                                    checkBox1.Checked = true;
                                    break;
                                case 1:
                                    checkBox2.Checked = true;
                                    break;
                                case 2:
                                    checkBox4.Checked = true;
                                    break;
                                case 3:
                                    checkBox3.Checked = true;
                                    break;
                                case 4:
                                    checkBox6.Checked = true;
                                    break;
                                case 5:
                                    checkBox5.Checked = true;
                                    break;
                                case 6:
                                    checkBox10.Checked = true;
                                    break;
                                case 7:
                                    checkBox9.Checked = true;
                                    break;
                                case 8:
                                    checkBox20.Checked = true;
                                    break;
                                case 9:
                                    checkBox19.Checked = true;
                                    break;
                                case 10:
                                    checkBox18.Checked = true;
                                    break;
                                case 11:
                                    checkBox17.Checked = true;
                                    break;
                                case 12:
                                    checkBox16.Checked = true;
                                    break;
                                case 13:
                                    checkBox15.Checked = true;
                                    break;
                                case 14:
                                    checkBox14.Checked = true;
                                    break;
                                case 15:
                                    checkBox13.Checked = true;
                                    break;
                                case 16:
                                    checkBox30.Checked = true;
                                    break;
                                case 17:
                                    checkBox29.Checked = true;
                                    break;
                                case 18:
                                    checkBox28.Checked = true;
                                    break;
                                case 19:
                                    checkBox27.Checked = true;
                                    break;
                                case 20:
                                    checkBox26.Checked = true;
                                    break;
                                case 21:
                                    checkBox25.Checked = true;
                                    break;
                                case 22:
                                    checkBox24.Checked = true;
                                    break;
                                case 23:
                                    checkBox23.Checked = true;
                                    break;
                                case 24:
                                    checkBox40.Checked = true;
                                    break;
                                case 25:
                                    checkBox39.Checked = true;
                                    break;
                                case 26:
                                    checkBox38.Checked = true;
                                    break;
                                case 27:
                                    checkBox37.Checked = true;
                                    break;
                                case 28:
                                    checkBox36.Checked = true;
                                    break;
                                case 29:
                                    checkBox35.Checked = true;
                                    break;
                                case 30:
                                    checkBox34.Checked = true;
                                    break;
                                case 31:
                                    checkBox33.Checked = true;
                                    break;
                                case 32:
                                    checkBox50.Checked = true;
                                    break;
                                case 33:
                                    checkBox49.Checked = true;
                                    break;
                                case 34:
                                    checkBox48.Checked = true;
                                    break;
                                case 35:
                                    checkBox47.Checked = true;
                                    break;
                                case 36:
                                    checkBox46.Checked = true;
                                    break;
                                case 37:
                                    checkBox45.Checked = true;
                                    break;
                                case 38:
                                    checkBox44.Checked = true;
                                    break;
                                case 39:
                                    checkBox43.Checked = true;
                                    break;
                                case 40:
                                    checkBox100.Checked = true;
                                    break;
                                case 41:
                                    checkBox99.Checked = true;
                                    break;
                                case 42:
                                    checkBox98.Checked = true;
                                    break;
                                case 43:
                                    checkBox97.Checked = true;
                                    break;
                                case 44:
                                    checkBox96.Checked = true;
                                    break;
                                case 45:
                                    checkBox95.Checked = true;
                                    break;
                                case 46:
                                    checkBox94.Checked = true;
                                    break;
                                case 47:
                                    checkBox93.Checked = true;
                                    break;
                                case 48:
                                    checkBox90.Checked = true;
                                    break;
                                case 49:
                                    checkBox89.Checked = true;
                                    break;
                                case 50:
                                    checkBox88.Checked = true;
                                    break;
                                case 51:
                                    checkBox87.Checked = true;
                                    break;
                                case 52:
                                    checkBox86.Checked = true;
                                    break;
                                case 53:
                                    checkBox85.Checked = true;
                                    break;
                                case 54:
                                    checkBox84.Checked = true;
                                    break;
                                case 55:
                                    checkBox83.Checked = true;
                                    break;
                                case 56:
                                    checkBox80.Checked = true;
                                    break;
                                case 57:
                                    checkBox79.Checked = true;
                                    break;
                                case 58:
                                    checkBox78.Checked = true;
                                    break;
                                case 59:
                                    checkBox77.Checked = true;
                                    break;
                                case 60:
                                    checkBox76.Checked = true;
                                    break;
                                case 61:
                                    checkBox75.Checked = true;
                                    break;
                                case 62:
                                    checkBox74.Checked = true;
                                    break;
                                case 63:
                                    checkBox73.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (i-128)
                            {
                                case 0:
                                    checkBox1.Checked = false;
                                    break;
                                case 1:
                                    checkBox2.Checked = false;
                                    break;
                                case 2:
                                    checkBox4.Checked = false;
                                    break;
                                case 3:
                                    checkBox3.Checked = false;
                                    break;
                                case 4:
                                    checkBox6.Checked = false;
                                    break;
                                case 5:
                                    checkBox5.Checked = false;
                                    break;
                                case 6:
                                    checkBox10.Checked = false;
                                    break;
                                case 7:
                                    checkBox9.Checked = false;
                                    break;
                                case 8:
                                    checkBox20.Checked = false;
                                    break;
                                case 9:
                                    checkBox19.Checked = false;
                                    break;
                                case 10:
                                    checkBox18.Checked = false;
                                    break;
                                case 11:
                                    checkBox17.Checked = false;
                                    break;
                                case 12:
                                    checkBox16.Checked = false;
                                    break;
                                case 13:
                                    checkBox15.Checked = false;
                                    break;
                                case 14:
                                    checkBox14.Checked = false;
                                    break;
                                case 15:
                                    checkBox13.Checked = false;
                                    break;
                                case 16:
                                    checkBox30.Checked = false;
                                    break;
                                case 17:
                                    checkBox29.Checked = false;
                                    break;
                                case 18:
                                    checkBox28.Checked = false;
                                    break;
                                case 19:
                                    checkBox27.Checked = false;
                                    break;
                                case 20:
                                    checkBox26.Checked = false;
                                    break;
                                case 21:
                                    checkBox25.Checked = false;
                                    break;
                                case 22:
                                    checkBox24.Checked = false;
                                    break;
                                case 23:
                                    checkBox23.Checked = false;
                                    break;
                                case 24:
                                    checkBox40.Checked = false;
                                    break;
                                case 25:
                                    checkBox39.Checked = false;
                                    break;
                                case 26:
                                    checkBox38.Checked = false;
                                    break;
                                case 27:
                                    checkBox37.Checked = false;
                                    break;
                                case 28:
                                    checkBox36.Checked = false;
                                    break;
                                case 29:
                                    checkBox35.Checked = false;
                                    break;
                                case 30:
                                    checkBox34.Checked = false;
                                    break;
                                case 31:
                                    checkBox33.Checked = false;
                                    break;
                                case 32:
                                    checkBox50.Checked = false;
                                    break;
                                case 33:
                                    checkBox49.Checked = false;
                                    break;
                                case 34:
                                    checkBox48.Checked = false;
                                    break;
                                case 35:
                                    checkBox47.Checked = false;
                                    break;
                                case 36:
                                    checkBox46.Checked = false;
                                    break;
                                case 37:
                                    checkBox45.Checked = false;
                                    break;
                                case 38:
                                    checkBox44.Checked = false;
                                    break;
                                case 39:
                                    checkBox43.Checked = false;
                                    break;
                                case 40:
                                    checkBox100.Checked = false;
                                    break;
                                case 41:
                                    checkBox99.Checked = false;
                                    break;
                                case 42:
                                    checkBox98.Checked = false;
                                    break;
                                case 43:
                                    checkBox97.Checked = false;
                                    break;
                                case 44:
                                    checkBox96.Checked = false;
                                    break;
                                case 45:
                                    checkBox95.Checked = false;
                                    break;
                                case 46:
                                    checkBox94.Checked = false;
                                    break;
                                case 47:
                                    checkBox93.Checked = false;
                                    break;
                                case 48:
                                    checkBox90.Checked = false;
                                    break;
                                case 49:
                                    checkBox89.Checked = false;
                                    break;
                                case 50:
                                    checkBox88.Checked = false;
                                    break;
                                case 51:
                                    checkBox87.Checked = false;
                                    break;
                                case 52:
                                    checkBox86.Checked = false;
                                    break;
                                case 53:
                                    checkBox85.Checked = false;
                                    break;
                                case 54:
                                    checkBox84.Checked = false;
                                    break;
                                case 55:
                                    checkBox83.Checked = false;
                                    break;
                                case 56:
                                    checkBox80.Checked = false;
                                    break;
                                case 57:
                                    checkBox79.Checked = false;
                                    break;
                                case 58:
                                    checkBox78.Checked = false;
                                    break;
                                case 59:
                                    checkBox77.Checked = false;
                                    break;
                                case 60:
                                    checkBox76.Checked = false;
                                    break;
                                case 61:
                                    checkBox75.Checked = false;
                                    break;
                                case 62:
                                    checkBox74.Checked = false;
                                    break;
                                case 63:
                                    checkBox73.Checked = false;
                                    break;
                            }
                        }
                    }
                    break;
                case 4:
                    for (int i = 192; i < 256; i++)
                    {
                        if (1 == ledGen[Frame, i])
                        {
                            switch (i - 192)
                            {
                                case 0:
                                    checkBox1.Checked = true;
                                    break;
                                case 1:
                                    checkBox2.Checked = true;
                                    break;
                                case 2:
                                    checkBox4.Checked = true;
                                    break;
                                case 3:
                                    checkBox3.Checked = true;
                                    break;
                                case 4:
                                    checkBox6.Checked = true;
                                    break;
                                case 5:
                                    checkBox5.Checked = true;
                                    break;
                                case 6:
                                    checkBox10.Checked = true;
                                    break;
                                case 7:
                                    checkBox9.Checked = true;
                                    break;
                                case 8:
                                    checkBox20.Checked = true;
                                    break;
                                case 9:
                                    checkBox19.Checked = true;
                                    break;
                                case 10:
                                    checkBox18.Checked = true;
                                    break;
                                case 11:
                                    checkBox17.Checked = true;
                                    break;
                                case 12:
                                    checkBox16.Checked = true;
                                    break;
                                case 13:
                                    checkBox15.Checked = true;
                                    break;
                                case 14:
                                    checkBox14.Checked = true;
                                    break;
                                case 15:
                                    checkBox13.Checked = true;
                                    break;
                                case 16:
                                    checkBox30.Checked = true;
                                    break;
                                case 17:
                                    checkBox29.Checked = true;
                                    break;
                                case 18:
                                    checkBox28.Checked = true;
                                    break;
                                case 19:
                                    checkBox27.Checked = true;
                                    break;
                                case 20:
                                    checkBox26.Checked = true;
                                    break;
                                case 21:
                                    checkBox25.Checked = true;
                                    break;
                                case 22:
                                    checkBox24.Checked = true;
                                    break;
                                case 23:
                                    checkBox23.Checked = true;
                                    break;
                                case 24:
                                    checkBox40.Checked = true;
                                    break;
                                case 25:
                                    checkBox39.Checked = true;
                                    break;
                                case 26:
                                    checkBox38.Checked = true;
                                    break;
                                case 27:
                                    checkBox37.Checked = true;
                                    break;
                                case 28:
                                    checkBox36.Checked = true;
                                    break;
                                case 29:
                                    checkBox35.Checked = true;
                                    break;
                                case 30:
                                    checkBox34.Checked = true;
                                    break;
                                case 31:
                                    checkBox33.Checked = true;
                                    break;
                                case 32:
                                    checkBox50.Checked = true;
                                    break;
                                case 33:
                                    checkBox49.Checked = true;
                                    break;
                                case 34:
                                    checkBox48.Checked = true;
                                    break;
                                case 35:
                                    checkBox47.Checked = true;
                                    break;
                                case 36:
                                    checkBox46.Checked = true;
                                    break;
                                case 37:
                                    checkBox45.Checked = true;
                                    break;
                                case 38:
                                    checkBox44.Checked = true;
                                    break;
                                case 39:
                                    checkBox43.Checked = true;
                                    break;
                                case 40:
                                    checkBox100.Checked = true;
                                    break;
                                case 41:
                                    checkBox99.Checked = true;
                                    break;
                                case 42:
                                    checkBox98.Checked = true;
                                    break;
                                case 43:
                                    checkBox97.Checked = true;
                                    break;
                                case 44:
                                    checkBox96.Checked = true;
                                    break;
                                case 45:
                                    checkBox95.Checked = true;
                                    break;
                                case 46:
                                    checkBox94.Checked = true;
                                    break;
                                case 47:
                                    checkBox93.Checked = true;
                                    break;
                                case 48:
                                    checkBox90.Checked = true;
                                    break;
                                case 49:
                                    checkBox89.Checked = true;
                                    break;
                                case 50:
                                    checkBox88.Checked = true;
                                    break;
                                case 51:
                                    checkBox87.Checked = true;
                                    break;
                                case 52:
                                    checkBox86.Checked = true;
                                    break;
                                case 53:
                                    checkBox85.Checked = true;
                                    break;
                                case 54:
                                    checkBox84.Checked = true;
                                    break;
                                case 55:
                                    checkBox83.Checked = true;
                                    break;
                                case 56:
                                    checkBox80.Checked = true;
                                    break;
                                case 57:
                                    checkBox79.Checked = true;
                                    break;
                                case 58:
                                    checkBox78.Checked = true;
                                    break;
                                case 59:
                                    checkBox77.Checked = true;
                                    break;
                                case 60:
                                    checkBox76.Checked = true;
                                    break;
                                case 61:
                                    checkBox75.Checked = true;
                                    break;
                                case 62:
                                    checkBox74.Checked = true;
                                    break;
                                case 63:
                                    checkBox73.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (i-192)
                            {
                                case 0:
                                    checkBox1.Checked = false;
                                    break;
                                case 1:
                                    checkBox2.Checked = false;
                                    break;
                                case 2:
                                    checkBox4.Checked = false;
                                    break;
                                case 3:
                                    checkBox3.Checked = false;
                                    break;
                                case 4:
                                    checkBox6.Checked = false;
                                    break;
                                case 5:
                                    checkBox5.Checked = false;
                                    break;
                                case 6:
                                    checkBox10.Checked = false;
                                    break;
                                case 7:
                                    checkBox9.Checked = false;
                                    break;
                                case 8:
                                    checkBox20.Checked = false;
                                    break;
                                case 9:
                                    checkBox19.Checked = false;
                                    break;
                                case 10:
                                    checkBox18.Checked = false;
                                    break;
                                case 11:
                                    checkBox17.Checked = false;
                                    break;
                                case 12:
                                    checkBox16.Checked = false;
                                    break;
                                case 13:
                                    checkBox15.Checked = false;
                                    break;
                                case 14:
                                    checkBox14.Checked = false;
                                    break;
                                case 15:
                                    checkBox13.Checked = false;
                                    break;
                                case 16:
                                    checkBox30.Checked = false;
                                    break;
                                case 17:
                                    checkBox29.Checked = false;
                                    break;
                                case 18:
                                    checkBox28.Checked = false;
                                    break;
                                case 19:
                                    checkBox27.Checked = false;
                                    break;
                                case 20:
                                    checkBox26.Checked = false;
                                    break;
                                case 21:
                                    checkBox25.Checked = false;
                                    break;
                                case 22:
                                    checkBox24.Checked = false;
                                    break;
                                case 23:
                                    checkBox23.Checked = false;
                                    break;
                                case 24:
                                    checkBox40.Checked = false;
                                    break;
                                case 25:
                                    checkBox39.Checked = false;
                                    break;
                                case 26:
                                    checkBox38.Checked = false;
                                    break;
                                case 27:
                                    checkBox37.Checked = false;
                                    break;
                                case 28:
                                    checkBox36.Checked = false;
                                    break;
                                case 29:
                                    checkBox35.Checked = false;
                                    break;
                                case 30:
                                    checkBox34.Checked = false;
                                    break;
                                case 31:
                                    checkBox33.Checked = false;
                                    break;
                                case 32:
                                    checkBox50.Checked = false;
                                    break;
                                case 33:
                                    checkBox49.Checked = false;
                                    break;
                                case 34:
                                    checkBox48.Checked = false;
                                    break;
                                case 35:
                                    checkBox47.Checked = false;
                                    break;
                                case 36:
                                    checkBox46.Checked = false;
                                    break;
                                case 37:
                                    checkBox45.Checked = false;
                                    break;
                                case 38:
                                    checkBox44.Checked = false;
                                    break;
                                case 39:
                                    checkBox43.Checked = false;
                                    break;
                                case 40:
                                    checkBox100.Checked = false;
                                    break;
                                case 41:
                                    checkBox99.Checked = false;
                                    break;
                                case 42:
                                    checkBox98.Checked = false;
                                    break;
                                case 43:
                                    checkBox97.Checked = false;
                                    break;
                                case 44:
                                    checkBox96.Checked = false;
                                    break;
                                case 45:
                                    checkBox95.Checked = false;
                                    break;
                                case 46:
                                    checkBox94.Checked = false;
                                    break;
                                case 47:
                                    checkBox93.Checked = false;
                                    break;
                                case 48:
                                    checkBox90.Checked = false;
                                    break;
                                case 49:
                                    checkBox89.Checked = false;
                                    break;
                                case 50:
                                    checkBox88.Checked = false;
                                    break;
                                case 51:
                                    checkBox87.Checked = false;
                                    break;
                                case 52:
                                    checkBox86.Checked = false;
                                    break;
                                case 53:
                                    checkBox85.Checked = false;
                                    break;
                                case 54:
                                    checkBox84.Checked = false;
                                    break;
                                case 55:
                                    checkBox83.Checked = false;
                                    break;
                                case 56:
                                    checkBox80.Checked = false;
                                    break;
                                case 57:
                                    checkBox79.Checked = false;
                                    break;
                                case 58:
                                    checkBox78.Checked = false;
                                    break;
                                case 59:
                                    checkBox77.Checked = false;
                                    break;
                                case 60:
                                    checkBox76.Checked = false;
                                    break;
                                case 61:
                                    checkBox75.Checked = false;
                                    break;
                                case 62:
                                    checkBox74.Checked = false;
                                    break;
                                case 63:
                                    checkBox73.Checked = false;
                                    break;
                            }
                        }
                    }
                    break;
                case 5:
                    for (int i = 256; i < 320; i++)
                    {
                        if (1 == ledGen[Frame, i])
                        {
                            switch (i - 256)
                            {
                                case 0:
                                    checkBox1.Checked = true;
                                    break;
                                case 1:
                                    checkBox2.Checked = true;
                                    break;
                                case 2:
                                    checkBox4.Checked = true;
                                    break;
                                case 3:
                                    checkBox3.Checked = true;
                                    break;
                                case 4:
                                    checkBox6.Checked = true;
                                    break;
                                case 5:
                                    checkBox5.Checked = true;
                                    break;
                                case 6:
                                    checkBox10.Checked = true;
                                    break;
                                case 7:
                                    checkBox9.Checked = true;
                                    break;
                                case 8:
                                    checkBox20.Checked = true;
                                    break;
                                case 9:
                                    checkBox19.Checked = true;
                                    break;
                                case 10:
                                    checkBox18.Checked = true;
                                    break;
                                case 11:
                                    checkBox17.Checked = true;
                                    break;
                                case 12:
                                    checkBox16.Checked = true;
                                    break;
                                case 13:
                                    checkBox15.Checked = true;
                                    break;
                                case 14:
                                    checkBox14.Checked = true;
                                    break;
                                case 15:
                                    checkBox13.Checked = true;
                                    break;
                                case 16:
                                    checkBox30.Checked = true;
                                    break;
                                case 17:
                                    checkBox29.Checked = true;
                                    break;
                                case 18:
                                    checkBox28.Checked = true;
                                    break;
                                case 19:
                                    checkBox27.Checked = true;
                                    break;
                                case 20:
                                    checkBox26.Checked = true;
                                    break;
                                case 21:
                                    checkBox25.Checked = true;
                                    break;
                                case 22:
                                    checkBox24.Checked = true;
                                    break;
                                case 23:
                                    checkBox23.Checked = true;
                                    break;
                                case 24:
                                    checkBox40.Checked = true;
                                    break;
                                case 25:
                                    checkBox39.Checked = true;
                                    break;
                                case 26:
                                    checkBox38.Checked = true;
                                    break;
                                case 27:
                                    checkBox37.Checked = true;
                                    break;
                                case 28:
                                    checkBox36.Checked = true;
                                    break;
                                case 29:
                                    checkBox35.Checked = true;
                                    break;
                                case 30:
                                    checkBox34.Checked = true;
                                    break;
                                case 31:
                                    checkBox33.Checked = true;
                                    break;
                                case 32:
                                    checkBox50.Checked = true;
                                    break;
                                case 33:
                                    checkBox49.Checked = true;
                                    break;
                                case 34:
                                    checkBox48.Checked = true;
                                    break;
                                case 35:
                                    checkBox47.Checked = true;
                                    break;
                                case 36:
                                    checkBox46.Checked = true;
                                    break;
                                case 37:
                                    checkBox45.Checked = true;
                                    break;
                                case 38:
                                    checkBox44.Checked = true;
                                    break;
                                case 39:
                                    checkBox43.Checked = true;
                                    break;
                                case 40:
                                    checkBox100.Checked = true;
                                    break;
                                case 41:
                                    checkBox99.Checked = true;
                                    break;
                                case 42:
                                    checkBox98.Checked = true;
                                    break;
                                case 43:
                                    checkBox97.Checked = true;
                                    break;
                                case 44:
                                    checkBox96.Checked = true;
                                    break;
                                case 45:
                                    checkBox95.Checked = true;
                                    break;
                                case 46:
                                    checkBox94.Checked = true;
                                    break;
                                case 47:
                                    checkBox93.Checked = true;
                                    break;
                                case 48:
                                    checkBox90.Checked = true;
                                    break;
                                case 49:
                                    checkBox89.Checked = true;
                                    break;
                                case 50:
                                    checkBox88.Checked = true;
                                    break;
                                case 51:
                                    checkBox87.Checked = true;
                                    break;
                                case 52:
                                    checkBox86.Checked = true;
                                    break;
                                case 53:
                                    checkBox85.Checked = true;
                                    break;
                                case 54:
                                    checkBox84.Checked = true;
                                    break;
                                case 55:
                                    checkBox83.Checked = true;
                                    break;
                                case 56:
                                    checkBox80.Checked = true;
                                    break;
                                case 57:
                                    checkBox79.Checked = true;
                                    break;
                                case 58:
                                    checkBox78.Checked = true;
                                    break;
                                case 59:
                                    checkBox77.Checked = true;
                                    break;
                                case 60:
                                    checkBox76.Checked = true;
                                    break;
                                case 61:
                                    checkBox75.Checked = true;
                                    break;
                                case 62:
                                    checkBox74.Checked = true;
                                    break;
                                case 63:
                                    checkBox73.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (i-265)
                            {
                                case 0:
                                    checkBox1.Checked = false;
                                    break;
                                case 1:
                                    checkBox2.Checked = false;
                                    break;
                                case 2:
                                    checkBox4.Checked = false;
                                    break;
                                case 3:
                                    checkBox3.Checked = false;
                                    break;
                                case 4:
                                    checkBox6.Checked = false;
                                    break;
                                case 5:
                                    checkBox5.Checked = false;
                                    break;
                                case 6:
                                    checkBox10.Checked = false;
                                    break;
                                case 7:
                                    checkBox9.Checked = false;
                                    break;
                                case 8:
                                    checkBox20.Checked = false;
                                    break;
                                case 9:
                                    checkBox19.Checked = false;
                                    break;
                                case 10:
                                    checkBox18.Checked = false;
                                    break;
                                case 11:
                                    checkBox17.Checked = false;
                                    break;
                                case 12:
                                    checkBox16.Checked = false;
                                    break;
                                case 13:
                                    checkBox15.Checked = false;
                                    break;
                                case 14:
                                    checkBox14.Checked = false;
                                    break;
                                case 15:
                                    checkBox13.Checked = false;
                                    break;
                                case 16:
                                    checkBox30.Checked = false;
                                    break;
                                case 17:
                                    checkBox29.Checked = false;
                                    break;
                                case 18:
                                    checkBox28.Checked = false;
                                    break;
                                case 19:
                                    checkBox27.Checked = false;
                                    break;
                                case 20:
                                    checkBox26.Checked = false;
                                    break;
                                case 21:
                                    checkBox25.Checked = false;
                                    break;
                                case 22:
                                    checkBox24.Checked = false;
                                    break;
                                case 23:
                                    checkBox23.Checked = false;
                                    break;
                                case 24:
                                    checkBox40.Checked = false;
                                    break;
                                case 25:
                                    checkBox39.Checked = false;
                                    break;
                                case 26:
                                    checkBox38.Checked = false;
                                    break;
                                case 27:
                                    checkBox37.Checked = false;
                                    break;
                                case 28:
                                    checkBox36.Checked = false;
                                    break;
                                case 29:
                                    checkBox35.Checked = false;
                                    break;
                                case 30:
                                    checkBox34.Checked = false;
                                    break;
                                case 31:
                                    checkBox33.Checked = false;
                                    break;
                                case 32:
                                    checkBox50.Checked = false;
                                    break;
                                case 33:
                                    checkBox49.Checked = false;
                                    break;
                                case 34:
                                    checkBox48.Checked = false;
                                    break;
                                case 35:
                                    checkBox47.Checked = false;
                                    break;
                                case 36:
                                    checkBox46.Checked = false;
                                    break;
                                case 37:
                                    checkBox45.Checked = false;
                                    break;
                                case 38:
                                    checkBox44.Checked = false;
                                    break;
                                case 39:
                                    checkBox43.Checked = false;
                                    break;
                                case 40:
                                    checkBox100.Checked = false;
                                    break;
                                case 41:
                                    checkBox99.Checked = false;
                                    break;
                                case 42:
                                    checkBox98.Checked = false;
                                    break;
                                case 43:
                                    checkBox97.Checked = false;
                                    break;
                                case 44:
                                    checkBox96.Checked = false;
                                    break;
                                case 45:
                                    checkBox95.Checked = false;
                                    break;
                                case 46:
                                    checkBox94.Checked = false;
                                    break;
                                case 47:
                                    checkBox93.Checked = false;
                                    break;
                                case 48:
                                    checkBox90.Checked = false;
                                    break;
                                case 49:
                                    checkBox89.Checked = false;
                                    break;
                                case 50:
                                    checkBox88.Checked = false;
                                    break;
                                case 51:
                                    checkBox87.Checked = false;
                                    break;
                                case 52:
                                    checkBox86.Checked = false;
                                    break;
                                case 53:
                                    checkBox85.Checked = false;
                                    break;
                                case 54:
                                    checkBox84.Checked = false;
                                    break;
                                case 55:
                                    checkBox83.Checked = false;
                                    break;
                                case 56:
                                    checkBox80.Checked = false;
                                    break;
                                case 57:
                                    checkBox79.Checked = false;
                                    break;
                                case 58:
                                    checkBox78.Checked = false;
                                    break;
                                case 59:
                                    checkBox77.Checked = false;
                                    break;
                                case 60:
                                    checkBox76.Checked = false;
                                    break;
                                case 61:
                                    checkBox75.Checked = false;
                                    break;
                                case 62:
                                    checkBox74.Checked = false;
                                    break;
                                case 63:
                                    checkBox73.Checked = false;
                                    break;
                            }
                        }
                    }
                    break;
                case 6:
                    for (int i = 320; i < 384; i++)
                    {
                        if (1 == ledGen[Frame, i])
                        {
                            switch (i - 320)
                            {
                                case 0:
                                    checkBox1.Checked = true;
                                    break;
                                case 1:
                                    checkBox2.Checked = true;
                                    break;
                                case 2:
                                    checkBox4.Checked = true;
                                    break;
                                case 3:
                                    checkBox3.Checked = true;
                                    break;
                                case 4:
                                    checkBox6.Checked = true;
                                    break;
                                case 5:
                                    checkBox5.Checked = true;
                                    break;
                                case 6:
                                    checkBox10.Checked = true;
                                    break;
                                case 7:
                                    checkBox9.Checked = true;
                                    break;
                                case 8:
                                    checkBox20.Checked = true;
                                    break;
                                case 9:
                                    checkBox19.Checked = true;
                                    break;
                                case 10:
                                    checkBox18.Checked = true;
                                    break;
                                case 11:
                                    checkBox17.Checked = true;
                                    break;
                                case 12:
                                    checkBox16.Checked = true;
                                    break;
                                case 13:
                                    checkBox15.Checked = true;
                                    break;
                                case 14:
                                    checkBox14.Checked = true;
                                    break;
                                case 15:
                                    checkBox13.Checked = true;
                                    break;
                                case 16:
                                    checkBox30.Checked = true;
                                    break;
                                case 17:
                                    checkBox29.Checked = true;
                                    break;
                                case 18:
                                    checkBox28.Checked = true;
                                    break;
                                case 19:
                                    checkBox27.Checked = true;
                                    break;
                                case 20:
                                    checkBox26.Checked = true;
                                    break;
                                case 21:
                                    checkBox25.Checked = true;
                                    break;
                                case 22:
                                    checkBox24.Checked = true;
                                    break;
                                case 23:
                                    checkBox23.Checked = true;
                                    break;
                                case 24:
                                    checkBox40.Checked = true;
                                    break;
                                case 25:
                                    checkBox39.Checked = true;
                                    break;
                                case 26:
                                    checkBox38.Checked = true;
                                    break;
                                case 27:
                                    checkBox37.Checked = true;
                                    break;
                                case 28:
                                    checkBox36.Checked = true;
                                    break;
                                case 29:
                                    checkBox35.Checked = true;
                                    break;
                                case 30:
                                    checkBox34.Checked = true;
                                    break;
                                case 31:
                                    checkBox33.Checked = true;
                                    break;
                                case 32:
                                    checkBox50.Checked = true;
                                    break;
                                case 33:
                                    checkBox49.Checked = true;
                                    break;
                                case 34:
                                    checkBox48.Checked = true;
                                    break;
                                case 35:
                                    checkBox47.Checked = true;
                                    break;
                                case 36:
                                    checkBox46.Checked = true;
                                    break;
                                case 37:
                                    checkBox45.Checked = true;
                                    break;
                                case 38:
                                    checkBox44.Checked = true;
                                    break;
                                case 39:
                                    checkBox43.Checked = true;
                                    break;
                                case 40:
                                    checkBox100.Checked = true;
                                    break;
                                case 41:
                                    checkBox99.Checked = true;
                                    break;
                                case 42:
                                    checkBox98.Checked = true;
                                    break;
                                case 43:
                                    checkBox97.Checked = true;
                                    break;
                                case 44:
                                    checkBox96.Checked = true;
                                    break;
                                case 45:
                                    checkBox95.Checked = true;
                                    break;
                                case 46:
                                    checkBox94.Checked = true;
                                    break;
                                case 47:
                                    checkBox93.Checked = true;
                                    break;
                                case 48:
                                    checkBox90.Checked = true;
                                    break;
                                case 49:
                                    checkBox89.Checked = true;
                                    break;
                                case 50:
                                    checkBox88.Checked = true;
                                    break;
                                case 51:
                                    checkBox87.Checked = true;
                                    break;
                                case 52:
                                    checkBox86.Checked = true;
                                    break;
                                case 53:
                                    checkBox85.Checked = true;
                                    break;
                                case 54:
                                    checkBox84.Checked = true;
                                    break;
                                case 55:
                                    checkBox83.Checked = true;
                                    break;
                                case 56:
                                    checkBox80.Checked = true;
                                    break;
                                case 57:
                                    checkBox79.Checked = true;
                                    break;
                                case 58:
                                    checkBox78.Checked = true;
                                    break;
                                case 59:
                                    checkBox77.Checked = true;
                                    break;
                                case 60:
                                    checkBox76.Checked = true;
                                    break;
                                case 61:
                                    checkBox75.Checked = true;
                                    break;
                                case 62:
                                    checkBox74.Checked = true;
                                    break;
                                case 63:
                                    checkBox73.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (i-320)
                            {
                                case 0:
                                    checkBox1.Checked = false;
                                    break;
                                case 1:
                                    checkBox2.Checked = false;
                                    break;
                                case 2:
                                    checkBox4.Checked = false;
                                    break;
                                case 3:
                                    checkBox3.Checked = false;
                                    break;
                                case 4:
                                    checkBox6.Checked = false;
                                    break;
                                case 5:
                                    checkBox5.Checked = false;
                                    break;
                                case 6:
                                    checkBox10.Checked = false;
                                    break;
                                case 7:
                                    checkBox9.Checked = false;
                                    break;
                                case 8:
                                    checkBox20.Checked = false;
                                    break;
                                case 9:
                                    checkBox19.Checked = false;
                                    break;
                                case 10:
                                    checkBox18.Checked = false;
                                    break;
                                case 11:
                                    checkBox17.Checked = false;
                                    break;
                                case 12:
                                    checkBox16.Checked = false;
                                    break;
                                case 13:
                                    checkBox15.Checked = false;
                                    break;
                                case 14:
                                    checkBox14.Checked = false;
                                    break;
                                case 15:
                                    checkBox13.Checked = false;
                                    break;
                                case 16:
                                    checkBox30.Checked = false;
                                    break;
                                case 17:
                                    checkBox29.Checked = false;
                                    break;
                                case 18:
                                    checkBox28.Checked = false;
                                    break;
                                case 19:
                                    checkBox27.Checked = false;
                                    break;
                                case 20:
                                    checkBox26.Checked = false;
                                    break;
                                case 21:
                                    checkBox25.Checked = false;
                                    break;
                                case 22:
                                    checkBox24.Checked = false;
                                    break;
                                case 23:
                                    checkBox23.Checked = false;
                                    break;
                                case 24:
                                    checkBox40.Checked = false;
                                    break;
                                case 25:
                                    checkBox39.Checked = false;
                                    break;
                                case 26:
                                    checkBox38.Checked = false;
                                    break;
                                case 27:
                                    checkBox37.Checked = false;
                                    break;
                                case 28:
                                    checkBox36.Checked = false;
                                    break;
                                case 29:
                                    checkBox35.Checked = false;
                                    break;
                                case 30:
                                    checkBox34.Checked = false;
                                    break;
                                case 31:
                                    checkBox33.Checked = false;
                                    break;
                                case 32:
                                    checkBox50.Checked = false;
                                    break;
                                case 33:
                                    checkBox49.Checked = false;
                                    break;
                                case 34:
                                    checkBox48.Checked = false;
                                    break;
                                case 35:
                                    checkBox47.Checked = false;
                                    break;
                                case 36:
                                    checkBox46.Checked = false;
                                    break;
                                case 37:
                                    checkBox45.Checked = false;
                                    break;
                                case 38:
                                    checkBox44.Checked = false;
                                    break;
                                case 39:
                                    checkBox43.Checked = false;
                                    break;
                                case 40:
                                    checkBox100.Checked = false;
                                    break;
                                case 41:
                                    checkBox99.Checked = false;
                                    break;
                                case 42:
                                    checkBox98.Checked = false;
                                    break;
                                case 43:
                                    checkBox97.Checked = false;
                                    break;
                                case 44:
                                    checkBox96.Checked = false;
                                    break;
                                case 45:
                                    checkBox95.Checked = false;
                                    break;
                                case 46:
                                    checkBox94.Checked = false;
                                    break;
                                case 47:
                                    checkBox93.Checked = false;
                                    break;
                                case 48:
                                    checkBox90.Checked = false;
                                    break;
                                case 49:
                                    checkBox89.Checked = false;
                                    break;
                                case 50:
                                    checkBox88.Checked = false;
                                    break;
                                case 51:
                                    checkBox87.Checked = false;
                                    break;
                                case 52:
                                    checkBox86.Checked = false;
                                    break;
                                case 53:
                                    checkBox85.Checked = false;
                                    break;
                                case 54:
                                    checkBox84.Checked = false;
                                    break;
                                case 55:
                                    checkBox83.Checked = false;
                                    break;
                                case 56:
                                    checkBox80.Checked = false;
                                    break;
                                case 57:
                                    checkBox79.Checked = false;
                                    break;
                                case 58:
                                    checkBox78.Checked = false;
                                    break;
                                case 59:
                                    checkBox77.Checked = false;
                                    break;
                                case 60:
                                    checkBox76.Checked = false;
                                    break;
                                case 61:
                                    checkBox75.Checked = false;
                                    break;
                                case 62:
                                    checkBox74.Checked = false;
                                    break;
                                case 63:
                                    checkBox73.Checked = false;
                                    break;
                            }
                        }
                    }
                    break;
                case 7:
                    for (int i = 384; i < 448; i++)
                    {
                        if (1 == ledGen[Frame, i])
                        {
                            switch (i - 384)
                            {
                                case 0:
                                    checkBox1.Checked = true;
                                    break;
                                case 1:
                                    checkBox2.Checked = true;
                                    break;
                                case 2:
                                    checkBox4.Checked = true;
                                    break;
                                case 3:
                                    checkBox3.Checked = true;
                                    break;
                                case 4:
                                    checkBox6.Checked = true;
                                    break;
                                case 5:
                                    checkBox5.Checked = true;
                                    break;
                                case 6:
                                    checkBox10.Checked = true;
                                    break;
                                case 7:
                                    checkBox9.Checked = true;
                                    break;
                                case 8:
                                    checkBox20.Checked = true;
                                    break;
                                case 9:
                                    checkBox19.Checked = true;
                                    break;
                                case 10:
                                    checkBox18.Checked = true;
                                    break;
                                case 11:
                                    checkBox17.Checked = true;
                                    break;
                                case 12:
                                    checkBox16.Checked = true;
                                    break;
                                case 13:
                                    checkBox15.Checked = true;
                                    break;
                                case 14:
                                    checkBox14.Checked = true;
                                    break;
                                case 15:
                                    checkBox13.Checked = true;
                                    break;
                                case 16:
                                    checkBox30.Checked = true;
                                    break;
                                case 17:
                                    checkBox29.Checked = true;
                                    break;
                                case 18:
                                    checkBox28.Checked = true;
                                    break;
                                case 19:
                                    checkBox27.Checked = true;
                                    break;
                                case 20:
                                    checkBox26.Checked = true;
                                    break;
                                case 21:
                                    checkBox25.Checked = true;
                                    break;
                                case 22:
                                    checkBox24.Checked = true;
                                    break;
                                case 23:
                                    checkBox23.Checked = true;
                                    break;
                                case 24:
                                    checkBox40.Checked = true;
                                    break;
                                case 25:
                                    checkBox39.Checked = true;
                                    break;
                                case 26:
                                    checkBox38.Checked = true;
                                    break;
                                case 27:
                                    checkBox37.Checked = true;
                                    break;
                                case 28:
                                    checkBox36.Checked = true;
                                    break;
                                case 29:
                                    checkBox35.Checked = true;
                                    break;
                                case 30:
                                    checkBox34.Checked = true;
                                    break;
                                case 31:
                                    checkBox33.Checked = true;
                                    break;
                                case 32:
                                    checkBox50.Checked = true;
                                    break;
                                case 33:
                                    checkBox49.Checked = true;
                                    break;
                                case 34:
                                    checkBox48.Checked = true;
                                    break;
                                case 35:
                                    checkBox47.Checked = true;
                                    break;
                                case 36:
                                    checkBox46.Checked = true;
                                    break;
                                case 37:
                                    checkBox45.Checked = true;
                                    break;
                                case 38:
                                    checkBox44.Checked = true;
                                    break;
                                case 39:
                                    checkBox43.Checked = true;
                                    break;
                                case 40:
                                    checkBox100.Checked = true;
                                    break;
                                case 41:
                                    checkBox99.Checked = true;
                                    break;
                                case 42:
                                    checkBox98.Checked = true;
                                    break;
                                case 43:
                                    checkBox97.Checked = true;
                                    break;
                                case 44:
                                    checkBox96.Checked = true;
                                    break;
                                case 45:
                                    checkBox95.Checked = true;
                                    break;
                                case 46:
                                    checkBox94.Checked = true;
                                    break;
                                case 47:
                                    checkBox93.Checked = true;
                                    break;
                                case 48:
                                    checkBox90.Checked = true;
                                    break;
                                case 49:
                                    checkBox89.Checked = true;
                                    break;
                                case 50:
                                    checkBox88.Checked = true;
                                    break;
                                case 51:
                                    checkBox87.Checked = true;
                                    break;
                                case 52:
                                    checkBox86.Checked = true;
                                    break;
                                case 53:
                                    checkBox85.Checked = true;
                                    break;
                                case 54:
                                    checkBox84.Checked = true;
                                    break;
                                case 55:
                                    checkBox83.Checked = true;
                                    break;
                                case 56:
                                    checkBox80.Checked = true;
                                    break;
                                case 57:
                                    checkBox79.Checked = true;
                                    break;
                                case 58:
                                    checkBox78.Checked = true;
                                    break;
                                case 59:
                                    checkBox77.Checked = true;
                                    break;
                                case 60:
                                    checkBox76.Checked = true;
                                    break;
                                case 61:
                                    checkBox75.Checked = true;
                                    break;
                                case 62:
                                    checkBox74.Checked = true;
                                    break;
                                case 63:
                                    checkBox73.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (i-384)
                            {
                                case 0:
                                    checkBox1.Checked = false;
                                    break;
                                case 1:
                                    checkBox2.Checked = false;
                                    break;
                                case 2:
                                    checkBox4.Checked = false;
                                    break;
                                case 3:
                                    checkBox3.Checked = false;
                                    break;
                                case 4:
                                    checkBox6.Checked = false;
                                    break;
                                case 5:
                                    checkBox5.Checked = false;
                                    break;
                                case 6:
                                    checkBox10.Checked = false;
                                    break;
                                case 7:
                                    checkBox9.Checked = false;
                                    break;
                                case 8:
                                    checkBox20.Checked = false;
                                    break;
                                case 9:
                                    checkBox19.Checked = false;
                                    break;
                                case 10:
                                    checkBox18.Checked = false;
                                    break;
                                case 11:
                                    checkBox17.Checked = false;
                                    break;
                                case 12:
                                    checkBox16.Checked = false;
                                    break;
                                case 13:
                                    checkBox15.Checked = false;
                                    break;
                                case 14:
                                    checkBox14.Checked = false;
                                    break;
                                case 15:
                                    checkBox13.Checked = false;
                                    break;
                                case 16:
                                    checkBox30.Checked = false;
                                    break;
                                case 17:
                                    checkBox29.Checked = false;
                                    break;
                                case 18:
                                    checkBox28.Checked = false;
                                    break;
                                case 19:
                                    checkBox27.Checked = false;
                                    break;
                                case 20:
                                    checkBox26.Checked = false;
                                    break;
                                case 21:
                                    checkBox25.Checked = false;
                                    break;
                                case 22:
                                    checkBox24.Checked = false;
                                    break;
                                case 23:
                                    checkBox23.Checked = false;
                                    break;
                                case 24:
                                    checkBox40.Checked = false;
                                    break;
                                case 25:
                                    checkBox39.Checked = false;
                                    break;
                                case 26:
                                    checkBox38.Checked = false;
                                    break;
                                case 27:
                                    checkBox37.Checked = false;
                                    break;
                                case 28:
                                    checkBox36.Checked = false;
                                    break;
                                case 29:
                                    checkBox35.Checked = false;
                                    break;
                                case 30:
                                    checkBox34.Checked = false;
                                    break;
                                case 31:
                                    checkBox33.Checked = false;
                                    break;
                                case 32:
                                    checkBox50.Checked = false;
                                    break;
                                case 33:
                                    checkBox49.Checked = false;
                                    break;
                                case 34:
                                    checkBox48.Checked = false;
                                    break;
                                case 35:
                                    checkBox47.Checked = false;
                                    break;
                                case 36:
                                    checkBox46.Checked = false;
                                    break;
                                case 37:
                                    checkBox45.Checked = false;
                                    break;
                                case 38:
                                    checkBox44.Checked = false;
                                    break;
                                case 39:
                                    checkBox43.Checked = false;
                                    break;
                                case 40:
                                    checkBox100.Checked = false;
                                    break;
                                case 41:
                                    checkBox99.Checked = false;
                                    break;
                                case 42:
                                    checkBox98.Checked = false;
                                    break;
                                case 43:
                                    checkBox97.Checked = false;
                                    break;
                                case 44:
                                    checkBox96.Checked = false;
                                    break;
                                case 45:
                                    checkBox95.Checked = false;
                                    break;
                                case 46:
                                    checkBox94.Checked = false;
                                    break;
                                case 47:
                                    checkBox93.Checked = false;
                                    break;
                                case 48:
                                    checkBox90.Checked = false;
                                    break;
                                case 49:
                                    checkBox89.Checked = false;
                                    break;
                                case 50:
                                    checkBox88.Checked = false;
                                    break;
                                case 51:
                                    checkBox87.Checked = false;
                                    break;
                                case 52:
                                    checkBox86.Checked = false;
                                    break;
                                case 53:
                                    checkBox85.Checked = false;
                                    break;
                                case 54:
                                    checkBox84.Checked = false;
                                    break;
                                case 55:
                                    checkBox83.Checked = false;
                                    break;
                                case 56:
                                    checkBox80.Checked = false;
                                    break;
                                case 57:
                                    checkBox79.Checked = false;
                                    break;
                                case 58:
                                    checkBox78.Checked = false;
                                    break;
                                case 59:
                                    checkBox77.Checked = false;
                                    break;
                                case 60:
                                    checkBox76.Checked = false;
                                    break;
                                case 61:
                                    checkBox75.Checked = false;
                                    break;
                                case 62:
                                    checkBox74.Checked = false;
                                    break;
                                case 63:
                                    checkBox73.Checked = false;
                                    break;
                            }
                        }
                    }
                    break;
                case 8:
                    for (int i = 448; i < 512; i++)
                    {
                        if (1 == ledGen[Frame, i])
                        {
                            switch (i - 448)
                            {
                                case 0:
                                    checkBox1.Checked = true;
                                    break;
                                case 1:
                                    checkBox2.Checked = true;
                                    break;
                                case 2:
                                    checkBox4.Checked = true;
                                    break;
                                case 3:
                                    checkBox3.Checked = true;
                                    break;
                                case 4:
                                    checkBox6.Checked = true;
                                    break;
                                case 5:
                                    checkBox5.Checked = true;
                                    break;
                                case 6:
                                    checkBox10.Checked = true;
                                    break;
                                case 7:
                                    checkBox9.Checked = true;
                                    break;
                                case 8:
                                    checkBox20.Checked = true;
                                    break;
                                case 9:
                                    checkBox19.Checked = true;
                                    break;
                                case 10:
                                    checkBox18.Checked = true;
                                    break;
                                case 11:
                                    checkBox17.Checked = true;
                                    break;
                                case 12:
                                    checkBox16.Checked = true;
                                    break;
                                case 13:
                                    checkBox15.Checked = true;
                                    break;
                                case 14:
                                    checkBox14.Checked = true;
                                    break;
                                case 15:
                                    checkBox13.Checked = true;
                                    break;
                                case 16:
                                    checkBox30.Checked = true;
                                    break;
                                case 17:
                                    checkBox29.Checked = true;
                                    break;
                                case 18:
                                    checkBox28.Checked = true;
                                    break;
                                case 19:
                                    checkBox27.Checked = true;
                                    break;
                                case 20:
                                    checkBox26.Checked = true;
                                    break;
                                case 21:
                                    checkBox25.Checked = true;
                                    break;
                                case 22:
                                    checkBox24.Checked = true;
                                    break;
                                case 23:
                                    checkBox23.Checked = true;
                                    break;
                                case 24:
                                    checkBox40.Checked = true;
                                    break;
                                case 25:
                                    checkBox39.Checked = true;
                                    break;
                                case 26:
                                    checkBox38.Checked = true;
                                    break;
                                case 27:
                                    checkBox37.Checked = true;
                                    break;
                                case 28:
                                    checkBox36.Checked = true;
                                    break;
                                case 29:
                                    checkBox35.Checked = true;
                                    break;
                                case 30:
                                    checkBox34.Checked = true;
                                    break;
                                case 31:
                                    checkBox33.Checked = true;
                                    break;
                                case 32:
                                    checkBox50.Checked = true;
                                    break;
                                case 33:
                                    checkBox49.Checked = true;
                                    break;
                                case 34:
                                    checkBox48.Checked = true;
                                    break;
                                case 35:
                                    checkBox47.Checked = true;
                                    break;
                                case 36:
                                    checkBox46.Checked = true;
                                    break;
                                case 37:
                                    checkBox45.Checked = true;
                                    break;
                                case 38:
                                    checkBox44.Checked = true;
                                    break;
                                case 39:
                                    checkBox43.Checked = true;
                                    break;
                                case 40:
                                    checkBox100.Checked = true;
                                    break;
                                case 41:
                                    checkBox99.Checked = true;
                                    break;
                                case 42:
                                    checkBox98.Checked = true;
                                    break;
                                case 43:
                                    checkBox97.Checked = true;
                                    break;
                                case 44:
                                    checkBox96.Checked = true;
                                    break;
                                case 45:
                                    checkBox95.Checked = true;
                                    break;
                                case 46:
                                    checkBox94.Checked = true;
                                    break;
                                case 47:
                                    checkBox93.Checked = true;
                                    break;
                                case 48:
                                    checkBox90.Checked = true;
                                    break;
                                case 49:
                                    checkBox89.Checked = true;
                                    break;
                                case 50:
                                    checkBox88.Checked = true;
                                    break;
                                case 51:
                                    checkBox87.Checked = true;
                                    break;
                                case 52:
                                    checkBox86.Checked = true;
                                    break;
                                case 53:
                                    checkBox85.Checked = true;
                                    break;
                                case 54:
                                    checkBox84.Checked = true;
                                    break;
                                case 55:
                                    checkBox83.Checked = true;
                                    break;
                                case 56:
                                    checkBox80.Checked = true;
                                    break;
                                case 57:
                                    checkBox79.Checked = true;
                                    break;
                                case 58:
                                    checkBox78.Checked = true;
                                    break;
                                case 59:
                                    checkBox77.Checked = true;
                                    break;
                                case 60:
                                    checkBox76.Checked = true;
                                    break;
                                case 61:
                                    checkBox75.Checked = true;
                                    break;
                                case 62:
                                    checkBox74.Checked = true;
                                    break;
                                case 63:
                                    checkBox73.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (i-448)
                            {
                                case 0:
                                    checkBox1.Checked = false;
                                    break;
                                case 1:
                                    checkBox2.Checked = false;
                                    break;
                                case 2:
                                    checkBox4.Checked = false;
                                    break;
                                case 3:
                                    checkBox3.Checked = false;
                                    break;
                                case 4:
                                    checkBox6.Checked = false;
                                    break;
                                case 5:
                                    checkBox5.Checked = false;
                                    break;
                                case 6:
                                    checkBox10.Checked = false;
                                    break;
                                case 7:
                                    checkBox9.Checked = false;
                                    break;
                                case 8:
                                    checkBox20.Checked = false;
                                    break;
                                case 9:
                                    checkBox19.Checked = false;
                                    break;
                                case 10:
                                    checkBox18.Checked = false;
                                    break;
                                case 11:
                                    checkBox17.Checked = false;
                                    break;
                                case 12:
                                    checkBox16.Checked = false;
                                    break;
                                case 13:
                                    checkBox15.Checked = false;
                                    break;
                                case 14:
                                    checkBox14.Checked = false;
                                    break;
                                case 15:
                                    checkBox13.Checked = false;
                                    break;
                                case 16:
                                    checkBox30.Checked = false;
                                    break;
                                case 17:
                                    checkBox29.Checked = false;
                                    break;
                                case 18:
                                    checkBox28.Checked = false;
                                    break;
                                case 19:
                                    checkBox27.Checked = false;
                                    break;
                                case 20:
                                    checkBox26.Checked = false;
                                    break;
                                case 21:
                                    checkBox25.Checked = false;
                                    break;
                                case 22:
                                    checkBox24.Checked = false;
                                    break;
                                case 23:
                                    checkBox23.Checked = false;
                                    break;
                                case 24:
                                    checkBox40.Checked = false;
                                    break;
                                case 25:
                                    checkBox39.Checked = false;
                                    break;
                                case 26:
                                    checkBox38.Checked = false;
                                    break;
                                case 27:
                                    checkBox37.Checked = false;
                                    break;
                                case 28:
                                    checkBox36.Checked = false;
                                    break;
                                case 29:
                                    checkBox35.Checked = false;
                                    break;
                                case 30:
                                    checkBox34.Checked = false;
                                    break;
                                case 31:
                                    checkBox33.Checked = false;
                                    break;
                                case 32:
                                    checkBox50.Checked = false;
                                    break;
                                case 33:
                                    checkBox49.Checked = false;
                                    break;
                                case 34:
                                    checkBox48.Checked = false;
                                    break;
                                case 35:
                                    checkBox47.Checked = false;
                                    break;
                                case 36:
                                    checkBox46.Checked = false;
                                    break;
                                case 37:
                                    checkBox45.Checked = false;
                                    break;
                                case 38:
                                    checkBox44.Checked = false;
                                    break;
                                case 39:
                                    checkBox43.Checked = false;
                                    break;
                                case 40:
                                    checkBox100.Checked = false;
                                    break;
                                case 41:
                                    checkBox99.Checked = false;
                                    break;
                                case 42:
                                    checkBox98.Checked = false;
                                    break;
                                case 43:
                                    checkBox97.Checked = false;
                                    break;
                                case 44:
                                    checkBox96.Checked = false;
                                    break;
                                case 45:
                                    checkBox95.Checked = false;
                                    break;
                                case 46:
                                    checkBox94.Checked = false;
                                    break;
                                case 47:
                                    checkBox93.Checked = false;
                                    break;
                                case 48:
                                    checkBox90.Checked = false;
                                    break;
                                case 49:
                                    checkBox89.Checked = false;
                                    break;
                                case 50:
                                    checkBox88.Checked = false;
                                    break;
                                case 51:
                                    checkBox87.Checked = false;
                                    break;
                                case 52:
                                    checkBox86.Checked = false;
                                    break;
                                case 53:
                                    checkBox85.Checked = false;
                                    break;
                                case 54:
                                    checkBox84.Checked = false;
                                    break;
                                case 55:
                                    checkBox83.Checked = false;
                                    break;
                                case 56:
                                    checkBox80.Checked = false;
                                    break;
                                case 57:
                                    checkBox79.Checked = false;
                                    break;
                                case 58:
                                    checkBox78.Checked = false;
                                    break;
                                case 59:
                                    checkBox77.Checked = false;
                                    break;
                                case 60:
                                    checkBox76.Checked = false;
                                    break;
                                case 61:
                                    checkBox75.Checked = false;
                                    break;
                                case 62:
                                    checkBox74.Checked = false;
                                    break;
                                case 63:
                                    checkBox73.Checked = false;
                                    break;
                            }
                        }
                    }
                    break;
            }
            IsFrozen = false;
        }
        //label Parameter 2
        private void label4_Click(object sender, EventArgs e)
        {

        }
        //Connect knop
        private void button3_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }
        //alle connectie afbreken
        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Close();
            button3.Text = "Connect";
            disableControls();
        }
    }
}