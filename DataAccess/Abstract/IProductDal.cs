using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //NOT: interface metodlarının metodları default olarak public tir ama interface public değildir
    public interface IProductDal:IEntityRepository<Product>
    {
        
    }
}
