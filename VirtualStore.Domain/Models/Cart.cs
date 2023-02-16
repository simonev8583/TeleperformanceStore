using VirtualStore.Domain.Models.Shared;
using System;

namespace VirtualStore.Domain.Models
{
    public class Cart : BaseModel
    {
        public string PersonId { get; set; }

        public List<Product> Products { get; set; }

        public Cart(string personId, List<Product> products)
        {
            PersonId = personId;
            Products = products;
        }
    }
}

