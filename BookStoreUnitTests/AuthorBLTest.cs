using Bookstore.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bookstore.UnitTests
{
    [TestClass]
    public class AuthorBLTest
    {
        // AuthorBL authorBL = new AuthorBL(new DummyAuthorDal(), new AuthorValidator());
        Mock mock = new Mock<IAuthorBL>();

        [TestMethod]
        public void CreateAuthor_AuthorNameEmpty_ReturnsMinus1()
        {
            
            ////arrange
            //ggg.Setup(x => x.SaveAuthor).Returns(1);


            //AuthorBL abl = new BL.AuthorBL(ggg.Object, new AuthorValidator());

            ////act
            //var result = authorBL.CreateAuthor(author);

            ////assert
            //Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CreateAuthor_AuthorNameIsJohn_Returns0()
        {
            ////arrange
            //Author author = new Author() { authorName = "John" };

            ////act
            //var result = authorBL.CreateAuthor(author);

            ////assert
            //Assert.AreEqual(0, result);
        }
    }
}