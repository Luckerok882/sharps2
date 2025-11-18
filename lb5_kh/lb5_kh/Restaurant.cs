using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrderSystem
{
    public class Restaurant
    {
        private List<MenuItem> _menu;
        private List<Order> _orders;

        public Restaurant()
        {
            _menu = new List<MenuItem>();
            _orders = new List<Order>();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            // Upcasting (приведення: Dish/Drink до MenuItem)
            _menu.Add(new Dish("Борщ", 120, DishCategory.Soup, 300));
            _menu.Add(new Dish("Стейк", 450, DishCategory.MainCourse, 350));
            _menu.Add(new Drink("Кава", 60, 200, false));
            _menu.Add(new Drink("Вино", 150, 150, true));
        }

        public void PrintMenu()
        {
            Console.WriteLine("\n--- МЕНЮ РЕСТОРАНУ ---");
            foreach (var item in _menu)
            {
                // Downcasting (перевірка типу та приведення)
                if (item is Dish dish)
                {
                    Console.WriteLine($"1. {dish.Name} (Категорія: {dish.Category}) - {dish.Price} грн");
                }
                else if (item is Drink drink)
                {
                    string alcoholMark = drink.IsAlcoholic ? "*" : "";
                    Console.WriteLine($"2. {drink.Name} {alcoholMark} ({drink.VolumeMl} мл) - {drink.Price} грн");
                }
            }
            Console.WriteLine("----------------------\n");
        }

        public void CreateOrder(int tableNumber)
        {
            var order = new Order(tableNumber);
            _orders.Add(order);
            Console.WriteLine($"Створено нове замовлення ID: {order.Id} для столика №{tableNumber}");
        }

        public Order GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void AddItemToOrder(int orderId, string itemName)
        {
            var order = GetOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine($"Помилка: Замовлення ID:{orderId} не знайдено!");
                return;
            }

            var item = _menu.FirstOrDefault(m => m.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                Console.WriteLine($"Помилка: Позицію '{itemName}' не знайдено в меню.");
                return;
            }
            order.AddItem(item);
        }

        public void ShowAllOrders()
        {
            Console.WriteLine("\n--- УСІ ЗАМОВЛЕННЯ ---");
            foreach (var order in _orders)
            {
                Console.WriteLine($"ID: {order.Id} | Стіл: {order.TableNumber} | Статус: {order.Status} | Сума: {order.CalculateTotal()} грн");
            }
            Console.WriteLine("--------------------------");
        }
    }
}