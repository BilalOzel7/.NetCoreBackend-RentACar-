using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{//
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)//60 dk sonra cache bellekten atılacak.
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();//ServiceTool u kullanarak hangi Cache i kullanacağımı belirliyorum.İlerde Redis de kullanabilirim
        }

        public override void Intercept(IInvocation invocation)
        {//key oluşturmak için parametreleri olusturuyoruz.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//ReflectedType namespace demektir. 
            var arguments = invocation.Arguments.ToList();//Methodun parametrelerini listeye çevir.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//Business.Abstract.ICarService.GetAll(Buraya key yazılır).
                                                                                                            //join birleştir demektir , ile. ?? ; var ise ilkini yoksa ikincisini ekle demektir.
            if (_cacheManager.IsAdd(key))//Bellekte daha önce böyle bir cache anahtarı var mi?
            {
                invocation.ReturnValue = _cacheManager.Get(key);//var ise al değeri
                return;
            }
            invocation.Proceed();//Methodu çalıştırmaya devam et 
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//Cache bellekte oluştur.
        }
    }
}
