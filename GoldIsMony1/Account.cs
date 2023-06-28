namespace GoldIsMony1
{
    class Account
    {                                                       // Class Accuont
        public int CustumerID { get; set; }
        public string AccountNr { get; set; }


        public Account(int custumerID, string accountNr)
        {
            CustumerID = custumerID;
            AccountNr = accountNr;
        }

        
    }
}
