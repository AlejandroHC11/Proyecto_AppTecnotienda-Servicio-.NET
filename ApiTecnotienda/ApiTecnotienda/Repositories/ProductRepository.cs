using ApiTecnotienda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTecnotienda.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BDTecnotiendaContext dbContext;
        public ProductRepository(BDTecnotiendaContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.IdProduct == id);
            if (product == null)
            {
                return false;
            }
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<byte[]> GenerateJasperReport()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var urlServicioJava = "http://192.168.1.102:7212/GenerateJasperReport";
                    return await httpClient.GetByteArrayAsync(urlServicioJava);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de conexion: {ex.Message}");
                throw;
            }
        }

        public async Task<Product?> GetProductByOrder(int order)
        {
            var orderedProduct = await dbContext.Products.OrderBy(p => p.IdProduct).Skip(order - 1).FirstOrDefaultAsync();
            return orderedProduct;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
    }
}
