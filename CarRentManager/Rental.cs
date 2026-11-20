using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentManager
{
    class Rental
    {
        //Public fields
        private string plate;
        private string customerName;
        private string customerPhone;
        private  DateTime rentDate;
        private DateTime returnDate;
        private int days;
        private decimal totalCost;

        //public fields
        public string Plate
        {
            get { return plate; }
        }
        public string CustomerName
        {
            get { return customerName; }
        }
        public string CustomerPhone
        {
            get { return customerPhone; }
        }
        public DateTime RentDate
        {
            get { return rentDate; }
        }
        public DateTime ReturnDate
        {
            get { return returnDate; }
        }
        public int Days
        {
            get { return days; }
        }
        public decimal TotalCost
        {
            get { return totalCost; }
        }

        //CONSTRUCTOR
        public Rental(string plate, string customerName, string customerPhone, DateTime rentDate)
        {
            this.plate = plate;
            this.customerName = customerName;
            this.customerPhone = customerPhone;
            this.rentDate = rentDate;
            returnDate = DateTime.MinValue;
        }

        //check wheather car has been returned
        public bool IsReturned
        {
            get { return returnDate != DateTime.MinValue; }
        }
        //mark rental as returned
            public void MarkReturned(DateTime returnDate, decimal dailyRate)
        {
            //calculate number of days btwn renting and returning
            int CalculateDays = (returnDate - RentDate).Days;
            //make sure the rental costs at least one day
            if (CalculateDays < 1)
            {
                days = 1;
            }
            else
            {
                days = CalculateDays;
            }
            //calculate total rent
            totalCost = days * dailyRate;
            //mark the rental as returned
            this.returnDate = returnDate;
        }
    }
}
