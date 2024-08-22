using ProductSalesSystem.Models;

namespace ProductSalesSystem.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(ProductDTO _productDTO);

        void UpdateProduct(ProductDTO product);

        void DeleteProduct(ProductDTO productDTO);

        void ProductMarketing(SellDTO _sell);
        List<ProductDTO> GetAllProduct();

        ProductDTO GetProductById(int id);
    }
}
