using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NotesLayerApp.Core.Dto;
using NotesLayerApp.Core.Entities;
using NotesLayerApp.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NotesLayerApp.Application.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public IdentityService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    public async Task<LoginResponse> LoginAsync(User user)
    {

        var existedUser = await _context.Users.FirstOrDefaultAsync(x=>x.UserName == user.UserName && x.PasswordHash == user.PasswordHash);

        if (existedUser != null)
        {
            var key = _configuration.GetSection("Identity:JwtKey").Value;

            var encKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Identity:JwtKey").Value));

            var userClaims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
            };

            var expires = DateTime.UtcNow.AddDays(1);

            var jwt = new JwtSecurityToken(
                claims: userClaims,
                expires: expires,
                signingCredentials: new SigningCredentials(encKey, SecurityAlgorithms.HmacSha256)
                );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new LoginResponse()
            {
                Success = true,
                Token = encodedJwt
            };
        }

        return new LoginResponse() { Success = false };
    }

    public async Task<LoginResponse> RegisterAsync(User user)
    {
        var existedUser = await _context.Users.FirstOrDefaultAsync(x=>x.UserName == user.UserName);

        if (existedUser == null)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new LoginResponse()
            {
                Success = true,
            };
        }

        return new LoginResponse() { Success = false, };
    }
}
