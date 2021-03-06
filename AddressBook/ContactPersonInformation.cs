using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace AddressBook
{
    public class ContactPersonInformation
    {
        //Declaring List to store contact details
        List<ContactDetails> contactDetailsList;
        Dictionary<string, List<ContactDetails>> cityDetailsDictionary;
        HashSet<string> cityList;
        HashSet<string> stateList;

        /// <summary>
        /// Declaring constructor to inititate list
        /// </summary>
        public ContactPersonInformation()
        {
            contactDetailsList = new List<ContactDetails>();
            cityDetailsDictionary = new Dictionary<string, List<ContactDetails>>();
            cityList = new HashSet<string>();
            stateList = new HashSet<string>();
        }

        /// <summary>
        /// Adding contact details in the list
        /// </summary>
        public void AddingContactDetails()
        {
            ContactPersonInformation contactPersonalInformation = new ContactPersonInformation();
            //able to add multiple contact details in one list

            Console.WriteLine("Enter How many contact you want to add");
            int num = Convert.ToInt32(Console.ReadLine());

            for ( int x=0; x<num; x++)
            {
                //used goto method to call the method again
                Repeat: Console.WriteLine("Please enter first name, last name, address, city, state, zip, phoneno and email");
                string firstName = Console.ReadLine();
                if (firstName == "")
                {
                    //if first name is null, then no more contact details are entered
                    Console.WriteLine("No more contact details have been entered");
                    break;
                }

                string lastName = Console.ReadLine();
                bool checkForContactInList = contactPersonalInformation.CheckingForNameinExistingContactList(contactDetailsList, firstName, lastName);
                if (checkForContactInList == false)
                {
                    Console.WriteLine("Name already exist in the contact list, please enter new name");
                    continue;
                }
                string address = Console.ReadLine();
                string city = Console.ReadLine();
                string state = Console.ReadLine();
                int zip = Convert.ToInt32(Console.ReadLine());
                double phoneNo = Convert.ToDouble(Console.ReadLine());
                if (phoneNo <= 200000)
                {
                    //if phone no is less than 200000 than details are entered again
                    Console.WriteLine("Entered Wrong Phone no. : AdditionContactDetails()");
                    Console.WriteLine("Wrong phone details entered, please enter your details again");
                    goto Repeat;
                }
                string eMail = Console.ReadLine();

                ContactDetails contactDetails = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNo, eMail);

                //Adding Contact details in the list
                contactDetailsList.Add(contactDetails);
                Console.WriteLine("Contact Details Addition Successful: AddingContactDetails()");
            }
            contactPersonalInformation.DisplayContactDetails();

        }
        /// <summary>
        /// Displaying contact details of one address book
        /// </summary>
        public void DisplayContactDetails()
        {
            foreach (ContactDetails contactPerson in contactDetailsList)
            {
                Console.WriteLine($"First Name : {contactPerson.firstName} || Last Name: {contactPerson.lastName} || Address: {contactPerson.address} || City: {contactPerson.city} || State: {contactPerson.state}|| zip: {contactPerson.zip} || Phone No: {contactPerson.phoneNo} || eMail: {contactPerson.eMail}");
            }
            Console.WriteLine("Displaying Contact Details Successful :DisplayingContactDetails()");
        }

        public void AddingContactDetailsinTextFile(string addressBookName)
        {
            string path = @"C:\Users\Swapnil Bagul\source\repos\AddressBook\AddressBook\Files\Data.txt";
            if (File.Exists(path))
            {

                using (StreamWriter sr = File.AppendText(path))
                {
                    sr.WriteLine("The name of the address book is" + addressBookName);
                    foreach (ContactDetails contactPerson in contactDetailsList)
                    {
                        sr.WriteLine($"First Name : {contactPerson.firstName} || Last Name: {contactPerson.lastName} || Address: {contactPerson.address} || City: {contactPerson.city} || State: {contactPerson.state}|| zip: {contactPerson.zip} || Phone No: {contactPerson.phoneNo} || eMail: {contactPerson.eMail}");
                    }

                    //string lines = File.ReadAllText(path);
                    //Console.WriteLine(lines);
                    sr.Close();
                }
            }
        }
        public void AddingContactDetailsInJsonFile(string addressBookName)
        {
            //giving path of the json file with the help of address book name
            string pathforJson = @"C:\Users\Swapnil Bagul\source\repos\AddressBook\AddressBook\Files\Data.json";
            //path for writing each json file, is converted into stream
            StreamWriter writerJson = new StreamWriter(pathforJson);
            //serializing data to write to json file
            JsonSerializer serializer = new JsonSerializer();
            JsonWriter sw = new JsonTextWriter(writerJson);
            //passing list to serialize and convert to json
            serializer.Serialize(sw, contactDetailsList);
            writerJson.Close();
        }
        /// <summary>
        /// Edits contact details in address book
        /// </summary>
        public void EditingContactDetails()
        {
            ContactPersonInformation contact = new ContactPersonInformation();
        //using go to method for repeating the process
        //better process is using exceptions
        addingDetailsAgainForEditing: Console.WriteLine("Please help us, first identify you");
            Console.WriteLine("Please enter your first name and phone no");
            string firstNm = Console.ReadLine();
            int editCheck = 0;
            double mobileNo = Convert.ToDouble(Console.ReadLine());
            foreach (ContactDetails contactDetails in contactDetailsList)
            {
                //using first name and mobile  no to verify contact person
                if (contactDetails.firstName == firstNm && contactDetails.phoneNo == mobileNo)
                {
                    //asking user to input detail of what needs to be edited and forwarding the input to switch case.
                    EditAgain: Console.WriteLine("please select the serial no. of field which you want to change\n 1. First name \n2.Last name\n3.Address\n4.City\n5.State\n6.Zip code\n7.Phone no.\n 8.email");
                    int inputForEditing = Convert.ToInt32(Console.ReadLine());
                    editCheck++;
                    switch (inputForEditing)
                    {
                        case 1:
                        firstname: Console.WriteLine("please enter the first name");
                            string newFirstName = Console.ReadLine();
                            if (contactDetails.firstName == newFirstName)
                            {
                                Console.WriteLine("You entered same user name");
                                Console.WriteLine("Please enter details again");
                                goto firstname;
                            }
                            //details are edited
                            contactDetails.firstName = newFirstName;
                            Console.WriteLine("Debug successful, firstname successfully changed : EditingContactDetails()");
                            Console.WriteLine("Do you want to update anything else, press y to update again,else press enter");
                            string inputAfterFirstName = Console.ReadLine();
                            if (inputAfterFirstName.ToLower() == "y")
                            {
                                Console.WriteLine("User wants to update further information");
                                goto EditAgain;
                            }
                            else
                            {
                                Console.WriteLine("Updation Process Completed : EditinContactDetails()");
                                break;
                            }
                        case 2:
                        lastname: Console.WriteLine("please enter the last name");
                            string newlastName = Console.ReadLine();
                            if (contactDetails.lastName == newlastName)
                            {
                                Console.WriteLine("You entered same user name");
                                Console.WriteLine("Please enter details again");
                                goto lastname;
                            }
                            contactDetails.lastName = newlastName;
                            Console.WriteLine("Debug successful, lastname successfully changed : EditingContactDetails()");
                            Console.WriteLine("Do you want to update anything else, press y to update again,else press enter");
                            string inputAfterlastName = Console.ReadLine();
                            if (inputAfterlastName.ToLower() == "y")
                            {
                                Console.WriteLine("User wants to update further information");
                                goto EditAgain;
                            }
                            else
                            {
                                Console.WriteLine("Updation Process Completed : EditinContactDetails()");
                                break;
                            }
                        case 3:
                        address: Console.WriteLine("please enter the address");
                            string newaddress = Console.ReadLine();
                            if (contactDetails.address == newaddress)
                            {
                                Console.WriteLine("You entered same user name");
                                Console.WriteLine("Please enter details again");
                                goto address;
                            }
                            contactDetails.address = newaddress;
                            Console.WriteLine("Debug successful, address successfully changed : EditingContactDetails()");
                            Console.WriteLine("Do you want to update anything else, press y to update again,else press enter");
                            string inputAfteraddress = Console.ReadLine();
                            if (inputAfteraddress.ToLower() == "y")
                            {
                                Console.WriteLine("User wants to update further information");
                                goto EditAgain;
                            }
                            else
                            {
                                Console.WriteLine("Updation Process Completed : EditinContactDetails()");
                                break;
                            }
                        case 4:
                        city: Console.WriteLine("please enter the city");
                            string newcity = Console.ReadLine();
                            if (contactDetails.city == newcity)
                            {
                                Console.WriteLine("You entered same detail");
                                Console.WriteLine("Please enter details again");
                                goto city;
                            }
                            contactDetails.city = newcity;
                            Console.WriteLine("Debug successful, city successfully changed : EditingContactDetails()");
                            Console.WriteLine("Do you want to update anything else, press y to update again,else press enter");
                            string inputAftercity = Console.ReadLine();
                            if (inputAftercity.ToLower() == "y")
                            {
                                Console.WriteLine("User wants to update further information");
                                goto EditAgain;
                            }
                            else
                            {
                                Console.WriteLine("Updation Process Completed : EditinContactDetails()");
                                break;
                            }
                        case 5:
                        state: Console.WriteLine("please enter the state");
                            string newstate = Console.ReadLine();
                            if (contactDetails.state == newstate)
                            {
                                Console.WriteLine("You entered same detail");
                                Console.WriteLine("Please enter details again");
                                goto state;
                            }
                            contactDetails.state = newstate;
                            Console.WriteLine("Debug successful, state successfully changed : EditingContactDetails()");
                            Console.WriteLine("Do you want to update anything else, press y to update again,else press enter");
                            string inputAfterstate = Console.ReadLine();
                            if (inputAfterstate.ToLower() == "y")
                            {
                                Console.WriteLine("User wants to update further information");
                                goto EditAgain;
                            }
                            else
                            {
                                Console.WriteLine("Updation Process Completed : EditinContactDetails()");
                                break;
                            }
                        case 6:
                        zip: Console.WriteLine("please enter the zip code");
                            int newzip = Convert.ToInt32(Console.ReadLine());
                            if (contactDetails.zip == newzip)
                            {
                                Console.WriteLine("You entered same detail");
                                Console.WriteLine("Please enter details again");
                                goto zip;
                            }
                            contactDetails.zip = newzip;
                            Console.WriteLine("Debug successful, zip successfully changed : EditingContactDetails()");
                            Console.WriteLine("Do you want to update anything else, press y to update again,else press enter");
                            string inputAfterzip = Console.ReadLine();
                            if (inputAfterzip.ToLower() == "y")
                            {
                                Console.WriteLine("User wants to update further information");
                                goto EditAgain;
                            }
                            else
                            {
                                Console.WriteLine("Updation Process Completed : EditinContactDetails()");
                                break;
                            }
                        case 7:
                        phoneno: Console.WriteLine("please enter the zip code");
                            double newmobileno = Convert.ToDouble(Console.ReadLine());
                            if (contactDetails.phoneNo == newmobileno || newmobileno <= 200000)
                            {
                                Console.WriteLine("You either entered same details or wrong details");
                                Console.WriteLine("Please enter details again");
                                goto phoneno;
                            }
                            contactDetails.phoneNo = newmobileno;
                            Console.WriteLine("Debug successful, phoneno successfully changed : EditingContactDetails()");
                            Console.WriteLine("Do you want to update anything else, press y to update again,else press enter");
                            string inputAfterphone = Console.ReadLine();
                            if (inputAfterphone.ToLower() == "y")
                            {
                                Console.WriteLine("User wants to update further information");
                                goto EditAgain;
                            }
                            else
                            {
                                Console.WriteLine("Updation Process Completed : EditinContactDetails()");
                                break;
                            }
                        case 8:
                        email: Console.WriteLine("please enter the email code");
                            string newemail = Console.ReadLine();
                            if (contactDetails.eMail == newemail)
                            {
                                Console.WriteLine("You entered same detail");
                                Console.WriteLine("Please enter details again");
                                goto email;
                            }
                            contactDetails.eMail = newemail;
                            Console.WriteLine("Debug successful, email successfully changed : EditingContactDetails()");
                            Console.WriteLine("Do you want to update anything else, press y to update again,else press enter");
                            string inputAfteremail = Console.ReadLine();
                            if (inputAfteremail.ToLower() == "y")
                            {
                                Console.WriteLine("User wants to update further information");
                                goto EditAgain;
                            }
                            else
                            {
                                Console.WriteLine("Updation Process Completed : EditinContactDetails()");
                                break;
                            }
                        default:
                            Console.WriteLine("Wrong input entered");
                            Console.WriteLine("Do you want to input again");
                            string input = Console.ReadLine();
                            if (input.ToLower() == "y")
                            {
                                goto EditAgain;
                            }
                            else
                                break;

                    }
                }

                //ContactPersonInformation contact = new ContactPersonInformation();

            }
            //Console.WriteLine("Your input does not match our data");
            if (editCheck == 0)
            {
                Console.WriteLine("It looks like you are entering wrong details");
                Console.WriteLine("Wrong details entered for editing");
                Console.WriteLine("Nothing has been edited");
            }
            Console.WriteLine("Do you want to input again, press y to input details");

            string check = Console.ReadLine();
            if (check.ToLower() == "y")
            {
                Console.WriteLine("details are being entered again by user");
                goto addingDetailsAgainForEditing;
            }
            contact.DisplayContactDetails();
        }
        /// <summary>
        /// Deleting contact details from address book
        /// </summary>
        public void DeletingContactDetails()
        {
        addingDetailsForDeleting: Console.WriteLine("Please help us, first identify you");
            Console.WriteLine("Please enter your first name and phone no");
            string firstNm = Console.ReadLine();
            double mobileNo = Convert.ToDouble(Console.ReadLine());
            int index = 0;
            foreach (ContactDetails contactDetails in contactDetailsList)
            {
                if (contactDetails.firstName == firstNm && contactDetails.phoneNo == mobileNo)
                {
                    //removing selected object of contact details from contact details list
                    contactDetailsList.Remove(contactDetails);
                    Console.WriteLine("deletion operation successful");
                    Console.WriteLine("Deletion Operation Successful:DeletingContactDetails()");
                    index++;
                    break;
                }

            }
            //Console.WriteLine("Your input does not match our data");
            if (index == 0)
            {
                Console.WriteLine("It looks like you are entering wrong details");
                Console.WriteLine("Wrong details entered for deleting");
                Console.WriteLine("Nothing has been deleted");
            }
            Console.WriteLine("Do you want to input again, press y to input details");

            string check = Console.ReadLine();
            if (check.ToLower() == "y")
            {
                Console.WriteLine("details are being entered again by user:DeletingContactDetails()");
                goto addingDetailsForDeleting;
            }
            else
            {
                Console.WriteLine("Process Completed");
            }

        }
        /// <summary>
        /// checking if the same name exist in the list
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public bool CheckingForNameinExistingContactList(List<ContactDetails> contactDetailsList, string firstName, string lastName)
        {
            //checking the details using lambda expression
            //find is used to return object, once value matches
            //s contains individual element from list, which is contact details, hence assigned to contact details
            ContactDetails contactDetails = contactDetailsList.Find(s => s.firstName == firstName && s.lastName == lastName);
            if (contactDetails != null)
            {
                //if same contact details are entered, than details are entered again
                Console.WriteLine("Contact details have already been entered");
                Console.WriteLine("Contact details have already been entered \n please add new contact details");
                return false;

            }
            return true;
        }
        /// <summary>
        /// Method to search contact details using city
        /// </summary>
        /// <param name="searchCity"></param>
        /// <returns>used to throw exception</returns>
        public void SearchingContactDetailsByCity(string searchCity)
        {
            //used to check if city exist and increments the index. If index=0, exception is thrown
            int index = 0;
            //used lambda expression for checking equality with the city
            foreach (ContactDetails contactPerson in contactDetailsList.FindAll(s => s.city.Equals(searchCity)))
            {
                //checks if city is there in list
                //if(contactPerson.city.Equals(searchCity))
                // {
                Console.WriteLine($"First Name : {contactPerson.firstName} || Last Name: {contactPerson.lastName} || Address: {contactPerson.address} || City: {contactPerson.city} || State: {contactPerson.state}|| zip: {contactPerson.zip} || Phone No: {contactPerson.phoneNo} || eMail: {contactPerson.eMail}");
                index++;
                //}
            }
            if (index == 0)
            {
                //custom exception is thrown when city is not in list
                Console.WriteLine("there is no state in this list with this name");
            }

        }
        /// <summary>
        /// Method to search details using state
        /// </summary>
        /// <param name="searchState"></param>
        /// <returns>used to throw exception</returns>
        public void SearchingContactDetailsByState(string searchState)
        {
            //index is used to check if state exist
            int index = 0;
            //using lambda expression to search for state among contact person list
            foreach (ContactDetails contactPerson in contactDetailsList.FindAll(s => s.state.Equals(searchState)))
            {
                //if (contactPerson.state.Equals(searchState))
                //{
                //Displays details for particular state
                Console.WriteLine($"First Name : {contactPerson.firstName} || Last Name: {contactPerson.lastName} || Address: {contactPerson.address} || City: {contactPerson.city} || State: {contactPerson.state}|| zip: {contactPerson.zip} || Phone No: {contactPerson.phoneNo} || eMail: {contactPerson.eMail}");
                index++;
                //}
            }
            if (index == 0)
            {
                //prints message
                Console.WriteLine("there is no state in this list with this name");
            }
        }
        /// <summary>
        /// Adding contact details by city in list
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="cityDetailsList">city details list obtained from other address books</param>
        /// <returns>list of contact details from one address book</returns>
        public List<ContactDetails> AddingContactDetailsByCity(string cityName, List<ContactDetails> cityDetailsList)
        {
            //foreach loop iterates over each contact person details, and if city matches, contact details are added in list
            //loop runs until all the values are searched in one addressbook, contact detail list.
            //returns the citydetail list from one addressbook
            //same city detail list is received as a parameter for other address book
            //using lambda expression to search for cityname in contact detail list
            foreach (ContactDetails contactPerson in contactDetailsList.FindAll(s => s.city.Equals(cityName)))
            {
                //checks if city is there in list
                //if (contactPerson.city.Equals(cityName))
                //{
                cityDetailsList.Add(contactPerson);
                //}
            }
            return cityDetailsList;
        }
        /// <summary>
        /// Gets hashset of all the cities in particular contact list
        /// </summary>
        /// <returns></returns>
        public HashSet<string> GettingCityList()
        {
            //foreach loop is used to get each entry in contact list in address book
            //each city is taken out and added in cityList which is hashset
            //hashset is returned
            foreach (ContactDetails contactPerson in contactDetailsList)
            {
                cityList.Add(contactPerson.city);
            }
            return cityList;
        }
        /// <summary>
        /// Adding contact details by state in list
        /// </summary>
        /// <param name="stateName"></param>
        /// <param name="stateDetailsList">city details list obtained from other address books</param>
        /// <returns>list of contact details from one address book</returns>
        public List<ContactDetails> AddingContactDetailsByState(string stateName, List<ContactDetails> stateDetailsList)
        {
            //foreach loop iterates over each contact person details, and if state matches, contact details are added in list
            //loop runs until all the values are searched in one addressbook, contact detail list.
            //returns the statedetail list from one addressbook
            //same state detail list is received as a parameter for other address book
            //using lambda function to search for state name in contact list
            foreach (ContactDetails contactPerson in contactDetailsList.FindAll(s => s.state.Equals(stateName)))
            {
                //checks if state is there in list
                //if (contactPerson.state.Equals(stateName))
                //{
                stateDetailsList.Add(contactPerson);
                //}
            }
            return stateDetailsList;
        }
        /// <summary>
        /// Gets hashset of all the states in particular contact list
        /// </summary>
        /// <returns></returns>
        public HashSet<string> GettingStateList()
        {
            //foreach loop is used to get each entry in contact list in address book
            //each state is taken out and added in stateList which is hashset
            //hashset is returned
            foreach (ContactDetails contactPerson in contactDetailsList)
            {
                stateList.Add(contactPerson.state);
            }
            return stateList;
        }
    }


}
