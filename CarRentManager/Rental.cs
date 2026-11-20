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
            public void MarkReturned(DateTime date)
        {
            returnDate = date;
        }
    }
}
