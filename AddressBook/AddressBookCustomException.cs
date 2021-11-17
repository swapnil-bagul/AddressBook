using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBookCustomException : Exception
    {
        public enum ExceptionType
        {
            Wrong_city_name, Wrong_state_name
        }
        private readonly ExceptionType type;
        /// <summary>
        /// Address Book custom exception constructor to define exception type and write message
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public AddressBookCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }


    }
}
