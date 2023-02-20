using VirtualStore.Domain.Models;
using System;

namespace VirtualStore.Application.Dtos
{
    public class ProductDto
    {
        public string? Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public string? Owner { get; set; } = "";

        public int Quantity { get; set; }

        public string Filename { get; set; }

        public ProductDto()
        {
        }

        public static ProductDto FromDomain(Product product)
        {
            var dto = new ProductDto();

            dto.Title = product.Title;
            dto.Description = product.Description;
            dto.Price = product.Price;
            dto.Stock = product.Stock;
            dto.Id = product.Id;
            dto.Owner = product.Owner;
            dto.Quantity = product.Quantity;
            dto.Filename = product.Filename;

            return dto;
        }

        public static Product ToDomain(ProductDto dto, string? owner)
        {
            var product = new Product(dto.Title!, dto.Description!);

            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.Owner = owner ?? dto.Owner!;
            product.Id = dto.Id;
            product.Quantity = dto.Quantity;
            product.Filename = dto.Filename;

            return product;
        }

        public static Product ToDomain(ProductDto dto)
        {
            var product = new Product(dto.Title!, dto.Description!);

            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.Owner = dto.Owner!;
            product.Id = dto.Id;
            product.Quantity = dto.Quantity;
            product.Filename = dto.Filename;

            return product;
        }
    }
}

