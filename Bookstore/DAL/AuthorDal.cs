﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;
using System.Data.Entity;

namespace Bookstore.DAL
{
    public class AuthorDal : IAuthorDal
    {
        readonly IDbContext db;

        public AuthorDal(IDbContext _db)
        {
            db = _db;
        }

        public int delete(Author entity)
        {
            db.authors.Remove(entity);
            db.SaveChanges();

            return 0;
        }

        public List<Author> findAll()
        {
            return db.authors.ToList();
        }

        public Author findByKey(Guid key)
        {
            return db.authors.Where(a => a.id.Equals(key)).FirstOrDefault();
        }

        public int save(Author entity)
        {
            db.authors.Add(entity);
            db.SaveChanges();

            return 0;
        }

        public int update(Author entity)
        {
            db.authors.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

            return 0;
        }
    }
}