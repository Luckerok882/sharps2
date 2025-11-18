namespace RestaurantOrderSystem
{
    public abstract class MenuItem
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }

        protected MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public abstract string GetDescription();
    }
}