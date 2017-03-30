using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BookstoreBL;
using Bookstore.Controllers;

namespace BookStoreUnitTests.ReaderTests
{
    [TestClass]
    public class ReaderControllerTests
    {
        private ReadersController readersConroller;

        public ReaderControllerTests()
        {
            readersConroller = new ReadersController();
        }

        [TestMethod]
        public void Index_RouteTest()
        {

        }

        [TestMethod]
        public void Details_RouteTest()
        {

        }

        [TestMethod]
        public void Create_RouteTest()
        {

        }
    }
}
