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
        bool Ledraster8 = false;
        int[] code;
        int EffectNumber = 1;

        public Form1()
        {
            InitializeComponent();
            //disableControls();
            getAvailableComPorts();
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
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            //AAN TE PASSEN!
            //port.Write("#STAR\n");
            //button1.Text = "Disconnect";
            enableControls();
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

        }
        //Generator
        private void Generator_Click(object sender, EventArgs e)
        {

        }
        //Simpele naam Effecten
        private void label1_Click(object sender, EventArgs e)
        {

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

        }
        //snelheid nummer
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        //effect parameter 1
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
        //effect parameter 2
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
        //upload button effecten
        private void button1_Click(object sender, EventArgs e)
        {

        }


        ///effect generators
        //frame parameters
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }



        //LEEEEDS////////////
        //led 1
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 2
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 3
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 4
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 5
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 6
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 7
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 8
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 9
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 10
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 11
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {

        }
        //led 12
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {

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

        }
        
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }
        //de connectie protocol keuze
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //led selector slide
        private void numericUpDown5_ValueChanged_1(object sender, EventArgs e)
        {
           // int x = ConvertToInt(numericUpDown5.Value);
        }
        //de connectie protocol keuze
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}