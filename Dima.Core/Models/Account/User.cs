namespace Dima.Core.Models.Account;

public class User
{
    //v1/identity/manage/info
    public string Email { get; set; } = String.Empty;
    public bool IsEmailConfirmed { get; set; }

    public Dictionary<string, string> Claims { get; set; } = [];
}