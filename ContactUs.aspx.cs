using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AssessmentShop;

namespace Template_Project
{
    public partial class Page5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //getting input for text box field
            string fName = txtFirstName.Text;
            string sName = txtLastName.Text;
            string emailAddress = txtEmail.Text;
            string comment = txtComment.Text;

            //create & declare person object to access constructors in class person
            Customer customerContactingUs = new Customer();

            //check if first & last name, email address and comment fields are empty
            if (fName == "" || sName == "" || emailAddress == "" || comment == "")
            {
                //display error message in the confirmation label
                lblConfirmation.Text = "Error: Please Enter ALL Details.";
            }
            else
            {
                //pass user input through setter methods and set Persons attributes
                customerContactingUs.setFirstName(fName);
                customerContactingUs.setLastName(sName);
                customerContactingUs.setEmailAddress(emailAddress);
                customerContactingUs.setComment(comment);

                //pass person attributes to write peson method
                writePersonToText(customerContactingUs);

                ////get values entered through getter method to return and display persons attributes in the confirmation label
                //lblConfirmation.Text = "" +
                //    "Name: " + customerContactingUs.getFirstName() + "<br/>" +
                //    "Last Name: " + customerContactingUs.getLastName() + "<br/>" +
                //    "Email Address: " + customerContactingUs.getEmailAddress() + "<br/>" +
                //    "Comment: " + customerContactingUs.getComment() + "<br/>";
            }
        }

        public void writePersonToText(Customer customerContactingUs)
        {
            string location = Server.MapPath("~/");
            string file = Path.Combine(location, "KieranBurns.txt"); //combine location path with file name

            
            using (StreamWriter sw = new StreamWriter(file, true)) //using auto closes the stream writer
            {
                //formatted string for date and time
                sw.WriteLine("Time Submitted: " + DateTime.Now.ToString("HH:mm:ss\nddd - dd/MM/yyyy")); //writting out time submited, taking in a string to write commands

                //gets/returns person attributes and store them into the sream writer class
                sw.WriteLine("Name: " + customerContactingUs.getFirstName());
                sw.WriteLine("Surname: " + customerContactingUs.getLastName());
                sw.WriteLine("Email Address: " + customerContactingUs.getEmailAddress());
                sw.WriteLine("Comment: " + customerContactingUs.getComment());
                sw.WriteLine("------------------------------------------------------------");
                //calls form submitted
                formSubmitted();
            }
        }

        public void formSubmitted()
        {

            lblConfirmation.Text = "Details Submitted successfully";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtComment.Text = "";
        }

        //navigates to each page if you press the links
        protected void lnkFruits_Click(object sender, EventArgs e)
        {
            Response.Redirect("Fruits.aspx");
        }

        protected void lnkVegetables_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vegetables.aspx");
        }

        protected void lnkMeats_Click(object sender, EventArgs e)
        {
            Response.Redirect("Meats.aspx");
        }

        protected void lnkDesserts_Click(object sender, EventArgs e)
        {
            Response.Redirect("Desserts.aspx");
        }

        protected void lnkContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }
    }
}