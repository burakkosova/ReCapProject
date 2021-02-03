using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(new Car { Id=10, BrandId = 5, ColorId=3, DailyPrice=1756.99, Description="Range Rover Vogue", ModelYear=2015 });
            var result = carManager.GetAll();
            foreach (var c in result)
            {
                Console.WriteLine(c.Description);
            }

            Console.WriteLine();

            Console.WriteLine("CarID=4 before update: {0}",carManager.GetById(4).Description);
            Car car = new Car {Id=4, BrandId = 9, ColorId = 1, DailyPrice = 120, Description = "Peugeot 206", ModelYear = 2011 };
            carManager.Update(car);
            Console.WriteLine("CarID=4 after update: {0}", carManager.GetById(4).Description);

            carManager.Delete(new Car { Id = 4 });
            Console.WriteLine();
            Console.WriteLine("After deleting CarID=4");

            result = carManager.GetAll();
            foreach (var c in result)
            {
                Console.WriteLine(c.Description);
            }

        }
    }
}
