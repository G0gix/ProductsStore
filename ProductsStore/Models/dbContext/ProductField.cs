#nullable disable

namespace ProductsStore.Models.dbContext
{
    public partial class ProductField
    {
        public int ProductId { get; set; }
        public int FieldId { get; set; }
        public string Value { get; set; }

        public virtual Field Field { get; set; }
        public virtual Product Product { get; set; }
    }
}
