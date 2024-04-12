using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                //Oracle, Sql Server,Postgres, MongoDb den geliyormuş gibi
                new Product{ProductId=1,  CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2,  CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3,  CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4,  CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5,  CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LİNQ=Language Integrated Query dile gömülü sorgu
            //Product productToDelete=null; //liste olduğu için "new Products();" şeklinde yaparsak yeni bir referans oluşturur ve bu da belleği yorar o yüzden liste olduğu için null yazarız referans yok anlamına gelir
            //foreach(var p in _products) //Liste deki tüm elemanları dolaşıyorum 
            //{
            //    if (product.ProductId==p.ProductId) //id leri birbirine eşit olanı buluyorum
            //    {
            //        productToDelete = p;//refans numarasını değişkenime atıyorum
            //    }
            //}

             
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);// tek bir eleman bulmaya yarar _products ı tek tek dolaşır yani p tek tek dolaşırken verilen takma isimdir. "=>"Lambda işaretidir bu. "p.ProductId==product.ProductId " bu kısımda içindeki if kısmıdır yapacağı işlemdir.





            _products.Remove(productToDelete);



        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList(); //where koşulu içindeki şarta uyan bütün elemanları yeni bir liste yapar ve onu döndürür
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
