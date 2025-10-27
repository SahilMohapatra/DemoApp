using BooksManagement.Models;

namespace BooksManagement.GraphQL
{
    public class BookMutation
    {   
        public async Task<Book> AddBook([Service] HealthContext context, string title, string author, decimal price)
        {
            var book = new Book { Title = title, Author = author, Price = price };
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook([Service] HealthContext context, int id, string title, string author, decimal price)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
                throw new Exception("Book not found");

            book.Title = title;
            book.Author = author;
            book.Price = price;
            await context.SaveChangesAsync();

            return book;
        }

        public async Task<bool> DeleteBook([Service] HealthContext context, int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null) return false;

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return true;
        }

    }
}


