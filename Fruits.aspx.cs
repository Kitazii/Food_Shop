using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssessmentShop;

namespace Template_Project
{   
    public partial class Page1 : System.Web.UI.Page
    {
        //stage 4 - Linking WebForms

        List<Food> fruitTypesList = new List<Food>(); //creating a list to store fruit type values
        private int caloriesTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadFruitTypes(); //calling method to page_load
        }

        public void loadFruitTypes()
        {
            //stage 5 : Displaying Images

            //public Food(string nameOfFoodin, string weightOfFoodin, int kiloCaloriesin, string picturein)
            //creating an object which is an instance of the food class and passing values through to the constructor in that class
            Food fruitType1 = new Food("Apples", "250g", 130, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/apples-at-farmers-market-royalty-free-image-1627321463.jpg");
            Food fruitType2 = new Food("Bannanas", "250g", 223, "https://images.immediate.co.uk/production/volatile/sites/30/2017/01/Bananas-218094b-scaled.jpg");
            Food fruitType3 = new Food("Oranges", "250g", 118, "https://cdn.britannica.com/24/174524-050-A851D3F2/Oranges.jpg");
            Food fruitType4 = new Food("Grapes", "250g", 168, "https://www.heddensofwoodtown.co.uk/wp-content/uploads/2020/05/grapes_green_opt.jpg");

            //adding the values to the list created above
            fruitTypesList.Add(fruitType1);
            fruitTypesList.Add(fruitType2);
            fruitTypesList.Add(fruitType3);
            fruitTypesList.Add(fruitType4);

            createFruitGrid(); //call grid method
            LoadAndSaveTotal(); //call load and save method

        }

        public void LoadAndSaveTotal()
        {
            //checking and saving orderTotal
            if (Session["caloriesTotal"] == null)
            {
                caloriesTotal = 0;
            }
            //setting/getting values into orderTotal
            else
            {
                caloriesTotal = Convert.ToInt32(Session["caloriesTotal"]);
            }

            //displaying order total
            lblCalTotal.Text = "Calories Total: " + caloriesTotal;
        }

        public void createFruitGrid()
        {
            //storing a table in memory - creating and storing columns here
            DataTable fruitTableData = new DataTable();
            fruitTableData.Columns.Add("nameOfFood");
            fruitTableData.Columns.Add("weightOfFood");
            fruitTableData.Columns.Add("kiloCalories");
            fruitTableData.Columns.Add("picture");
            fruitTableData.Columns.Add("fruitsCalBtn");

            //add fruits stored in the List to each row in the fruitTable
            foreach (Food fruits in fruitTypesList)
            {
                fruitTableData.Rows.Add(
                    fruits.getnameOfFood(),
                    fruits.getweightOfFood(),
                    fruits.getkiloCalories() + " kcals",
                    fruits.getpicture()
                    );
            }

            //retrieves the data stored in the table and stores it in grid grdfruits
            //binds the data to the grid
            grdFruits.DataSource = fruitTableData; 
            grdFruits.DataBind();

            int rowForImage = 0;
            //adding the images to each fruit in the List
            foreach (Food fruits in fruitTypesList)
            {
                System.Web.UI.WebControls.Image fruitImage = new System.Web.UI.WebControls.Image {
                    ImageUrl = fruits.getpicture(),
                    Height = 75,
                    Width = 75
                };

                //Controls which image goes where on the grid
                grdFruits.Rows[rowForImage].Cells[3].Controls.Add(fruitImage);
                rowForImage++;
            }

            int rowForButton = 0;
            //adding the images to each fruit in the List
            foreach (Food fruits in fruitTypesList)
            {
                Button fruitsCalBtn = new Button {
                    Text = "Fruits Calories",
                    CommandName = Convert.ToString(fruits.getkiloCalories())
                };

                fruitsCalBtn.Command += new CommandEventHandler(fruitsCalBtn_Click);

                //Controls which image goes where on the grid
                grdFruits.Rows[rowForButton].Cells[4].Controls.Add(fruitsCalBtn);
                rowForButton++;

                //Changes button Border style & Background colour
                fruitsCalBtn.BorderStyle = BorderStyle.Groove;
                fruitsCalBtn.BackColor = Color.Lime;
            }
        }

        protected void fruitsCalBtn_Click(object sender, CommandEventArgs e)
        {
            int fruitsCalories = Convert.ToInt32(e.CommandName);

            //checking and saving orderTotal
            if (Session["caloriesTotal"] == null)
            {
                caloriesTotal = fruitsCalories;
                Session["caloriesTotal"] = caloriesTotal;
            }
            //getting values into orderTotal
            else
            {
                caloriesTotal = Convert.ToInt32(Session["caloriesTotal"]);
                caloriesTotal += fruitsCalories;
            }

            //saving and displaying caloriesTotal
            Session["caloriesTotal"] = caloriesTotal;
            lblCalTotal.Text = "Calories Total: " + caloriesTotal;
        }

        protected void btnClearCal_Click(object sender, EventArgs e)
        {
            //sets vars values to empty then displays calories to 0
            Session["caloriesTotal"] = null;
            lblCalTotal.Text = "Calories Total: 0";
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