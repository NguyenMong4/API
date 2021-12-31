using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.DemoProductCategory.Dtos
{
    public class ProductCategoryDto:Entity<int>
    {
      
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
