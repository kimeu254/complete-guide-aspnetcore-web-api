using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDBInitializer
    {
        public static void Seed(AppDBContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(new List<Book>
                {
                    new() {
                        Title = "Book 1",
                        Author = "Author 1",
                        Description = "Description 1",
                        Genre = "Genre 1",
                        IsRead = true,
                        DateRead = DateTime.Now,
                        Rate = 5,
                        CoverUrl = "https://example.com/book1.jpg",
                        DateAdded = DateTime.Now
                    },
                    new() {
                        Title = "Book 2",
                        Author = "Author 2",
                        Description = "Description 2",
                        Genre = "Genre 2",
                        IsRead = false,
                        DateRead = null,
                        Rate = null,
                        CoverUrl = "https://example.com/book2.jpg",
                        DateAdded = DateTime.Now
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
