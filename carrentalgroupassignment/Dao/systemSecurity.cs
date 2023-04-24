using System.Text;

namespace carrentalgroupassignment.Dao
{
    public class systemSecurity
    {
      public  static string Encrypt(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message); // convert message to bytes
            string encodedMessage = Convert.ToBase64String(bytes); // encode bytes to Base64 string
            return encodedMessage;
        }

      public  static string Decrypt(string encodedMessage)
        {
            byte[] bytes = Convert.FromBase64String(encodedMessage); // decode Base64 string to bytes
            string decodedMessage = Encoding.UTF8.GetString(bytes); // convert bytes to message
            return decodedMessage;
        }
    }
}


