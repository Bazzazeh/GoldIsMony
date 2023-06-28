using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace GoldIsMony1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)            //Method to open and display the customers when i click Open Button
        {
            List<Customer> list = FileReader.ReadCustomers("Kunden.csv");
            foreach (Customer customer in list)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = "CustomerID:   "+customer.CustomerID + " ---- " + " Name:   "+customer.Name; 
                listBoxItem.Tag = customer;
                ListBox.Items.Add(listBoxItem);

            }
        }

        private void DetailBtn_Click(object sender, RoutedEventArgs e)          //Method to  display the accuonts for the selected customer  when i click Details Button
        {
            ListBoxTwo.Items.Clear();
            ListBoxItem item = ListBox.SelectedItem as ListBoxItem;
            Customer customer = item.Tag as Customer;
            List<Account> accounts = FileReader.ReadAccounts("Konten.csv");
            foreach (Account account in accounts)
            {
                if (account.CustumerID == customer.CustomerID)
                {
                    ListBoxItem accountitem = new ListBoxItem();
                    accountitem.Content = account.AccountNr;
                    accountitem.Tag = account;
                    ListBoxTwo.Items.Add(accountitem);
                }

            }
        }

        private void BookingBtn_Click(object sender, RoutedEventArgs e)             //Method to  display the bookings for the selected account when i click Details Button
        {
            
            ListBoxThree.Items.Clear();
            ListBoxItem item = ListBoxTwo.SelectedItem as ListBoxItem;
            Account account = item.Tag as Account;
            List<Booking> bookings = FileReader.ReadBooking("Buchungen.csv");

            foreach (Booking book in bookings)
            {
                if (book.SenderAccount == account.AccountNr)
                {
                    ListBoxItem bookingItem = new ListBoxItem();
                    bookingItem.Content = "RecipientAccount:  " + book.RecipientAccount + "--"+" Propose:  " + book.Propose + "--" + " Amount:  " + book.Amount + "--" +" Date:  "+ book.Date;
                    bookingItem.Tag = book;
                    ListBoxThree.Items.Add(bookingItem);
                    
                }
            }
        }

        private void SaveBookingBtn_Click(object sender, RoutedEventArgs e)             //Method to  svae the booking  when i click Details Button
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save in";
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFile.Filter = "Text File|*.txt|Csv File|*.csv";
            
            if(saveFile.ShowDialog() == true)
            {
                string file = saveFile.FileName;
                using(StreamWriter sw = new StreamWriter(file))
                {
                    foreach (var item in ListBoxThree.Items)
                    {
                        sw.WriteLine((item as ListBoxItem).Content.ToString());
                    }
                }
            }

        }

    }
}
