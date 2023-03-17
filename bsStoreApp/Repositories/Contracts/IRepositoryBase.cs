using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        //Sorgulanabilir ifadeler tanımlamak için 
        //T Şeklinde ifade etmemizin sebebi farklı farklı class ları dikkate alınabilir hale gelmesidir.
        // T Bir type dir ör book,kategori

        //CRUD TANIMLARI
        IQueryable<T> FindAll(bool trackChanges);
        //FindByCondation -> koşulambağlı olarak liste alınabilir
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression, bool trackChanges);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
