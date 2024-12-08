using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //url den nasıl ulaşılacağı
    [ApiController] //ATTIRIBUT BU CLASS BİR CONTROLLERDİR ONA GÖRE YAPILANDIR .NET DİYOZ
    public class ProductsController : ControllerBase //controllerbase de kenfdiliğindden geldi
    {
        IProductService _productService;
        public ProductsController(IProductService productService) //IProductService ProductManager aslında çünkü onun referansını tutabiliyo
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() //methodun ismi ,string döndürüyo
        {
           Thread.Sleep( 1000);

            //IProductService productService = new ProductManager(new EfProductDal()); bu bağımlı yapar o yüzden constructor injection kullanırız
            var result = _productService.GetAll();
            
            if (result.Success) //if (result.Success==true) bununla aynı
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) //sadece bir ürünü çekmek için kullanırız
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId) //sadece bir ürünü çekmek için kullanırız
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)//if (result.Success==true) bununla aynı
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
