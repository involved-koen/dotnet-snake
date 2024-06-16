using Microsoft.AspNetCore.Components;

namespace Koen.DotNet.Snake.Presentation.Web.Components.Account.Pages.Manage;

public partial class PersonalData
{
    [Inject] private IdentityUserAccessor UserAccessor { get; set; } = null!;

    [CascadingParameter] private HttpContext HttpContext { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _ = await UserAccessor.GetRequiredUserAsync(HttpContext);
    }
}