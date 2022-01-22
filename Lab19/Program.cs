using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Computer
    {
        public float Code { get; set; }
        public string Mark { get; set; }
        public string CPU { get; set; }
        public double FreqProc { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int VRAM { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){Code=2548624,Mark="Avalon",CPU="AMD",FreqProc=3.5,RAM=1024,HDD=400,VRAM=512,Price=200,Count=2},               
                new Computer(){Code=2548624,Mark="IBM",CPU="AMD",FreqProc=3.2,RAM=4096,HDD=200,VRAM=1024,Price=300,Count=10},
                new Computer(){Code=2548624,Mark="SGI",CPU="AMD",FreqProc=3.0,RAM=4096,HDD=500,VRAM=1024,Price=500,Count=15},               
                new Computer(){Code=2548624,Mark="Sequent",CPU="AMD",FreqProc=3.2,RAM=2048,HDD=400,VRAM=2048,Price=200,Count=20},
                new Computer(){Code=2548624,Mark="Parsytec",CPU="AMD",FreqProc=2.8,RAM=1024,HDD=500,VRAM=512,Price=300,Count=25},               
                new Computer(){Code=2548624,Mark="Avalon",CPU="AMD",FreqProc=2.5,RAM=4096,HDD=400,VRAM=1024,Price=500,Count=30},
                
            };

            Console.Write("Введите CPU:");
            string CPU = Console.ReadLine();
            Console.Write("Введите RAM:");
            int RAM = Convert.ToInt32(Console.ReadLine());
            //Определение по определенному процесору и по объему ОУЗ
            List<Computer> COMP = computers
                .Where(c => c.RAM > RAM)
                .Where(c => c.CPU == CPU)
                .ToList();
            Console.WriteLine();

            //Сортировка по увелечению цены
            List<Computer> comp0 = computers
                .OrderBy(c => c.Price)
                .ToList();
            foreach (Computer c in comp0)
                Console.WriteLine($" Code:{c.Code}\n Mark:{c.Mark}\n CPU:{c.CPU}\n FreqProc:{c.FreqProc} HZ\n RAM:{c.RAM} MB\n HDD:{c.HDD} TB\n VRAM:{c.VRAM} MB\n Price:{c.Price} y.e\n Count:{c.Count} шт.\n");
            Console.WriteLine();

            
            var comp2 = computers
                .GroupBy(com => (com.CPU)
                , (cpu, count) => new
                {
                    CPU = cpu,
                    Count = count.Count(),
                });
            foreach (var result in comp2)
            {
                Console.WriteLine("\nCPU: " + result.CPU);
                Console.WriteLine("Колличество: " + result.Count);
            }
            Console.WriteLine();

            
            var comp = computers
                .Min(c => c.Price);
            Console.WriteLine($"Минимальная цена : {comp} ");
            Console.WriteLine();

            
            var comp1 = computers
                .Max(c => c.Price);
            Console.WriteLine($"Максимальная цена : {comp1} ");
            Console.WriteLine();

            
            var comp3 = computers
                .Any(c => c.Count > 30);
            bool YoN = comp3;
            Console.WriteLine("В списке {0} компьютеров больше 30 шт.", YoN ? "есть" : "нет");

            Console.ReadKey();
        }
    }
}
