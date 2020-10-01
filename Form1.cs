using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.IO;

namespace SafePasswordGenerator
{
    public partial class Form1 : Form
    {
        private bool darkMode = true;
        private bool exportButton = false;

        private Color color1;
        private Color color2;
        private Color color3;
        private readonly Color color4 = Color.White;

        private readonly Color color1Dark = Color.FromArgb(30, 39, 46);
        private readonly Color color2Dark = Color.FromArgb(72, 84, 96);
        private readonly Color color3Dark = Color.FromArgb(210, 218, 226);

        private readonly Color color1Light = Color.FromArgb(210, 218, 226);
        private readonly Color color2Light = Color.FromArgb(5, 196, 107);
        private readonly Color color3Light = Color.FromArgb(30, 39, 46);

        private readonly PrivateFontCollection pfc;
        private readonly Font password;
        private readonly Font smallText;
        private readonly Font regularText;
        private readonly Font boldTitle;

        private Image closeIcon;
        private Image minimizeIcon;

        private readonly Image closeIconDark = Image.FromFile("..\\..\\Resources\\Images\\closeIconDark.png");
        private readonly Image minimizeIconDark = Image.FromFile("..\\..\\Resources\\Images\\minimizeIconDark.png");

        private readonly Image closeIconLight = Image.FromFile("..\\..\\Resources\\Images\\closeIconLight.png");
        private readonly Image minimizeIconLight = Image.FromFile("..\\..\\Resources\\Images\\minimizeIconLight.png");

        private readonly SaveFileDialog sfd;

        public Form1()
        {
            InitializeComponent();

            darkMode = File.ReadAllLines("..\\..\\dark.txt")[0] == "True";

            pfc = new PrivateFontCollection();
            pfc.AddFontFile("..\\..\\Resources\\Fonts\\DejaVuSans.ttf");
            pfc.AddFontFile("..\\..\\Resources\\Fonts\\Poppins-Regular.ttf");

            password = new Font(pfc.Families[0], 15.75f, FontStyle.Regular);
            smallText = new Font(pfc.Families[1], 9.75f, FontStyle.Regular);
            regularText = new Font(pfc.Families[1], 12f, FontStyle.Regular);
            boldTitle = new Font(pfc.Families[1], 27.75f, FontStyle.Bold);

            maskedTextBox1.Font = password;
            label3.Font = smallText;
            label4.Font = smallText;
            label5.Font = smallText;
            label7.Font = smallText;
            button5.Font = smallText;
            button1.Font = regularText;
            button3.Font = regularText;
            button6.Font = regularText;
            button8.Font = regularText;
            label2.Font = regularText;
            label6.Font = regularText;
            label8.Font = regularText;
            label9.Font = regularText;
            numericUpDown1.Font = regularText;
            numericUpDown2.Font = regularText;
            checkedListBox1.Font = regularText;
            checkedListBox2.Font = regularText;
            label1.Font = boldTitle;

            button5_Click(null, null);

            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button4.BackgroundImageLayout = ImageLayout.Zoom;

            button1.ForeColor = color4;
            button3.ForeColor = color4;
            numericUpDown1.ForeColor = color4;
            numericUpDown2.ForeColor = color4;

            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(1, true);
            checkedListBox1.SelectionMode = SelectionMode.None;

            checkedListBox2.SetItemChecked(0, true);
            checkedListBox2.SetItemChecked(1, true);

            button3.Enabled = false;
            label5.Visible = false;

            numericUpDown1.Minimum = 6;
            numericUpDown1.Maximum = 32;

            button8.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown2.Minimum = 1;

            sfd = new SaveFileDialog
            {
                InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\Desktop",
                Title = "Choose location",
                CheckFileExists = false,
                CheckPathExists = true,
                DefaultExt = "txt",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
        }

        private void updateColors()
        {
            BackColor = color1;

            checkedListBox1.BackColor = color1;
            checkedListBox2.BackColor = color1;

            button1.BackColor = color2;
            button3.BackColor = color2;
            button6.BackColor = color2;
            button8.BackColor = color2;

            numericUpDown1.BackColor = color2;
            numericUpDown2.BackColor = color2;

            label1.ForeColor = color3;
            label2.ForeColor = color3;
            label3.ForeColor = color3;
            label4.ForeColor = color3;
            label5.ForeColor = color3;
            label6.ForeColor = color3;
            label7.ForeColor = color3;
            label8.ForeColor = color3;

            checkedListBox1.ForeColor = color3;
            checkedListBox2.ForeColor = color3;

            button2.BackgroundImage = closeIcon;
            button4.BackgroundImage = minimizeIcon;
        }

        private void calculateSafetyRate()
        {
            if (checkedListBox2.GetItemChecked(0) && checkedListBox2.GetItemChecked(1))
            {
                if (numericUpDown1.Value < 8)
                {
                    label9.Text = "Very weak";
                    label9.ForeColor = Color.Red;
                }
                else if (numericUpDown1.Value < 9)
                {
                    label9.Text = "Average";
                    label9.ForeColor = Color.Orange;
                }
                else if (numericUpDown1.Value < 10)
                {
                    label9.Text = "Good";
                    label9.ForeColor = Color.GreenYellow;
                }
                else if (numericUpDown1.Value < 11)
                {
                    label9.Text = "Very good";
                    label9.ForeColor = Color.Green;
                }
                else
                {
                    label9.Text = "Extremely safe";
                    label9.ForeColor = Color.DarkGreen;
                }
            }
            else if (checkedListBox2.GetItemChecked(0) || checkedListBox2.GetItemChecked(1))
            {
                if (numericUpDown1.Value < 9)
                {
                    label9.Text = "Very weak";
                    label9.ForeColor = Color.Red;
                }
                else if (numericUpDown1.Value < 10)
                {
                    label9.Text = "Average";
                    label9.ForeColor = Color.Orange;
                }
                else if (numericUpDown1.Value < 12)
                {
                    label9.Text = "Good";
                    label9.ForeColor = Color.GreenYellow;
                }
                else if (numericUpDown1.Value < 13)
                {
                    label9.Text = "Very good";
                    label9.ForeColor = Color.Green;
                }
                else
                {
                    label9.Text = "Extremely safe";
                    label9.ForeColor = Color.DarkGreen;
                }
            }
            else
            {
                if (numericUpDown1.Value < 9)
                {
                    label9.Text = "Very weak";
                    label9.ForeColor = Color.Red;
                }
                else if (numericUpDown1.Value < 12)
                {
                    label9.Text = "Average";
                    label9.ForeColor = Color.Orange;
                }
                else if (numericUpDown1.Value < 13)
                {
                    label9.Text = "Good";
                    label9.ForeColor = Color.GreenYellow;
                }
                else if (numericUpDown1.Value < 14)
                {
                    label9.Text = "Very good";
                    label9.ForeColor = Color.Green;
                }
                else
                {
                    label9.Text = "Extremely safe";
                    label9.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = Generator.generate(checkedListBox2.GetItemChecked(0), checkedListBox2.GetItemChecked(1), Decimal.ToInt32(numericUpDown1.Value));
            button3.Enabled = true;
            label5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("..\\..\\dark.txt", (!darkMode).ToString());
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(maskedTextBox1.Text);
            label5.Visible = true;
        }

        private void maskedTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            button3_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "G")
            {
                button1_Click(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(darkMode)
            {
                button5.Text = "Light mode";
                button5.ForeColor = color3Light;
                button5.BackColor = color1Light;

                closeIcon = closeIconLight;
                minimizeIcon = minimizeIconLight;

                color1 = color1Dark;
                color2 = color2Dark;
                color3 = color3Dark;
            }
            else
            {
                button5.Text = "Dark mode";
                button5.ForeColor = color3Dark;
                button5.BackColor = color1Dark;

                closeIcon = closeIconDark;
                minimizeIcon = minimizeIconDark;

                color1 = color1Light;
                color2 = color2Light;
                color3 = color3Light;
            }
            darkMode = !darkMode;
            updateColors();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!exportButton)
            {
                button1.Visible = false;
                button3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                maskedTextBox1.Visible = false;

                button6.Text = "Generate one";
                button8.Visible = true;
                numericUpDown2.Visible = true;
                label6.Visible = true;
                exportButton = true;
            }
            else
            {
                button1.Visible = true;
                button3.Visible = true;
                label4.Visible = true;
                maskedTextBox1.Visible = true;

                button6.Text = "Generate to file";
                button8.Visible = false;
                numericUpDown2.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                exportButton = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                string[] passwords = new string[Decimal.ToInt32(numericUpDown2.Value)];
                string path = sfd.FileName;

                for (int i = 0; i < numericUpDown2.Value; i++)
                {
                    passwords[i] = Generator.generate(checkedListBox2.GetItemChecked(0), checkedListBox2.GetItemChecked(1), Decimal.ToInt32(numericUpDown1.Value));
                }

                File.WriteAllLines(path, passwords);

                label7.Visible = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            calculateSafetyRate();
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            calculateSafetyRate();
        }
    }
}
