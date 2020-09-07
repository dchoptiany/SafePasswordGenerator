using System;
using System.Drawing;
using System.Windows.Forms;

namespace SafePasswordGenerator
{
    public partial class Form1 : Form
    {
        private bool darkMode = true;

        private Color color1;
        private Color color2;
        private Color color3;
        private Color color4 = Color.White;

        private Color color1Dark = Color.FromArgb(49, 54, 56);
        private Color color2Dark = Color.FromArgb(33, 161, 121);
        private Color color3Dark = Color.FromArgb(234, 224, 204);

        private Color color1Light = Color.FromArgb(247, 236, 225);
        private Color color2Light = Color.FromArgb(90, 167, 90);
        private Color color3Light = Color.FromArgb(35, 27, 30);

        public Form1()
        {
            InitializeComponent();

            button5_Click(null, null);

            button1.ForeColor = color4;
            button3.ForeColor = color4;
            numericUpDown1.ForeColor = color4;

            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(1, true);
            checkedListBox1.SelectionMode = SelectionMode.None;

            checkedListBox2.SetItemChecked(0, true);
            checkedListBox2.SetItemChecked(1, true);

            button3.Enabled = false;

            numericUpDown1.Minimum = 6;
            numericUpDown1.Maximum = 32;
        }

        private void updateColors()
        {
            BackColor = color1;
            checkedListBox1.BackColor = color1;
            checkedListBox2.BackColor = color1;

            button1.BackColor = color2;
            button3.BackColor = color2;
            numericUpDown1.BackColor = color2;

            label1.ForeColor = color3;
            label2.ForeColor = color3;
            label3.ForeColor = color3;
            label4.ForeColor = color3;
            checkedListBox1.ForeColor = color3;
            checkedListBox2.ForeColor = color3;
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
                button5.ForeColor = color3Light;
                button5.BackColor = color1Light;

                color1 = color1Dark;
                color2 = color2Dark;
                color3 = color3Dark;
            }
            else
            {
                button5.Text = "Dark mode";
                button5.ForeColor = color3Dark;
                button5.BackColor = color1Dark;

                color1 = color1Light;
                color2 = color2Light;
                color3 = color3Light;
            }
            darkMode = !darkMode;
            updateColors();
        }
    }
}
