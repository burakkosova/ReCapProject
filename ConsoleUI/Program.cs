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
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { Name = "Lamborghini" });
            //brandManager.Add(new Brand { Name = "Fiat" });
            //brandManager.Add(new Brand { Name = "Pagani" });
            //brandManager.Add(new Brand { Name = "Rolls Royce" });
            //brandManager.Add(new Brand { Name = "Range Rover" });
            //brandManager.Add(new Brand { Name = "Volkswagen" });

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { Name = "Siyah" });
            //colorManager.Add(new Color { Name = "Beyaz" });
            //colorManager.Add(new Color { Name = "Gri" });
            //colorManager.Add(new Color { Name = "Kırmızı" });
            //colorManager.Add(new Color { Name = "Lacivert" });


            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(
            //    new Car
            //    {
            //        Name = "Fiat Egea",
            //        BrandId = 2,
            //        ColorId = 2,
            //        DailyPrice = 150,
            //        Description = "Fiat Egea 1.6 Dizel",
            //        ModelYear = 2018
            //    });

            //carManager.Add(
            //    new Car
            //    {
            //        Name = "Lamborghini Huracan",
            //        BrandId = 1,
            //        ColorId = 1,
            //        DailyPrice = 15000,
            //        Description = "Lamborghini Huracan 5.0 Coupe",
            //        ModelYear = 2020
            //    });

            //carManager.Add(
            //    new Car
            //    {
            //        Name = "Pagani Huayra",
            //        BrandId = 3,
            //        ColorId = 4,
            //        DailyPrice = 25000,
            //        Description = "Pagani Huayra Roadster V12 791 Beygir",
            //        ModelYear = 2020
            //    });

            //carManager.Add(
            //    new Car
            //    {
            //        Name = "Rolls Royce Ghost",
            //        BrandId = 4,
            //        ColorId = 5,
            //        DailyPrice = 35000,
            //        Description = "Rolls Royce Ghost II 6750 cc 563 beygir 820 Nm tork 5 kişilik",
            //        ModelYear = 2019
            //    });

            //carManager.Add(
            //   new Car
            //   {
            //       Name = "Range Rover Velar",
            //       BrandId = 5,
            //       ColorId = 1,
            //       DailyPrice = 2500,
            //       Description = "Range Rover Velar 1997 cc 182 beygir 365 Nm torque",
            //       ModelYear = 2018
            //   });

            //carManager.Add(
            //   new Car
            //   {
            //       Name = "Volkswagen Passat",
            //       BrandId = 6,
            //       ColorId = 3,
            //       DailyPrice = 650,
            //       Description = "Volkswagen Passat 1968 cc 175 hp 350 Nm tork",
            //       ModelYear = 2017
            //   });

            //carManager.Add(new Car { BrandId = 2, ColorId = 2, DailyPrice = 200, Description = "Fiat 500x Kompakt SUV", Name = "Fiat 500x",ModelYear = 2017 });

            try
            {
                //carManager.Add(new Car { Name="a", DailyPrice = 100 });
                //carManager.Add(new Car { Name="araba", DailyPrice = -20 });
                //carManager.Add(new Car { Name = "Range Rover Vogue", DailyPrice = 750, BrandId = 5, ColorId = 2, ModelYear = 2012 });
                //carManager.Add(new Car { Name="araba" });

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            List<Car> cars = carManager.GetByBrandId(5);

            foreach (var car in cars)
            {
                Console.WriteLine("{0} aracının günlük fiyatı: {1}",car.Name,car.DailyPrice);
            }
        }
    }
}
