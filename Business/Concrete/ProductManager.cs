using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.CrossCuttingConcerns;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
       private IProductDal _productDal;
        //Bir manager kendisi dışındaki bir Data Access Layer ı implemente edemez. 
        //Bunun yerine Service ler kullanılır.
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

            //Business: İş gereksinimleriyle ilgili kodların yazıldıgı kısımdır.
            //Validation: Eklenecek nesnenin veri yapısıyla ilgili kodlardır


            //if (product.ProductName.Length < 2)
            //{
            //   return new ErrorResult(Messages.ProductNameInvalid);
            //}
            //ValidationTool.Validate(new ProductValidator(),product);


            //if (ChekIfProductCountOfCategoryCorrect(product.ProductId).Success)
            //{
            //    if (ChekIfProductCountOfCategoryCorrect(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);
            //        return new SuccessResult(Messages.ProductAdded);
            //    }
            //}

            //return new ErrorResult(Messages.ProductAdded);

           

            IResult result = BusinessRules.Run(ChekIfProductCountOfCategoryCorrect(product.ProductId),
                              ChekIfProductCountOfCategoryCorrect(product.ProductName),
                              CheckIfCategoryLimitExcided());

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        private IResult CheckIfCategoryLimitExcided()
        {
            //15 adetten fazla kategori varsa urun eklenemez.
            var categoryCount = _categoryService.GetAll().Data.Count();
            if (categoryCount >= 15)
            {
                return new ErrorResult(Messages.CategoryLimitExcited);
            }
            return new SuccessResult();
        }
        //Aynı isimde urun eklenemez
       private IResult ChekIfProductCountOfCategoryCorrect(string productName)
        {   //Bir categoride en fazla 10 urun olabilir.
            // Once tüm urunleri secip sonradan filtre uygulamıyor. "select count(*) from Products where productId=" şeklinde çalışıyor
            bool existsProduct = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (existsProduct)
            {
                return new ErrorResult(Messages.ProdocutNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult ChekIfProductCountOfCategoryCorrect(int categoryId)
        {   //Bir categoride en fazla 10 urun olabilir.
            // Once tüm urunleri secip sonradan filtre uygulamıyor. "select count(*) from Products where productId=" şeklinde çalışıyor
            var products = _productDal.GetAll(p => p.CategoryId == categoryId).Count();
            if (products >= 10)
            {
                return new ErrorResult(Messages.ProdocutCountOfCategoryError);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanenceTime);
            }
           return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => (p.CategoryId == id)));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get((p) => (p.ProductId == productId)));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => (p.UnitPrice >= min && p.UnitPrice <= max)));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails()); 
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.UpdatedProduct);
        }
    }
}

