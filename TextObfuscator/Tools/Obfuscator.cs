using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextObfuscator.Tools
{
    public static class Obfuscator
    {
        public class ObfuscationConfig
        {
            public string[] Filters;
            public bool ObfuscateEmails;
            public char ObfuscationChar;

            public ObfuscationConfig(string[] filters, bool obfuscateEmails, char obfuscationChar = '▓')
            {
                Filters = filters;
                ObfuscateEmails = obfuscateEmails;
                ObfuscationChar = obfuscationChar;
            }
        }

        public static char[] AvailableObfuscationChars = "▓▒░█■".ToCharArray();

        public static string Obfuscate(ObfuscationConfig config, string text)
        {
            string obfuscated = "";
            string[] split = text.Split(' '); // Split the string

            if(config.ObfuscateEmails)
            {
                for (int i = 0; i < split.Length; i++)
                {
                    if(split[i].ToCharArray().Contains('@'))
                    {
                        split[i] = RepeatChar(config.ObfuscationChar, split[i].Length);
                    }
                }
            }

            for (int i = 0; i < config.Filters.Length; i++)
            {
                for (int j = 0; j < split.Length; j++)
                {
                    if(split[j].Contains(config.Filters[i]))
                    {
                        split[j] = RepeatChar(config.ObfuscationChar, split[j].Length);
                    }
                }
            }

            for (int i = 0; i < split.Length; i++)
            {
                obfuscated += split[i] + " ";
            }

            return obfuscated.TrimEnd();
        }

        public static string RepeatChar(char c, int r)
        {
            string repeated = "";

            for (int i = 0; i < r; i++)
            {
                repeated += c;
            }

            return repeated;
        }
    }
}
