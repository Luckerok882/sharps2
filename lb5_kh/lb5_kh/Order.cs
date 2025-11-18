using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrderSystem
{
    public class Order
    {
        private static int _idCounter = 100;
        public int Id { get; private set; }
        public int TableNumber { get; private set; }
        public OrderStatus Status { get; private set; }

        private List<MenuItem> _items;

        public Order(int tableNumber)
        {
            Id = ++_idCounter;
            TableNumber = tableNumber;
            Status = OrderStatus.New;
            _items = new List<MenuItem>();
        }

        public void AddItem(MenuItem item)
        {
            if (Status == OrderStatus.Paid)
            {
                Console.WriteLine($"Помилка: Не можна додавати позиції в оплачене замовлення #{Id}.");
                return;
            }
            _items.Add(item);
            Console.WriteLine($"-> У замовлення #{Id} додано: {item.Name}");
        }

        public decimal CalculateTotal()
        {
            return _items.Sum(x => x.Price);
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"> Статус замовлення #{Id} змінено на: {Status}");
        }

        public void PrintOrderDetails()
        {
            Console.WriteLine($"\n--- Замовлення #{Id} (Стіл {TableNumber}) ---");
            Console.WriteLine($"Статус: {Status}");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item.GetDescription()} ... {item.Price} грн");
            }
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"ЗАГАЛЬНА СУМА: {CalculateTotal()} грн\n");
        }
    }
}