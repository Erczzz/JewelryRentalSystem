namespace JewelryRentalSystem.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public double Amount { get; set; }
        public int TotalNoOfDays { get; set; }
        public DateTime ReturnDate { get; set; }
        public int ReturnAsPerDueDate { get; set; }

        public Payment() { }

        public Payment(int paymentId, double amount, int totalNoOfDays, DateTime returnDate, int returnAsPerDueDate)
        {
            PaymentId = paymentId;
            Amount = amount;
            TotalNoOfDays = totalNoOfDays;
            ReturnDate = returnDate;
            ReturnAsPerDueDate = returnAsPerDueDate;
        }
    }
}
