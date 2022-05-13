
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataLayer;

public class GADBContext : DbContext
{
    public GADBContext() : base() { }
    public GADBContext(DbContextOptions options) : base(options) { }
    public DbSet<BandMember> BandMembers { get; set; }
    public DbSet<Band> Bands { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
}