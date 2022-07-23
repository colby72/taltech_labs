using System;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {
            string command;
            do {
                Console.WriteLine("C Ceasar");
                Console.WriteLine("V Vigenere");
                Console.WriteLine("D Diffie-Hellman");
                Console.WriteLine("-----------------");
                Console.WriteLine("X Exit");

                command = Console.ReadLine();

                switch (command) {
                    case "C":
                      RunCeasar();
                      break;
                    case "V":
                      RunVigenere();
                      break;
                    case "D":
                      RunDH();
                      break;
                }
            } while (command!= "X");
        }

        static void RunCeasar() {
          string command;
          Console.WriteLine("E Encrypt");
          Console.WriteLine("D Decrypt");
          Console.WriteLine("----------");
          command = Console.ReadLine();
          switch (command) {
              case "E":
                  RunCeasarEncrypt();
                  break;
              case "D":
                  RunCeasarDecrypt();
                  break;
          }
        }

        static void RunVigenere() {
          string command;
          Console.WriteLine("E Encrypt");
          Console.WriteLine("D Decrypt");
          Console.WriteLine("----------");
          command = Console.ReadLine();
          switch (command) {
              case "E":
                  RunVigenereEncrypt();
                  break;
              case "D":
                  RunVigenereDecrypt();
                  break;
          }
        }

        static void RunDH() {
          string command;
          Console.WriteLine("E Encrypt");
          Console.WriteLine("D Decrypt");
          Console.WriteLine("----------");
          command = Console.ReadLine();
          switch (command) {
              case "E":
                  RunDHEncrypt();
                  break;
              case "D":
                  RunDHDecrypt();
                  break;
          }
        }

        static void RunCeasarEncrypt() {
            Console.WriteLine("Text to encrypt");
            Console.Write("> ");
            string plainText = Console.ReadLine()?.Trim().ToUpper() ?? "";

            Console.WriteLine("Amount to shift");
            Console.Write("> ");
            string shiftAmountText = Console.ReadLine();

            var shiftAmount = 0;
            if (int.TryParse(shiftAmountText, out shiftAmount)) {
                string encryptedtext = CeasarEncrypt(plainText, shiftAmount);
                Console.WriteLine("-------------");
                Console.WriteLine("Shift: " + shiftAmount);
                Console.WriteLine("Original: " + plainText);
                Console.WriteLine("Encrypted: " + encryptedtext);
                Console.WriteLine("-------------");
            }
            else {
                Console.WriteLine("Error : " + shiftAmountText + " is not a number");
            }
        }

        static void RunCeasarDecrypt() {
            Console.WriteLine("Text to decrypt");
            Console.Write("> ");
            string encryptedtext = Console.ReadLine()?.Trim().ToUpper() ?? "";

            Console.WriteLine("Amount to shift");
            Console.Write("> ");
            string shiftAmountText = Console.ReadLine();

            var shiftAmount = 0;
            if (int.TryParse(shiftAmountText, out shiftAmount)) {
                string plainText = CeasarDecrypt(encryptedtext, shiftAmount);
                Console.WriteLine("-------------");
                Console.WriteLine("Shift: " + shiftAmount);
                Console.WriteLine("Encrypted: " + encryptedtext);
                Console.WriteLine("Original: " + plainText);
                Console.WriteLine("-------------");
            }
            else {
                Console.WriteLine("Error : " + shiftAmountText + " is not a number");
            }
        }

        private static readonly char[] _alphabet = new char[] {
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        static string CeasarEncrypt(string plainText, int shiftAmount) {
            Console.WriteLine("Alphabet size: " + _alphabet.Length);

            string result = "";
            foreach (var letter in plainText)
            {
                var indexInAlphabet = Array.IndexOf(_alphabet, letter);
                indexInAlphabet = (indexInAlphabet + shiftAmount) % _alphabet.Length;
                Console.WriteLine(indexInAlphabet);
                result += _alphabet[indexInAlphabet];
            }

            return result;
        }

        static string CeasarDecrypt(string encrypted, int shiftAmount) {
            string result = "";
            foreach (var letter in encrypted) {
                var indexInAlphabet = Array.IndexOf(_alphabet, letter);
                indexInAlphabet = (indexInAlphabet - shiftAmount) % _alphabet.Length;

                while (indexInAlphabet < 0) {
                    indexInAlphabet += _alphabet.Length;
                }
                result += _alphabet[indexInAlphabet];
            }
            return result;
        }

        static void RunVigenereEncrypt() {
          Console.WriteLine("Text to encrypt :");
          Console.Write("> ");
          string codein = Console.ReadLine()?.Trim().ToUpper() ?? "";
          Console.WriteLine("Encryption key");
          Console.Write("> ");
          string key = Console.ReadLine();
          string cipher = vigenereEncrypt(codein, key);
          Console.WriteLine("-----------------------------");
          Console.WriteLine("Plain Text : " + codein);
          Console.WriteLine("Key text : " + key);
          Console.WriteLine("Encrypted text >> " + cipher);
          Console.WriteLine("-----------------------------");
        }

        static void RunVigenereDecrypt() {
          Console.WriteLine("Text to decrypt :");
          Console.Write("> ");
          string cipher = Console.ReadLine()?.Trim().ToUpper() ?? "";
          Console.WriteLine("Decryption key");
          Console.Write("> ");
          string key = Console.ReadLine();
          string text = vigenereDecrypt(cipher, key);
          Console.WriteLine("-----------------------------");
          Console.WriteLine("Encrypted Text : " + cipher);
          Console.WriteLine("Key text : " + key);
          Console.WriteLine("Decrypted text >> " + text);
          Console.WriteLine("-----------------------------");
        }

        static string vigenereEncrypt(string codein, string key) {
          var t = codein.Length;
          var k = key.Length;
          string cipher = "";

          int j = 0;
          int x = 0;

          while (j<t) {
            var let = codein[j];
            if (let!=' ') {
              x = Array.IndexOf(_alphabet, let) + Array.IndexOf(_alphabet, key[j%k]);
              Console.WriteLine((x+26)%_alphabet.Length);
              //Console.WriteLine("cipher " + cipher);
              cipher += _alphabet[(x+26)%_alphabet.Length];
            }
            else {
              cipher += " ";
            }
            j++;
          }
          return cipher;
        }

        static string vigenereDecrypt(string codein, string key) {
          var t = codein.Length;
          var k = key.Length;
          string text = "";

          int j = 0;
          int x = 0;

          while (j<t) {
            var let = codein[j];
            if (let!=' ') {
              x = Array.IndexOf(_alphabet, let) - Array.IndexOf(_alphabet, key[j%k]);
              text += _alphabet[x%26];
            }
            else {
              text += " ";
            }
            j++;
          }
          return text;
        }

        static void RunDHEncrypt() {
          int g, p, a, y;
          Console.Write("Enter G > ");
          var gt = Console.ReadLine();
          int.TryParse(gt, out g);
          Console.Write("Enter P > ");
          var pt = Console.ReadLine();
          int.TryParse(pt, out p);
          Console.Write("Enter private key > ");
          var at = Console.ReadLine();
          int.TryParse(at, out a);
          var x = Math.Pow(g, a) % p;
          Console.WriteLine("Generated key >> " + x);
          Console.Write("Enter distant generated key > ");
          var yt = Console.ReadLine();
          int.TryParse(yt, out y);
          var ka = Math.Pow(y, a) % p;
          Console.WriteLine("Generated secret key >> " + ka);
        }

        static void RunDHDecrypt() {
          Console.WriteLine("Diffie-Hellman decrypt !");
        }
    }
}
