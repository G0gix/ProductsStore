using System.Collections.Generic;

namespace ProductsStore.Models.MainModels
{
    public class CategoryWithFields
    {
        public CategoryModel Category { get; set; }
        public List<FieldModel> Fields { get; set; }
    }

    public class FieldModel
    {
        public string Name { get; set; }
    }
}
