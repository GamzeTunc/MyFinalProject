﻿using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //injection yaparız bu sayede ne memory ne entity leri kullanmıycaz
        ICategoryService _categoryService;
        
        public ProductManager(IProductDal productDal,ICategoryService categoryService) //ProductManager new lendiğinde çalışır
        {
            _productDal = productDal;
            _categoryService = categoryService;
            
        }

        //[SecuredOperation(roles:"product.add.admin")]bizim verdiğimiz bir Aspect ismi operation diyince metoddur. admin olacak veya product add 
        [ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect(pattern:"IProductService.Get")] bu hocada vardı ben yazmamışım
        public IResults Add(Product product)//public void Add(Product product)
        {

            IResults result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName), 
                CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded());

            if (result != null) //result boş değilse
            {
                return result; //result ı yani hatayı döndür
            }
            //void bişey döndürmez ama ben işlem başarılıysa işlem başarılı diye bişey döndürmek istiyorum result diye class ekler onunla ekleme yaparım.
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);//IResults interface i result taki metodlara sahip olduğu için kullanılabilir. //SuccessResults olduğunda zaten true ki biz bu klasa yolluyoz successaresult ta kullanırız o yüzden true yollayıp mesaj yollamamayı

           
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //if else ler
            //yrtkisi var mı 
            //bunlar geçince data access e veriyi verebilirsin ürünleri gösterebilirsin diyor

            if (DateTime.Now.Hour == 19)//sistemin saatini verir pc de saat 22 old. ErrorDataResult çalışcak
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
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
            if (DateTime.Now.Hour == 09)//sistemin saatini verir pc de saat 00 old. ErrorDataResult çalışcak
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResults Update(Product product)
        {
            var results = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (results >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);


            }
            throw new NotImplementedException();
        }

        private IResults CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var results = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (results >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);


            }
            return new SuccessResult();
        }



        private IResults CheckIfProductNameExists(string productname)
        {
            var results = _productDal.GetAll(p => p.ProductName == productname).Any();//any var mı demek parantez içindekine uyan kayıt var mı demek
            if (results)//result==true ile aynı şey (any bool öner yani true yada false 
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);


            }
            return new SuccessResult();
        }


        private IResults CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }


    }
}
