using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.DemoProductCategory.Dtos
{
    public class UpdateProductCategory:EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
