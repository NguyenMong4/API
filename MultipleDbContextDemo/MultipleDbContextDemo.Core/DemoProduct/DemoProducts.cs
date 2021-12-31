using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.DemoProduct
{
    [Table("DemoProducts")]
    public class DemoProducts:Entity<int>
    {       
        public int CategoryId { get; set; }
        public string ProductName { get; set; }

    }
}
