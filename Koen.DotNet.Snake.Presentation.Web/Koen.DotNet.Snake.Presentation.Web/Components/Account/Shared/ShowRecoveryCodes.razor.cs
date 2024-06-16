using Microsoft.AspNetCore.Components;

namespace Koen.DotNet.Snake.Presentation.Web.Components.Account.Shared;

public partial class ShowRecoveryCodes
{
    [Parameter] public string[] RecoveryCodes { get; set; } = [];

    [Parameter] public string? StatusMessage { get; set; }
}