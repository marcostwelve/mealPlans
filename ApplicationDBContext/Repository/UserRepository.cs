using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Model.Dto.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository.Repository.IUserRepository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDBContext _context;

    public UserRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task AddAsync(User user)
    {
         await _context.Users.AddAsync(user);
         await SaveAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
