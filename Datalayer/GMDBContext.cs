namespace Datalayer
{
    public class GMDBContext : DbContext
    {
        //Set Up things ~Leo
        public GMDBContext() : base() { }
        public GMDBContext(DbContextOptions options) : base(options) { }

        //DbSets ~Leo
        public DbSet<Band> Bands { get; set; }
        public DbSet<BandMember> BandMembers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

//dotnet ef migrations add initial -c GMDBContext --startup-project ../WebAPI
//dotnet ef database update --startup-project ../WebAPI
//if there's a new table or change in models, delete migrations folder and rerun first, then second ~Leo