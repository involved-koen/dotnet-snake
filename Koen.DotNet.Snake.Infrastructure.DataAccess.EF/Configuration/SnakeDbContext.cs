using Koen.DotNet.Snake.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Koen.DotNet.Snake.Infrastructure.DataAccess.EF.Configuration;

public class SnakeDbContext(DbContextOptions<SnakeDbContext> options)
    : IdentityDbContext<ApplicationUser>(options), ISnakeDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>()
            .Property(b => b.ConcurrencyStamp)
            .IsETagConcurrency();

        builder.Entity<ApplicationUser>() // ApplicationUser means the Identity user 'ApplicationUser : IdentityUser'
            .Property(b => b.ConcurrencyStamp)
            .IsETagConcurrency();
        
        builder.Entity<IdentityUserLogin<string>>()
            .HasKey(login => new { login.LoginProvider, login.ProviderKey });
        
        builder.Entity<IdentityUserRole<string>>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });
        
        builder.Entity<IdentityUserToken<string>>()
            .HasKey(token => new { token.UserId, token.LoginProvider, token.Name });
    }
}