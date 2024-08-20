namespace DuPontRegistry.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public int CarId { get; set; }
        public DateTime CreateDate {  get; set; }
    }
}
