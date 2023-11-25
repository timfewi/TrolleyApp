using System.ComponentModel.DataAnnotations.Schema;

namespace Trolley.API.Entities
{
    [Table(nameof(Category))]
    public class Category : BaseEntity
    {

        public string Name { get; set; }


        // Foreign key for parent category
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public Guid IconId { get; set; }
        public Icon Icon { get; set; }


        // Collection of child categories
        public ICollection<Category> ChildCategories { get; set; }
    }
}
