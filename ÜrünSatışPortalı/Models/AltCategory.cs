using ÜrünSatışPortalı.Models;

namespace ÜrünSatışPortalı.API.Models
{
    public class AltCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public List<Product> Products { get; set; }
    }
}
