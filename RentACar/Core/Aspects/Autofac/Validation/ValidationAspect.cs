using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        //Aspect,methodun başında sonunda neresinde istersek çalışacak yapıdır.
        private Type _validatorType;
        public ValidationAspect(Type validatorType)                                      //bana validator type ı ver diyor
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))                     //validator type Ivalidator değilse hata ver.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)                            //methodınterfactor da on before methodu çalışsın
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];             //basetype ını bul (mesela CarValidator için Car) generic argümanlarından ilkini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);     //invocation method demek mesela add methodunun parametrelerine bak carvalidator daki entity parametrelerin bul eşleştir. mesela ikisinde de car parametresini
            foreach (var entity in entities)                                               //birden fazla olabilir her biri için gez 
            {
                ValidationTool.Validate(validator, entity); //her biri için validation tool u çalıştır
            }
        }
    }
}
