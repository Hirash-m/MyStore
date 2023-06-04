namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public int Id { get; set; }
        public string PrudoctName { get; set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
    public class CustomerDiscountSearch
    {
        public int Id { get; set; }
        public string PrudoctName { get; set; }
    }
}
