using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)//İlgli method da bu blok u çalıştır.(Intercept)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();//methodu çalıştır
                    transactionScope.Complete();//sorun yok ise bitir.
                }
                catch (System.Exception)
                {
                    transactionScope.Dispose();//Eğer işlem adımlarında  hata var ise işlemin hepsini iptal et.
                    throw;
                }
            }
        }
    }
}
