namespace GoldIsMony1
{
    public class Booking
    {                                                                       //Class Booking
        public string SenderAccount { get; set; }
        public string RecipientAccount { get; set; }
        public string Propose { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }


        public Booking(string senderAccount, string recipientAccount, string propose, double amount, string date)
        {
            SenderAccount = senderAccount;
            RecipientAccount = recipientAccount;
            Propose = propose;
            Amount = amount;
            Date = date;
        }
    }
        
}
