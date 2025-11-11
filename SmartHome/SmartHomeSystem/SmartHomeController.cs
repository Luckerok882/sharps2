using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private readonly List<ISwitchable> switchableDevices = new List<ISwitchable>();
        private readonly List<IEnergyConsumer> energyConsumer = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            switchableDevices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            energyConsumer.Add(device);
        }

        public void TurnAllOn()
        {
            foreach (var device in switchableDevices)
            {
                device.TurnOn();
            }
        }

        public void TurnAllOff()
        {
            foreach (var device in switchableDevices)
            {
                device.TurnOff();
            }
        }

        public void ShowEnergyReport(int hours)
        {
            double totalConsumption = 0;
            const double pricePerKWh = 4.0;

            var ukCulture = new CultureInfo("uk-UA");

            Console.WriteLine($"Звіт про споживання енергії за {hours} год:");

            foreach (var consumer in energyConsumer)
            {
                double usage = consumer.GetEnergyUsage(hours);
                totalConsumption += usage;

                Console.WriteLine($"{consumer.DeviceName}: {usage.ToString("F2", ukCulture)} кВт·год (потужність: {consumer.PowerConsumption} Вт)");
            }

            double totalCost = totalConsumption * pricePerKWh;

            Console.WriteLine($"Загальне споживання: {totalConsumption.ToString("F2", ukCulture)} кВт·год");
            Console.WriteLine($"Вартість (~{pricePerKWh} грн/кВт·год): {totalCost.ToString("F2", ukCulture)} грн");
        }

        public IEnumerable<ISwitchable> GetAllDevices() => switchableDevices;
    }
}