using Business.Abstract;
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
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            //GetAll expression fonksiyon oldugu için lambda fonksiyonu alır.
            return _categoryDal.Get((c) => c.CategoryId == categoryId);
        }
    }
}
