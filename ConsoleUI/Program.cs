// See https://aka.ms/new-console-template for more information



using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//ProductManager productManager = new ProductManager(new InMemoryProductDal());
//foreach (var product in productManager.GetAll())
//{
//    Console.WriteLine(product.ProductName);
//}
//ProductManager productManager = new ProductManager(new EfProductDal());
//foreach (var product in productManager.GetAll())
//{
//    Console.WriteLine(product.ProductName);
//}
//ProductManager productManager = new ProductManager(new EfProductDal());
//foreach (var product in productManager.GetAllByCategoryId(2))
//{
//    Console.WriteLine(product.ProductName);
//}
ProductManager productManager = new ProductManager(new EfProductDal());
foreach (var product in productManager.GetByUnitPrice(40,100))
{
    Console.WriteLine(product.ProductName);
}