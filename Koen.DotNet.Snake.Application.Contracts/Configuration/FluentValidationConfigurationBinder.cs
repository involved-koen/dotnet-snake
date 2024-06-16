using FluentValidation;
using Microsoft.Extensions.Configuration;

namespace Koen.DotNet.Snake.Application.Contracts.Configuration;

public static class FluentValidationConfigurationBinder
{
    public static TSection BindAndValidateConfiguration<TSection, TSectionValidator>(this IConfiguration configuration,
        string section) where TSection : class, new() where TSectionValidator : class, IValidator<TSection>, new()
    {
        var sectionObject = new TSection();
        configuration.Bind(section, sectionObject);

        var sectionValidator = new TSectionValidator();
        var sectionValidationResult = sectionValidator.Validate(sectionObject);

        if (sectionValidationResult.IsValid) return sectionObject;
        
        var messages = sectionValidationResult.Errors.Select(e => e.ErrorMessage);
        throw new InvalidOperationException(string.Join(", ", messages));
    }
}