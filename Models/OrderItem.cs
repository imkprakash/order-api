namespace OrderApi.Models
{
    public class OrderItem
    {
        public string Name { get; set; }
        public UInt64 Price { get; set; }
        public UInt64 Units { get; set; }
        public UInt64 Total => Price * Units;

        public OrderItem(string name, string price, string units)
        {
            Name = name;
            Price = Convert.ToUInt64(price);
            Units = Convert.ToUInt64(units);
        }

        public OrderItem() { }
    }
}
