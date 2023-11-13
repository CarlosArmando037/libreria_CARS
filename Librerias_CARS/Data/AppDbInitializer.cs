using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Librerias_CARS.Data.Models;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Librerias_CARS.Data
{
    public class AppDbInitializer
    {
        //Metodo que agrega datos a nuestra DB

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Titulo = "1ts Book Title",
                        Descripcion = "1ts Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Biography",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                    },
                    new Book()
                    {
                        Titulo = "2nd Book Title",
                        Descripcion = "2nd Book Description",
                        IsRead = true,
                        Genero = "Biography",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                    });
                    //context.SaveChanges();

                }
            }
        }
    }
}
