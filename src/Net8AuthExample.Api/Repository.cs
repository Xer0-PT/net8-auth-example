using Microsoft.EntityFrameworkCore;

namespace Net8AuthExample.Api;

public class Repository
{
    private readonly MyAppDbContext _context;

    public Repository(MyAppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserAsync(string name) => await _context.Users.FirstOrDefaultAsync(x => x.UserName == name);
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}