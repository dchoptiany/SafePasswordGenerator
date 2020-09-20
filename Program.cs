using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;

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
        private const string lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string digit = "0123456789";
        private const string special = "!@#$%^&*/-+=";

        public Generator()
        {
        }

        public int next(int max)
        {
            using(var rng = new RNGCryptoServiceProvider())
            {
                var data = new byte[4];
                rng.GetBytes(data);
                return Math.Abs(BitConverter.ToInt32(data, startIndex: 0)) % max;
            }
        }

        public string generate(bool numbers, bool symbols, int length)
        {
            StringBuilder password = new StringBuilder();
            string chars = characters;

            if(numbers)
            {
                chars += digit;
            }

            if(symbols)
            {
                chars += special;
            }

            do
            {
                password.Clear();
                for(int i = 0; i < length; i++)
                {
                    password.Append(chars[next(chars.Length)]);
                }
            } while(!isValid(password.ToString(), numbers, symbols));

            return password.ToString();
        }

        private bool isValid(string password, bool numbers, bool symbols)
        {
            bool lower = false;
            bool upper = false;
            bool dig = !numbers;
            bool spec = !symbols;

            for (int i = 0; i < password.Length; i++)
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
