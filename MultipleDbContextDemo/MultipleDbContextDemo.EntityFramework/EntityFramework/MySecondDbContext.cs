using System.Data.Entity;
using Abp.EntityFramework;
using MultipleDbContextDemo.DemoProduct;
using MultipleDbContextDemo.DemoProductCategory;

namespace MultipleDbContextDemo.EntityFramework
{
    public class MySecondDbContext : AbpDbContext
    {
        public virtual IDbSet<Course> Courses { get; set; }       
        public virtual IDbSet<DemoProductCategorys> DemoProductCategorys { get; set; }
      

        public MySecondDbContext()
            : base("Second")
        {
            
        }
    }
}
