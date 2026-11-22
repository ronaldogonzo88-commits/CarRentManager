using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentManager
{
    public class Luxury : Car
    {
        public Luxury(string plate, string model, decimal dailyRate) 
            : base(plate, model, dailyRate)
        {
        }
        //Calculate luxury rental cost
        public override decimal CalculateTotal(int days)
        {
            decimal total = days * DailyRate;
            total = total + (total * 0.15m);
            return Math.Round(total, 2);
        }
        //return the car category
        public override string GetCategory()
        {
            return "Luxury";
        }
    }
}
