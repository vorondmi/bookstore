using System;
using System.Collections.Generic;
using BookstoreModels;

namespace BookstoreDAL
{
    public interface IAuthorDal
    {
        List<Author> GetAllAuthors();
        Author FindAuthorById(Guid key);
        int SaveAuthor(Author entity);
        int UpdateAuthor(Author entity);
        int DeleteAuthor(Author entity);
    }
}
