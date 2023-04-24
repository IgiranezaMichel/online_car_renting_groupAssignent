using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using carrentalgroupassignment.Dao;
using carrentalgroupassignment.Tables;

namespace carrentalgroupassignment.Pages.admin
{
    public class usersModel : PageModel
    {public UserDao userdao=new UserDao();
        private User user=new User();
        string action = "";
        private string message="";
        public string Message { get { return message; } set { message = value; } }
        public User User { get { return user; } set { user = value; }}
        public List<User> userlist()
        {
           return UserDao.getAllUser();
        }
       
       
        public void OnGet()
        {
        }
        public void OnPost()
        { 
            action = Request.Form["action"];
            if(action.Equals("getuser"))
            {
                string email = Request.Form["email"];
                user = UserDao.findUserbyEmail(email);
            }
            else if(action.Equals("deleteuser"))
            {
                string email = Request.Form["email"];
                user = UserDao.findUserbyEmail(email);
                message=UserDao.deleteUser(user);
            }
            
        }
    }
}
