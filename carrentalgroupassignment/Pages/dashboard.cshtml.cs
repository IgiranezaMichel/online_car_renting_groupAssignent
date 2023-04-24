using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using carrentalgroupassignment.Dao;
using carrentalgroupassignment.Tables;

namespace carrentalgroupassignment.Pages
{ 
    public class dashboardModel : PageModel
    {
        public Cardao cardao = new Cardao();
        public string useremail;
        public List<Car> getAllCars()
        {
            return cardao.getAllcar();
        }
        public User usr=new User();
        public void OnGet()
        {
            useremail = Request.Query["i"].ToString();
            string email = systemSecurity.Decrypt(useremail); 
            usr = UserDao.findUserbyEmail(email);  
        }
    }
}