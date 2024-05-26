using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //data(veriler),işlem sonucu ve mesaj içercek data dışındakileri IResult ta yaptık zaten o yüzden o interface i implement ederiz.
    //t kullanırız generic çünkü ürün,ürünler,kategori,kategoriler herşeyi döndürebilir
    public interface IDataResult<T>:IResults
    {
        T Data { get; }
    }
}
