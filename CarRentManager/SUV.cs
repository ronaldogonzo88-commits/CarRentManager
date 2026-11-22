using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentManager
{
    public class SUV : Car
    {
        public SUV(string plate, string model, decimal dailyRate) 
            : base(plate, model, dailyRate)
        {
        }
        //calculate SUV rental cost
        public override decimal CalculateTotal(int days)
        {
            decimal total = days * DailyRate;
            total = total + 20;
            return Math.Round(total, 2);
        }
        //return the car category
        public override string GetCategory()
        {
            return "SUV";
        }
    }
}
