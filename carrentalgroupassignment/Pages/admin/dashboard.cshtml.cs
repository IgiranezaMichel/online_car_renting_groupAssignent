using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using carrentalgroupassignment.Dao;
using carrentalgroupassignment.Tables;

namespace carrentalgroupassignment.Pages.admin
{
    public class Dashboard : PageModel
    {
        public User user = new User();
        public Car car = new Car();
        public UserDao userdao = new UserDao();
        public Cardao cardao = new Cardao();
        public string message = "";
        public string action="";
        private string getaction="";
         public string Getaction { get { return getaction; } set { getaction = value; } }
        public Car GetCar()
        {
            return car;
        }
        public void setCar(Car car)
        {
            this.car = car;
        }
        public List<Car> getAllCars()
        {
            return cardao.getAllcar();
        }
        public void OnGet()
        {
            Getaction = Request.Query["action"];
            if (Getaction==null)
            {

            }
            else if(Getaction.Equals("deletecar"))
            {

            }
    
        }
        public void OnPost()
        {
            action = Request.Form["action"];
            if (action.Equals("createcar"))
            {
                message = saveCar();
            }
            else if(action.Equals("updatecar"))
            {
                message = saveCar();
            }
            else if(action.Equals("action"))
            {
                string platenumber = Request.Form["platenumber"];
                message = Cardao.deleteCar(platenumber);
            }
            else
            {
                message = "Deviated";
            }

        }

        public string saveCar()
        {   
            car.Platenumber = Request.Form["platenumber"];
            car.Brand = Request.Form["brand"];
            car.Seats = int.Parse(Request.Form["seats"]);
            car.Suitcase = int.Parse(Request.Form["suitcase"]);
            car.Description = (Request.Form["description"]);
            car.Price = int.Parse(Request.Form["price"]);
            var file1 = Request.Form.Files["image1"];
            var file2 = Request.Form.Files["image2"];
            if (file1 != null && file1.Length > 0)
            {
                var fileName = file1.FileName;
                using (var ms = new MemoryStream())
                {
                    file1.CopyTo(ms);
                    car.Image1 = ms.ToArray();
                    //string res=Convert.ToBase64String(filescp);
                    //message=res;
                }
            }
            if (file2 != null && file2.Length > 0)
            {
                var fileName = file2.FileName;
                using (var ms = new MemoryStream())
                {
                    file2.CopyTo(ms);
                    car.Image2 = ms.ToArray();
                    //string res=Convert.ToBase64String(filescp);
                    //message=res;
                }
            }
            if(action.Equals("createcar"))
            {
                return Cardao.saveCar(car);
            }
            //(action.Equals("updatecar"))
            else 
            {
                return Cardao.updateCar(car);
            }
        }
    }
}
