using System;

public class LoginRequest
{
	[Required]
	[EmailAddress]
	public string Email { get; set; } = string.Empty;

	[Required(ErrorMessage = "Не правильный пароль")]
	public string Password { get; set; } = string.Empty;

	public LoginRequest()
	{
	}
}
