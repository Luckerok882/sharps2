namespace RestaurantOrderSystem
{
    public enum DishCategory
    {
        Soup,
        MainCourse,
        Dessert,
        Salad
    }

    public class Dish : MenuItem
    {
        public DishCategory Category { get; private set; }
        public int WeightGrams { get; private set; }

        public Dish(string name, decimal price, DishCategory category, int weight)
            : base(name, price)
        {
            Category = category;
            WeightGrams = weight;
        }

        public override string GetDescription()
        {
            return $"[Страва] {Name} ({Category}, {WeightGrams}г)";
        }
    }
}