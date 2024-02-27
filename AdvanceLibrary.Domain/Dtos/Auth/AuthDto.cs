﻿namespace AdvanceLibrary.Domain.Dtos.Auth;
public class AuthDto
{
    public string Message { get; set; }
    public string Username { get; set; }
    public bool IsAuthenticated { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public DateTime ExpiresOn { get; set; }
}
