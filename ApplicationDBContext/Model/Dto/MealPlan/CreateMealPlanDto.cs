using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model.Dto.MealPlan
{
    public class CreateMealPlanDto
    {
        public int PatientId { get; set; }
        public DateTime PlanDate { get; set; }
    }
}
