using VirtualStore.Application.Interfaces;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Application.Dtos;
using VirtualStore.Domain.Models;
using System;

namespace VirtualStore.Application.Services
{
    public class CartService : ICartService<CartDto>
    {
        private readonly ICartRepository<Cart> _cartProvider;

        public CartService(ICartRepository<Cart> cartRepository)
        {
            _cartProvider = cartRepository;
        }

        public CartDto Get(string personId)
        {
            return this.CreateCart(personId);
        }

        public CartDto Update(CartDto cartDto, string personId)
        {

            this.CreateCart(personId);

            var products = new List<Product>();

            cartDto.Products.ForEach((dto) =>
            {
                products.Add(ProductDto.ToDomain(dto));
            });

            Cart cart = new Cart(personId, products);
            cart.Id = cartDto.Id;

            var cartUpdated = _cartProvider.Update(cart);

            return CartDto.FromDomain(cartUpdated);
        }

        private CartDto CreateCart(string personId)
        {
            var cart = _cartProvider.GetByPerson(personId);

            if (cart == null)
            {
                var cartToStorage = new Cart(personId, new List<Product>());

                var cartCreated = _cartProvider.Create(cartToStorage);

                return CartDto.FromDomain(cartCreated);
            }

            return CartDto.FromDomain(cart);
        }
    }
}

