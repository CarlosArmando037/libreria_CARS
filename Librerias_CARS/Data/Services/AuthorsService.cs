using Librerias_CARS.Data.Models;
using Librerias_CARS.Data.ViewModels;
using System;

namespace Librerias_CARS.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        //metodo para añadri libro
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

    }
}
