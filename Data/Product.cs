namespace DeliveryApp.Data;


    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; } = default!;
        public Category Category { get; set; } = default!;
    }


