﻿using VirtualStore.Domain.Models.Shared;
using System;

namespace VirtualStore.Domain.Models
{
    public class Product : BaseModel
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public Product(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
