using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Bookstore.Models
{
    public interface IDbContext
    {
        DbSet<Book> books { get; set; }
        DbSet<Author> authors { get; set; }
        DbSet<Reader> readers { get; set; }
        DbSet<ISBN> isbns { get; set; }
        int SaveChanges();

        DbEntityEntry Entry(object entity);

        //void SaveChanges();
    }
}
