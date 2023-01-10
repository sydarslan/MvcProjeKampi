using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator() 
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı  adresi boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("100 karakterden fazla değer girişi yapılamaz");


        }
    }
}
