namespace Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Item() { }
        public Item (
            string name, 
            string description,
            string image
            ) 
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Image = image;
            Status = "active";
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

        }
    }
}
