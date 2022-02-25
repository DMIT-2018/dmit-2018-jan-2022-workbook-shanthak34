using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinookLibrary.BLL;
using ChinookLibrary.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChinookLibrary
{
    public static class ChinookExtensions
    {
        public static void ChinookDependencies(this IServiceCollection services, 
            Action<DbContextOptionsBuilder> options)
        {
            
            services.AddDbContext<ChinookContext>(options);

            services.AddTransient<AboutServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<ChinookContext>();
                return new AboutServices(context);
            });
            services.AddTransient<GenreServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<ChinookContext>();
                return new GenreServices(context);
            });
            services.AddTransient<AlbumServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<ChinookContext>();
                return new AlbumServices(context);
            });

        }
    }
}
