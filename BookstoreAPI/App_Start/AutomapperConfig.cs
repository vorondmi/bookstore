using AutoMapper;
using BookstoreAPI.BookStoreViewModels;
using BookstoreModels;

namespace BookstoreAPI.App_Start
{
    public class AutomapperConfig
    {
        public static void init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>()
                    //.ForMember(p => p.readers, opt => opt.Ignore())
                    .ReverseMap();
                cfg.CreateMap<NewBookViewModel, Book>();
                cfg.CreateMap<Book, BookDetailViewModel>();
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