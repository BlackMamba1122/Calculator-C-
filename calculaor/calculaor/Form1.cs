using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace calculaor
{
    public partial class body : Form
    {
        double result = 0;
        string operation = string.Empty;
        string num1, num2;
        bool first = true;
        bool program = false;
        bool bin = false, dec = false, oct = false, hex = false;
        private List<Button> bB = new List<Button>();
        private List<Button> dB = new List<Button>();
        private List<Button> oB = new List<Button>();
        private List<Button> hB = new List<Button>();
        private List<Button> eB = new List<Button>();
        public body()
        {
            InitializeComponent();
            this.Width = 300;
            maxi.Enabled = false;
            bB.Add(zero);
            bB.Add(one);
            oB.Add(two);
            oB.Add(three);
            oB.Add(four);
            oB.Add(five);
            oB.Add(six);
            oB.Add(seven);
            dB.Add(eight);
            dB.Add(nine);
            hB.Add(A);
            hB.Add(B);
            hB.Add(Cc);
            hB.Add(D);
            hB.Add(Ee);
            hB.Add(F);
            eB.Add(percent);
            eB.Add(CE);
            eB.Add(square);
            eB.Add(fraction);
            eB.Add(plusMinus);
            eB.Add(dot);
            eB.Add(underrrot);
            eB.Add(plus);
            eB.Add(minus);
            eB.Add(multiply);
            eB.Add(divide);
            eB.Add(equal);
            eB.Add(history);
            Dec_Click(null, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (!program)
            {
                num2 = pScreen.Text;
                sScreen.Text = $"{sScreen.Text}{pScreen.Text}=";
                if (pScreen.Text != string.Empty)
                {
                    if (pScreen.Text == "0")
                        sScreen.Text = string.Empty;
                    switch (operation)
                    {
                        case "+":
                            pScreen.Text = (result + double.Parse(pScreen.Text)).ToString();
                            break;
                        case "-":
                            pScreen.Text = (result - double.Parse(pScreen.Text)).ToString();
                            break;
                        case "×":
                            pScreen.Text = (result * double.Parse(pScreen.Text)).ToString();
                            break;
                        case "÷":
                            pScreen.Text = (result / double.Parse(pScreen.Text)).ToString();
                            break;
                        case "^x":
                            pScreen.Text = (Math.Pow(result, double.Parse(pScreen.Text))).ToString();
                            break;
                        case "Mod":
                            pScreen.Text = (result % double.Parse(pScreen.Text)).ToString();
                            break;
                        case "× 10x":
                            pScreen.Text = (result + new string('0', int.Parse(pScreen.Text)));
                            break;
                        default:
                            sScreen.Text = $"{pScreen.Text}";
                            break;
                    }
                    richTextBox1.AppendText($"{num1}{num2}={pScreen.Text}\n");
                    result = double.Parse(pScreen.Text);
                    operation = string.Empty;
                }
            }
        }
        private void percent_Click(object sender, EventArgs e)
        {

        }
        private void pScreen_TextChanged(object sender, EventArgs e)
        {

        }

        private void primeoperatorclick(object sender, EventArgs e)
        {

            if (!program)
            {
                if (result != 0)
                    equal.PerformClick();
                else
                    result = double.Parse(pScreen.Text);
                Button btn = (Button)sender;
                operation = btn.Text;
                first = true;
                if (pScreen.Text != "0")
                {
                    num1 = $"{result}{operation}";
                    if (operation == "^x" || operation == "× 10x")
                        num1 = num1.Remove(num1.Length - 1, 1);
                    sScreen.Text = num1;
                    pScreen.Text = string.Empty;
                }
            }
        }

        private void history_Click(object sender, EventArgs e)
        {
            pHistory.Height = (pHistory.Height == 1) ? pHistory.Height = 345 : 1;
        }


        private void erase_Click(object sender, EventArgs e)
        {
            if (!program)
            {
                if (pScreen.Text.Length > 0)
                    pScreen.Text = pScreen.Text.Remove(pScreen.Text.Length - 1, 1);
                if (pScreen.Text == string.Empty)
                    pScreen.Text = "0";
            }
            else
            {
                if (bin)
                    if (binscreen.Text.Length > 7)
                    {
                        binscreen.Text = binscreen.Text.Remove(binscreen.Text.Length - 1, 1);
                        if (binscreen.Text.Length == 7)
                        { C_Click(null, EventArgs.Empty); return; }
                            
                        decscreen.Text = $"Dec:   {Convert.ToInt32(binscreen.Text.Substring(7), 2)}";
                        octt();
                        hexx();
                    }
                if (dec)
                    if (decscreen.Text.Length > 7)
                    {
                        decscreen.Text = decscreen.Text.Remove(decscreen.Text.Length - 1, 1);
                        if (decscreen.Text.Length == 7)
                        { C_Click(null, EventArgs.Empty); return; }

                        binn();
                        octt();
                        hexx();
                    }
                if (oct)
                    if (octscreen.Text.Length > 7)
                    { 
                        octscreen.Text = octscreen.Text.Remove(octscreen.Text.Length - 1, 1);
                        if (octscreen.Text.Length == 7)
                        { C_Click(null, EventArgs.Empty); return; }
                        decscreen.Text = $"Dec:   {Convert.ToInt32(octscreen.Text.Substring(7), 8)}";
                        binn();
                        hexx();
                    }
                if (hex)
                    if (hexscreen.Text.Length > 7)
                    {
                        hexscreen.Text = hexscreen.Text.Remove(hexscreen.Text.Length - 1, 1);
                        if (hexscreen.Text.Length == 7)
                        { C_Click(null, EventArgs.Empty); return; }
                        decscreen.Text = $"Dec:   {Convert.ToInt32(hexscreen.Text.Substring(7), 16)}";
                        binn();
                        octt();
                    }
            }
        }

        private void CE_Click(object sender, EventArgs e)
        {
                pScreen.Text = "0";
                sScreen.Text = string.Empty;
                result = 0;
        }

        private void C_Click(object sender, EventArgs e)
        {
            if(!program)
                pScreen.Text = "0";
            else
            {
                binscreen.Text = "Bin:   ";
                decscreen.Text = "Dec:   ";
                octscreen.Text = "Oct:   ";
                hexscreen.Text = "Hex:   ";
            }
        }

        private double fact(int number)
        {
            if (number == 1 || number == 0)
                return 1;
            else
                return number * fact(number - 1);
        }
        private void secondarysimpleclick(object sender, EventArgs e)
        {
            if (!program)
            {
                Button btn = (Button)sender;
                operation = btn.Text;
                switch (operation)
                {
                    case "√x":
                        sScreen.Text = $"√{pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Sqrt(Double.Parse(pScreen.Text)));
                        break;
                    case "^2":
                        sScreen.Text = $"{pScreen.Text}^2";
                        pScreen.Text = Convert.ToString(Convert.ToDouble(Double.Parse(pScreen.Text)) * Convert.ToDouble(Double.Parse(pScreen.Text)));
                        break;
                    case "1⁄x":
                        sScreen.Text = $"1⁄{pScreen.Text}";
                        pScreen.Text = Convert.ToString(1.0 / Convert.ToDouble(Double.Parse(pScreen.Text)));
                        break;
                    case "%":
                        sScreen.Text = $"{pScreen.Text}%";
                        pScreen.Text = Convert.ToString(Convert.ToDouble(Double.Parse(pScreen.Text)) / 100);
                        break;
                    case "±":
                        sScreen.Text = $"±{pScreen.Text}";
                        pScreen.Text = Convert.ToString(-1 * Convert.ToDouble(Double.Parse(pScreen.Text)));
                        break;
                    case "!":
                        sScreen.Text = $"{pScreen.Text}!";
                        pScreen.Text = Convert.ToString(fact(Convert.ToInt32(Double.Parse(pScreen.Text))));
                        break;
                    case "Log":
                        if (pScreen.Text != "0")
                        {
                            sScreen.Text = $"log{pScreen.Text}";
                            pScreen.Text = Convert.ToString(Math.Log10(Double.Parse(pScreen.Text)));
                        }
                        break;
                    case "e^":
                        sScreen.Text = $"e^ {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Exp(Double.Parse(pScreen.Text)));
                        break;
                    case "ln":
                        sScreen.Text = $"ln {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Log(Double.Parse(pScreen.Text)));
                        break;
                    case "π":
                        if (pScreen.Text == "0" || pScreen.Text == string.Empty)
                            pScreen.Text = "1";
                        sScreen.Text = $"{pScreen.Text} π";
                        pScreen.Text = Convert.ToString(Math.PI * Convert.ToDouble(Double.Parse(pScreen.Text)));
                        break;
                    case "|x|":
                        sScreen.Text = $"|{pScreen.Text}|";
                        pScreen.Text = Convert.ToString(Math.Abs(Double.Parse(pScreen.Text)));
                        break;
                }
                richTextBox1.AppendText($"{sScreen.Text}={pScreen.Text}\n");
                //first = true;
            }
        }

        private void cross_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trignometricClick(object sender, EventArgs e)
        {
            if (!program)
            {
                Button btn = (Button)sender;
                operation = btn.Text;
                switch (operation)
                {
                    case "Sin":
                        sScreen.Text = $"sin {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Sin(Convert.ToDouble(pScreen.Text) * Math.PI / 180));
                        break;
                    case "Cos":
                        sScreen.Text = $"cos {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Cos(Double.Parse(pScreen.Text) * Math.PI / 180));
                        break;
                    case "Tan":
                        sScreen.Text = $"tan {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Tan(Double.Parse(pScreen.Text) * Math.PI / 180));
                        break;
                    case "Sinh":
                        sScreen.Text = $"sinh {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Sinh(Double.Parse(pScreen.Text) ));
                        break;
                    case "Cosh":
                        sScreen.Text = $"cosh {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Cosh(Double.Parse(pScreen.Text) ));
                        break;
                    case "Tanh":
                        sScreen.Text = $"tanh {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Tanh(Double.Parse(pScreen.Text)));
                        break;
                    case "Sin -1":
                        sScreen.Text = $"sin-1 {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Asin(Convert.ToDouble(pScreen.Text) )/ Math.PI * 180);
                        break;
                    case "Cos -1":
                        sScreen.Text = $"cos-1 {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Acos(Double.Parse(pScreen.Text) )/ Math.PI * 180);
                        break;
                    case "Tan -1":
                        sScreen.Text = $"tan-1 {pScreen.Text}";
                        pScreen.Text = Convert.ToString(Math.Atan(Double.Parse(pScreen.Text) )/ Math.PI * 180);
                        break;
                }
                richTextBox1.AppendText($"{sScreen.Text}={pScreen.Text}\n");
                //first = true;
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            pmenu.Width = (pmenu.Width == 1) ? pmenu.Width = 245 : 1;
        }
        private void standard_Click_1(object sender, EventArgs e)
        {
            this.Width = 300;
            panelpro.Width = 1;
            program = false;
            menu_Click(null, EventArgs.Empty);
            foreach (Button button in eB)
                button.Enabled = true;
            foreach (Button button in oB)
                button.Enabled = true;
            foreach (Button button in dB)
                button.Enabled = true;

        }

        private void science_Click(object sender, EventArgs e)
        {
            this.Width = 537;
            pprogram.Width = 1;
            panelpro.Width = 1;
            program = false;
            menu_Click(null, EventArgs.Empty);
            foreach (Button button in eB)
                button.Enabled = true;
            foreach (Button button in oB)
                button.Enabled = true;
            foreach (Button button in dB)
                button.Enabled = true;

        }
        private void Programmer_Click(object sender, EventArgs e)
        {
            this.Width = 537;
            pprogram.Width = 230;
            panelpro.Width = 528;
            program = true;
            menu_Click(null, EventArgs.Empty);
            foreach (Button button in eB)
                button.Enabled = false;
        }

        private void Dec_Click(object sender, EventArgs e)
        {
            dec = true;
            bin = false;
            oct = false;
            hex = false;
            foreach (Button button in oB)
                button.Enabled = true;
            foreach (Button button in dB)
                button.Enabled = true;
            foreach (Button button in hB)
                button.Enabled = false;
            binscreen.BackColor = Color.Silver;
            decscreen.BackColor = Color.HotPink;
            octscreen.BackColor = Color.Silver;
            hexscreen.BackColor = Color.Silver;
        }

        private void Bin_Click(object sender, EventArgs e)
        {
            dec = false;
            bin = true;
            oct = false;
            hex = false;
            foreach (Button button in oB)
                button.Enabled = false;
            foreach (Button button in dB)
                button.Enabled = false;
            foreach (Button button in hB)
                button.Enabled = false;
            binscreen.BackColor = Color.HotPink;
            decscreen.BackColor = Color.Silver;
            octscreen.BackColor = Color.Silver;
            hexscreen.BackColor = Color.Silver;

        }

        private void Oct_Click(object sender, EventArgs e)
        {
            dec = false;
            bin = false;
            oct = true;
            hex = false;
            foreach (Button button in oB)
                button.Enabled = true;
            foreach (Button button in dB)
                button.Enabled = false;
            foreach (Button button in hB)
                button.Enabled = false;
            binscreen.BackColor = Color.Silver;
            decscreen.BackColor = Color.Silver;
            octscreen.BackColor = Color.HotPink;
            hexscreen.BackColor = Color.Silver;

        }

        private void Hex_Click(object sender, EventArgs e)
        {
            dec = false;
            bin = false;
            oct = false;
            hex = true;
            foreach (Button button in oB)
                button.Enabled = true;
            foreach (Button button in dB)
                button.Enabled = true;
            foreach (Button button in hB)
                button.Enabled = true;
            binscreen.BackColor = Color.Silver;
            decscreen.BackColor = Color.Silver;
            octscreen.BackColor = Color.Silver;
            hexscreen.BackColor = Color.HotPink;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void clear_Click_2(object sender, EventArgs e)
        {
            richTextBox1.Text= string.Empty;
            if (richTextBox1.Text == string.Empty)
                richTextBox1.Text = "No history\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maxi_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void binn()
        {
            binscreen.Text = $"Bin:   {Convert.ToString(int.Parse(decscreen.Text.Substring(7)), 2)}";
        }
        void octt()
        {
            octscreen.Text = $"Oct:   {Convert.ToString(int.Parse(decscreen.Text.Substring(7)), 8)}";
        }
        void hexx()
        {
            hexscreen.Text = $"Hex:   {Convert.ToString(int.Parse(decscreen.Text.Substring(7)), 16)}";
        }

        private void numClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!program)
            {
                if (pScreen.Text == "0" || first)
                    pScreen.Text = string.Empty;
                first = false;
                if (btn.Text == ".")
                {
                    if (!pScreen.Text.Contains("."))
                        pScreen.Text += btn.Text;
                    else
                        pScreen.Text = pScreen.Text.Replace(".", string.Empty);
                }
                else
                    pScreen.Text += btn.Text;
            }
            else
            {
                if (bin)
            //        if (btn.Text == "0" || btn.Text == "1")
                    {
                        binscreen.Text += btn.Text;
                        decscreen.Text = $"Dec:   {Convert.ToInt32(binscreen.Text.Substring(7), 2)}";
                        octt();
                        hexx();
                    }
                if(dec)
              //      if ((int)btn.Text[0] >= '0' && (int)btn.Text[0] <= '9')
                    {
                        decscreen.Text += btn.Text;
                        binn();
                        octt();
                        hexx();
                    }
                if (oct)
             //       if ((int)btn.Text[0] >= '0' && (int)btn.Text[0] <= '7')
                    {
                        octscreen.Text += btn.Text;
                        decscreen.Text = $"Dec:   {Convert.ToInt32(octscreen.Text.Substring(7), 8)}";
                        binn();
                        hexx();
                    }
                if (hex)
             //       if (((int)btn.Text[0] >= '0' && (int)btn.Text[0] <= '9') || ((int)btn.Text[0] >= 'A' && (int)btn.Text[0] <= 'F'))
                    {
                        hexscreen.Text += btn.Text;
                        decscreen.Text = $"Dec:   {Convert.ToInt32(hexscreen.Text.Substring(7), 16)}";
                        binn();
                        octt();
                    }
            }
        }
    }
}
