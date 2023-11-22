using ApiTecnotienda.Models;

namespace ApiTecnotienda.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProductByOrder(int order);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<byte[]> GenerateJasperReport();
    }
}
