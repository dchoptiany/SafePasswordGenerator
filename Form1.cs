using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafePasswordGenerator
{
    public partial class Form1 : Form
    {
        private bool darkMode = false;
        
        private Color lightBackgroundColor1 = Color.FromArgb(247, 236, 225);
        private Color lightBackgroundColor2 = Color.FromArgb(90, 167, 90);
        private Color lightTextColor1 = Color.FromArgb(35, 27, 30);
        private Color lightTextColor2 = Color.White;

        private Color darkBackgroundColor1 = Color.FromArgb(49, 54, 56);
        private Color darkBackgroundColor2 = Color.FromArgb(33, 161, 121);
        private Color darkTextColor1 = Color.FromArgb(234, 224, 204);
        private Color darkTextColor2 = Color.White;

        public Form1()
        {
            InitializeComponent();

            BackColor = lightBackgroundColor1;

            label1.ForeColor = lightTextColor1;
            label2.ForeColor = lightTextColor1;
            label3.ForeColor = lightTextColor1;
            label4.ForeColor = lightTextColor1;

            checkedListBox1.ForeColor = lightTextColor1;
            checkedListBox1.BackColor = lightBackgroundColor1;

            checkedListBox2.ForeColor = lightTextColor1;
            checkedListBox2.BackColor = lightBackgroundColor1;

            button1.ForeColor = lightTextColor2;
            button1.BackColor = lightBackgroundColor2;

            button3.ForeColor = lightTextColor2;
            button3.BackColor = lightBackgroundColor2;

            numericUpDown1.ForeColor = lightTextColor2;
            numericUpDown1.BackColor = lightBackgroundColor2;

            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(1, true);
            checkedListBox1.SelectionMode = SelectionMode.None;

            checkedListBox2.SetItemChecked(0, true);
            checkedListBox2.SetItemChecked(1, true);

            button3.Enabled = false;

            numericUpDown1.Minimum = 6;
            numericUpDown1.Maximum = 32;

            button5.ForeColor = darkTextColor1;
            button5.BackColor = darkBackgroundColor1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generator generator = new Generator(Decimal.ToInt32(numericUpDown1.Value));
            maskedTextBox1.Text = generator.generate(checkedListBox2.GetItemChecked(0), checkedListBox2.GetItemChecked(1));
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(maskedTextBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.ToString() == "G")
            {
                button1_Click(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(!darkMode)
            {
                button5.Text = "Light mode";

                BackColor = darkBackgroundColor1;

                label1.ForeColor = darkTextColor1;
                label2.ForeColor = darkTextColor1;
                label3.ForeColor = darkTextColor1;
                label4.ForeColor = darkTextColor1;

                checkedListBox1.ForeColor = darkTextColor1;
                checkedListBox1.BackColor = darkBackgroundColor1;

                checkedListBox2.ForeColor = darkTextColor1;
                checkedListBox2.BackColor = darkBackgroundColor1;

                button1.ForeColor = darkTextColor2;
                button1.BackColor = darkBackgroundColor2;

                button3.ForeColor = darkTextColor2;
                button3.BackColor = darkBackgroundColor2;

                numericUpDown1.ForeColor = darkTextColor2;
                numericUpDown1.BackColor = darkBackgroundColor2;
                button5.ForeColor = lightTextColor1;
                button5.BackColor = lightBackgroundColor1;

                darkMode = true;
            }
            else
            {
                button5.Text = "Dark mode";

                BackColor = lightBackgroundColor1;

                label1.ForeColor = lightTextColor1;
                label2.ForeColor = lightTextColor1;
                label3.ForeColor = lightTextColor1;
                label4.ForeColor = lightTextColor1;

                checkedListBox1.ForeColor = lightTextColor1;
                checkedListBox1.BackColor = lightBackgroundColor1;

                checkedListBox2.ForeColor = lightTextColor1;
                checkedListBox2.BackColor = lightBackgroundColor1;

                button1.ForeColor = lightTextColor2;
                button1.BackColor = lightBackgroundColor2;

                button3.ForeColor = lightTextColor2;
                button3.BackColor = lightBackgroundColor2;

                numericUpDown1.ForeColor = lightTextColor2;
                numericUpDown1.BackColor = lightBackgroundColor2;

                button5.ForeColor = darkTextColor1;
                button5.BackColor = darkBackgroundColor1;

                darkMode = false;
            }
        }
    }
}
