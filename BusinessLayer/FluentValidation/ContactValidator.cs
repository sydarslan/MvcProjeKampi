using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapın");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapın");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("20 karakterden fazla değer girişi yapılamaz");

        }
    }
}
