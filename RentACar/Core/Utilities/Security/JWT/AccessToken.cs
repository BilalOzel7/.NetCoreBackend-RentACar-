using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
   public class AccessToken
    {//Kullanıcıya verilen jeton gibi , erişim anahtarı.bu jetonda senin token ın bu ve erişim bitiş zamanını veriyoruz.
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
