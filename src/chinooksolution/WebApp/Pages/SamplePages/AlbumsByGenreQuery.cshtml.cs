#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChinookLibrary.BLL;
using ChinookLibrary.ViewModels;
namespace WebApp.Pages.SamplePages
{
    public class AlbumsByGenreQueryModel : PageModel
    {

        #region Private variable and DI constructor

        private readonly ILogger<IndexModel> _logger;
        private readonly AlbumServices _albumServices;
        private readonly GenreServices _genreServices;
        public AlbumsByGenreQueryModel(ILogger<IndexModel> logger, AlbumServices albumServices,GenreServices genreservices)
        {
            _logger = logger;
            _albumServices = albumServices;
            _genreServices = genreservices;
        }
        #endregion
        #region FeedBack and ErrorHandling
        [TempData]
        public string FeedBack { get; set; }
        public bool HasFeedback => !string.IsNullOrWhiteSpace(FeedBack);
        [TempData]
        public string ErrorMsg { get; set; }
        public bool HasErrorMsg => !string.IsNullOrWhiteSpace(ErrorMsg);
        #endregion

        [BindProperty]

        public List<SelectionList> GenreList { get; set; }
        [BindProperty]
        public int GenreId { get; set; }
        public void OnGet()
        {
            GenreList = _genreServices.GetAllGenres();
            //sort the List<T> using the method .sort
            GenreList.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));
        }
        public IActionResult OnPost()
        {
            if(GenreId == 0)
            {
                FeedBack = "you did not select a genre";
            }
            else
            {
                FeedBack = $"you select genreid of {GenreId}";
            }
            return RedirectToPage();
        }
    }
}
