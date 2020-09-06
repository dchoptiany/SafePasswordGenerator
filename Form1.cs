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

            button1.ForeColor = textColor2;
            button1.BackColor = backgroundColor2;

            numericUpDown1.ForeColor = textColor2;
            numericUpDown1.BackColor = backgroundColor2;
            numericUpDown1.Minimum = 6;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
