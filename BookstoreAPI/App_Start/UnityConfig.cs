using BookstoreBL;
using BookstoreBL.Services.Validation;
using BookstoreDAL;
using BookstoreModels;
using FluentValidation;
using Microsoft.Practices.Unity;
using System.Data.Common;
using System.Web.Http;
using Unity.WebApi;

namespace BookstoreAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            DbConnection connection = Effort.EntityConnectionFactory.CreateTransient("BookStoreConnection");

            container.RegisterType<IDbContext, BookStoreContext>(new ContainerControlledLifetimeManager(), new InjectionConstructor(connection));

            container.RegisterType<IISBNDal, ISBNDal>();
            container.RegisterType<IAuthorDal, AuthorDal>();
            container.RegisterType<IBookDal, BookDal>();
            container.RegisterType<IReaderDal, ReaderDal>();

            container.RegisterType<IISBNBL, ISBNBL>();
            container.RegisterType<IAuthorBL, AuthorBL>();
            container.RegisterType<IBookBL, BookBL>();
            container.RegisterType<IReaderBL, ReaderBL>();

            container.RegisterType<IValidator<Author>, AuthorValidator>();

            container.RegisterType<IValidationService, ValidationService>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}