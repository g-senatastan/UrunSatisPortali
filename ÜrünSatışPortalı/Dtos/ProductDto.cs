namespace ÜrünSatışPortalı.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }

        public int AltCategoryId { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        
    }
}
