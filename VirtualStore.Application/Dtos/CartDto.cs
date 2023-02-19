using System;
using VirtualStore.Domain.Models;

namespace VirtualStore.Application.Dtos
{
    public class CartDto
    {
        public string? Id { get; set; }

        public string? PersonId { get; set; }

        public List<ProductDto> Products { get; set; }

        public static CartDto FromDomain(Cart cart)
        {
            var dto = new CartDto();

            dto.Id = cart.Id;
            dto.PersonId = cart.PersonId;
            var products = new List<ProductDto>();

            cart.Products.ForEach((product) =>
            {
                products.Add(ProductDto.FromDomain(product));
            });

            dto.Products = products;

            return dto;
        }

    }
}

