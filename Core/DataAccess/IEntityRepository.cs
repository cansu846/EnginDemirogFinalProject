using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//Core katmanı evrensel katmandır. Her projede kllanılabilir
//Core katmanı diğer katmanları referans almaz. bu bagımlılık yaratır

namespace Core.DataAccess
{
    //Generic Constraint
    //class: Referans tip ifade eder.
    //IEntit: IEntity olabilir yada IEntity implemente eden class olabilir
    //new(): new lenebilir olmalı

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {   //Expression<Func<T, bool>> ifadesi bir T türünde nesne alıp bool döndüren
        //bir lambda ifadesini veya fonksiyonu kabul eder.
        //Filtre verilirse, Data filtreye göre getirilir.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
