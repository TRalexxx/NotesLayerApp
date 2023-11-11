using Microsoft.AspNetCore.Http;

namespace NotesLayerApp.Core.Entities;

public class FileModel
{
    public string FileName { get; set; } = string.Empty;
    public IFormFile FormFile { get; set; } = default!;
}
