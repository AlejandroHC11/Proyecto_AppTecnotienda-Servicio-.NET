using ApiTecnotienda.Models;
using ApiTecnotienda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiTecnotienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            //Por inyeccion de dependencia se crea la instancia de la clase
            this.productRepository = productRepository;
        }
        [HttpGet]
        [Route("/GetProducts")]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await productRepository.GetProducts();
        }
        [HttpGet]
        [Route("/GetProductByOrder/{order}")]
        public async Task<Product?> GetCustomerById(int order)
        {
            return await productRepository.GetProductByOrder(order);
        }

        [HttpPost]
        [Route("/CreateProduct")]
        public async Task<Product> CreateProduct(Product product)
        {
            return await productRepository.CreateProduct(product);
        }
        [HttpPut]
        [Route("/UpdateProduct")]
        public async Task<Product> UpdateProduct(Product product)
        {
            return await productRepository.UpdateProduct(product);
        }
        [HttpDelete]
        [Route("/DeleteProduct")]
        public async Task<bool> DeleteProduct(int id)
        {
            return await productRepository.DeleteProduct(id);
        }
        [HttpGet("/GenerateJasperReport")]
        public async Task<IActionResult> ObtenerInforme()
        {
            var informeBytes = await productRepository.GenerateJasperReport();
            return File(informeBytes, "application/pdf", "informe.pdf");
            
        }
    }
}
