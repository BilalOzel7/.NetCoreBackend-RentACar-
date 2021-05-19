using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{

    //Attribute methodu çalıştığı zaman üstüne bak ,belli kurala uyan attribute ler var mı çalıştır.
    //Bu Attribute leri class lara metodlara birden fazla ekleyebilirsin.inherite edilen noktalarda da kullanılabilir.
    //Birden fazka kullanılmasının güzel yönü : Mesela loglamayı hem database e hem de bir file a loglayabilirsin aynı attribute ü farklı parametrelerle çağırabilirsin


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //öncelik ,sıralama yapmak istersek

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
