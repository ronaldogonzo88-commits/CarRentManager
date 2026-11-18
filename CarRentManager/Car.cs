using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentManager
{
    class Car
    {
        //Private fields that stores cars info and rental status
        private string plate;
        private string model;
        private decimal dailyRate;
        private bool isRented;

        //Gets cars registration plate
        public string Plate
        {
            get { return plate; }
        }
        //Gets cars model
        public string Model
        {
            get { return model; }
        }
        //Gets daily rental rate
        public decimal DailyRate
        {
            get { return dailyRate; }
        }
        //Gets or sets either the car is currently rented
        public bool IsRented
        {
            get { return isRented; }
            set { isRented = value; }
        }

        //This constructor create a car and stores its details
        public Car(string plate, string model, decimal dailyRate)
        {
            this.plate = plate;
            this.model = model;
            this.dailyRate = dailyRate;
        }

        //Method which checks if the car is rented or not
        public string GetStatus()
        {
            if (isRented)
            {
                return "Rented";
            }
            else
            {
                return "Available";
            }
        }
    }
}
