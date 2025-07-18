using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<MealPlanItem> MealPlanItems { get; set; }
        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MealPlan>(entity =>
            {
                entity.HasOne(mp => mp.Patient)
                .WithMany(p => p.MealPlans)
                .HasForeignKey(mp => mp.PatientId);
            });

            modelBuilder.Entity<MealPlanItem>(entity =>
            {
                entity.HasOne(mpi => mpi.MealPlan)
                .WithMany(mp => mp.MealPlanItems)
                .HasForeignKey(mpi => mpi.MealPlanId);


                entity.HasOne(mpi => mpi.Food)
               .WithMany()
               .HasForeignKey(mpi => mpi.FoodId);
            });

        }
    }
}
