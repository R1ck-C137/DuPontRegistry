namespace DuPontRegistry.Models
{
    public class CarFilters
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public int? DealerVersion { get; set; }
        public OrderBy? OrderByPrice { get; set; }
        public string? DealerName { get; set; }

        public bool WithoutFilters;

        public CarFilters()
        {
            WithoutFilters = true;
        }
    }

    public enum OrderBy
    {
        asc,
        desc
    }
}
