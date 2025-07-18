using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<MealPlan> MealPlans { get; set; }
    }
}
