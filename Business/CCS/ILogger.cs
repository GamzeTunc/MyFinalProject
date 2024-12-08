using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS
{
    public interface ILogger //interface ıoluşturuyoruz ki başka loglama db, mesaj yolu,klasörde tutma gibi farklı log işlemleri yaparsak  hepsinin ortak kodlarını ve metodlarını burada çalıştıralım
    {
        void Log();
    }
}
