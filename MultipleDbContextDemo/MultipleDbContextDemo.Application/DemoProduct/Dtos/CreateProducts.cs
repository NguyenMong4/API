﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.DemoProduct
{
    public class CreateProducts:EntityDto<int>
    {
        
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }

    }
}
