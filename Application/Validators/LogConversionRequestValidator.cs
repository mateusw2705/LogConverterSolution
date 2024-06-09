using Domain.Request;
using FluentValidation;

namespace Application.Validators
{
    public class LogConversionRequestValidator : AbstractValidator<LogConversionRequest>
    {
        public LogConversionRequestValidator()
        {
            RuleFor(x => x.SourceUrl)
                .NotEmpty().WithMessage("A URL de origem não pode estar vazia.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("A URL de origem deve ser válida.");

            RuleFor(x => x.TargetPath)
                .NotEmpty().WithMessage("O caminho de destino não pode estar vazio.")
                .Must(path => !string.IsNullOrEmpty(path) && Path.IsPathFullyQualified(path))
                .WithMessage("O caminho de destino deve ser um caminho absoluto válido.");
        }
    }
}
