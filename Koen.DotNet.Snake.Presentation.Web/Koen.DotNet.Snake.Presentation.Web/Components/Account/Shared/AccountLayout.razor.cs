using Microsoft.AspNetCore.Components;

namespace Koen.DotNet.Snake.Presentation.Web.Components.Account.Shared;

public partial class AccountLayout
{
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [CascadingParameter] private HttpContext? HttpContext { get; set; }

    protected override void OnParametersSet()
    {
        if (HttpContext is null)
        {
            // If this code runs, we're currently rendering in interactive mode, so there is no HttpContext.
            // The identity pages need to set cookies, so they require an HttpContext. To achieve this we
            // must transition back from interactive mode to a server-rendered page.
            NavigationManager.Refresh(forceReload: true);
        }
    }
}