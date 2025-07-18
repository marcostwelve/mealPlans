using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class MealPlanItem
    {
        public int Id { get; set; }

        public string ServingSize { get; set; }

        public int MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
