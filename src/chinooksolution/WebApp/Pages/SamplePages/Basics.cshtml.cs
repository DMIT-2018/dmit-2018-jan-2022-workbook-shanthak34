#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class BasicsModel : PageModel
    {
        //data fields
        public string MyName;
        //Properties
        [TempData]
        public string FeedBack {get;set;}
        // to retain a value in the control tied to this property AND retained // via the @page use the SupportGet attribute = true
        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }
        public void OnGet()
        {
           Random rnd = new Random();
            int oddeven = rnd.Next(0, 25);
            if(oddeven % 2 == 0)
            {
                MyName = $"Don is even {oddeven}";

            }
            else
            {
                MyName = null;
            }
        }
        public IActionResult OnPost()
        {
            //this line of code is used to cause a delay in processing
            ///so we can see on the network activity some type of simulated processing
            Thread.Sleep(2000);
            string buttonvalue = Request.Form["theButton"];
            FeedBack = $"Button pressed is {buttonvalue} with numeric input of {id}";
            return RedirectToPage(new { id = id });

        }



    }
}
