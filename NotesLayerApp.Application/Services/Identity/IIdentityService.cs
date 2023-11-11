using NotesLayerApp.Core.Dto;
using NotesLayerApp.Core.Entities;

namespace NotesLayerApp.Application.Services.Identity;

public interface IIdentityService
{
    Task<LoginResponse> RegisterAsync(User user);
    Task<LoginResponse> LoginAsync(User user);
}
