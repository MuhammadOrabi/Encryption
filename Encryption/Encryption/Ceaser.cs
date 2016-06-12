using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Ceaser
    {
        string alpha;
        string Alpha;
        string encrypted;
        string decrypted;
        public Ceaser()
        {
            alpha = "abcdefghijklmnopqrstuvwxyz";
            Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        public string enc (string text, int key)
        {
            encrypted = "";
            for (int i = 0 ; i < text.Length ; i++)
            {
                if(char.IsLower(text[i]))
                {
                    int tmp = 0;
                    for (int j = 0; j < alpha.Length; j++)
                    {
                        if (alpha[j] == text[i])
                        {
                            tmp = j + key;
                            while(tmp >= alpha.Length)
                            {
                                tmp = tmp - alpha.Length;
                            }
                            encrypted += alpha[tmp];
                            break;
                            
                        }
                    }
                }
                else if(char.IsUpper(text[i]))
                {
                    int tmp = 0;
                    for (int j = 0; j < Alpha.Length; j++)
                    {
                        if (Alpha[j] == text[i])
                        {
                            tmp = j + key;
                            while (tmp >= Alpha.Length)
                            {
                                tmp = tmp - Alpha.Length;
                            }
                            encrypted += Alpha[tmp];
                            break;
                        }
                    }
                }
                else
                {
                    encrypted += text[i];
                }
            }
            return encrypted;
        }
        public string dec(string text, int key)
        {
            decrypted = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLower(text[i]))
                {
                    int tmp = 0;
                    for (int j = 1; j < alpha.Length; j++)
                    {
                        if (alpha[j] == text[i])
                        {
                            tmp = j - key;
                            while (tmp < 0)
                            {
                                tmp = alpha.Length + tmp;
                            }
                            decrypted += alpha[tmp];
                            break;
                        }
                    }
                }
                else if (char.IsUpper(text[i]))
                {
                    int tmp = 0;
                    for (int j = 1; j < Alpha.Length; j++)
                    {
                        if (Alpha[j] == text[i])
                        {
                            tmp = j - key;
                            while (tmp < 0)
                            {
                                tmp = Alpha.Length + tmp;
                            }
                            decrypted += Alpha[tmp];
                            break;
                        }
                    }
                }
                else
                {
                    decrypted += text[i];
                }
            }
            return decrypted;
        } 
    }
}
