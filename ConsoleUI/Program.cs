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
ProductText();

//CategoryText();

static void ProductText()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    var result = productManager.GetProductDetails();
    if (result.Success==true)
    {
        foreach (var product in result.Data)
        {
            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
   
}

static void CategoryText()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}