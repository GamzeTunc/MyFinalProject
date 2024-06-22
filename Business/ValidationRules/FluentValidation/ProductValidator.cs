using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product> //eklediğimiz paketten geliyo product için old belirtiyoruz
    { 
        //yapıcı metodun içine yazılır validationlar. // dtos lar için de yazılabilir
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();// ürün ismi boş olmaz
            RuleFor(p => p.ProductName).MinimumLength(2);//rulefor kural için p burada product ı temsil ediyo
            RuleFor(p => p.UnitPrice).NotEmpty(); //p için p nin ürün fiyatı boş olamaz diye okunur.
            RuleFor(p => p.UnitPrice).GreaterThan(0); // sıfırdan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //içecek kategorisi 10 tl ye eşit veya büyük olmalı
            //GreaterThanOrEqualTo gibi hazır olnmayanın metodun yazılması

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A Harfi ile başlamalı");  //ürünün ismi A ile başlamalı


        }

        private bool StartWithA(string arg) //true false döner
        {
            return arg.StartsWith("A");                    
        }
    }
}
