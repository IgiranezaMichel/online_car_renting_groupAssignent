using carrentalgroupassignment.Tables;
using System.Data.SqlClient;

namespace carrentalgroupassignment.Dao
{
    public class BookingDao
    {
        public static string addbooking(booking booking)
        {
            string result = "booking Added Successfully";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=MICHAEL\\SQLEXPRESS;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("createbooking", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", booking.Customeremail);
                        cmd.Parameters.AddWithValue("@platenumber", booking.Platenumber);
                        cmd.Parameters.AddWithValue("@fromdate", booking.FromDate);
                        cmd.Parameters.AddWithValue("@todate", booking.ToDate);
                        cmd.Parameters.AddWithValue("@isbooked", booking.Isbooked);
                        cmd.Parameters.AddWithValue("@payment", booking.Payment);

                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public static string deletebooking(booking booking)
        {
            string result = "booking Added Successfully";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=MICHAEL\\SQLEXPRESS;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("createbooking", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", booking.Customeremail);
                        cmd.Parameters.AddWithValue("@platenumber", booking.Platenumber);
                        cmd.Parameters.AddWithValue("@fromdate", booking.FromDate);
                        cmd.Parameters.AddWithValue("@todate", booking.ToDate);
                        cmd.Parameters.AddWithValue("@isbooked", booking.Isbooked);
                        cmd.Parameters.AddWithValue("@payment", booking.Payment);

                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

    }
}
