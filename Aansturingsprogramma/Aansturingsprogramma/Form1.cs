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
        bool Ledraster1;
        bool Ledraster2;
        bool Ledraster3;
        bool Ledraster4;
        bool Ledraster5;
        bool Ledraster6;
        bool Ledraster7;
        string code;
        int[,] ledGen = new int[20,511];
        int EffectNumber = 1;
        int Snelheid = 2;
        int Para1 = 0;
        int Para2 = 0;
        int Slide = 1;
        int Frame = 0;
        bool ThereArePorts = false;

        public Form1()
        {
            InitializeComponent();
            disableControls();
            getAvailableComPorts();
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

        //alle poorten opzoeken
        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
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
                //AAN TE PASSEN!
                //port.Write("#STAR\n");
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
            //NOG BIJ TE WERKEN
        }

        ///effect generators
        //frame parameters
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Frame = Convert.ToInt32(numericUpDown4.Value);
        }



        //LEEEEDS////////////
        //led 1
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
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
            if (checkBox2.Checked == false)
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
            if (checkBox4.Checked == false)
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
            if (checkBox3.Checked == false)
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
            if (checkBox6.Checked == false)
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
            if (checkBox5.Checked == false)
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
            if (checkBox10.Checked == false)
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
            if (checkBox9.Checked == false)
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
            if (checkBox20.Checked == false)
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
            if (checkBox19.Checked == false)
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
            if (checkBox18.Checked == false)
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
            if (checkBox17.Checked == false)
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

        }
        //led 14
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 15
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 16
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 17
        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 18
        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 19
        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 20
        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 21
        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 22
        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 23
        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 24
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 25
        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 26
        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 27
        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 28
        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 29
        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 30
        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 31
        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 32
        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 33
        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 34
        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 35
        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 36
        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 37
        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 38
        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 39
        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 40
        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 40
        private void checkBox100_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 41
        private void checkBox99_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 42
        private void checkBox98_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 43
        private void checkBox97_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 44
        private void checkBox96_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 45
        private void checkBox95_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 46
        private void checkBox94_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 47
        private void checkBox93_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 48
        private void checkBox90_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 49
        private void checkBox89_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 50
        private void checkBox88_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 51
        private void checkBox87_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 52
        private void checkBox86_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 53
        private void checkBox85_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 54
        private void checkBox84_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 55
        private void checkBox83_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 56
        private void checkBox80_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 57
        private void checkBox79_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 58
        private void checkBox78_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 59
        private void checkBox77_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 60
        private void checkBox76_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 61
        private void checkBox75_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 62
        private void checkBox74_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 63
        private void checkBox73_CheckedChanged(object sender, EventArgs e)
        {

        }
        //effecten generator upload
        private void button2_Click(object sender, EventArgs e)
        {
            Upload();
        }   
        //de connectie protocol keuze
       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            //resetDefaults(); nog aan te maken
        }
        private void resetgrid()
        {
            //nog aan te vullen
        }
    }
}