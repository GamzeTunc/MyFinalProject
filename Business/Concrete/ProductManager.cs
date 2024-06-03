using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //injection yaparız bu sayede ne memory ne entity leri kullanmıycaz
public ProductManager(IProductDal productDal) //ProductManager new lendiğinde çalışır
        {
            _productDal = productDal;
        }

        public IResults Add(Product product)//public void Add(Product product)
        {
            //business codes (eğer böyleyse eğer şöyleyse diye buraya yazılır) geçerliyse ekleriz

            if(product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInValid);
            }

            //void bişey döndürmez ama ben işlem başarılıysa işlem başarılı diye bişey döndürmek istiyorum result diye class ekler onunla ekleme yaparım
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);//IResults interface i result taki metodlara sahip olduğu için kullanılabilir. //SuccessResults olduğunda zaten true ki biz bu klasa yolluyoz successaresult ta kullanırız o yüzden true yollayıp mesaj yollamamayı
        }
        
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //if else ler
            //yrtkisi var mı 
            //bunlar geçince data access e veriyi verebilirsin ürünleri gösterebilirsin diyor

            if (DateTime.Now.Hour==22)//sistemin saatini verir pc de saat 22 old. ErrorDataResult çalışcak
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 00)//sistemin saatini verir pc de saat 00 old. ErrorDataResult çalışcak
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
