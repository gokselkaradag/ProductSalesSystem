using ProductSalesSystem.Data;
using ProductSalesSystem.Migrations;
using ProductSalesSystem.Models;
using System.Composition;

namespace ProductSalesSystem.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public void AddProduct(ProductDTO _productDTO)
        {
            Product product = new Product();

            product.Name = _productDTO.Name;
            product.Sale = _productDTO.Sale;
            product.Purchase = _productDTO.Purchase;
            product.Stock = _productDTO.Stock;
            product.ProductSaleCount = _productDTO.ProductSaleCount;
            product.TotalPrice = _productDTO.TotalPrice;
            product.FilePath = _productDTO.FilePath;

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(ProductDTO productDTO)
        {
            var exPro = _context.Products.FirstOrDefault(c => c.Id == productDTO.Id);
            if (exPro != null) 
            {
                _context.Products.Remove(exPro);
                _context.SaveChanges();
            }
        }

        public List<ProductDTO> GetAllProduct()
        {
            List<Product> products = _context.Products.ToList();

            var productsDTO = new List<ProductDTO>();
            foreach (var product in products)
            {
                productsDTO.Add(new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Sale = product.Sale,
                    Purchase = product.Purchase,
                    Stock = product.Stock,
                    ProductSaleCount = product.ProductSaleCount,
                    TotalPrice = product.TotalPrice,
                    FilePath = product.FilePath,

                });
            }
            return productsDTO;

        }

        public ProductDTO GetProductById(int id)
        {
            var pro = _context.Products.FirstOrDefault(p => p.Id == id);
            if (pro == null) return null;

            return new ProductDTO
            {
                Id = pro.Id,
                Name = pro.Name,
                Sale = pro.Sale,
                Purchase = pro.Purchase,
                Stock = pro.Stock,
                ProductSaleCount = pro.ProductSaleCount,
                TotalPrice = pro.TotalPrice,
                FilePath = pro.FilePath
            };
            
        }

        public void UpdateProduct(ProductDTO product)
        {
            var exProd = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (exProd != null)
            {
                exProd.Id = product.Id;
                exProd.Name = product.Name;
                exProd.Sale = product.Sale;
                exProd.Purchase = product.Purchase;
                exProd.Stock = product.Stock;
                exProd.ProductSaleCount = product.ProductSaleCount;
                exProd.TotalPrice = product.TotalPrice;
                exProd.FilePath = product.FilePath;

                _context.Products.Update(exProd);
                _context.SaveChanges();
            }
        }

        public void ProductMarketing(SellDTO _sell)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == _sell.Id);
            if (_sell.Quantity <= product.Stock)
            {
                product.Stock -= _sell.Quantity;
                _sell.TotalPrice = product.Sale * _sell.Quantity;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
        }
    }
}
