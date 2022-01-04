using Abp.Application.Services;
using MultipleDbContextDemo.DemoProductCategory.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MultipleDbContextDemo.DemoProductCategory
{
    public interface IDemoProductCategoryAppService : IApplicationService
    {

        List<DemoProductCategorys> GetProduct();
        void CreateProduct(CreateProductCategory input);
        void Update(UpdateProductCategory input);
        int DeleteProductCategory(int id);
        [HttpGet]
        Task<Result> Delete(int id);
        void CreateProductCategoryLinQ(CreateProductCategory input);
        void UpdateProductCategoryLinQ(UpdateProductCategory input);
        int DeleteLinQ(int id);
        List<DemoProductCategorys> GetProductLinQ();
        List<DemoProductCategorys> GetProductSQL();
        void CreateProductCategorySql(CreateProductCategory input);
        void UpdateProductCategorySql(UpdateProductCategory input);
        int DeleteSql(int id);
    }
}
