namespace ERPNet.Models
{
    public class OrderProduct : IEntity
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public double PriceItem { get; set; }
        public double PriceItemIva { get; set; }
        public double TotalPrice { get; set; }
    }
}
