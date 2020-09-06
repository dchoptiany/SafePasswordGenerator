using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafePasswordGenerator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Generator
    {
        private int length;
        private char[] lowercase = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        private char[] uppercase = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        private char[] digit = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private char[] special = {'!', '@', '#', '$', '%', '^', '&', '*', '/', '-', '+', '='};

        public Generator(int _length)
        {
            length = _length;
        }

        public String generate(bool numbers, bool symbols)
        {
            String password = "";
            Random rnd = new Random();

            int key = 2 + (numbers ? 1 : 0) + (symbols ? 1 : 0);

            if(!numbers && symbols)
            {
                key = 3;

                for (int i = 0; i < length; i++)
                {
                    switch (rnd.Next(key))
                    {
                        case 0:
                            {
                                password += lowercase[rnd.Next(26)];
                                break;
                            }
                        case 1:
                            {
                                password += uppercase[rnd.Next(26)];
                                break;
                            }
                        case 2:
                            {
                                password += special[rnd.Next(12)];
                                break;
                            }
                    }
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    switch (rnd.Next(key))
                    {
                        case 0:
                            {
                                password += lowercase[rnd.Next(26)];
                                break;
                            }
                        case 1:
                            {
                                password += uppercase[rnd.Next(26)];
                                break;
                            }
                        case 2:
                            {
                                password += digit[rnd.Next(10)];
                                break;
                            }
                        case 3:
                            {
                                password += special[rnd.Next(12)];
                                break;
                            }
                    }
                }
            }

            return password;
        }
    }
}
