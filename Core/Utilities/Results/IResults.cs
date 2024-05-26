using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel voidler için kullanacağımız interface
    public interface IResults
    {
        bool Success{ get; }//okunabilir 
        string Message { get; }
    }
}
