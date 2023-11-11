namespace NotesLayerApp.Core.Dto;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}
