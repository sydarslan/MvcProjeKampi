using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı boş geçilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı boş geçilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanı boş geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karakter girişi yapın");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("50 karakterden fazla değer girişi yapılamaz");

        }
    }
}
