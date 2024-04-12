using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext()) //Northwincontext ağır olduğu için bellekten işi bitince atılsın diye
            {
                var addedEntity = context.Entry(entity); //veritanbanından bir tane nesneyi eşleştir,veri kaynağı ile eşleştir//referansı yakala
                addedEntity.State = EntityState.Added; //veritabanına ekle //veritabanına ekle
                context.SaveChanges();//kaydet

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //Northwincontext ağır olduğu için bellekten işi bitince atılsın diye
            {
                var deletedEntity = context.Entry(entity); //veritanbanından bir tane nesneyi eşleştir,veri kaynağı ile eşleştir//referansı yakala
                deletedEntity.State = EntityState.Deleted; //veritabanından sil //veritabanından sil
                context.SaveChanges();//kaydet

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using(NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); //içerisinde dönüp getireceğimizi bulmaya yarar ama 1 elemean için kullanılır
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {//filtre null ise Product a yerleş ve ordaki tüm veriyi listeye çevirip getir
                //context.Set<Product> bu NorthwindContext.cs ye gidip db set ile eşleştirdiğin veritabanında işlemler yaptırır
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //Northwincontext ağır olduğu için bellekten işi bitince atılsın diye
            {
                var updatedEntity = context.Entry(entity); //veritanbanından bir tane nesneyi eşleştir,veri kaynağı ile eşleştir//referansı yakala
                updatedEntity.State = EntityState.Modified; //veritabanında güncelle //veritabanından güncelle
                context.SaveChanges();//kaydet

            }
        }
    }
}
