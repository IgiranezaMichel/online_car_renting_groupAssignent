namespace carrentalgroupassignment.Tables
{
    public class Car
    {
        private string platenumber;
        private string brand;
        private int seats;
        private int suitcase;
        private string description;
        private int price;
        private byte[] img1;
        private byte[] img2;
        private string bas64img1;
        private string bas64img2;
        public string Platenumber { get { return platenumber; } set { platenumber = value; } }
        public string Brand { get { return brand; } set { brand = value; } }
        public int Seats { get { return seats; } set { seats = value; } }
        public int Suitcase { get { return suitcase; } set { suitcase = value; } }
        public byte[] Image1 { get { return img1;} set { img1 = value; } }
        public byte[] Image2 { get { return img2; } set { img2 = value; } }
        public string Description { get { return description; }set {description = value; }   }
        public int Price { get { return price;} set { price = value; } }
        public string Bas64img1 { get { return bas64img1; }set { bas64img1 = value; } }
        public string Bas64img2 { get { return bas64img2; } set { bas64img2 = value; } }

    }
    }

