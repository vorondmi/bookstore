using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreDAL;
using BookstoreModels;
using BookstoreBL;

namespace BookStoreUnitTests.ReaderTests
{
    [TestClass]
    class ReaderBLTests
    {
        [TestMethod]
        public void CreateReader_ValidReader_Returns0()
        {
            //arrange
            var readerDal = new Mock<IReaderDal>();
            var validReader = new Reader() { id = Guid.Empty, name = "John", genre = "Drama" };
            readerDal.Setup(r => r.SaveReader(validReader)).Returns(0);

            var readerBL = new ReaderBL(readerDal.Object, new ValidationService());

            //act
            var result = readerBL.CreateReader(validReader);

            //assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void CreateReader_EmptyReader_Returns1()
        {

        }
    }
}
