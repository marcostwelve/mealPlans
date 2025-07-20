using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model.Dto.MealPlan
{
    public class MealPlanDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime PlanDate { get; set; }
        public List<MealPlanItemDto> MealPlanItems { get; set; }
        public double TotalCalories { get; set; }
    }
}
