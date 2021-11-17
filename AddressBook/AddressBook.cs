using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    public class AddressBook
    {
        public Dictionary<string, ContactPersonInformation> addressBookMapper = new Dictionary<string, ContactPersonInformation>();
        /// <summary>
        /// Adding new Address Book
        /// </summary>
        public void AddAdressBook()
        {
            Console.WriteLine("\nEnter Name for the New Address Book");
            string name = Console.ReadLine();
            //checking address book, if name entered is existing
            if (addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("Address Book Already exist with this name");
            }
            else
            {
                //Adding the name and contact person information class in dictionary
                ContactPersonInformation contactPersonInformation = new ContactPersonInformation();
                addressBookMapper.Add(name, contactPersonInformation);
            }
        }

        /// <summary>
        /// Adding contacts in Address Book
        /// </summary>
        public void AddContactsInAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to add new contact");
            string name = Console.ReadLine();
            //checking, if the name is existing in the dictionary
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                //displaying the available dictionary names
                foreach (KeyValuePair<string, ContactPersonInformation> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                //calling the methods to add contact details in dictionary and displaying it
                ContactPersonInformation contactPersonInformation = addressBookMapper[name];
                contactPersonInformation.AddingContactDetails();
                contactPersonInformation.DisplayContactDetails();
            }
        }
        /// <summary>
        /// Editing contact person details from address book
        /// </summary>
        public void EditDetailsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to modify contact details");
            string name = Console.ReadLine();
            //checking if the name exist in dictionary
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                //displaying the names that are available in dictionary
                foreach (KeyValuePair<string, ContactPersonInformation> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                // calling the methods from contact person information to display and edit contact person details in address book 
                ContactPersonInformation contactPersonInformation = addressBookMapper[name];
                contactPersonInformation.EditingContactDetails();
                contactPersonInformation.DisplayContactDetails();
            }
        }
        /// <summary>
        /// Deleting contact person details from address book
        /// </summary>

        public void DeleteContactsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to delete contact details");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, ContactPersonInformation> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                //Calling method to delete contact details from address book
                ContactPersonInformation contactPersonInformation = addressBookMapper[name];
                contactPersonInformation.DeletingContactDetails();
                contactPersonInformation.DisplayContactDetails();
            }
        }
        /// <summary>
        /// Displaying available adddress books and their contact details
        /// </summary>
        public void DisplayingAddressBooks()
        {
            Console.WriteLine("***********************************************************");
            foreach (KeyValuePair<string, ContactPersonInformation> dictionaryPair in addressBookMapper)
            {
                Console.WriteLine("the name of address book is " + dictionaryPair.Key);
                ContactPersonInformation contactPersonInformation = dictionaryPair.Value;
                contactPersonInformation.DisplayContactDetails();
            }
        
        }
        /// <summary>
        /// Removing complete address book
        /// </summary>
        public void DeletingAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to delete ");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, ContactPersonInformation> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                //Removes address book from the Dictionary
                addressBookMapper.Remove(name);
            }
        }
        /// <summary>
        /// Searching by city for address book and contact details
        /// </summary>
        public void SearchingByCity()
        {
            try
            {
                Console.WriteLine("Please enter the city");
                string searchCity = Console.ReadLine();
                //foreach loop to print name of address book and pass address book value to contact person information class
                foreach (KeyValuePair<string, ContactPersonInformation> keyValuePair in addressBookMapper)
                {
                    Console.WriteLine("Name of the address book: " + keyValuePair.Key);
                    ContactPersonInformation contactPersonInformation = keyValuePair.Value;
                    bool checkForException = contactPersonInformation.SearchingContactDetailsByCity(searchCity);
                }
            }
            //catches exception if city name does not exist
            catch (AddressBookCustomException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Do you want to enter city again, press y for yes");
                string checkInput = Console.ReadLine();
                if (checkInput.ToLower() == "y")
                {
                    SearchingByCity();
                }
                else
                {
                    Console.WriteLine("No city entered");

                }
            }
        }
        /// <summary>
        /// Searching by state to get address book and contact details
        /// </summary>
        public void SearchingByState()
        {
            //used to find custom exception, if state do not exist
            try
            {
                Console.WriteLine("Please enter the state");
                string searchState = Console.ReadLine();
                //foreach loop is used to print key for dictionary and pass the values of dictionary to contact person information class
                foreach (KeyValuePair<string, ContactPersonInformation> keyValuePair in addressBookMapper)
                {
                    Console.WriteLine("Name of the address book: " + keyValuePair.Key);
                    ContactPersonInformation contactPersonInformation = keyValuePair.Value;
                    bool checkForException = contactPersonInformation.SearchingContactDetailsByCity(searchState);
                }
            }
            catch (AddressBookCustomException ex)
            {
                //Exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Do you want to enter state again, press y for yes");
                string checkInput = Console.ReadLine();
                if (checkInput.ToLower() == "y")
                {
                    //Details of state are entered again.
                    SearchingByState();
                }
                else
                {
                    Console.WriteLine("No state entered");

                }
            }
        }
    }
}
