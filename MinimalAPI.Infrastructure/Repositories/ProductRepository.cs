using Microsoft.EntityFrameworkCore;
using MinimalAPI.Application.Interfaces;
using MinimalAPI.Domain.Models;

namespace MinimalAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProdDbContext _prodDb;

        public ProductRepository(ProdDbContext prodDbContext)
        {
            _prodDb = prodDbContext;
        }
        public async Task<ICollection<Product>> GetAllProducts() => await _prodDb.Products.ToListAsync();

        public async Task<Product?> GetProductById(int _id) => await _prodDb.Products.FirstOrDefaultAsync(p => p.Id == _id);

        // TODO: Дописать проверку в API если возвращается Null!
        public async Task<Product> CreateProduct(Product _newProduct)
        {
            _newProduct.CreationDate = DateTime.Now;
            _newProduct.LastModified = DateTime.Now;
            await _prodDb.Products.AddAsync(_newProduct);
            await _prodDb.SaveChangesAsync();
            return _newProduct;
        }

        public async Task<Product?> UpdateProduct(int _id, Product _updateProduct)
        {
            var _checkProduct = await _prodDb.Products.FirstOrDefaultAsync(p => p.Id == _id);
            if (_checkProduct is null || _checkProduct.Id != _updateProduct.Id) return null;
            _checkProduct.Name = _updateProduct.Name;
            _checkProduct.Description = _updateProduct.Description;
            _checkProduct.Qnt = _updateProduct.Qnt;
            _checkProduct.Price = _updateProduct.Price;
            _checkProduct.LastModified = DateTime.Now;
            await _prodDb.SaveChangesAsync();
            return _checkProduct;

        }
        public async Task<bool> DeleteProduct(int _id)
        {
            var _deleteProduct = await _prodDb.Products.FirstOrDefaultAsync(p => p.Id == _id);
            if (_deleteProduct is null) return false;
            _prodDb.Products.Remove(_deleteProduct);
            await _prodDb.SaveChangesAsync();
            return true;
        }
    }
}
