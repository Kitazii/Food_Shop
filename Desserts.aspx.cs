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
    public partial class Page4 : System.Web.UI.Page
    {
        List<Food> dessertTypesList = new List<Food>(); //creating a list to store dessert type values
        private int caloriesTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadDessertTypes(); //calling method to page_load
        }

        public void loadDessertTypes()
        {
            //public Food(string nameOfFoodin, string weightOfFoodin, int kiloCaloriesin, string picturein)
            //creating an object which is an instance of the food class and passing values through to the constructor in that class
            Food dessertsType1 = new Food("Chocolate Cake", "250g", 928, "https://www.cookingclassy.com/wp-content/uploads/2019/10/chocolate-cake-3.jpg");
            Food dessertsType2 = new Food("Ice Cream", "250g", 518, "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/recipe-image-legacy-id-44893_12-ab2de24.jpg");
            Food dessertsType3 = new Food("Apple Pie", "250g", 593, "https://www.inspiredtaste.net/wp-content/uploads/2019/11/Homemade-Apple-Pie-From-Scratch-1200.jpg");
            Food dessertsType4 = new Food("Cookies", "250g", 1255, "https://handletheheat.com/wp-content/uploads/2020/10/BAKERY-STYLE-CHOCOLATE-CHIP-COOKIES-9-637x637-1.jpg");

            //adding the values to the list created above
            dessertTypesList.Add(dessertsType1);
            dessertTypesList.Add(dessertsType2);
            dessertTypesList.Add(dessertsType3);
            dessertTypesList.Add(dessertsType4);

            createDessertGrid(); //call grid method
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

        public void createDessertGrid()
        {
            //storing a table in memory - creating and storing columns here
            DataTable DessertTableData = new DataTable();
            DessertTableData.Columns.Add("nameOfFood");
            DessertTableData.Columns.Add("weightOfFood");
            DessertTableData.Columns.Add("kiloCalories");
            DessertTableData.Columns.Add("picture");
            DessertTableData.Columns.Add("dessertsCalBtn");

            //add fruits stored in the List to each row in the fruitTable
            foreach (Food Desserts in dessertTypesList)
            {
                DessertTableData.Rows.Add(
                    Desserts.getnameOfFood(),
                    Desserts.getweightOfFood(),
                    Desserts.getkiloCalories() + " kcals",
                    Desserts.getpicture()
                    );
            }

            //retrieves the data stored in the table and stores it in grid grdfruits
            //binds the data to the grid
            grdDesserts.DataSource = DessertTableData;
            grdDesserts.DataBind();

            int rowForImage = 0;
            //adding the images to each fruit in the List
            foreach (Food desserts in dessertTypesList)
            {
                System.Web.UI.WebControls.Image dessertImage = new System.Web.UI.WebControls.Image {
                    ImageUrl = desserts.getpicture(),
                    Height = 75,
                    Width = 75
                };

                //Controls which image goes where on the grid
                grdDesserts.Rows[rowForImage].Cells[3].Controls.Add(dessertImage);
                rowForImage++;
            }

            int rowForButton = 0;
            //adding the images to each fruit in the List
            foreach (Food desserts in dessertTypesList)
            {
                Button dessertsCalBtn = new Button {
                    Text = "Desserts Calories",
                    CommandName = Convert.ToString(desserts.getkiloCalories())
                };

                dessertsCalBtn.Command += new CommandEventHandler(dessertsCalBtn_Click);

                //Controls which image goes where on the grid
                grdDesserts.Rows[rowForButton].Cells[4].Controls.Add(dessertsCalBtn);
                rowForButton++;

                //Changes button Border style & Background colour
                dessertsCalBtn.BorderStyle = BorderStyle.Groove;
                dessertsCalBtn.BackColor = Color.BurlyWood;
            }
        }

        protected void dessertsCalBtn_Click(object sender, CommandEventArgs e)
        {
            int dessertsCalories = Convert.ToInt32(e.CommandName);

            //checking and saving orderTotal
            if (Session["caloriesTotal"] == null)
            {
                caloriesTotal = dessertsCalories;
                Session["caloriesTotal"] = caloriesTotal;
            }
            //getting values into orderTotal
            else
            {
                caloriesTotal = Convert.ToInt32(Session["caloriesTotal"]);
                caloriesTotal += dessertsCalories;
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