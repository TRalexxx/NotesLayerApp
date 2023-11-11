namespace NotesLayerApp.Core.Dto;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public bool Success { get; set; }
}
