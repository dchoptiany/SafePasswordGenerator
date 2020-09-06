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
        public Form1()
        {
            InitializeComponent();

            Color backgroundColor1 = Color.FromArgb(247, 236, 225);
            Color backgroundColor2 = Color.FromArgb(90, 167, 90);
            Color textColor1 = Color.FromArgb(35, 27, 30);
            Color textColor2 = Color.White;

            BackColor = backgroundColor1;

            label1.ForeColor = textColor1;
            label2.ForeColor = textColor1;

            checkedListBox1.ForeColor = textColor1;
            checkedListBox1.BackColor = backgroundColor1;
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(1, true);
            checkedListBox1.SelectionMode = SelectionMode.None;

            checkedListBox2.ForeColor = textColor1;
            checkedListBox2.BackColor = backgroundColor1;
            checkedListBox2.SetItemChecked(0, true);
            checkedListBox2.SetItemChecked(1, true);

            button1.ForeColor = textColor2;
            button1.BackColor = backgroundColor2;

            button3.ForeColor = textColor2;
            button3.BackColor = backgroundColor2;
            button3.Enabled = false;

            numericUpDown1.ForeColor = textColor2;
            numericUpDown1.BackColor = backgroundColor2;
            numericUpDown1.Minimum = 6;
            numericUpDown1.Maximum = 32;
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
            System.Windows.Forms.Clipboard.SetText(maskedTextBox1.Text);
        }
    }
}
