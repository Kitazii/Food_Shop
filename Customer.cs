using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssessmentShop
{
    public class Customer
    {
        //Private atts for customer
        private string firstName, lastName, emailAddress, comment;

        //Constructor (0 parameter)
        public Customer()
        {
            firstName = "Kieran";
            lastName = "Burns";
            emailAddress = "mr.kieranburns@gmail.com";
            comment = "Yessir";
        }

        // Constructor (4 parameter)
        public Customer(string firstNamein, string lastNamein, string emailAddressin, string commentin)
        {
            firstName = firstNamein;
            lastName = lastNamein;
            emailAddress = emailAddressin;
            comment = commentin;
        }

        //create setter methods for customer
        public void setFirstName(string firstNamein)
        {
            firstName = firstNamein;
        }

        public void setLastName(string lastNamein)
        {
            lastName = lastNamein;
        }

        public void setEmailAddress(string emailAddressin)
        {
            emailAddress = emailAddressin;
        }

        public void setComment(string commentin)
        {
            comment = commentin;
        }

        //create getter method for customer
        public string getFirstName() 
        { 
            return firstName; 
        }
        public string getLastName()
        {
            return lastName;
        }

        public string getEmailAddress()
        {
            return emailAddress;
        }

        public string getComment()
        {
            return comment;
        }

    }
}