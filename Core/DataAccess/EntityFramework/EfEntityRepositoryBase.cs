using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class,IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext()) //Northwincontext ağır olduğu için bellekten işi bitince atılsın diye
            {
                var addedEntity = context.Entry(entity); //veritanbanından bir tane nesneyi eşleştir,veri kaynağı ile eşleştir//referansı yakala
                addedEntity.State = EntityState.Added; //veritabanına ekle //veritabanına ekle
                context.SaveChanges();//kaydet

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //Northwincontext ağır olduğu için bellekten işi bitince atılsın diye
            {
                var deletedEntity = context.Entry(entity); //veritanbanından bir tane nesneyi eşleştir,veri kaynağı ile eşleştir//referansı yakala
                deletedEntity.State = EntityState.Deleted; //veritabanından sil //veritabanından sil
                context.SaveChanges();//kaydet

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); //içerisinde dönüp getireceğimizi bulmaya yarar ama 1 elemean için kullanılır
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {//filtre null ise Product a yerleş ve ordaki tüm veriyi listeye çevirip getir
                //context.Set<Product> bu NorthwindContext.cs ye gidip db set ile eşleştirdiğin veritabanında işlemler yaptırır
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //Northwincontext ağır olduğu için bellekten işi bitince atılsın diye
            {
                var updatedEntity = context.Entry(entity); //veritanbanından bir tane nesneyi eşleştir,veri kaynağı ile eşleştir//referansı yakala
                updatedEntity.State = EntityState.Modified; //veritabanında güncelle //veritabanından güncelle
                context.SaveChanges();//kaydet

            }
        }
    }
}
