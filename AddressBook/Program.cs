using System;

namespace AddressBook
{
    class Program
    {
        /// <summary>
        /// Main program to call different methods
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Management System");
            //creating object for Address Book Class
            AddressBook addressBook = new AddressBook();
            bool flag = true;

            while (flag)
            {
                //Taking input for user to determine task to do
                //passing the input to switch case
                //Calling the methods from Address Book accordingly
                Console.WriteLine("\nEnter 1 to add New Address Book \nEnter 2 to Add Contacts \nEnter 3 to Edit Contacts \nEnter 4 to Delete Contacts\nEnter 5 to display all the addressbooks and contact details\nEnter 6 to delete address book\nEnter 7 to Search Contact Details using City\nEnter 8 to search Contact Details using state\nEnter any other key to exit");
                string options = Console.ReadLine();
                switch (options)
                {
                    case "1":
                        addressBook.AddAdressBook();
                        //addressBook.DisplayingAddressBooks(); 
                        break;
                    case "2":
                        addressBook.AddContactsInAddressBook();
                        addressBook.DisplayingAddressBooks();
                        break;
                    case "3":
                        addressBook.EditDetailsOfAddressBook();
                        addressBook.DisplayingAddressBooks();
                        break;
                    case "4":
                        addressBook.DeleteContactsOfAddressBook();
                        addressBook.DisplayingAddressBooks();
                        break;
                    case "5":
                        addressBook.DisplayingAddressBooks();
                        break;
                    case "6":
                        addressBook.DeletingAddressBook();
                        break;
                    case "7":
                        addressBook.SearchingByCity();
                        break;
                    case "8":
                        addressBook.SearchingByState();
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}
