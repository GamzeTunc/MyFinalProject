﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id); //kendimizden değişken ve parametre verdik
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);//product döndürür. tek birşey için kullanılır ürünün detayının getirilmesi gibi yani
                                       // void Add(Product product);//void birşey döndürmüyor.
        IResults Add(Product product);
        IResults Update(Product product);
    }
}
