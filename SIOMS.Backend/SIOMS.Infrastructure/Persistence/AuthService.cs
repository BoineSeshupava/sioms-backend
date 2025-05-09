using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SIOMS.Application.Interfaces;
using SIOMS.Domain.Entities;
using SIOMS.Domain.Shared;
using SIOMS.Infrastructure.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text; // Adjust based on your structure

public class AuthService : IAuthService
{
    private readonly SIOMSDbContext _context;
    private readonly JwtSettings _jwtSettings;
    public AuthService(SIOMSDbContext context, JwtSettings jwtSettings)
    {
        _context = context;
        _jwtSettings = jwtSettings;
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _context.Customers
            .Include(c => c.Role)
            .FirstOrDefaultAsync(x => x.Email == email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            throw new Exception("Invalid Credentials");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.CustomerId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.RoleName)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public async Task RegisterAsync(string name, string email, string password)
    {
        if (_context.Customers.Any(c => c.Email == email))
            throw new Exception("Email already registered");

        var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "Customer");
        if (role == null)
            throw new Exception("Default role 'Customer' not found");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        var customer = new Customer
        {
            CustomerId = Guid.NewGuid(),
            Name = name,
            Email = email,
            Password = hashedPassword,
            RoleId = role.RoleId,
        };

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }
}
