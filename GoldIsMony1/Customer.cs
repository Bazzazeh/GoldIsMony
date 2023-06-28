namespace GoldIsMony1
{
    class Customer
    {                                                   //Class Customer
        public int CustomerID { get; set; }
        public string Name { get; set; }

        public Customer(int customerID, string name)
        {
            CustomerID = customerID;
            Name = name;
        }

        
    }
}
