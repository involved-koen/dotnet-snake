using FluentValidation;

namespace Koen.DotNet.Snake.Infrastructure.DataAccess.EF.Configuration;

public class CosmosDbSettingsValidator : AbstractValidator<CosmosDbSettings>
{
    public CosmosDbSettingsValidator()
    {
        RuleFor(x => x.Endpoint).NotEmpty();
        RuleFor(x => x.Key).NotEmpty();
        RuleFor(x => x.Database).NotEmpty();
    }
}