using carrentalgroupassignment.Tables;
using System.Data.SqlClient;

namespace carrentalgroupassignment.Dao
{
    public class UserDao
    {public static User user=new User();
        public static String  saveUser(User user)
        { 
            try
            {
                using(SqlConnection conn=new SqlConnection("Data Source=MICHAEL\\SQLEXPRESS;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using(SqlCommand cmd=new SqlCommand("createuser", conn))
                    { 
                        cmd.CommandType=System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@phone", user.Phone);
                        cmd.Parameters.AddWithValue("@gender", user.Gender);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Credentials Saved Successfully";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        public static string deleteUser(User user)
        {
            string isSaved = "User Deleted Successfully";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=MICHAEL\\SQLEXPRESS;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("deleteUser", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
             
            }
            catch (Exception ex)
            {
                isSaved = ex.Message;
            }
            return isSaved;
        }
        public static string updateUser(User user)
        {
            string isSaved = "Credential Updated Successfully";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=MICHAEL\\SQLEXPRESS;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("updateuser", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@phone", user.Phone);
                        cmd.Parameters.AddWithValue("@gender", user.Gender);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                isSaved = e.Message;
            }
            return isSaved;
        }
        public static List<User> getAllUser()
        {
            List<User> users = new List<User>();
            User user = new User();
            using (SqlConnection conn = new SqlConnection("Data Source=MICHAEL\\SQLEXPRESS;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("displayallcustomer", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                         conn.Open();
                        SqlDataReader rd=cmd.ExecuteReader(); 
                        while(rd.Read())
                        {
                            user = new User();
                            user.Email = rd.GetString(0);
                            user.Name= rd.GetString(1);
                            user.Phone= rd.GetString(2);
                            user.Gender= rd.GetString(3);
                            users.Add(user);
                        }
                    }
                }
                return users;
   
            }
        public static String UserLogin(User user)
        {
            string result="";
                using (SqlConnection conn = new SqlConnection("Data Source=MICHAEL\\SQLEXPRESS;Initial Catalog=carrent;Integrated Security=True"))
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

        public static User findUserbyEmail(string email)     
        {
            User usr = new User();
            using (SqlConnection conn = new SqlConnection("Data Source=MICHAEL\\SQLEXPRESS;Initial Catalog=carrent;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("finduserbyemail", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", email);
                    conn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        usr.Email = rd.GetString(0);
                        usr.Name = rd.GetString(1);
                        usr.Phone = rd.GetString(2);
                        usr.Gender = rd.GetString(3);
                    }
                }
            }
            return usr;
        }

    }
    
}
