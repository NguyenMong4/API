using Abp.Application.Services;
using MultipleDbContextDemo.DemoProduct.Dtos;
using MultipleDbContextDemo.DemoProductCategory.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.DemoProduct
{
    public interface IDemoProductAppService: IApplicationService
    {
        List<DemoProducts> GetProduct();
        void CreateProduct(CreateProducts input);
        void UpdateProduct(UpdateProducts input);
        bool Delete(int id);

        List<ProductInnerjoincategory> GetProductCategory();
        List<ProductInnerjoincategory> LeftJoin();
    }
}
