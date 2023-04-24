namespace carrentalgroupassignment.Tables
{
    public class User
    {
        private string email;
        private string name;
        private string phone;
        private string gender;
        private string password;
        public string Email { get { return email; } set { email = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Password { get { return password; }  set { password = value;} 
    }
    }
}
