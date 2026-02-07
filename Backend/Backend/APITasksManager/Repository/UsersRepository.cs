using Backend.APITasksManager.IRepository;
using Backend.APITasksManager.Requests;
using Backend.APITasksManager.Responses;
using Backend.Data;
using Backend.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Backend.APITasksManager.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UsersRepository(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<RegisterUserResponse> RegisterUser(CreateUserRequest request)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == request.Username && u.Active == true);

            if (existingUser != null)
            {
                return new RegisterUserResponse()
                {
                    UserId = 0,
                    Message = "User already exist"
                };
            }

            string encrypted = BCrypt.Net.BCrypt.HashPassword(request.Password);

            Users newUser = new Users
            {
                Username = request.Username,
                Password = encrypted,
                Active = true,
                CreatedAt = DateTime.Now
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            // Implement user registration logic here
            return new RegisterUserResponse()
            {
                UserId = newUser.Id,
                Message = "Success"
            };
        }

        public async Task<LoginResponse> Login(CreateUserRequest request)
        {
            // validar si existe el usuario
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == request.Username && u.Active == true);

            if (user == null)
            {
                return new LoginResponse()
                {
                    UserId = 0,
                    Message = "User does not exist"
                };
            }

            bool decifred = BCrypt.Net.BCrypt.Verify(request.Password.ToString(), user.Password.ToString());

            if (!decifred)
            {
                return new LoginResponse()
                {
                    UserId = 0,
                    Message = "Invalid password"
                };
            }
    
            user.LastLogin = DateTime.Now;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            user.Password = null;

            // Implement user login logic here
            return new LoginResponse()
            {
                UserId = user.Id,
                Message = "Success",
                Token = GenerateJwt(user)
            };
        }

        private string GenerateJwt(Users user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username.ToString())
                },
                expires: DateTime.Now.AddMinutes(
                    int.Parse(_configuration["Jwt:ExpireMinutes"])
                ),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
