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
    public class AboutServices
    {
        //this class needs to be accessed by an "outside user"(web app)
        //therefore the class needs to be public

        #region Constructed and Context Dependency
        private readonly ChinookContext _context;
        internal AboutServices(ChinookContext context)
        {
            _context = context;
        }
        #endregion

        #region services
        //query to obtain DbVersion data
        public DbVersioninfo GetDbVersion()
        {

            DbVersioninfo info = _context.DbVersions
                                      .Select(x => new DbVersioninfo
                                      {
                                         Major = x.Major,
                                         Minor = x.Minor,
                                         Build = x.Build,
                                         ReleaseDate = x.ReleaseDate

                                       })
                                      .SingleOrDefault();
            return info;
        }

        #endregion




    }
}
