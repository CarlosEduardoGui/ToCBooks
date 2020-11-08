using System;
using System.Security.Cryptography;
using System.Text;

namespace ToCBooks.App.Business.Validadores
{
    public class Criptografia
    {
        // Nossa frase secreta
        private static byte[] _chave = Encoding.UTF8.GetBytes("#ef");

        public string Encrypt(string texto)
        {
            using (var hashProvider = new MD5CryptoServiceProvider())
            {
                var encriptar = new TripleDESCryptoServiceProvider
                {
                    Mode = CipherMode.ECB,
                    Key = hashProvider.ComputeHash(_chave),
                    Padding = PaddingMode.PKCS7
                };

                using (var transforme = encriptar.CreateEncryptor())
                {
                    var dados = Encoding.UTF8.GetBytes(texto);
                    return Convert.ToBase64String(transforme.TransformFinalBlock(dados, 0, dados.Length));
                }
            }
        }

        public string Decrypt(string texto)
        {
            using (var hashProvider = new MD5CryptoServiceProvider())
            {
                var descriptografar = new TripleDESCryptoServiceProvider
                {
                    Mode = CipherMode.ECB,
                    Key = hashProvider.ComputeHash(_chave),
                    Padding = PaddingMode.PKCS7
                };

                using (var transforme = descriptografar.CreateDecryptor())
                {
                    var dados = Convert.FromBase64String(texto.Replace(" ", "+"));
                    return Encoding.UTF8.GetString(transforme.TransformFinalBlock(dados, 0, dados.Length));
                }
            }
        }
    }
}
