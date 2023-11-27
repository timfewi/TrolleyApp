namespace Trolley.API.Dtos
{
    public class ShoppingListReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCheapest { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
