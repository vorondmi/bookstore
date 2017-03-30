using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreDAL;
using BookstoreModels;
using BookstoreBL;
using System.Collections.Generic;
using BookstoreAPI.App_Start;

namespace BookStoreUnitTests.ReaderTests
{
    [TestClass]
    public class ReaderBLTests
    {
        private Mock<IReaderDal> readerDal;
        private ReaderBL readerBL;

        private List<Reader> readerList;

        private Reader validNewReader, validUpdatedReader, validReaderToDelete;

        public ReaderBLTests()
        {
            InitialiseList();

            readerDal = new Mock<IReaderDal>();
            readerDal.Setup(r => r.GetAllReaders()).Returns(readerList);
            readerDal.Setup(r => r.FindReaderById(readerList[1].id)).Returns(readerList[1]);
            readerDal.Setup(r => r.SaveReader(validNewReader)).Returns(0);
            readerDal.Setup(r => r.UpdateReader(validUpdatedReader)).Returns(0);
            readerDal.Setup(r => r.DeleteReader(validReaderToDelete)).Returns(0);

            readerBL = new ReaderBL(readerDal.Object, new ValidationService());
        }

        private void InitialiseList()
        {
            readerList = new List<Reader>()
            {
                new Reader() { id = Guid.NewGuid(), name="Reader1", genre="Drama", books= null, authors=null },
                new Reader() { id = Guid.NewGuid(), name="Reader2", genre="SciFi", books=null, authors=null }
            };         
        }

        [TestMethod]
        public void GetAllReaders_ReturnsReaderList()
        {
            //arrange
            InitialiseList();

            //act
            var result = readerBL.GetAllReaders();

            //assert
            Assert.AreEqual(readerList, result);
        }

        [TestMethod]
        public void FindReaderById_ValidId_ReturnsReader()
        {
            //arrange
            InitialiseList();

            //act
            var result = readerBL.FindReaderById(readerList[1].id);

            //assert
            Assert.AreEqual(readerList[1], result);
        }

        [TestMethod]
        public void CreateReader_ValidReader_Returns0()
        {
            //arrange
            InitialiseList();
            validNewReader = new Reader() { id = Guid.Empty, name = "John", genre = "Drama" };

            //act
            var result = readerBL.CreateReader(validNewReader);

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void UpdateReader_ValidReader_Returns0()
        {
            //arrange
            InitialiseList();
            validUpdatedReader = new Reader() { id = readerList[1].id, name = "John", genre = "Drama" };

            //act
            var result = readerBL.UpdateReader(validUpdatedReader);

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void DeleteReader_ValidReader_Returns0()
        {
            //arrange
            InitialiseList();
            validReaderToDelete = new Reader() { id = readerList[1].id, name = readerList[1].name, genre = readerList[1].genre };

            //act
            var result = readerBL.DeleteReaderById(validReaderToDelete.id);

            //assert
            Assert.AreEqual(0, result);
        }
    }
}
