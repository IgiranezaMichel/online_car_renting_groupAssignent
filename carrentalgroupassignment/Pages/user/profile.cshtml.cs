using carrentalgroupassignment.Dao;
using carrentalgroupassignment.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace carrentalgroupassignment.Pages.user
{
    public class profileModel : PageModel
    {
        public Cardao cardao = new Cardao();
        public string action;
        public string message;
        public string useremail;
        public List<Car> getAllCars()
        {
            return cardao.getAllcar();
        }
        public User usr = new User();
        public void OnGet()
        {
            useremail = Request.Query["i"].ToString();
            string email = systemSecurity.Decrypt(useremail);
            usr = UserDao.findUserbyEmail(email);
        }
        public void OnPost()
        {
            action = Request.Form["action"];
            if(action.Equals("updateuser"))
            {
                usr.Name = Request.Form["name"];
                usr.Email = Request.Form["email"];
                usr.Password = Request.Form["password"];
                usr.Phone = Request.Form["phone"];
                usr.Gender = Request.Form["gender"];
                message = UserDao.updateUser(usr);

            }
        }
    }
}
