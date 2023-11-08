using System.Collections.Generic;

namespace Librerias_CARS.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //propiedades de navegacion

        public List<Book> Books {get; set;}
    }
}
