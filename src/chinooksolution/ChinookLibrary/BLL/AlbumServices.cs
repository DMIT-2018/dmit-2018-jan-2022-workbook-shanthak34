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
    public class AlbumServices
    {
        #region Constructor and Context Dependency
        private readonly ChinookContext _context;
        internal AlbumServices(ChinookContext context)
        {
            _context = context;
        }
        #endregion
        #region Services: Queries
        public List<AlbumsListBy> AlbumsByGenre(int genreid)
        {
            //return raw data and let the presentation layer decide ordering
            IEnumerable<AlbumsListBy> info = _context.Tracks
                                           .Where(x => x.GenreId == genreid)
                                           .Select(x => new AlbumsListBy
                                           {
                                               AlbumId = (int)x.AlbumId,
                                               Title = x.Album.Title,
                                               ArtistId = x.Album.ArtistId,
                                               ReleaseYear = x.Album.ReleaseYear,
                                               ReleaseLabel = x.Album.ReleaseLabel,
                                               ArtistName = x.Album.Artist.Name

                                           }) ;
            return info.ToList();
                                            
        }


        #endregion




    }

}
