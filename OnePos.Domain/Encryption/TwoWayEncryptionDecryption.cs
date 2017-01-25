using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace OnePos.Domain.Encryption
{
    public class TwoWayEncryptionDecryption
    {
        private static byte[] key = { 26, 200, 15, 11, 24, 26, 85, 45, 114, 184, 15, 162, 37, 119, 222, 209, 241, 24, 175, 194, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
        private static byte[] vector = { 146, 26, 191, 111, 26, 5, 113, 119, 231, 126, 221, 222, 79, 32, 111, 156 };
        private ICryptoTransform encryptor, decryptor;
        private UTF8Encoding encoder;

        public TwoWayEncryptionDecryption()
        {
            RijndaelManaged rm = new RijndaelManaged();
            encryptor = rm.CreateEncryptor(key, vector);
            decryptor = rm.CreateDecryptor(key, vector);
            encoder = new UTF8Encoding();
        }

        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
        }

        public string Decrypt(string encrypted)
        {
            try
            {
                return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }

        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, encryptor);
        }

        public byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, decryptor);
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}
