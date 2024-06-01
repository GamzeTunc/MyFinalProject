using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //<T> Sana çalışacağın tipi çalışırken söylicem demek
    //Result classındakilere de sahip o yüzden onun ctor larını implemente ederiz
    public class DataResults<T> : Result, IDataResult<T>
    {
        //bu ctor a T türünde data verdik bu da ProductManager den gelir
        //Result class ından tek farkı T data
        //base ile de Result a success ve message yi yolluyoz

        public DataResults(T data, bool success, string message):base(success,message)
        {
            Data = data;
        }
        public DataResults(T data, bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
