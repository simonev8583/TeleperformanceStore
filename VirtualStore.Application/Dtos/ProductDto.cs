﻿using VirtualStore.Domain.Models;
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

            return dto;
        }

        public static Product ToDomain(ProductDto dto, string? owner)
        {
            var product = new Product(dto.Title!, dto.Description!);

            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.Owner = owner ?? "";
            product.Id = dto.Id;

            return product;
        }
    }
}
