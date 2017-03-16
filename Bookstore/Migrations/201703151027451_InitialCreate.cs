namespace Bookstore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        authorName = c.String(nullable: false),
                        alive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        bookTitle = c.String(nullable: false),
                        release = c.DateTime(nullable: false),
                        isbnID = c.Guid(nullable: false),
                        author_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Authors", t => t.author_id)
                .ForeignKey("dbo.ISBNs", t => t.id)
                .Index(t => t.id)
                .Index(t => t.author_id);
            
            CreateTable(
                "dbo.ISBNs",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        isbn = c.Int(nullable: false),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(nullable: false),
                        genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ReaderAuthors",
                c => new
                    {
                        Reader_id = c.Guid(nullable: false),
                        Author_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reader_id, t.Author_id })
                .ForeignKey("dbo.Readers", t => t.Reader_id, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_id, cascadeDelete: true)
                .Index(t => t.Reader_id)
                .Index(t => t.Author_id);
            
            CreateTable(
                "dbo.ReaderBooks",
                c => new
                    {
                        Reader_id = c.Guid(nullable: false),
                        Book_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reader_id, t.Book_id })
                .ForeignKey("dbo.Readers", t => t.Reader_id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_id, cascadeDelete: true)
                .Index(t => t.Reader_id)
                .Index(t => t.Book_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReaderBooks", "Book_id", "dbo.Books");
            DropForeignKey("dbo.ReaderBooks", "Reader_id", "dbo.Readers");
            DropForeignKey("dbo.ReaderAuthors", "Author_id", "dbo.Authors");
            DropForeignKey("dbo.ReaderAuthors", "Reader_id", "dbo.Readers");
            DropForeignKey("dbo.Books", "id", "dbo.ISBNs");
            DropForeignKey("dbo.Books", "author_id", "dbo.Authors");
            DropIndex("dbo.ReaderBooks", new[] { "Book_id" });
            DropIndex("dbo.ReaderBooks", new[] { "Reader_id" });
            DropIndex("dbo.ReaderAuthors", new[] { "Author_id" });
            DropIndex("dbo.ReaderAuthors", new[] { "Reader_id" });
            DropIndex("dbo.Books", new[] { "author_id" });
            DropIndex("dbo.Books", new[] { "id" });
            DropTable("dbo.ReaderBooks");
            DropTable("dbo.ReaderAuthors");
            DropTable("dbo.Readers");
            DropTable("dbo.ISBNs");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
