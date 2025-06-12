using FluentValidation;
using IBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    public class Validator : AbstractValidator<FilmPostDTO>
    {
        public Validator() {

            RuleFor(f => f.Tytul)
                .NotNull().WithMessage("Tytul jest wymagany")
                .MaximumLength(100).WithMessage("max dlug to 100 znak");
            RuleFor(f => f.Rok_wydania)
                .LessThan(2026).WithMessage("Rok musi nie być większy niż 2025");
            RuleFor(f => f.Gatunek)
                .NotNull().WithMessage("Gatunek jest wymagany")
                .Must(BeAValidGatunek).WithMessage("Gatunek musi być jednym z: Sci-Fi, historyczny, dramat");

        }
        private bool BeAValidGatunek(string gatunek)
        {
            var validGenres = new[] { "Sci-Fi", "historyczny", "dramat" };
            return validGenres.Contains(gatunek, StringComparer.OrdinalIgnoreCase);
        }
    }
}
