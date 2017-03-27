using System;
using System.Collections.Generic;
using BookstoreModels;

namespace BookstoreDAL
{
    public interface IReaderDal
    {
        List<Reader> GetAllReaders();
        Reader FindReaderById(Guid key);
        int SaveReader(Reader entity);
        int UpdateReader(Reader entity);
        int DeleteReader(Reader entity);
    }
}
