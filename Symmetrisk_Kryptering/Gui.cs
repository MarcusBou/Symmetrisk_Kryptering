using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Symmetrisk_Kryptering
{
    internal class Gui
    {
        public void start()
        {
            Cryption cryption = new Cryption();
            while (true)
            {
                bool possible = true;
                string algorhytmChoosen = "";
                Console.Clear();
                Console.Write("Message to be Crypto: ");
                string message = Console.ReadLine();
                Console.WriteLine("1. DES");
                Console.WriteLine("2. TripleDES");
                Console.WriteLine("3. AES");
                Console.WriteLine("4. RC2");
                Console.WriteLine("Choose Crypto Algorhytm: ");
                char cryptoAlgorhytm = Console.ReadKey().KeyChar;
                switch (cryptoAlgorhytm)
                {
                    case '1':
                        cryption.SetSymmetric(DES.Create());
                        algorhytmChoosen = "DES";
                        break;
                    case '2':
                        cryption.SetSymmetric(TripleDES.Create());
                        algorhytmChoosen = "TripleDES";
                        break;
                    case '3':
                        cryption.SetSymmetric(Aes.Create());
                        algorhytmChoosen = "AES";
                        break;
                    case '4':
                        cryption.SetSymmetric(Aes.Create());
                        algorhytmChoosen = "RC2";
                        break;
                    default:
                        possible = false;
                        break;
                }
                Console.Clear();
                if (possible)
                {
                    byte[] cryptet = cryption.Encrypt(Encoding.ASCII.GetBytes(message));
                    byte[] decryptet = cryption.Decrypt(cryptet);
                    Console.WriteLine("Algorhytm choosen: " + algorhytmChoosen);
                    Console.WriteLine("Original text: " + message);
                    Console.WriteLine("Encrypted text: " + Convert.ToBase64String(cryptet));
                    Console.WriteLine("Decrypted text: " + Encoding.UTF8.GetString(decryptet));
                }
                else{
                    Console.WriteLine("\nNot a valid encryption algorhitm selected");
                }
                Console.ReadKey();
            }
        }
    }
}
