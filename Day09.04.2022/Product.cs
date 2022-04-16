namespace Day09._04._2022
{
    public class Product
    {
        public Product(int productNumber, string productName, int count, double price, double totalPrice)
        {
            ProductNumber = productNumber;
            ProductName = productName;
            Count = count;
            Price = price;
            TotalPrice = totalPrice;
        }

        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString()
        {
            return $"{ProductNumber} {ProductName} {Count} {Price} {TotalPrice}";
        }
    }
}