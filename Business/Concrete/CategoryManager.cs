using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal _categoryDal) { 
            this._categoryDal = _categoryDal;
        }    
        public IDataResult<List<Category>> GetAll()
        { 
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }
             
        public IDataResult<Category> GetById(int categoryId)
        {
            //GetAll expression fonksiyon oldugu için lambda fonksiyonu alır.
            return new SuccessDataResult<Category>(_categoryDal.Get((c) => c.CategoryId == categoryId));
        }

    }
}
