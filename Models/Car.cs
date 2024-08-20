using Newtonsoft.Json.Linq;
namespace DuPontRegistry.Models
{
    public class Car 
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public JObject? Vars { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int? DealerVersion { get; set; }
        public int? Price { get; set; }
        public int? Mileage { get; set; }
        public int? Modelyear { get; set; }
        public JArray? Pictures { get; set; }
        public string? DealerName { get; set; }
    }
}
