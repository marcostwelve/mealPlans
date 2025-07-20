using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model.Dto.MealPlan
{
    public class AddFoodToPlanDto
    {
        public int FoodId { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }
}
