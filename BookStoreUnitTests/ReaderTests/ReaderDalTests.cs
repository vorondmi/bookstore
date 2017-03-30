using BookstoreDAL;
using BookstoreModels;
using DeepEqual.Syntax;
using Effort.DataLoaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreUnitTests.ReaderTests
{
    [TestClass]
    public class ReaderDalTests
    {
        private BookStoreContext db;
        private ReaderDal readerDal;

        private Reader expectedReader;
        private List<Reader> expectedReaderList;

        public ReaderDalTests()
        {
            //expectedReaderList = new List<Reader>() {
            //    new Reader() { id = Guid.Parse("D53082F4-2AC4-437C-AC37-4240E7969A78"), name="reader1", genre="Drama" },
            //    new Reader() { id = Guid.Parse("B807381C-05F1-4F91-A518-9AF155656849"), name="reader2", genre="SciFi" },
            //    new Reader() { id = Guid.Parse("CAF36D09-F5EF-4D39-9047-F141042AA452"), name="reader3", genre="Comedy" }
            //};

            expectedReader = new Reader()
            {
                id = Guid.Parse("CAF36D09-F5EF-4D39-9047-F141042AA452"),
                name = "reader3",
                genre = "Comedy"
            };
        }

        private void InitialiseClass()
        {
            
        }

        private void InitialiseDatabase()
        {
            //id,name,genre
            //D53082F4 - 2AC4 - 437C - AC37 - 4240E7969A78,reader1,Drama
            //B807381C - 05F1 - 4F91 - A518 - 9AF155656849,reader2,SciFi
            //CAF36D09 - F5EF - 4D39 - 9047 - F141042AA452,reader3,Comedy
            //var path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            IDataLoader loader = new CsvDataLoader(@"C:\temp\");
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient(loader);
            db = new BookStoreContext(connection);

            //db.readers.Add(new Reader() { id = Guid.NewGuid(), genre="baubas", name="Jurgis" });
            //db.SaveChanges();

            readerDal = new ReaderDal(db);
        }

        [TestMethod]
        public void GetAllReaders_ReturnsReaderList()
        {
            //arrange
            InitialiseDatabase();

            //act
            var result = readerDal.GetAllReaders();
            var expectedReaderList = db.readers.ToList();

            //assert
            Assert.IsTrue(expectedReaderList.IsDeepEqual(result));
        }

        [TestMethod]
        public void FindReaderById_ReturnsReader()
        {
            //arrange
            InitialiseDatabase();

            //act
            Guid readerId = Guid.Parse("CAF36D09-F5EF-4D39-9047-F141042AA452");

            var result = readerDal.FindReaderById(readerId);
            var expectedReader = db.readers.Where(r => r.id.Equals(readerId)).FirstOrDefault();

            //assert
            Assert.IsTrue(expectedReader.IsDeepEqual(result));
        }

        [TestMethod]
        public void SaveReader_ValidReader_Returns0()
        {
            //arrange
            InitialiseDatabase();
            var newValidReader = new Reader() { id = Guid.NewGuid(), name="newReader", genre="Comedy" };

            //act
            var result = readerDal.SaveReader(newValidReader);

            //assert
            Assert.AreEqual(0, result);
            Assert.IsTrue(db.readers.Contains(newValidReader));
        }

        [TestMethod]
        public void UpdateReader_ReaderValidAndExists_Returns0()
        {
            //arrange
            InitialiseDatabase();
            var readerId = Guid.Parse("B807381C-05F1-4F91-A518-9AF155656849");
            var updatedReader = new Reader() { id = readerId, name = "reader4", genre = "Drama" };

            //act
            var readers = db.readers.ToList();
            var readerToUpdate = db.readers.Where(r => r.id.Equals(readerId)).FirstOrDefault();

            readerDal.UpdateReader(updatedReader);

            //assert
            Assert.IsTrue(db.readers.Contains(updatedReader) && !db.readers.Contains(readerToUpdate));
        }

        [TestMethod]
        public void DeleteReader_ReaderExists_Returns0()
        {
            //arrange
            InitialiseDatabase();
            var readerToDelete = new Reader() { id = Guid.Parse("CAF36D09-F5EF-4D39-9047-F141042AA452"), name = "reader3", genre = "Comedy" };

            //act
            var result = readerDal.DeleteReader(readerToDelete);

            //assert
            Assert.AreEqual(0, result);
            Assert.IsTrue(!db.readers.Contains(readerToDelete));
        }
    }
}
