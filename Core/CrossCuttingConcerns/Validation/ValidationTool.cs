using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //IValidator bunu kullanıyoruz çünkü bizim kurallarımız ProductValidator da ve o da bir IValidator
                                   //doğrulama kodlarının olduğu class,doğrulanacak class
        public static void Validate(IValidator validator,object entity) //object hepsinin babası dto da olur ** entity de object tipinde parametre oluyor
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context); //IValidator un Validate metodunu (hazır) kullanarak doğrumu iye baktık
            if (!result.IsValid) //geçersizse
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
