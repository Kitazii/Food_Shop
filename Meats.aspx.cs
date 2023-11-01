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
    public partial class Page3 : System.Web.UI.Page
    {
        List<Food> meatTypesList = new List<Food>(); //creating a list to store meat type values
        private int caloriesTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadMeatTypes(); //calling method to page_load
        }

        public void loadMeatTypes()
        {
            //public Food(string nameOfFoodin, string weightOfFoodin, int kiloCaloriesin, string picturein)
            //creating an object which is an instance of the food class and passing values through to the constructor in that class
            Food meatType1 = new Food("Chicken Breast", "500g", 1195, "https://cdn-prod.medicalnewstoday.com/content/images/articles/326/326767/chicken-on-a-plate-that-has-a-number-of-calories.jpg");
            Food meatType2 = new Food("Steak", "500g", 1355, "https://www.allrecipes.com/thmb/3cixVDmAtbb2hYxoFLVJ4VPQ7rA=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/143809-best-steak-marinade-in-existence-ARMag-1x1-1-8105b6b8e5cb4931ba8061f0425243dd.jpg");
            Food meatType3 = new Food("Cooked Prawns", "500g", 495, "https://www.aheadofthyme.com/wp-content/uploads/2015/12/pan-fried-garlic-prawns-with-soy-sauce--1024x683.jpg");
            Food meatType4 = new Food("Cooked Lobster", "500g", 1055, "https://www.simplyrecipes.com/thmb/qXek-SCDI1cBvdif6gEiYuRsp1M=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Simply-Recipes-How-to-Boil-and-Eat-Lobster-LEAD-11-2c9590bc2c0a41e1b9372b31f2c1b4eb.JPG");

            //adding the values to the list created above
            meatTypesList.Add(meatType1);
            meatTypesList.Add(meatType2);
            meatTypesList.Add(meatType3);
            meatTypesList.Add(meatType4);

            createMeatGrid(); //call grid method
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

        public void createMeatGrid()
        {
            //storing a table in memory - creating and storing columns here
            DataTable meatTableData = new DataTable();
            meatTableData.Columns.Add("nameOfFood");
            meatTableData.Columns.Add("weightOfFood");
            meatTableData.Columns.Add("kiloCalories");
            meatTableData.Columns.Add("picture");
            meatTableData.Columns.Add("meatsCalBtn");

            //add fruits stored in the List to each row in the meatTable
            foreach (Food meats in meatTypesList)
            {
                meatTableData.Rows.Add(
                    meats.getnameOfFood(),
                    meats.getweightOfFood(),
                    meats.getkiloCalories() + " kcals",
                    meats.getpicture()
                    );
            }

            //retrieves the data stored in the table and stores it in grid grdMeats
            //binds the data to the grid
            grdMeats.DataSource = meatTableData;
            grdMeats.DataBind();

            int rowForImage = 0;
            //adding the images to each fruit in the List
            foreach (Food meats in meatTypesList)
            {
                System.Web.UI.WebControls.Image meatImage = new System.Web.UI.WebControls.Image {
                    ImageUrl = meats.getpicture(),
                    Height = 75,
                    Width = 75
                };

                //Controls which image goes where on the grid
                grdMeats.Rows[rowForImage].Cells[3].Controls.Add(meatImage);
                rowForImage++;
            }

            int rowForButton = 0;
            //adding the images to each fruit in the List
            foreach (Food meats in meatTypesList)
            {
                Button meatsCalBtn = new Button {
                    Text = "Meats Calories",
                    CommandName = Convert.ToString(meats.getkiloCalories())
                };

                meatsCalBtn.Command += new CommandEventHandler(meatsCalBtn_Click);

                //Controls which image goes where on the grid
                grdMeats.Rows[rowForButton].Cells[4].Controls.Add(meatsCalBtn);
                rowForButton++;

                //Changes button Border style & Background colour
                meatsCalBtn.BorderStyle = BorderStyle.Groove;
                meatsCalBtn.BackColor = Color.Orange;
            }
        }

        protected void meatsCalBtn_Click(object sender, CommandEventArgs e)
        {
            
            int meatsCalories = Convert.ToInt32(e.CommandName);

            //checking and saving orderTotal
            if (Session["caloriesTotal"] == null)
            {
                caloriesTotal = meatsCalories;
                Session["caloriesTotal"] = caloriesTotal;
            }
            //getting values into orderTotal
            else
            {
                caloriesTotal = Convert.ToInt32(Session["caloriesTotal"]);
                caloriesTotal += meatsCalories;
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

        protected void lnkDesserts_Click(object sender, EventArgs e)
        {
            Response.Redirect("Desserts.aspx");
        }

        protected void lnkContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }

        protected void lnkMeats_Click(object sender, EventArgs e)
        {
            Response.Redirect("Meats.aspx");
        }
    }
}