using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models.Auth;

public class LoginViewModel
{
    [Required(ErrorMessage ="Username is required!")]
    public string Username { get; set; } = default!;

    [Required(ErrorMessage ="Password is required!")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;
}
