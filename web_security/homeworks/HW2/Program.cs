using System;
﻿using System.Collections.Generic;

namespace ConsoleApp {
  class Program {
      static void Main(string[] args) {
        string command;
        do {
          Console.WriteLine("\nT Test");
          Console.WriteLine("B Break code");
          Console.WriteLine("-----------------");
          Console.WriteLine("X Exit");
          Console.Write("> ");
          command = Console.ReadLine();
          switch (command) {
              case "T":
                RunTest();
                break;
              case "B":
                RunBreak();
                break;
              default:
                Console.WriteLine("Command incorrect !");
                break;
          }
        } while (command!="X");
      }

      static void RunTest() {
        Console.WriteLine("Hello RSA !");
        var p=19;
        var q=7;
        var n = p*q;
        var m = (p-1)*(q-1);

        // calculate e
        var e = 1;
        var g = 0;
        do {
          e++;
          g = gcd(m, e);
        } while (g!=1);
        Console.WriteLine(e + " is coprime to m=" + m);
        // calculate d
        var d = inverse(e, 1, m);
        if (d!=-1) {
          Console.WriteLine($"Public key : e={e}, n={n}");
          Console.WriteLine($"Private key : d={d}, m={m}");
        }

        // test
        encrypt(e, n);
        Console.WriteLine("-------------------------------\n");
        decrypt(d, n);
      }

      static void RunBreak() {
        var e = 0;
        var n = 0;
        Console.WriteLine("Enter public key:");
        Console.Write("E > ");
        var es = Console.ReadLine();
        Console.Write("N > ");
        var ns = Console.ReadLine();
        if (int.TryParse(es, out e) && int.TryParse(ns, out n)) {
          var b = breakCode3(e, n);
          if (b[0]==-1 && b.Length==1) {
            Console.WriteLine("Couldn't break this cipher :( Sorry!)");
          }
          else {
            var p = b[0];
            var q = b[1];
            var m = b[2];
            var d = inverse(e, 1, m);
            Console.WriteLine("Public key cracked:");
            Console.WriteLine($"Prime numbers : p={p}, q={q}");
            Console.WriteLine($"Private key : d={d}, m={m}");
          }
        }
        else {
          Console.WriteLine("Error: entered N and/or E is not an integer");
        }
      }

      // breaking while disposing of private key (not used)
      static int[] breakCode(int d0, int m0) {
        var p=3;
        var q=3;
        var m=0;
        do {
          do {
            if (isPrime(q)) {
              m = (p-1)*(q-1);
              if (verify(p, q, d0, m0)) {
                int[] pk = new int[] {p, q};
                return pk;
              }
            }
            q = q+2;
          } while (m<m0);
          p = p+2;
          q = p;
        } while (m<m0);
        return new int[] {-1, -1};
      }

      // breaking while disposing of public key (not working)
      static int[] breakCode2(int e0, int n0) {
        var p=3;
        var q=3;
        var n=0;
        var m=0;
        var e = 1;
        var g = 0;
        do {
          Console.WriteLine("p="+p);
          do {
            Console.WriteLine("q="+q);
            if (isPrime(q)) {
              n = p*q;
              if (n!=n0) {
                q = q+2;
                continue;
              }
              //Console.WriteLine("good n");
              m = (p-1)*(q-1);
              e = 1;
              g = 0;
              do {
                e++;
                g = gcd(m, e);
              } while (g!=1);
              if (e==e0) {
                int[] pk = new int[] {p, q, m};
                return pk;
              }
            }
            q = q+2;
          } while (n<=n0);
          p = p+2;
          q = p;
        } while (n<=n0);
        return new int[] {-1};
      }

      // breaking while disposing of public key (working and used)
      static int[] breakCode3(int e0, int n0) {
        //var p=3;
        //var q=3;
        var n=0;
        var m=0;
        var e = 1;
        var g = 0;
        var primes = generator(n0);
        foreach (int p in primes) {
          foreach (int q in primes) {
            n = p*q;
            if (n!=n0) {
              continue;
            }
            m = (p-1)*(q-1);
            e = 1;
            g = 0;
            do {
              e++;
              g = gcd(m, e);
            } while (g!=1);
            if (e==e0) {
              int[] pk = new int[] {p, q, m};
              return pk;
            }
          }
        }
        return new int[] {-1};
      }

      static bool verify(int p, int q, int d0, int m0) {
        var n = p*q;
        var m = (p-1)*(q-1);
        if (m!=m0) {
          return false;
        }
        var e = 1;
        var g = 0;
        do {
          e++;
          g = gcd(m, e);
        } while (g!=1);
        var d = inverse(e, 1, m);
        if (d!=d0) {
          return false;
        }
        return true;
      }

      static List<int> generator(int n) {
        var primes = new List<int>();
        primes.Add(2);
        var i = 3;
        while (i<=n) {
          if (isPrime(i)) {
            primes.Add(i);
          }
          i = i+2;
        }
        return primes;
      }

      static bool isPrime(int p) {
        var i=2;
        var s = Math.Sqrt(p);
        do {
          if (p%i==0) {
            return false;
          }
          i++;
        } while (i<=s);
        return true;
      }

      static void encrypt(int e, int n) {
        Console.WriteLine("--- RSA Encryption ---");
        var plainTextString = Console.ReadLine();
        if (plainTextString.Length>=1) {
          var plainText = (int) plainTextString[0];
          Console.WriteLine($"Char code is: {plainText}");
          var cipher = ((int)Math.Pow(plainText, e)) % n;
          while (cipher<0) {
            cipher = cipher+n;
          }
          Console.WriteLine($"Cipher is: {cipher}");
        }
      }

      static void decrypt(int d, int n) {
        Console.WriteLine("--- RSA Decryption ---");
        var decryptText = 0; // init
        var cipherString = Console.ReadLine();
        if (cipherString.Length>=1) {
          var cipher = (int) cipherString[0];
          Console.WriteLine($"Cipher code is: {cipher}");
          decryptText = ((int)Math.Pow(cipher, d)) % n;
          while (decryptText<0) {
            decryptText = decryptText+n;
          }
          Console.WriteLine($"Decrypt text is: {decryptText}");
        }
      }

      static int gcd(int a, int b) {
        if (a<b) {
          var tmp = a;
          a = b;
          b = tmp;
        }
        if (b==0) {
          return a;
        }
        return gcd(a%b, b);
      }

      static int inverse(int a, int b, int m) {
        if (gcd(a,m)!=1) {
          return -1;
        }
        var x = 1;
        while ((a*x)%m!=b) {
          x++;
        }
        return x;
      }
  }
}
