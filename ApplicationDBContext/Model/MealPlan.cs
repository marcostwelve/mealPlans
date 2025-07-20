using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class MealPlan
    {
        public int Id { get; set; }
        public DateTime PlanDate { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public ICollection<MealPlanItem> MealPlanItems { get; set; }
    }
}
