using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            DtoTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { Name = "Turkuaz" });
            List<Color> colors = colorManager.GetAll();
            foreach (var color in colors)
            {
                Console.WriteLine("{0}: {1}", color.Id, color.Name);
            }
            Console.WriteLine();
            Color color1 = colorManager.GetById(5);
            Console.WriteLine("5: {0}", color1.Name);
            color1.Name = "Gece yarısı mavisi";
            colorManager.Update(color1);
            Console.WriteLine("5: {0}", color1.Name);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "TOGG" });
            List<Brand> brands = brandManager.GetAll();
            foreach (var brand in brands)
            {
                Console.WriteLine("{0}: {1}", brand.Id, brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { Name = "TOGG", ModelYear = 2023, BrandId = 13, ColorId = 4, DailyPrice = 1200.99M, Description = "Yerli ve Milli elektrikli araç" });
            List<Car> cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("{0}: {1}", car.Name, car.Description);
            }
            var result = carManager.GetById(16);
            Console.WriteLine();
            Console.WriteLine("16 numaralı araç {0} {1}", result.Name, result.ColorId);
            result.ColorId = 11;
            carManager.Update(result);
            Console.WriteLine("13 numaralı araç {0} {1}", result.Name, result.ColorId);
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var details = carManager.GetCarDetails();
            foreach (var detail in details)
            {
                Console.WriteLine("{0} marka {1} aracı {2} renkte ve günlük fiyatı {3}$", detail.BrandName, detail.CarName,detail.ColorName, detail.DailyPrice);
            }
        }
    }
}
