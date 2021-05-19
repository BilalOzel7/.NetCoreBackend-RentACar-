using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2); //carname min 2 karakter olmalıdır
            RuleFor(c => c.CarName).NotEmpty(); //carname boş olamaz
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100).When(c => c.CarId == 6); //günlük kiralama bedeli 100 den
                                                                                          //büyük olmalı carıd 6 olduğu zaman
            RuleFor(c => c.CarName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı"); //kendi metodumuzu yazıyoruz.must uymalı demek

        }

        private bool StartWithA(string arg) //arg gönderdiğimiz carname
        {
            return arg.StartsWith("A");
        }
    }
}
