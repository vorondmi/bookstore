using System;
using System.Collections.Generic;
using BookstoreModels;

namespace BookstoreDAL
{
    public interface IISBNDal
    {
        List<ISBN> GetAllISBNs();
        ISBN FindISBNById(Guid key);
        int SaveISBN(ISBN entity);
        int UpdateISBN(ISBN entity);
        int DeleteISBN(ISBN entity);
    }
}
