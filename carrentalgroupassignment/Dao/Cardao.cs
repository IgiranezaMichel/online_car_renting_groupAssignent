using System.Data.SqlClient;
using carrentalgroupassignment.Tables;
using System.Data;

namespace carrentalgroupassignment.Dao
{
    public class Cardao
    {
        public static string  saveCar(Car car)
        { 
            try
            {
                using(SqlConnection conn=new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrents;Integrated Security=True"))
                {
                    using(SqlCommand cmd=new SqlCommand("createcar", conn))
                    { 
                        cmd.CommandType=System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@platenumber", car.Platenumber);
                        cmd.Parameters.AddWithValue("@brand", car.Brand);
                        cmd.Parameters.AddWithValue("@seats", car.Seats);
                        cmd.Parameters.AddWithValue("@suitcase", car.Suitcase);
                        cmd.Parameters.AddWithValue("@description", car.Description);
                        cmd.Parameters.AddWithValue("@price", car.Price);
                        cmd.Parameters.AddWithValue("@img1", car.Image1);
                        cmd.Parameters.AddWithValue("@img2", car.Image2);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Car Saved Successfully";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        public static string deleteCar(String plateNumber)
        {
            string  Deleted = "Car Deleted Successfully";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrents;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("deleteacar", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@platenumber", plateNumber);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                   
                }
            }
            catch (Exception e)
            {
               Deleted = e.Message;
            }
            return Deleted;
        }
        public static string  updateCar(Car car)
        {
            string update = "Car is Update Successfully";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrents;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("updatecar", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@platenumber", car.Platenumber);
                        cmd.Parameters.AddWithValue("@brand", car.Brand);
                        cmd.Parameters.AddWithValue("@seats", car.Seats);
                        cmd.Parameters.AddWithValue("@suitcase", car.Suitcase);
                        cmd.Parameters.AddWithValue("@description", car.Description);
                        cmd.Parameters.AddWithValue("@price", car.Price);
                        cmd.Parameters.AddWithValue("@img1", car.Image1);
                        cmd.Parameters.AddWithValue("@img2", car.Image2);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
 
            }
            catch (Exception e)
            {
                update = e.Message;
            }
            return update;
        }
        public  List<Car> getAllcar()
        {
            List<Car> carlist = new List<Car>();
            
            using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrents;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("displaycars", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                         conn.Open();
                        SqlDataReader rd=cmd.ExecuteReader(); 
                        while(rd.Read())
                        {
                             Car car = new Car();
                            car.Platenumber = rd.GetString(0);
                            car.Brand= rd.GetString(1);
                            car.Seats=rd.GetInt32(2);
                            car.Suitcase= rd.GetInt32(3);
                            car.Description = rd.GetString(4);
                            car.Price = rd.GetInt32(5);
                            int dataIndex = rd.GetOrdinal("image1");
                            int dataIndex1 = rd.GetOrdinal("image2");
                            byte[] image1 = (byte[])rd[dataIndex];
                            car.Bas64img1 = Convert.ToBase64String(image1);
                            int dataIndex2 = rd.GetOrdinal("image2");
                            byte[] image2 = (byte[])rd[dataIndex1];
                            car.Bas64img2 = Convert.ToBase64String(image2);
                        
                        carlist.Add(car);
                        }
                    }
                }
                return carlist;
   
            }
        public static String UserLogin(User user)
        {
            string result="";
                using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrents;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("customerlogin", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        conn.Open();
                        SqlDataReader rd = cmd.ExecuteReader();
                        while(rd.Read())
                        {
                        result = rd.GetString(0);
                        }
                    }
                }

            return result;
        }

        public static Car findUserbyPlateNumber(string platenumber)     
        {
            Car car = new Car();
            using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrents;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("getCardetail", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@platenumber", platenumber);
                    conn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        car.Platenumber = rd.GetString(0);
                        car.Brand = rd.GetString(1);
                        car.Seats =rd.GetInt32(2);
                        car.Suitcase = rd.GetInt32(3);
                        car.Description= rd.GetString(4);   
                        car.Price=rd.GetInt32(5);

                        int dataIndex = rd.GetOrdinal("image1");
                        int dataIndex1 = rd.GetOrdinal("image2");
                        byte[] image1 = (byte[])rd[dataIndex];
                        car.Bas64img1 = Convert.ToBase64String(image1);
                        int dataIndex2 = rd.GetOrdinal("image2");
                        byte[] image2 = (byte[])rd[dataIndex1];
                        car.Bas64img2 = Convert.ToBase64String(image2);
                    }
                }
            }
            return car;
        }

    }
    
}
