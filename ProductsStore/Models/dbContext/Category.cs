﻿using System.Collections.Generic;

#nullable disable

namespace ProductsStore.Models.dbContext
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
