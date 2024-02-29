using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static public byte[] EncryptionFunc(byte[] message, byte[] key, byte[] iv) 
        {
            byte[] block = new byte[key.Length];
            byte[] result = new byte[message.Length];
            byte[] vec = new byte[iv.Length];
            Buffer.BlockCopy(iv, 0, vec, 0, vec.Length);

            for (int i = 0; i < result.Length / key.Length; i++) 
            { 
                Buffer.BlockCopy(message, i * key.Length, block, 0, key.Length);
                Buffer.BlockCopy(EncryptionFuncRecurent(block, key, vec), 0, vec, 0, vec.Length);
                Buffer.BlockCopy(vec, 0, result, i * key.Length, key.Length);
            }

            return result;
        }

        static public byte[] DecryptionFunc(byte[] cipher, byte[] key, byte[] iv)
        {
            byte[] block = new byte[key.Length];
            byte[] result = new byte[cipher.Length];
            byte[] vec = new byte[iv.Length];
            Buffer.BlockCopy(iv, 0, vec, 0, vec.Length);

            for (int i = 0; i < cipher.Length / key.Length; i++)
            {
                Buffer.BlockCopy(cipher, i * key.Length, block, 0, key.Length);
                Buffer.BlockCopy(EncryptionFuncRecurent(block, vec, key), 0, result, i * key.Length, key.Length);
                Buffer.BlockCopy(cipher, i * key.Length, vec, 0, vec.Length);
            }
            return result;
        }

        static private byte[] EncryptionFuncRecurent(byte[] block, byte[] key, byte[] p_iv)
        {
            for (int j = 0; j < key.Length; j++)
            {
                Buffer.SetByte(block, j, (byte)(block[j] ^ p_iv[j]));
            }
            if (key != p_iv) return EncryptionFuncRecurent(block, key, key);
            else return block;
        }

        static public byte[] NormalizeMessage(String mess, String k)
        {
            byte[] reader = new byte[mess.Length];
            byte[] message;
            int c = 0;
            int a; int b;
            if (mess.Length >= 4)
            {
                for (int i = 0; i < mess.Length - 4; i++)
                {
                    if (mess[i] == '0' && mess[i + 1] == 'x') // numb [48,57] and symb [65, 70]
                    {
                        if (((48 <= (int)mess[i + 2] && 57 >= (int)mess[i + 2]) || (65 <= (int)mess[i + 2] && 70 >= (int)mess[i + 2])))
                        {
                            if (((48 <= (int)mess[i + 3] && 57 >= (int)mess[i + 3]) || (65 <= (int)mess[i + 3] && 70 >= (int)mess[i])))
                            {
                                a = ((48 <= (int)mess[i + 2] && 57 >= (int)mess[i + 2])) ? (int)mess[i + 2] - 48 : (int)mess[i + 2] - 55;
                                b = ((48 <= (int)mess[i + 3] && 57 >= (int)mess[i + 3])) ? (int)mess[i + 3] - 48 : (int)mess[i + 3] - 55;
                                reader[c] = (byte)(a * 16 + b);
                                i += 3;
                            }
                        }
                    }
                    else {
                        reader[c] = (byte)mess[i];
                    }
                    c++;
                }
                reader[c] = (byte)mess[mess.Length - 4];
                c++;
                reader[c] = (byte)mess[mess.Length - 3];
                c++;
                reader[c] = (byte)mess[mess.Length - 2];
                c++;
                reader[c] = (byte)mess[mess.Length - 1];


                message = new byte[c + 1];
                Buffer.BlockCopy(reader, 0, message, 0, message.Length);
            }
            else message = Encoding.ASCII.GetBytes(mess);
            byte[] key = Encoding.ASCII.GetBytes(k);

            int scrap;
            scrap = key.Length - message.Length % key.Length;
             
            byte[] result = new byte[scrap + message.Length];
            Buffer.BlockCopy(message, 0, result, 0, message.Length);

            for (int i = 0; i < scrap; i++)
            {
                Buffer.BlockCopy("!".ToArray(), 0, result, message.Length + i, 1); // adding !
            }
            Buffer.BlockCopy(BitConverter.GetBytes(scrap), 0, result, result.Length - 1, 1); // adding scrapbyte

            return result;
        }

        static public string NormalizeOutPut(byte[] orig)
        {
            string s = string.Empty;
            char a, b;
            for (int i = 0; i < orig.Length; i++) {
                if ((int)orig[i] <= 31)
                {
                    a = (int)orig[i] / 16 > 9 ? (char)(55 + (int)orig[i] / 16) : (char)(48 + (int)orig[i] / 16);
                    b = (int)orig[i] % 16 > 9 ? (char)(55 + (int)orig[i] % 16) : (char)(48 + (int)orig[i] % 16);
                    s += "0x" + (char)a + (char)b;
                }
                else s += (char)((int)orig[i]);
            }

            return s;
        }

        static public byte[] ReadEncry(string mess)
        {
            byte[] reader = new byte[mess.Length];
            byte[] message;
            int c = 0;
            int a; int b;
            if (mess.Length >= 4)
            {
                for (int i = 0; i < mess.Length - 4; i++)
                {
                    if (mess[i] == '0' && mess[i + 1] == 'x') // numb [48,57] and symb [65, 70]
                    {
                        if (((48 <= (int)mess[i + 2] && 57 >= (int)mess[i + 2]) || (65 <= (int)mess[i + 2] && 70 >= (int)mess[i + 2])))
                        {
                            if (((48 <= (int)mess[i + 3] && 57 >= (int)mess[i + 3]) || (65 <= (int)mess[i + 3] && 70 >= (int)mess[i])))
                            {
                                a = ((48 <= (int)mess[i + 2] && 57 >= (int)mess[i + 2])) ? (int)mess[i + 2] - 48 : (int)mess[i + 2] - 55;
                                b = ((48 <= (int)mess[i + 3] && 57 >= (int)mess[i + 3])) ? (int)mess[i + 3] - 48 : (int)mess[i + 3] - 55;
                                reader[c] = (byte)(a * 16 + b);
                                i += 3;
                            }
                        }
                    }
                    else
                    {
                        reader[c] = (byte)mess[i];
                    }
                    c++;
                }
                reader[c] = (byte)mess[mess.Length - 4];
                c++;
                reader[c] = (byte)mess[mess.Length - 3];
                c++;
                reader[c] = (byte)mess[mess.Length - 2];
                c++;
                reader[c] = (byte)mess[mess.Length - 1];


                message = new byte[c + 1];
                Buffer.BlockCopy(reader, 0, message, 0, message.Length);
            }
            else message = Encoding.ASCII.GetBytes(mess);
            return message;
        }

        static public bool MooreSearch(byte[] sign, byte[] dec)
        {
            byte[] mor;
            int end;
            bool fl;


            int lf = 0;
            int count = 0;
            int[] indexe = new int[sign.Length / 2];
            indexe[0] = -2;
            for (byte i = 0; i < sign.Length; i++)
            {
                if (sign[i] == Encoding.Unicode.GetBytes("%")[0])
                {
                    count++;
                    indexe[count] = i - 1;
                }
            }

            for (int j = 1; j < count + 1; j++)
            {
                byte[] sign_part = new byte[indexe[j] + 1 - (indexe[j-1] + 2)];
                Buffer.BlockCopy(sign, indexe[j - 1] + 2, sign_part, 0, sign_part.Length);
                mor = MakeMooreTable(sign_part);
                end = sign_part.Length - 1;
                while (end <= dec.Length - 1)
                {
                    fl = true;
                    for (int i = 0; i < sign_part.Length; i++)
                    {
                        int mk = sign_part.Length - i - 1;
                        if (sign_part[sign_part.Length - i - 1] != dec[end - i])
                        {
                            end += GetByteInMoorTable(mor, dec[end - i]) != 0 ? GetByteInMoorTable(mor, dec[end - i]) : sign_part.Length;
                            fl = false;
                            break;
                        }
                    }
                    if (fl)
                    {
                        lf++;
                        break;
                    }
                }
            }
            return lf == count;
        }

        static private byte[] MakeMooreTable(byte[] sign) {
            byte[] result = new byte[sign.Length*2];
            bool fl = true;
            int j;
            for (int i = 0; i < sign.Length; i++)
            {
                j = 0;
                while (result[j] != 0)
                {
                    if (sign[i] == result[j])
                    {
                        fl = false;
                        break;
                    }
                    j+=2;
                }
                if (fl)
                {
                    result[j] = sign[i];
                    result[j + 1] = BitConverter.GetBytes(Math.Max(1, (sign.Length - i - 1)))[0];
                }
                else
                {
                    result[j] = sign[i];
                    result[j + 1] = BitConverter.GetBytes(Math.Max(1, (sign.Length - i - 1)))[0];
                }
            }
            return result;
        }

        static private byte GetByteInMoorTable(byte[] sign, byte ser)
        {
            for (int i = 0; i < sign.Length; i+=2) 
            { 
                if (ser == sign[i]) 
                {
                    return sign[i+1];
                }
            }
            return 0;
        }

        static public string SerchForKey(ulong bg, ulong end, byte[] sign, byte[] mess, byte[] iv)
        {
            String result = "";
            var name = Thread.CurrentThread.Name;
            byte[] tk = new byte[iv.Length];
            ulong c;
            bool fl;
            for (ulong i = bg; i < end; i++)
            {
                fl = true;
                c = i;
                for (int j = 1; j <= iv.Length; j++)
                {
                    tk[iv.Length - j] = (byte)(c % 256);
                    c /= 256;
                }

                for (int j = 0; j < iv.Length - 2; j++)
                {
                    for (int k = j + 1; k < iv.Length - 1; k++)
                    {
                        if (tk[j] == tk[k])
                        {
                            fl = false;
                            break;
                        }
                    }
                    if (!fl) break;
                }
                if (fl == true)
                {
                    if (Program.MooreSearch(sign, Program.DecryptionFunc(mess, tk, iv)))
                    {
                        result += Environment.NewLine + System.Text.Encoding.ASCII.GetString(tk, 0, tk.Length);
                    }
                }
                
            }
            return result;
        }
    }
}
