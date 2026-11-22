using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentManager
{
    public class Economy : Car
    {
        public Economy(string plate, string model, decimal dailyRate)
            :base(plate, model, dailyRate)
        {
        }
        //calculate economy rental cost
        public override decimal CalculateTotal(int days)
        {
            decimal total = days * DailyRate;
                if (days >= 7)
            {
                total = total * 0.90m;
            }
            return Math.Round(total, 2);
        }
        //return the car category
        public override string GetCategory()
        {
            return "Economy";
        }
    }
}
