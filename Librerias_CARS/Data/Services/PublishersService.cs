using Librerias_CARS.Data.Models;
using Librerias_CARS.Data.ViewModels;
using Librerias_CARS.Exceptions;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Librerias_CARS.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        //metodo para añadir una nueva editorial ejn la base de datos
        public Publisher AddPublishers(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("el numbre empieza con un numero",
                publisher.Name);
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherByID(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);
        public PublisherWithBooksandAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksandAuthorsVM()
                {
                    Name =n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Titulo,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }
        internal void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La editorial con el id {id} no existe!");
            }
        }
        public bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));

            /*
            if(Regex.IsMatch(name,@"^\d")) return true;
            return false;
            */

    }
}
