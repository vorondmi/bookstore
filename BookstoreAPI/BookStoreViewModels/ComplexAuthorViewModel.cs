using System.Collections.Generic;

namespace BookstoreAPI.BookStoreViewModels
{
    public class ComplexAuthorViewModel
    {
        public string authorName { get; set; }

        public bool alive { get; set; }

        public List<BookViewModel> books { get; set; }
    }
}