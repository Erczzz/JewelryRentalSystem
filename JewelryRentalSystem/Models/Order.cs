namespace JewelryRentalSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentDueDate { get; set;}

        public Order() { }

        public Order(int orderId, DateTime rentStartDate, DateTime rentDueDate)
        {
            OrderId = orderId;
            RentStartDate = rentStartDate;
            RentDueDate = rentDueDate;
        }
    }
}
