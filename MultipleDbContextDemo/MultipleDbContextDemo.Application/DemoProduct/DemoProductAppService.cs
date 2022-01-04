using Abp.Domain.Repositories;
using Abp.EntityFramework;

using MultipleDbContextDemo.DemoProduct.Dtos;
using MultipleDbContextDemo.DemoProductCategory;
using MultipleDbContextDemo.DemoProductCategory.Dtos;
using MultipleDbContextDemo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.DemoProduct
{
    public class DemoProductAppService : MultipleDbContextDemoAppServiceBase, IDemoProductAppService
    {

        private readonly IRepository<DemoProducts> _productRepository;
        private readonly IDbContextProvider<MySecondDbContext> _myseconddbcontext;
        public DemoProductAppService(IRepository<DemoProducts> productRepository, IDbContextProvider<MySecondDbContext> dbContextProvider)
        {
            _productRepository = productRepository;
            _myseconddbcontext = dbContextProvider;
        }
        public void CreateProduct(CreateProducts input)
        {
            try
            {
                var product = new DemoProducts();
                product.Id = input.Id;
                product.CategoryId = input.CategoryId;
                product.ProductName = input.ProductName;
                _productRepository.Insert(product);
            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var product = _productRepository.GetAll().Where(s => s.Id == id).FirstOrDefault();
                if (product != null)
                {
                    _productRepository.DeleteAsync(product);
                    return true;
                }
                return false;
            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        public List<DemoProducts> GetProduct()
        {
            var product = _productRepository.GetAll().Select(s => s).ToList();
            return product;

        }

        public void UpdateProduct(UpdateProducts input)
        {
            try
            {
                var product = _productRepository.GetAll().Where(s => s.Id == input.Id).FirstOrDefault();
                if (product != null)
                {
                    product.ProductName = input.ProductName;
                    product.CategoryId = input.CategoryId;
                    _productRepository.UpdateAsync(product);
                }
            }
            catch
            {
                throw new NotImplementedException();

            }
        }
        public List<ProductInnerjoincategory> GetProductCategory()
        {
            MySecondDbContext db = new MySecondDbContext();
            var query = (from s in db.DemoProducts
                         join c in db.DemoProductCategorys on s.CategoryId equals c.Id
                         select new
                         {
                             s.Id,
                             s.ProductName,
                             s.CategoryId,
                             c.Name
                         });
            var getproductinnerjoin = query.ToList().Select(s => new ProductInnerjoincategory
            {
                Id = s.Id,
                CategoryId = s.CategoryId,
                Name = s.Name,
                ProductName = s.ProductName
            }).ToList();
            return getproductinnerjoin;
        }
        public List<ProductInnerjoincategory> LeftJoin()
        {
            MySecondDbContext db = new MySecondDbContext();
            var query = from s in db.DemoProductCategorys
                        join c in db.DemoProducts on s.Id equals c.CategoryId
                        into Group
                        from lefjoin in Group
                        select new
                        {
                            Id = lefjoin.Id,
                            CategoryId = lefjoin.CategoryId,
                            Name = s.Name,
                            ProductName = lefjoin.ProductName
                        };
            var leftjoin = query.ToList().Select(s => new ProductInnerjoincategory
            {
                Id = s.Id,
                CategoryId = s.CategoryId,
                Name = s.Name,
                ProductName = s.ProductName
            }).ToList();
            return leftjoin;
        }
    }

}
