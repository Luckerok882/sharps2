namespace RestaurantOrderSystem
{
    public class Drink : MenuItem
    {
        public int VolumeMl { get; private set; }
        public bool IsAlcoholic { get; private set; }

        public Drink(string name, decimal price, int volume, bool isAlcoholic)
            : base(name, price)
        {
            VolumeMl = volume;
            IsAlcoholic = isAlcoholic;
        }

        public override string GetDescription()
        {
            string alcStr = IsAlcoholic ? "Алкогольне" : "Безалкогольне";
            return $"[Напій] {Name} ({VolumeMl} мл, {alcStr})";
        }
    }
}