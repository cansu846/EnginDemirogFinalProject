using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Interface metotları default publictir ama sınıfın kendisi internaldır
    public interface IProductDal:IEntitiesRepository<Product>
    {
        //List<Product> GetAll();
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);
        //List<Product> GetAllByCategory(int categoryId);

        List<ProductDetailDto> GetProductDetails();
    }
}
