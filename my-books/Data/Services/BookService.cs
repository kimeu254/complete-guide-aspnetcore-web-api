﻿using my_books.Data.Models;
using my_books.Data.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace my_books.Data.Services
{
    public class BookService(AppDBContext context)
    {
        private readonly AppDBContext _context = context;

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Genre = book.Genre,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                CoverUrl = book.CoverUrl
            };

            _context.Books.Add(_book);
            _context.SaveChanges();

        }

        public List<Book> GetAllBooks() => [.. _context.Books];

        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(b => b.Id == bookId);

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.Author = book.Author;
                _book.Genre = book.Genre;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
