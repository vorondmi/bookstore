using System.Data.Common;
using System.Data.Entity;

namespace BookstoreModels
{
    public class BookStoreContext : DbContext, IDbContext
    {
        //public BookStoreContext() : base("BookStoreConnection")
        //{
        //    this.Configuration.LazyLoadingEnabled = false;
        //}

        public BookStoreContext(DbConnection connection):base(connection, true) {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Reader> readers { get; set; }
        public DbSet<ISBN> isbns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ISBN>()
            //    .HasRequired(b => b.book)
            //    .WithRequiredPrincipal(i => i.isbn);

            modelBuilder.Entity<ISBN>()
                .HasOptional(b => b.book)
                .WithRequired(i => i.isbn);
        }
    }
}