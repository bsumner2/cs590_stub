using BulletinBoard_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard_Api.Data;

public class BulletinBoardContext : DbContext {
    public BulletinBoardContext(DbContextOptions<BulletinBoardContext> opts) : base(opts) { return; }
    public DbSet<Post> Post { get; set; }
    public DbSet<Account> Account { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().ToTable("Post");
        modelBuilder.Entity<Account>().ToTable("Account");
    }


}