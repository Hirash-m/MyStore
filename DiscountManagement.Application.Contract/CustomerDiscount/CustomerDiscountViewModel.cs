namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }    
        public string PrudoctName { get; set; }
        public int DiscountRate { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
    }
    public class CustomerDiscountSearch
    {
        public int Id { get; set; }
        public string PrudoctName { get; set; }
    }
}
