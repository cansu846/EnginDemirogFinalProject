// See https://aka.ms/new-console-template for more information


using DataAccess.Concrete.EntityFramework;
using Business.Concrete;
using Business.Abstract;


namespace ConsoleUI
{ 
    class Program
    {
        public static void Main(string[] args)
        {
            IProductService prodyctManager = new ProductManager(new EfProductDal());
            foreach (var product in prodyctManager.GetByUnitPrice(100,1000)) {
                Console.WriteLine(product.ProductName + ", price:  " + product.UnitPrice);

            }

        }
    }
 
}
