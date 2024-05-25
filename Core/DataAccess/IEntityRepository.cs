
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constraint(generic kısıtlama) yani T lere sadece Entities in altındaki class tiplerinin dönmesi için yapcaz ki IProductDal da mesala int tanımlayamasın
    //class:referans tip olabilir demek class olcak değil
    //IEntity yazdık çünkü başka bir class kullanılmasın Entities-concrete klasörünün altındaki class ların ortak özelliği hepsinde IEntity interface i kullanılması 
    //new()= new'lenebilir olmalı, bu sayede interface i devredışı bıraktık sadece IEntity ye sahip nesneleri verebiliriz
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//filter=null filtre vermeyebilirsin de
        T Get(Expression<Func<T,bool>> filter); //yukarıdaki sayesinde banka hesaplarını görürsün bununla da bir hesabın tüm detaylarını
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
