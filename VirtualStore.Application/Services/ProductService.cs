using VirtualStore.Application.Interfaces;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Application.Dtos;
using VirtualStore.Domain.Models;
using System;

namespace VirtualStore.Application.Services
{
    public class ProductService : IProductService<ProductDto>
    {
        private readonly IProductRepository<Product> _productProvider;

        public ProductService(IProductRepository<Product> productRepository)
        {
            _productProvider = productRepository;
        }

        public ProductDto Create(ProductDto dto, string personId)
        {
            if (dto == null) throw new ArgumentNullException("Debe enviar los datos correspondientes a un producto");

            var product = ProductDto.ToDomain(dto, personId);

            var productStored = _productProvider.Create(product);

            return ProductDto.FromDomain(productStored);
        }

        public string Delete(string productId, string ownerId)
        {
            _productProvider.Delete(productId, ownerId);

            return "Producto eliminado";
        }

        public ProductDto GetById(string productId)
        {
            var product = _productProvider.GetById(productId);

            if (product == null) throw new ArgumentNullException("No se encontró el producto");

            return ProductDto.FromDomain(product);
        }

        public List<ProductDto> GetProductsOwn(string personId)
        {
            var products = _productProvider.GetProductsOwn(personId);

            var result = new List<ProductDto>();

            products.ForEach(product =>
            {
                result.Add(ProductDto.FromDomain(product));
            });

            return result;
        }

        public List<ProductDto> GetProductsToBuy(string personId)
        {
            var products = _productProvider.GetProductsToBuy(personId);

            var result = new List<ProductDto>();

            products.ForEach(product =>
            {
                result.Add(ProductDto.FromDomain(product));
            });

            return result;
        }

        public ProductDto Update(ProductDto dto, string productId, string personId)
        {
            var productToUpdate = ProductDto.ToDomain(dto, personId);

            var productUpdated = _productProvider.Update(productToUpdate);

            return ProductDto.FromDomain(productUpdated);
        }

        public string UploadFile(string productId, string personId, string filename)
        {
            var product = _productProvider.GetById(productId);

            product.Filename = filename;

            var productUpdated = _productProvider.UploadImagen(product);

            return "Se cargó la imagen";
        }
    }
}

