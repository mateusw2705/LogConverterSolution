using Domain.Request;
using FluentValidation.TestHelper;
using Application.Validators;

namespace TestProject1.Validators
{
    public class LogConversionRequestValidatorTests
    {
        private readonly LogConversionRequestValidator _validator;

        public LogConversionRequestValidatorTests()
        {
            _validator = new LogConversionRequestValidator();
        }

        [Fact]
        public void Should_Have_Error_When_SourceUrl_Is_Empty()
        {
            var request = new LogConversionRequest { SourceUrl = string.Empty, TargetPath = "C:\\output\\log.txt" };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(r => r.SourceUrl);
        }

        [Fact]
        public void Should_Have_Error_When_TargetPath_Is_Empty()
        {
            var request = new LogConversionRequest { SourceUrl = "https://example.com/log.txt", TargetPath = string.Empty };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(r => r.TargetPath);
        }

        [Fact]
        public void Should_Have_Error_When_SourceUrl_Is_Invalid()
        {
            var request = new LogConversionRequest { SourceUrl = "invalid-url", TargetPath = "C:\\output\\log.txt" };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(r => r.SourceUrl);
        }

        [Fact]
        public void Should_Have_Error_When_TargetPath_Is_Not_Fully_Qualified()
        {
            var request = new LogConversionRequest { SourceUrl = "https://example.com/log.txt", TargetPath = "output\\log.txt" };

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(r => r.TargetPath);
        }
    }
}
