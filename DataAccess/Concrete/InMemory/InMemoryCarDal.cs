using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { Id=1, BrandId=2, ColorId=1, DailyPrice=150, Description="Fiat Egea", ModelYear=2018 }, 
                new Car { Id=2, BrandId=1, ColorId=3, DailyPrice=15000, Description="Lamborghini Huracan", ModelYear=2020}, 
                new Car { Id=3, BrandId=3, ColorId=5, DailyPrice=25000, Description="Pagani Huayra", ModelYear=2020}, 
                new Car { Id=4, BrandId=4, ColorId=5, DailyPrice=35000, Description="Rolls Royce Ghost", ModelYear=2019}, 
                new Car { Id=5, BrandId=5, ColorId=6, DailyPrice=2500, Description="Range Rover Velar", ModelYear=2018}, 
                new Car { Id=6, BrandId=6, ColorId=2, DailyPrice=650, Description="Volkswagen Passat", ModelYear=2017}, 
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            _cars.Remove(_cars.SingleOrDefault(c => c.Id == car.Id));
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
