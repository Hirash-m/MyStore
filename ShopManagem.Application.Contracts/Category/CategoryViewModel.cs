namespace ShopManagem.Application.Contracts.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public int ProductsCount{ get; set; }

    }
}
