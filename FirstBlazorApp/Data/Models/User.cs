namespace FirstBlazorApp.Data.Models;

public class User
{
    public int UserId { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string? ConfirmPassword { get; set; }

    public string Source { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public short RoleId { get; set; }

    public int PubId { get; set; }

    public DateTime? HireDate { get; set; }
}