using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private List<Product> _products;
        public InMemoryProductDal()
        {
            // {} koleksiyon başlatıcı (collection initializer) dır.
            // () ile kullanılırsa List<Product>() boş bir liste oluşturur.
            _products = new List<Product> {

             //C#’ta nesne başlatıcılar, new ifadesinden sonra { } içinde özelliklerin atanmasına izin verir.
             //Bu başlatma yöntemi, nesne oluşturma sırasında doğrudan özellik değerlerini ayarlamanızı sağlar.
                new Product{ProductId=1,ProductName="Bardak",CategoryId=1,UnitPrice=19, UnitsInStock=5 }
            };
               
        }

        //prudct nesnesi ile silemeye çalışırsak gonderilen nesnenin referansı farklı oalcagı için db den silinmeyecekti.
        //Bu sebeple id kullanılıyor
        public void Add(Product product)
        {
           _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
          return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //LINQ
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
            
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
