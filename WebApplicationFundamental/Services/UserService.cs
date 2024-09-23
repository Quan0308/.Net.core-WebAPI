using DataService;
using DataService.Entities;
using Microsoft.EntityFrameworkCore;
using DataService.Models;

namespace WebApplicationFundamental.Services;

public class UserService(ApplicationContext context)
{
    public async Task CreateUser(CreateUserAccount user)
    {
        try {
            // Check if user already exists
            var existingUser = await context.User.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }
            
            // Create new user
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
            
            context.User.Add(newUser);
            await context.SaveChangesAsync();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
    
}