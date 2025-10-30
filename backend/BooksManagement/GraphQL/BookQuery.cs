
using BooksManagement.Models;

namespace BooksManagement.GraphQL
{
    public class BookQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([Service] HealthContext context) => context.Books;

    }

}

