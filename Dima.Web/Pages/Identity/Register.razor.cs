using Dima.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Identity;


public partial class RegisterPage : ComponentBase
{
    [Inject]
    public CookieAuthenticationStateProvider autState { get; set; } = null!;
    public MudForm MudForm { get; set; }
}