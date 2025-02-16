namespace Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Item() { }
        public Item (
            Guid id,
            string name, 
            string description,
            string image,
            int stock
            ) 
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Status = "active";
            Stock = stock;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

        }
    }
}
