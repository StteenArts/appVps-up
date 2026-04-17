using appVps_up.Models;
using Microsoft.EntityFrameworkCore;

namespace appVps_up.Data;

public class MysqlDbContext : DbContext
{
    public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> users { get; set; }
}