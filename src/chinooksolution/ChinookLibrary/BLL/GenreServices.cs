#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespace
using ChinookLibrary.DAL;
using ChinookLibrary.Entities;
using ChinookLibrary.ViewModels;
#endregion

namespace ChinookLibrary.BLL
{
    public class GenreServices
    {
        #region Constructor and Context Dependency
        private readonly ChinookContext _context;
        internal GenreServices(ChinookContext context)
        {
            _context = context;
        }
        #endregion
        #region Services: Queries
        //obtain a list of genres to be used in a select list
        public List<SelectionList> GetAllGenres()
        {
            IEnumerable<SelectionList> info = _context.Genres
                .Select(g => new SelectionList
                {
                    ValueId = g.GenreId,
                    DisplayText = g.Name
                });
            return info.ToList();
            //return info.OrderBy(g => g.DisplayText).ToList();
        }
        #endregion
    }
}

