using System.Collections.Generic;

namespace Librerias_CARS.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        
        //propiedades de navegacion

        public List<Book_Author> Book_Authors { get; set; }
    }
}
