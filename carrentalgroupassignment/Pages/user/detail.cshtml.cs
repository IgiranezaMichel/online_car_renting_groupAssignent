using carrentalgroupassignment.Dao;
using carrentalgroupassignment.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace carrentalgroupassignment.Pages.user
{
    public class detailModel : PageModel
    {
        public Car car = new Car();
        public Cardao dao = new Cardao();
        string platenumber = "";
        public void OnGet()
        {
            platenumber = Request.Query["c"].ToString();
            car = Cardao.findUserbyPlateNumber(platenumber);
        }
    }
}
