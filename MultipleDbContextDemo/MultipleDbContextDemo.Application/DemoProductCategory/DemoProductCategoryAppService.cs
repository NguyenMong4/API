using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Abp.Domain.Repositories;
using MultipleDbContextDemo.EntityFramework;
using Abp.UI;
using Abp.EntityFramework;

using MultipleDbContextDemo.DemoProductCategory.Dtos;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MultipleDbContextDemo.DemoProductCategory
{
    public class DemoProductCategoryAppService : MultipleDbContextDemoAppServiceBase, IDemoProductCategoryAppService
    {
        private readonly IRepository<DemoProductCategorys> _productcategoryRepository;
        private readonly IDbContextProvider<MySecondDbContext> _mySecondatacontext;

        public DemoProductCategoryAppService(IRepository<DemoProductCategorys> productcatgoryRepository, IDbContextProvider<MySecondDbContext> dbContextProvider)

        {
            _productcategoryRepository = productcatgoryRepository;

            _mySecondatacontext = dbContextProvider;
        }
        public void CreateProduct(CreateProductCategory input)
        {
            try
            {
                var productcategory = new DemoProductCategorys()
                {
                    Id = input.Id,
                    Name = input.Name,
                    Active = input.Active
                };


                _productcategoryRepository.Insert(productcategory);
            }
            catch (Exception)
            {
                throw new Exception("ga");
            }
        }

        public void Update(UpdateProductCategory input)
        {
            try
            {
                var productcategory = _productcategoryRepository.GetAll().Where(s => s.Id == input.Id).FirstOrDefault();
                if (productcategory != null)
                {
                    productcategory.Name = input.Name;
                    productcategory.Active = input.Active;
                    _productcategoryRepository.UpdateAsync(productcategory);
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException("!!!");
            }
        }
        public int DeleteProductCategory(int id)
        {
            try
            {
                var productcategory = _productcategoryRepository.GetAll().Where(s => s.Id == id).FirstOrDefault();
                if (productcategory != null)
                    _productcategoryRepository.DeleteAsync(productcategory);
                return 1;
            }
            catch
            {
                throw;
            }

        }

        public List<DemoProductCategorys> GetProduct()
        {
            try
            {
                var productcategory = _productcategoryRepository.GetAll().Select(s => s);
                return productcategory.ToList();
            }
            catch
            {
                throw new NotImplementedException("!!!");
            }
        }

        //LinQ
        public void CreateProductCategoryLinQ(CreateProductCategory input)
        {
            try
            {
                DemoProductCategorys productcategory = new DemoProductCategorys();
                productcategory.Active = input.Active;
                productcategory.Name = input.Name;
                var Product = _mySecondatacontext.GetDbContext().DemoProductCategorys.Add(productcategory);
                _productcategoryRepository.InsertAsync(Product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProductCategoryLinQ(UpdateProductCategory input)
        {

            var productcategory = (from c in _mySecondatacontext.GetDbContext().DemoProductCategorys
                                   where c.Id == input.Id
                                   select c).FirstOrDefault();
            if (productcategory.Id != 0)
            {
                productcategory.Name = input.Name;
                productcategory.Active = input.Active;
                _productcategoryRepository.UpdateAsync(productcategory);
            }
        }

        public List<DemoProductCategorys> GetProductLinQ()
        {
            var productcategory = from c in _mySecondatacontext.GetDbContext().DemoProductCategorys
                                  select c;
            return productcategory.ToList();
        }

        public int DeleteLinQ(int id)
        {
            try
            {

                var deleteproductcategory = (from c in _mySecondatacontext.GetDbContext().DemoProductCategorys
                                             where c.Id == id
                                             select c
                                             ).First();

                _productcategoryRepository.Delete(deleteproductcategory);
                return 1;
            }
            catch
            {
                throw new Exception("!!!!");
            }
        }

        //SQL thuần

        public void CreateProductCategorySql(CreateProductCategory input)
        {
            try
            {
                var NameInput = new SqlParameter("@NameInput", input.Name);
                var ActiveInput = new SqlParameter("@ActiveInput", input.Active);
                var sql = "insert into DemoProductCategory(Name,Active) values (@NameInput,@ActiveInput)";
                _mySecondatacontext.GetDbContext().Database.ExecuteSqlCommand(sql, NameInput, ActiveInput);

            }
            catch
            {
                throw new Exception("!!");
            }
        }
        public void UpdateProductCategorySql(UpdateProductCategory input)
        {
            try
            {
                var NameInput = new SqlParameter("@NameInput", input.Name);
                var ActiveInput = new SqlParameter("@ActiveInput", input.Active);
                var IdInput = new SqlParameter("@Id", input.Id);
                var sql = "Update DemoProductCategory set Name = @NameInput , Active = @ActiveInput Where Id=@Id";
                _mySecondatacontext.GetDbContext().Database.ExecuteSqlCommand(sql, NameInput, ActiveInput, IdInput);

            }
            catch
            {
                throw new Exception("!!");
            }
        }
        public int DeleteSql(int id)
        {
            try
            {
                var Iddelete = new SqlParameter("@Id", id);
                var sql = "Delete from DemoProductCategory where Id=@Id";
                _mySecondatacontext.GetDbContext().Database.ExecuteSqlCommand(sql, Iddelete);
                return 1;
            }
            catch
            {
                throw;
            }
        }
        public List<DemoProductCategorys> GetProductSQL()
        {
            try
            {
                var sql = "select * from DemoProductCategory ";
                var get = _mySecondatacontext.GetDbContext().Database.SqlQuery<DemoProductCategorys>(sql);
                return get.ToList();
            }
            catch
            {
                throw;
            }

        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                var productcategory = await _productcategoryRepository.FirstOrDefaultAsync(id);
                if (productcategory != null)
                {
                    throw new Exception("productcategory null");
                }
                await _productcategoryRepository.DeleteAsync(productcategory);
                Result r = new Result();
                return r;
            }
            catch
            {
                throw new NotImplementedException();
            }


        }
    }
}
