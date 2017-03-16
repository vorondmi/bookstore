using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Bookstore.Controllers;
using Bookstore.Services;
using Bookstore.BL;
using Bookstore.DAL;
using Bookstore.Models;
using FluentValidation;
using Bookstore.Services.Validation;

namespace Bookstore.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IDbContext, BookStoreContext>(new ContainerControlledLifetimeManager());

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

            container.RegisterType<AuthorsApiController>();
        }
    }
}
