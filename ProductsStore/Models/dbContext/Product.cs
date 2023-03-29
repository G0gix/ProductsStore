using System;
using System.Collections.Generic;

#nullable disable

namespace ProductsStore.Models.dbContext
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
