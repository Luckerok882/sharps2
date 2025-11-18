using System;
using System.Text;

namespace RestaurantOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Restaurant restaurant = new Restaurant();


            restaurant.PrintMenu();

            restaurant.CreateOrder(7);
            int currentOrderId = 101;

            restaurant.AddItemToOrder(currentOrderId, "Борщ");
            restaurant.AddItemToOrder(currentOrderId, "Вино");

            Order myOrder = restaurant.GetOrderById(currentOrderId);

            if (myOrder != null)
            {
                Console.WriteLine($"\nПоточний статус замовлення #{myOrder.Id}: {myOrder.Status}");

                myOrder.ChangeStatus(OrderStatus.InProgress);
                myOrder.ChangeStatus(OrderStatus.Ready);

                myOrder.PrintOrderDetails();

                myOrder.ChangeStatus(OrderStatus.Paid);
            }

            restaurant.AddItemToOrder(currentOrderId, "Стейк");

            restaurant.ShowAllOrders();

            Console.ReadKey();
        }
    }
}