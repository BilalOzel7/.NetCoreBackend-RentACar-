using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute 
    {
        //Alttaki methodlar boş hangisini çalıştırırsak o çalışacak
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)//invocation method demek
        {
            var isSuccess = true;
            OnBefore(invocation);//methodun başında
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//hata alınca
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//başarılı olunca
                }
            }
            OnAfter(invocation);//metod dan sonra
        }
    }
}
