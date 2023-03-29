using System;
using System.Collections.Generic;
using ProductsStore.Models.MainModels;

#nullable disable

namespace ProductsStore.Models.dbContext
{
    public partial class CategoryField
    {
        public int CategoryId { get; set; }
        public int FieldId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Field Field { get; set; }
    }
}
