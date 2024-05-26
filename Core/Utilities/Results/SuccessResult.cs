using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //base Result classına bişey gönder diyor yani result a  
        //constraction ,mesage alsın base ye de ikisini yada true yolla
        public SuccessResult(string message):base(true,message)
        {

        }
        public SuccessResult():base(true) //productManeger.cs de zaten bu classı new ledik bu classa gelir eğer parametre yoksa bu metod çalışır bu çalıştıktan sonra da   burası result.cs ye yollar (base dediğimiz için de true yolluyoruz ) o yüzden de sadece true olan metod çalışır override olan yani.
        {

        }
    }
}
