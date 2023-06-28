using System.Collections.Generic;
using System.IO;

namespace GoldIsMony1
{
    class FileReader
    {
        public static List<Customer> ReadCustomers(string filename)         //Method to read the Kunden.csv
        {
            List<Customer> customers = new List<Customer>();
            using (StreamReader reader = new StreamReader(filename))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    int id = int.Parse(fields[0]);
                    string name = fields[1];
                    Customer customer = new Customer(id, name);
                    customers.Add(customer);
                }
            }
            return customers;
        }

        public static List<Account> ReadAccounts(string filename)           //Method to read Konten.csv
        {
            List<Account> accounts = new List<Account>();
            using (StreamReader reader = new StreamReader(filename))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    int customerID = int.Parse(fields[0]);
                    string accountNumber = (fields[1]);
                    Account account = new Account(customerID, accountNumber);
                    accounts.Add(account);

                }
            }
            return accounts;
        }

        public static List<Booking> ReadBooking(string filename)            //Method to read Buchungen.csv
        {
            List<Booking> bookings = new List<Booking>();
            using (StreamReader reader = new StreamReader(filename))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    string accountNumber = fields[0];
                    string recipientAccount = fields[1];
                    
                    string poropse = fields[2];
                    double amount = double.Parse(fields[3]);
                    string date = fields[4];



                    Booking booking = new Booking(accountNumber, recipientAccount, poropse, amount, date);
                    bookings.Add(booking);
                }
            }
            return bookings;
        }

    }
}
