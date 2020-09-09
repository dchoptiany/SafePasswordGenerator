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
        private const String lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const String uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const String digit = "0123456789";
        private const String special = "!@#$%^&*/-+=";

        public Generator(int _length)
        {
            length = _length;
        }

        public String generate(bool numbers, bool symbols)
        {
            String password;
            Random rnd = new Random();
            String characters = lowercase + uppercase;

            if(numbers)
            {
                characters += digit;
            }

            if(symbols)
            {
                characters += special;
            }

            do
            {
                password = "";

                for(int i = 0; i < length; i++)
                {
                    password += characters[rnd.Next(characters.Length)];
                }
            } while(!isValid(password, numbers, symbols));

            return password;
        }

        private bool isValid(String password, bool numbers, bool symbols)
        {
            bool lower = false;
            bool upper = false;
            bool dig = !numbers;
            bool spec = !symbols;

            for (int i = 0; i < length; i++)
            {
                if (!lower && lowercase.Contains(password[i]))
                {
                    lower = true;
                }

                if (!upper && uppercase.Contains(password[i]))
                {
                    upper = true;
                }

                if (!dig && digit.Contains(password[i]))
                {
                    dig = true;
                }

                if (!spec && special.Contains(password[i]))
                {
                    spec = true;
                }
            }

            return lower && upper && dig && spec;
        }
    }
}
