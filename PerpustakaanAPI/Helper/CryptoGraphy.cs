using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PerpustakaanAPI.Helper
{
    public class Cryptography
    {
       
        private static string _keyword = "abcdefghijklmnopqrstuvwxyz";

        public string Encrypt(string plainText)
        {
            string RetVal = "";
            
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(_keyword));
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = key;
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            byte[] bytes = uTF8Encoding.GetBytes(plainText);
            try
            {
                ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
                byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
                string returnObject = Convert.ToBase64String(inArray);
                RetVal = returnObject;
            }
            catch (Exception expr_9B)
            {
                
            }
            finally
            {
                mD5CryptoServiceProvider.Dispose();
                tripleDESCryptoServiceProvider.Dispose();
            }
            
            return RetVal;
        }

        public string Decrypt(string stringToDecrypt)
        {
            string RetVal = "";
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(_keyword));
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = key;
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            byte[] array = Convert.FromBase64String(stringToDecrypt);
            try
            {
                ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
                byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
                string @string = uTF8Encoding.GetString(bytes);
                RetVal = @string;
            }
            catch (Exception expr_9B)
            {
            }
            finally
            {
                mD5CryptoServiceProvider.Dispose();
                tripleDESCryptoServiceProvider.Dispose();
            }
            return RetVal;
        }
    }
}
