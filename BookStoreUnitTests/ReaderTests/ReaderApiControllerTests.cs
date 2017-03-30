using BookstoreAPI.BookStoreViewModels;
using BookstoreAPI.Controllers;
using BookstoreBL;
using BookstoreModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace BookStoreUnitTests.ReaderTests
{
    [TestClass]
    public class ReaderApiControllerTests
    {
        private Mock<IReaderBL> readerBL;
        private ReadersApiController readersApiController;

        private Reader newReader, updatedReader;
        private ReaderViewModel newReaderViewModel, updatedReaderViewModel;

        private List<Reader> readerList;
        private List<ReaderViewModel> readerViewModelList;

        public ReaderApiControllerTests()
        {
            //arrange
            readerList = new List<Reader>()
            {
                new Reader() { id = Guid.NewGuid(), name="Reader1", genre="Drama", books= null, authors=null },
                new Reader() { id = Guid.NewGuid(), name="Reader2", genre="SciFi", books=null, authors=null }
            };

            readerViewModelList = new List<ReaderViewModel>()
            {
                new ReaderViewModel() { id = readerList[0].id, name = readerList[0].name, genre=readerList[0].genre },
                new ReaderViewModel() { id = readerList[1].id, name = readerList[1].name, genre=readerList[1].genre }
            };

            newReader = new Reader()
            {
                name = "Reader3",
                genre = "Comedy"
            };
            newReaderViewModel = new ReaderViewModel()
            {
                name = "Reader3",
                genre = "Comedy"
            };

            updatedReader = new Reader()
            {
                id = readerList[1].id,
                name = "UpdatedReader",
                genre = "Drama",
            };
            updatedReaderViewModel = new ReaderViewModel()
            {
                id = readerList[1].id,
                name = "UpdatedReader",
                genre = "Drama",
            };


            readerBL = new Mock<IReaderBL>();
            readerBL.Setup(r => r.FindReaderById(readerList[1].id)).Returns(readerList[1]);
            readerBL.Setup(r => r.GetAllReaders()).Returns(readerList);
            readerBL.Setup(r => r.CreateReader(newReader)).Returns(0);
            readerBL.Setup(r => r.UpdateReader(updatedReader)).Returns(0);
            readerBL.Setup(r => r.DeleteReaderById(readerList[0].id));

            readersApiController = new ReadersApiController(readerBL.Object);
        }

        private void InitialiseTestClass()
        {
            
        }

        [TestMethod]
        public void GetAllReaders_ReturnsReadersList()
        {
            //act
            var result = readersApiController.GetAllReaders();

            //assert
            Assert.AreEqual(readerViewModelList, result);
        }

        [TestMethod]
        public void FindReaderById_ValidId_ReturnsReader()
        {
            //act
            var result = readersApiController.GetReaderDetailsById(readerList[1].id);

            //assert
            Assert.AreEqual(readerViewModelList[1], result);
        }

        [TestMethod]
        public void CreateReader_ValidReader_Returns0()
        {
            //act
            var result = readersApiController.CreateReader(newReaderViewModel);

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAllReaders_Routing()
        {
            //act
            

            //assert

        }
    }
}
