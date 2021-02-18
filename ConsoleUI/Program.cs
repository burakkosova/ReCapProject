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
            //AddEntities();


            //CarTest();
            //BrandTest();
            //ColorTest();
            //DtoTest();
            //RentalTest();
        }

        private static void AddEntities()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "Fiat" });
            brandManager.Add(new Brand { Name = "Land Rover" });
            brandManager.Add(new Brand { Name = "Pagani" });
            brandManager.Add(new Brand { Name = "Alfa Romeo" });
            brandManager.Add(new Brand { Name = "Lamborgini" });
            brandManager.Add(new Brand { Name = "Porsche" });
            brandManager.Add(new Brand { Name = "Opel" });
            brandManager.Add(new Brand { Name = "Renault" });

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = "Beyaz" });
            colorManager.Add(new Color { Name = "Siyah" });
            colorManager.Add(new Color { Name = "Lacivert" });
            colorManager.Add(new Color { Name = "Kırmızı" });
            colorManager.Add(new Color { Name = "Gri" });

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 1, Name = "Egea", ModelYear = 2018, DailyPrice = 150, Description = "1.6 Multijet Comfort, Yari Otomatik, Dizel, Sedan" });
            carManager.Add(new Car { BrandId = 2, ColorId = 2, Name = "Range Rover Velar", ModelYear = 2020, DailyPrice = 1650, Description = "2.0 TD4 R-Dynamic S, Otomatik, Dizel, SUV" });
            carManager.Add(new Car { BrandId = 3, ColorId = 3, Name = "Huayra", ModelYear = 2021, DailyPrice = 25789, Description = "6.0 V12 Turbocharged 764hp 1,001 Nm" });
            carManager.Add(new Car { BrandId = 4, ColorId = 4, Name = "Giulietta", ModelYear = 2014, DailyPrice = 169, Description = "1.6 JTD Progression Pluse, Manuel, Dizel, 5 Kapili Hatchback" });
            carManager.Add(new Car { BrandId = 1, ColorId = 4, Name = "500x", ModelYear = 2016, DailyPrice = 279, Description = "1.6 Multijet, Yari Otomatik, Dizel, Cross-SUV" });
            carManager.Add(new Car { BrandId = 5, ColorId = 1, Name = "Huracan", ModelYear = 2014, DailyPrice = 19879, Description = "LP-610-4, Coupe, 5204cc 610hp 4WD, Benzinli" });
            carManager.Add(new Car { BrandId = 6, ColorId = 2, Name = "911 Carrera S", ModelYear = 2013, DailyPrice = 12450, Description = "Chrono Sport Paket, Yari Otomatik, 4000cc Benzinli" });
            carManager.Add(new Car { BrandId = 7, ColorId = 5, Name = "Corsa", ModelYear = 2017, DailyPrice = 179, Description = "Manuel, 1.2 Benzinli" });
            carManager.Add(new Car { BrandId = 8, ColorId = 3, Name = "Megane", ModelYear = 2018, DailyPrice = 250, Description = "Otomatik, 1.6 Dizel" });
            carManager.Add(new Car { BrandId = 8, ColorId = 5, Name = "Symbol", ModelYear = 2016, DailyPrice = 149, Description = "Manuel, 1.2 Dizel" });
        }

        private static void RentalTest()
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Burak", LastName = "Kosova", Email = "burak.kosova@hotmail.com", Password = "123456" });

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customerAddResult = customerManager.Add(new Customer { CompanyName = "Kosova Enterprise", UserId = 1 });
            Console.WriteLine(customerAddResult.Message);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental { CarId = 5, CustomerId = 1, RentDate = new DateTime(2021, 02, 13, 18, 17, 53) });
            Console.WriteLine(result.Message);

            var getRental = rentalManager.GetById(1);
            if (getRental.Success)
            {
                var rentalToUpdate = getRental.Data;
                rentalToUpdate.ReturnDate = new DateTime(2021, 02, 13, 18, 30, 53);
                rentalManager.Update(rentalToUpdate);
            }
            else
            {
                Console.WriteLine(getRental.Message);
            }

            var rentResult = rentalManager.Add(new Rental { CarId = 5, CustomerId = 1, RentDate = new DateTime(2021, 02, 13, 18, 45, 53) });
            Console.WriteLine(rentResult.Message);

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Car ID: {0} Customer ID: {1} RentDate: {2}, ReturnData: {3}", rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var addResult = colorManager.Add(new Color { Name = "Turkuaz" });
            Console.WriteLine(addResult.Message);

            List<Color> colors = colorManager.GetAll().Data;
            foreach (var color in colors)
            {
                Console.WriteLine("{0}: {1}", color.ColorId, color.Name);
            }

            Console.WriteLine();
            var getByIdResult = colorManager.GetById(3);
            if (getByIdResult.Success)
            {
                Color color1 = getByIdResult.Data;
                Console.WriteLine("3: {0}", color1.Name);
                color1.Name = "Gece yarısı mavisi";

                var updateResult = colorManager.Update(color1);
                Console.WriteLine(updateResult.Message);
                Console.WriteLine("3: {0}", color1.Name);
            }
            else
            {
                Console.WriteLine(getByIdResult.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var addResult = brandManager.Add(new Brand { Name = "TOGG" });
            Console.WriteLine(addResult.Message);

            List<Brand> brands = brandManager.GetAll().Data;
            foreach (var brand in brands)
            {
                Console.WriteLine("{0}: {1}", brand.BrandId, brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var addResult = carManager.Add(
                new Car
                {
                    Name = "T",
                    ModelYear = 2023,
                    BrandId = 9,
                    ColorId = 4,
                    DailyPrice = 1399,
                    Description = "Yerli ve Milli elektrikli araç"
                });

            Console.WriteLine(addResult.Message);

            List<Car> cars = carManager.GetAll().Data;
            foreach (var car in cars)
            {
                Console.WriteLine("{0}: {1}", car.Name, car.Description);
            }


            var carToUpdate = carManager.GetById(16);
            if (carToUpdate.Success)
            {
                Car car1 = carToUpdate.Data;
                Console.WriteLine("{0} numaralı araç {1} {2}", car1.CarId, car1.Name, car1.ColorId);
                car1.ColorId = 3;
                var updateResult = carManager.Update(car1);
                Console.WriteLine(updateResult.Message);
                Console.WriteLine("{0} numaralı araç {1} {2}", car1.CarId, car1.Name, car1.ColorId);
            }
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var detail in result.Data)
                {
                    Console.WriteLine("{0} {1} {2} {3}TL", detail.BrandName, detail.CarName, detail.ColorName, detail.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
