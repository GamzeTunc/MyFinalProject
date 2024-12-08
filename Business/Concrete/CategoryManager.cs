using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //public List<Category> GetAll()
        public IDataResult<List<Category>> GetAll()
        {
            //iş kodları
            //return _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);

        }

        //select * from categories where CategoryId=3
        public Category GetById(int CategoryId)
        {
            //iş kodları
            return _categoryDal.Get(c => c.CategoryId == CategoryId);
        }
    }
}
