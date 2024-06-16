using Koen.DotNet.Snake.Core.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;

namespace Koen.DotNet.Snake.Presentation.Web.Components.Account.Pages.Manage;

public partial class TwoFactorAuthentication
{
    [Inject] private UserManager<ApplicationUser> UserManager { get; set; } = null!;
    [Inject] private SignInManager<ApplicationUser> SignInManager { get; set; } = null!;
    [Inject] private IdentityUserAccessor UserAccessor { get; set; } = null!;
    [Inject] private IdentityRedirectManager RedirectManager { get; set; } = null!;

    private bool _canTrack;
    private bool _hasAuthenticator;
    private int _recoveryCodesLeft;
    private bool _is2FaEnabled;
    private bool _isMachineRemembered;

    [CascadingParameter] private HttpContext HttpContext { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var user = await UserAccessor.GetRequiredUserAsync(HttpContext);
        _canTrack = HttpContext.Features.Get<ITrackingConsentFeature>()?.CanTrack ?? true;
        _hasAuthenticator = await UserManager.GetAuthenticatorKeyAsync(user) is not null;
        _is2FaEnabled = await UserManager.GetTwoFactorEnabledAsync(user);
        _isMachineRemembered = await SignInManager.IsTwoFactorClientRememberedAsync(user);
        _recoveryCodesLeft = await UserManager.CountRecoveryCodesAsync(user);
    }

    private async Task OnSubmitForgetBrowserAsync()
    {
        await SignInManager.ForgetTwoFactorClientAsync();

        RedirectManager.RedirectToCurrentPageWithStatus(
            "The current browser has been forgotten. When you login again from this browser you will be prompted for your 2fa code.",
            HttpContext);
    }
}