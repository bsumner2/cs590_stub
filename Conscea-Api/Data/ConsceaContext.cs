using Conscea_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Conscea_Api.Data;

public class ConsceaContext : DbContext {
    public ConsceaContext(DbContextOptions<ConsceaContext> opts) : base(opts) { return; }
    
    public DbSet<Account> Account { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().ToTable("Account");
    }


}