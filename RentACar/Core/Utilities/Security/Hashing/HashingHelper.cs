using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt) //out dışarıya verilecek değer
        {
            //bu method verdiğimiz password e göre salt ve hash değeri oluşturuyor
            using (var hmac=new System.Security.Cryptography.HMACSHA512()) //sha512 algoritması
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //password u byte değerine çevirmek için parantez içi
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
            //gelen hash i doğrulama methodu.gelen password aynı method ile tekrar hash lenir ve önceki ile karşılaştırılır
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var computedHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//hesaplanan hash
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])  //girilen hash database deki hash e eşit değilse 
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}
