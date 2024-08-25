using Newtonsoft.Json.Linq;

namespace DuPontRegistry.Models
{
    public class Seller : User
    {
        public string Title { get; set; }
        public string Web { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public string Descr { get; set; }
        public string Metro { get; set; }
        public string State { get; set; }
        public JObject Contact { get; set; }
    }
}
