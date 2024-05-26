﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages //static ekledik artık (sabit olduğu için verdik) yani new lenmez uygulama hayatı boyunca tek instance si oluyor
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInValid = "Ürün ismi geçersiz";
    }
}
