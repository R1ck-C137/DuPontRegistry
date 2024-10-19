namespace DuPontRegistry.Models
{
    public class CarFilters
    {
        public static string? Brand { get; set; }
        public static string? Model { get; set; }
        public static int? Year { get; set; }
        public static int? DealerVersion { get; set; }
        public static OrderBy? OrderByPrice { get; set; }
        public static string? DealerName { get; set; }

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
