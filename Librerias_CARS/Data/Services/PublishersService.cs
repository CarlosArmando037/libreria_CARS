using Librerias_CARS.Data.Models;
using Librerias_CARS.Data.ViewModels;
using System;

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
        public void AddPublishers(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

    }
}
