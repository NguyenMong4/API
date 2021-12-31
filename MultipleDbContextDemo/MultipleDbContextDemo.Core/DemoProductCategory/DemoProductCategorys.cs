using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.DemoProductCategory
{
    [Table("DemoProductCategory")]
    public class DemoProductCategorys:Entity<int>
    {       
        public string Name { get; set; }
        public bool Active { get; set; }

    }
}
