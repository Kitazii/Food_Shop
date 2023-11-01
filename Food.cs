using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssessmentShop
{
    public class Food
    {
        //Private atts for food
        private string nameOfFood, weightOfFood, picture;
        private int kiloCalories;

        // Constructor (0 parameter)
        public Food()
        {
            nameOfFood = "";
            weightOfFood = "";     
            kiloCalories = 0;
            picture = "";
        }

        // Constructor (4 parameter)
        public Food(string nameOfFoodin, string weightOfFoodin, int kiloCaloriesin, string picturein)
        {
            nameOfFood = nameOfFoodin;
            weightOfFood = weightOfFoodin;
            kiloCalories = kiloCaloriesin;
            picture = picturein;
        }

        //create setter methods for food
        public void setNameOfFood(string nameOfFoodin)
        {
            nameOfFood = nameOfFoodin;
        }

        public void setWeightOfFood(string weightOfFoodin)
        {
            weightOfFood = weightOfFoodin;
        }

        public void setPicture(string picturein)
        {
            picture = picturein;
        }

        public void setKiloCalories(int kiloCaloriesin)
        {
            kiloCalories = kiloCaloriesin;
        }

        //create getter method for food
        public string getnameOfFood()
        {
            return nameOfFood;
        }

        public string getweightOfFood()
        {
            return weightOfFood;
        }

        public string getpicture()
        {
            return picture;
        }

        public int getkiloCalories()
        {
            return kiloCalories;
        }
    }
}