using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }
    }
}
