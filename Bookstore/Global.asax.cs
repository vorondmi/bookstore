using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Bookstore.Models;
using Bookstore.ViewModels;
using System.Runtime.InteropServices;

namespace Bookstore
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Book, BookViewModel>().ReverseMap();
                cfg.CreateMap<Book, ComplexBookViewModel>().ForMember(x => x.isbn, opt => opt.Ignore());
                cfg.CreateMap<Author, ComplexBookViewModel>();
                cfg.CreateMap<ISBN, ComplexBookViewModel>();
                cfg.CreateMap<Reader, ComplexBookViewModel>();
                cfg.CreateMap<Author, AuthorViewModel>().ReverseMap();
                cfg.CreateMap<ISBN, ISBNViewModel>().ReverseMap();
                cfg.CreateMap<Reader, ReaderViewModel>().ReverseMap();
                cfg.CreateMap<Author, ComplexAuthorViewModel>();
            });
        }
    }
}
