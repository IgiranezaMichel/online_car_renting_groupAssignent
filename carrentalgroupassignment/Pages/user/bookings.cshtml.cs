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
        public Car car = new Car();
        public string message = "";
        public void getCar(Car car)
        {
            this.car = car;
        }
        public Cardao dao = new Cardao();
        public void OnGet()
        {
            useremail = Request.Query["i"].ToString();
            PlateNumber = Request.Query["c"].ToString();
            string email = systemSecurity.Decrypt(useremail);
            usr = UserDao.findUserbyEmail(email);
            car = Cardao.findUserbyPlateNumber(PlateNumber);
            getCar(car);
        }
        public void OnPost()
        {
            String email = systemSecurity.Decrypt(Request.Form["email"]);
            booking.Customeremail = email;
            booking.Platenumber = Request.Form["platenumber"];
            booking.FromDate = DateTime.Parse(Request.Form["fromdate"]);
            booking.ToDate = DateTime.Parse(Request.Form["todate"]);
            booking.Isbooked = 1;
            int book = booking.FromDate.DayOfYear - booking.ToDate.DayOfYear;
            booking.Payment = book * car.Price;
            String reuslt = BookingDao.addbooking(booking);
            email = systemSecurity.Encrypt(email);
            message = reuslt;
            Response.Redirect("/dashboard?i=" + email + "");
        }
    }
}