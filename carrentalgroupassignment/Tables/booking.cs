namespace carrentalgroupassignment.Tables
{
    public class booking
    {
        private string customeremail;
        private string platenumber;
        private DateTime fromDate;
        private DateTime toDate;
        private int isbooked;
        private double payment;
        public string Customeremail { get { return customeremail; } set { customeremail = value;} }
        public string Platenumber { get { return platenumber; } set { platenumber = value; } }
        public DateTime FromDate { get { return fromDate; } set { fromDate = value; } }
        public DateTime ToDate { get { return toDate; } set { toDate = value; } }
        public int Isbooked { get { return isbooked; } set { isbooked = value; } }
        public double Payment { get { return payment; } set { payment = value; } }
    }
}
