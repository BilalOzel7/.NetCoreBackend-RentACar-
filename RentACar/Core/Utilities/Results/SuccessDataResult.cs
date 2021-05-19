using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{//OverLoad yaparak farklı seçenekelr oluştururuz.Veri yönetimi yaptığımız methodlarda kullanılırız.
   public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {

        }

        public SuccessDataResult(T data):base(data,true)
        {

        }

        public SuccessDataResult(string message):base(default,true,message)
        {

        }

        public SuccessDataResult():base(default,true)
        {

        }
    }
}
