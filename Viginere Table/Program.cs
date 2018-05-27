namespace Viginere_Table
{
    using System;
    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            const string phrase = "TheLazyDogJumpedOverTheQuickFox";
            const string key = "hellohowareyou";

            Encrypt e = new Encrypt();
            e.Print();

            e.EncryptString(phrase, key);

            Console.Read();
        }
    }

    class Encrypt
    {
        char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                            'Y', 'Z'};

        char[,] table = new char[27,27];

        char[] cipher;

        public Encrypt()
        {
            for(int i = 1; i < 27; i++)
            {
                table[i, 0] = letters[i - 1];
                table[0, i] = letters[i - 1];
            }

            for (int y = 1; y < 27; y++)
            {
                for(int x = 1; x < 27; x++)
                {
                    int offset = y - 1;

                    if((x + offset) > 26)
                    {
                        int temp = x + offset - 26;
                        table[x, y] = letters[x - 1 + offset - 26];
                    } else
                    {
                        int temp = x + offset;
                        table[x, y] = letters[x - 1 + offset];
                    }
                }
            }
        }

        public void Print()
        {
            for(int y = 0; y < 27; y++)
            {
                Console.WriteLine();
                for(int x = 0; x < 27; x++)
                {
                    Console.Write(table[x, y] + " ");
                }
            }

            Console.WriteLine("\n\n");
        }

        public void EncryptString(string s, string key)
        {
            Console.WriteLine("The original string:");
            Console.WriteLine(s + "\n");

            Console.WriteLine("The key:");
            Console.WriteLine(key + "\n");

            s = s.ToUpper();
            key = key.ToUpper();

            char[] charArray = s.ToCharArray();
            char[] charKey = key.ToCharArray();
            cipher = new char[s.Length];

            int x = 0;
            int y = 0;

            int keyIndex = 0;
            int cipherIndex = 0;

            foreach (char c in charArray)
            {
                if (keyIndex > charKey.Length - 1)
                    keyIndex = 0;
                

                for(int i = 0; i < 26; i++)
                {
                    if (c == letters[i])
                    {
                        x = i + 1;

                        for(int j = 0; j < charKey.Length; j++)
                        {
                            if(letters[j] == charKey[keyIndex])
                            {
                                y = j;
                            }
                        }

                        cipher[cipherIndex] = table[x, y + 1];

                        Debug.WriteLine("X: " + x + " " + "Y: " + (y + 1) + " " +table[x, y + 1]);

                        cipherIndex++;
                    }                  
                }

                keyIndex++;
            }

            PrintCipher();
        }

        public void DecryptString()
        {
            Console.WriteLine("Decrypted:");

            foreach(char c in cipher)
            {
                
            }
        }

        private void PrintCipher()
        {
            Console.WriteLine("The Cipher:");

            foreach(char c in cipher)
            {
                Console.Write(c);
            }

            Console.WriteLine("\n");
        }
    }
}