using Librerias_CARS.Data.Models;
using Librerias_CARS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Librerias_CARS.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        //metodo para añadri libro
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }


        //listar libros
        public List<Book> GetAllBks() => _context.Books.ToList();
        //listar libro por Id
        public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);

        //metodo para editar un libro
        public Book UpdateBookById(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if (_book != null)
            {

                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }
        
        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n=>n.id == bookid);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
