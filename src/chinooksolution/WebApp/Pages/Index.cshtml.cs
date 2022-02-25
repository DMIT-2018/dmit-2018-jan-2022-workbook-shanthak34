#nullable disable
using ChinookLibrary.BLL;
using ChinookLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Private variable and DI constructor

        private readonly ILogger<IndexModel> _logger;
        private readonly AboutServices _aboutServices;
        public IndexModel(ILogger<IndexModel> logger, AboutServices aboutServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
        }
        #endregion
        #region FeedBack and ErrorHandling
        [TempData]
        public string FeedBack { get; set; }
        public bool HasFeedback => !string.IsNullOrWhiteSpace(FeedBack);
        #endregion
        public void OnGet()
        {
            DbVersioninfo info = _aboutServices.GetDbVersion();
            if(info == null)
            {
                FeedBack = "Version unknown";
            }
            else
            {
                FeedBack = $"Version:{info.Major}.{info.Minor}.{info.Build}" +
                    $"Release date of {info.ReleaseDate.ToShortDateString()}";
            }
        }
    }
}