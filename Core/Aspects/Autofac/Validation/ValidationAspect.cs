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
    //ÖNEMLİ:İnvocation metod demek
    //Aspect: Methodun başında,sonunda, hata verdiğinde çalışacak yapıdır
    //Validation doğrulama olduğu için sadece methodun başında çalışılır o yüzden before yi kullanıyoz sadece
    public class ValidationAspect : MethodInterception //sen bir methodInterception sun diyor ve orada bulunan metodlardan hangisi kullanılacak ise aşağida o methodu çağırıp ezme işlemini yapıyoruz.
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Activator.CreateInstance(_validatorType); bu productreflatıon un bir instance sini örneğimi(new lemesini) oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //productvalidator un base classını bul AbstractValidator ve onun generic tipinin ilkini bul diyo bu da product burasını anlmak için  ProductValidator a bakabilirsin
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//ilgili metodun parametrelerini bul hangi metod için çalışıyorsa o metodun aldığı paremetrelerin "entityType" a  eşit olan yani product
            foreach (var entity in entities)// hepsini tek tek gez parametrelerin
            {
                ValidationTool.Validate(validator, entity); //ValidationTool u kullanarak validate et
            }
        }
    }
}
