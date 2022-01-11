using Microsoft.EntityFrameworkCore;

namespace RESTWithWebAPI.Models.Context
{
  public class SQLServerContext : DbContext
  {
    public SQLServerContext() { }
    public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }

    public DbSet<Person> People { get; set; }
  }
}