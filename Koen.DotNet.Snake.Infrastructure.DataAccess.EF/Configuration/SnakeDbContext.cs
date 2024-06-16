using Koen.DotNet.Snake.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Koen.DotNet.Snake.Infrastructure.DataAccess.EF.Configuration;

public class SnakeDbContext(DbContextOptions<SnakeDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
}