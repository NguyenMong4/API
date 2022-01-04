﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.DemoProduct.Dtos
{
    public class ProductDto:Entity<int>
    {
       
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
