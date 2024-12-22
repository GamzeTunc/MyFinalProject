using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule:Module   
    {
        protected override void Load(ContainerBuilder builder) //load ettiğinde yani uygulama çalıştığında override etcek içeridekilerini çalıştırcak
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); //bir tane örnek oluşturur sadece çağırmalar için kullanırız data saklamayız içinde 
            //builder.RegisterType<ProductManager>().As<IProductService>(); // IProductService istendiğinde ProductManager new le yani örneği instance yi ver
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
