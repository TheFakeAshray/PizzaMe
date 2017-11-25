
using PizzaMe.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace PizzaMe.Data
{
    public class PizzaMeDbContext : DbContext
    {
        //PizzaMeDbContext is the variable(?) thing for the connection string ;)
        public PizzaMeDbContext() : base("PizzaMeDbContext")
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponRelation> CouponRelations { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<PizzaTypeCompany> PizzaTypeCompanies { get; set; }
        public DbSet<PizzaTypeList> PizzaTypeLists { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<SideList> SideLists { get; set; }

        //After changing any of the tables or creating/deleting a table we needa update DB.
        //In Package Manager Console: update-database


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}