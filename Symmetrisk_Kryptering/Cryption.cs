using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Symmetrisk_Kryptering
{
    internal class Cryption
    {
        SymmetricAlgorithm symmetricAlgorithm;
        public Cryption()
        {

        }

        public void SetSymmetric(SymmetricAlgorithm sa)
        {
            symmetricAlgorithm = sa;
            symmetricAlgorithm.GenerateKey();
            symmetricAlgorithm.GenerateIV();
        }

        public byte[] Encrypt(byte[] mess)
        {
            symmetricAlgorithm.Mode = CipherMode.CBC;
            symmetricAlgorithm.Padding = PaddingMode.PKCS7;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, this.symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(mess, 0, mess.Length);
            cs.FlushFinalBlock();
            return ms.ToArray();

        }

        public byte[] Decrypt(byte[] mess)
        {
            //Sets Ciphermode and paddingmode
            symmetricAlgorithm.Mode = CipherMode.CBC;
            symmetricAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] plaintext = new byte[mess.Length];
            MemoryStream ms = new MemoryStream(mess);
            CryptoStream cs = new CryptoStream(ms, this.symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(plaintext, 0, mess.Length);
            return plaintext;

        }
    }
}
