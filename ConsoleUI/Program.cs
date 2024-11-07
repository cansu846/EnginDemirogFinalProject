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
            ProductTest();

            //CategoryTest();

        }

        private static void CategoryTest()
        {
            ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryService.GetAll())
            {
                Console.WriteLine(category.CategoryName);

            }

            Console.WriteLine("Seçilen kategory: " + categoryService.GetById(5).CategoryName);
        }

        private static void ProductTest()
        {
            IProductService prodyctManager = new ProductManager(new EfProductDal());
            foreach (var product in prodyctManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + ", Category Name:  " + product.CategoryName);

            }
        }
    }
 
}
