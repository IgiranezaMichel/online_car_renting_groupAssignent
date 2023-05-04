using carrentalgroupassignment.Dao;
using carrentalgroupassignment.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace carrentalgroupassignment.Pages.user
{   
    public class bookingsModel : PageModel
    {
        public booking booking = new booking();
        public User usr = new User();
        public string PlateNumber = "";
        public string useremail = "";
        public Car car=new Car();
        public Cardao dao=new Cardao();
        public void OnGet()
        {
            useremail = Request.Query["i"].ToString();
            PlateNumber = Request.Query["c"].ToString();
            string email = systemSecurity.Decrypt(useremail);
            usr = UserDao.findUserbyEmail(email);
            car = Cardao.findUserbyPlateNumber(PlateNumber);
        }
        public void OnPost()
        {

        }
    }
}
