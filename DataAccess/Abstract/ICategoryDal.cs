using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntitiesRepository<Category>
    {
        //List<Category> GetAll();
        //T Get();
        //void Add(Category category);
        //void Update(Product product);
        //void Delete(Product product);
    }
}
