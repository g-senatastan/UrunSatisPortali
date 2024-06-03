using ÜrünSatışPortalı.API.Models;

namespace ÜrünSatışPortalı.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string BrandName { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public int AltCategoryId { get; set; }
        
        public AltCategory AltCategory { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        


    }
}
