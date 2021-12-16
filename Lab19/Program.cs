using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class PC
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Processor { get; set; }
        public int Frequency { get; set; }
        public int Memory { get; set; }
        public int Hdd { get; set; }
        public int Video { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<PC> specification = new List<PC>()
            {
                new PC(){Code=45, Name="Lenovo", Processor="Пентиум1", Frequency=3000, Memory=4, Hdd=64, Video=2, Price=20000, Number=10},
                new PC(){Code=01, Name="Acer", Processor="Пентиум3", Frequency=3500, Memory=16, Hdd=256, Video=8, Price=5000, Number=8},
                new PC(){Code=24, Name="Asus", Processor="Пентиум8", Frequency=9000, Memory=32, Hdd=1024, Video=16, Price=150000, Number=1},
                new PC(){Code=35, Name="Lenovo", Processor="Пентиум1", Frequency=3000, Memory=4, Hdd=512, Video=4, Price=16000, Number=30},
                new PC(){Code=99, Name="Dell", Processor="Селерон", Frequency=400, Memory=4, Hdd=12, Video=1, Price=1000, Number=18},
                new PC(){Code=66, Name="Dell", Processor="Пентиум1", Frequency=3000, Memory=8, Hdd=256, Video=8, Price=5000, Number=40},
                new PC(){Code=66, Name="Электроника", Processor="Атлас", Frequency=30, Memory=1, Hdd=32, Video=2, Price=50, Number=20}

            };

            Console.WriteLine("Какие процессоры найти:");
            string searchProc = Console.ReadLine();


            List<PC> compsProc = specification
                             .Where(d => d.Processor == searchProc)
                             .ToList();
            foreach (PC d in compsProc)
                Console.WriteLine($"Компьютер: {d.Code}, {d.Name}, {d.Processor}, {d.Frequency}, {d.Memory}, {d.Hdd}, {d.Video}, {d.Price}, {d.Number}");
            Console.WriteLine();

            Console.WriteLine("Какая минимальная память:");
            int minMemory = Convert.ToInt32(Console.ReadLine());
            List<PC> compsMemo = specification
                             .Where(d => d.Memory >= minMemory)
                             .ToList();
            foreach (PC d in compsMemo)
                Console.WriteLine($"Компьютер: {d.Code}, {d.Name}, {d.Processor}, {d.Frequency}, {d.Memory}, {d.Hdd}, {d.Video}, {d.Price}, {d.Number}");
            Console.WriteLine();

            var ascendingPrice = specification
                .OrderBy(d => d.Price)
                .ToList();
            foreach (var d in ascendingPrice)
                Console.WriteLine($"Сортировка по цене: {d.Code}, {d.Name}, {d.Processor}, {d.Frequency}, {d.Memory}, {d.Hdd}, {d.Video}, {d.Price}, {d.Number}");
            Console.WriteLine();

            var groupProc = specification
                .GroupBy(d => d.Processor);

            foreach (IGrouping<string, PC> d in groupProc)
            {
                Console.WriteLine($"Процессор { d.Key}:");
                foreach (var g in d)
                Console.WriteLine($"{g.Code}, {g.Name}, {g.Processor}, {g.Frequency}, {g.Memory}, {g.Hdd}, {g.Video}, {g.Price}, {g.Number}");
            };

            int maxPrice = specification.Max(d => d.Price);
            int minPrice = specification.Min(d => d.Price);
            Console.WriteLine();

            List<PC> compsMaxPrice = specification
                             .Where(d => d.Price == maxPrice)
                             .ToList();
            List<PC> compsMinPrice = specification
                             .Where(d => d.Price == minPrice)
                             .ToList();
            foreach (PC d in compsMaxPrice)
                Console.WriteLine($"Самый дорогой: {d.Code}, {d.Name}, {d.Processor}, {d.Frequency}, {d.Memory}, {d.Hdd}, {d.Video}, {d.Price}, {d.Number}");
            Console.WriteLine();
            foreach (PC d in compsMinPrice)
                Console.WriteLine($"Самый дешевый: {d.Code}, {d.Name}, {d.Processor}, {d.Frequency}, {d.Memory}, {d.Hdd}, {d.Video}, {d.Price}, {d.Number}");
            Console.WriteLine();

            bool findOver30 = specification.Any(d => d.Number >= 30);
            if (findOver30 == true)
            {
                Console.WriteLine("Есть компьютеры в количестве не менее 30 штук.");
            }
            else
            {
                Console.WriteLine("Каждого компьютера имеется менее 30 штук.");
            }

            Console.ReadKey();
        }
    }
}
