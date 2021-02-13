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
            //DtoTest();
            RentalTest();
        }

        private static void RentalTest()
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Burak", LastName = "Kosova", Email = "burak.kosova@hotmail.com", Password = "123456" });
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customerAddResult = customerManager.Add(new Customer { CompanyName = "Kosova Enterprise", UserId = 1 });
            Console.WriteLine(customerAddResult.Message);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental { CarId = 5, CustomerId = 1, RentDate = new DateTime(2021, 02, 13, 18, 17, 53)});
            Console.WriteLine(result.Message);

            var rentalToUpdate = rentalManager.GetById(4).Data;
            rentalToUpdate.ReturnDate = new DateTime(2021, 02, 13, 18, 30, 53);
            rentalManager.Update(rentalToUpdate);

            var rentResult = rentalManager.Add(new Rental { CarId = 5, CustomerId = 1, RentDate = new DateTime(2021, 02, 13, 18, 45, 53) });
            Console.WriteLine(rentResult.Message);

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Car ID: {0} Customer ID: {1} RentDate: {2}, ReturnData: {3}",rental.CarId,rental.CustomerId,rental.RentDate,rental.ReturnDate);
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
                Console.WriteLine("{0}: {1}", color.Id, color.Name);
            }

            Console.WriteLine();
            var getByIdResult = colorManager.GetById(25);
            if (getByIdResult.Success)
            {
                Color color1 = getByIdResult.Data;
                Console.WriteLine("5: {0}", color1.Name);
                color1.Name = "Gece yarısı mavisi";

                var updateResult = colorManager.Update(color1);
                Console.WriteLine(updateResult.Message);
                Console.WriteLine("5: {0}", color1.Name);
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
                Console.WriteLine("{0}: {1}", brand.Id, brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var addResult = carManager.Add(
                new Car
                {
                    Name = "Tıo",
                    ModelYear = 2023,
                    BrandId = 13,
                    ColorId = 4,
                    DailyPrice = 0,
                    Description = "Yerli ve Milli elektrikli araç"
                });

            Console.WriteLine(addResult.Message);

            List<Car> cars = carManager.GetAll().Data;
            foreach (var car in cars)
            {
                Console.WriteLine("{0}: {1}", car.Name, car.Description);
            }


            var carToUpdate = carManager.GetById(16).Data;
            Console.WriteLine();
            Console.WriteLine("16 numaralı araç {0} {1}", carToUpdate.Name, carToUpdate.ColorId);
            carToUpdate.ColorId = 11;
            var updateResult = carManager.Update(carToUpdate);
            Console.WriteLine(updateResult.Message);
            Console.WriteLine("13 numaralı araç {0} {1}", carToUpdate.Name, carToUpdate.ColorId);
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var detail in result.Data)
                {
                    Console.WriteLine("{0} marka {1} aracı {2} renkte ve günlük fiyatı {3}$", detail.BrandName, detail.CarName, detail.ColorName, detail.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
