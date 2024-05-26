using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResults
    {
        //buraya successResult tan geliyor değişkenler

        public Result(bool success, string message):this(success) //this demek class ın kendisi(result) demek yani result ın construction una message yi yolla 
        {
            Message = message;
           
        }
        public Result(bool success) //override etmiş oluyoz
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
