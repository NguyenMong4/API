using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.DemoProductCategory.Dtos
{
    public class CreateProductCategory:EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }

    }
}
