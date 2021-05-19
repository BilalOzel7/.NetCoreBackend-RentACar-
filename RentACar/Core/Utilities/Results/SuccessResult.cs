using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{//Overload yaparak farklı seçenekler oluşturabiliriz.Void Methodlarda kullanırız
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message)
        {

        }

        public SuccessResult() : base(true)
        {

        }
    }
}
