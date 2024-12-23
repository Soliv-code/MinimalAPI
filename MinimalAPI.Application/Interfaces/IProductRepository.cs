using MinimalAPI.Domain.Models;

namespace MinimalAPI.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllProducts();
        Task<Product?> GetProductById(int _id);
        Task<Product> CreateProduct(Product _newProduct);
        Task<Product?> UpdateProduct(int _id, Product _updateProduct);
        Task<bool> DeleteProduct(int _id);
    }
}
