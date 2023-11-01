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
    public partial class Page2 : System.Web.UI.Page
    {
        private List<Food> vegetableTypesList = new List<Food>(); //creating a list to store vegetable type values
        private int caloriesTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadVegetableTypes(); //calling method to page_load
        }

        public void loadVegetableTypes()
        {
            //public Food(string nameOfFoodin, string weightOfFoodin, int kiloCaloriesin, string picturein)
            //creating an object which is an instance of the food class and passing values through to the constructor in that class
            Food vegetablesType1 = new Food("Carrots", "250g", 103, "https://images.immediate.co.uk/production/volatile/sites/30/2021/11/carrots-953655d.jpg");
            Food vegetablesType2 = new Food("Broccoli", "250g", 85, "https://cdn.britannica.com/25/78225-050-1781F6B7/broccoli-florets.jpg");
            Food vegetablesType3 = new Food("Spinach", "250g", 58, "https://www.health.com/thmb/vlehi-KWIGaXmxou9sx3FadT4kk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/spinach-GettyImages-1135161567-1-2000-af5a3db960f7469faa7d281ae8769156.jpg");
            Food vegetablesType4 = new Food("Onions", "250g", 100, "https://www.creedfoodservice.co.uk/media/catalog/product/cache/d781aa45b0623b3b1e7a18c482a05dd6/c/4/c4367f3503738a1e9896821a455c520d.jpg");

            //adding the values to the list created above
            vegetableTypesList.Add(vegetablesType1);
            vegetableTypesList.Add(vegetablesType2);
            vegetableTypesList.Add(vegetablesType3);
            vegetableTypesList.Add(vegetablesType4);

            createVegetableGrid(); //call grid method
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

        public void createVegetableGrid()
        {
            //storing a table in memory - creating and storing columns here
            DataTable vegetableTableData = new DataTable();
            vegetableTableData.Columns.Add("nameOfFood");
            vegetableTableData.Columns.Add("weightOfFood");
            vegetableTableData.Columns.Add("kiloCalories");
            vegetableTableData.Columns.Add("picture");
            vegetableTableData.Columns.Add("vegetablesCalBtn");

            //add fruits stored in the List to each row in the fruitTable
            foreach (Food vegetables in vegetableTypesList)
            {
                vegetableTableData.Rows.Add(
                    vegetables.getnameOfFood(),
                    vegetables.getweightOfFood(),
                    vegetables.getkiloCalories() + " kcals",
                    vegetables.getpicture()
                    );
            }

            //retrieves the data stored in the table and stores it in grid grdfruits
            //binds the data to the grid
            grdVegetables.DataSource = vegetableTableData;
            grdVegetables.DataBind();

            int rowForImage = 0;
            //adding the images to each fruit in the List
            foreach (Food vegetables in vegetableTypesList)
            {
                System.Web.UI.WebControls.Image vegetablesImage = new System.Web.UI.WebControls.Image {
                    ImageUrl = vegetables.getpicture(),
                    Height = 75,
                    Width = 75
                };

                //Controls which image goes where on the grid
                grdVegetables.Rows[rowForImage].Cells[3].Controls.Add(vegetablesImage);
                rowForImage++;
            }

            int rowForButton = 0;
            //adding the images to each vegetable in the List
            foreach (Food vegetables in vegetableTypesList)
            {
                Button vegetablesCalBtn = new Button {
                    Text = "Vegetables Calories",
                    CommandName = Convert.ToString(vegetables.getkiloCalories())
                };

                vegetablesCalBtn.Command += new CommandEventHandler(vegetablesCalBtn_Click);

                //Controls which image goes where on the grid
                grdVegetables.Rows[rowForButton].Cells[4].Controls.Add(vegetablesCalBtn);
                rowForButton++;

                //Changes button Border style & Background colour
                vegetablesCalBtn.BorderStyle = BorderStyle.Groove;
                vegetablesCalBtn.BackColor = Color.YellowGreen;
            }
        }

        protected void vegetablesCalBtn_Click(object sender, CommandEventArgs e) //button adds calories value to the total
        {
            int vegetablesCalories = Convert.ToInt32(e.CommandName);

            //checking and saving orderTotal
            if (Session["caloriesTotal"] == null)
            {
                caloriesTotal = vegetablesCalories;
                Session["caloriesTotal"] = caloriesTotal;
            }
            //getting values into orderTotal
            else
            {
                caloriesTotal = Convert.ToInt32(Session["caloriesTotal"]);
                caloriesTotal += vegetablesCalories;
            }

            //saving and displaying caloriesTotal
            Session["caloriesTotal"] = caloriesTotal;
            lblCalTotal.Text = "Calories Total: " + caloriesTotal;
        }

        protected void btnClearCal_Click(object sender, EventArgs e) //button that clears callories value
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