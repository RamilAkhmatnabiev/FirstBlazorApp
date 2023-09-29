using System.ComponentModel.DataAnnotations;

namespace FirstBlazorApp.Data.Models;

public abstract record BaseNamedRecord : BaseRecord
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
}