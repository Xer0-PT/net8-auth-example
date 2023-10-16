using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Net8AuthExample.Api;

public class MyAppDbContext : IdentityDbContext<User>
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
    {
    }
}