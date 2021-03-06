﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { BrandId=2, ColorId=1, DailyPrice=150, Description="Fiat Egea", ModelYear=2018 }, 
                new Car { BrandId=1, ColorId=3, DailyPrice=15000, Description="Lamborghini Huracan", ModelYear=2020}, 
                new Car { BrandId=3, ColorId=5, DailyPrice=25000, Description="Pagani Huayra", ModelYear=2020}, 
                new Car { BrandId=4, ColorId=5, DailyPrice=35000, Description="Rolls Royce Ghost", ModelYear=2019}, 
                new Car { BrandId=5, ColorId=6, DailyPrice=2500, Description="Range Rover Velar", ModelYear=2018}, 
                new Car { BrandId=6, ColorId=2, DailyPrice=650, Description="Volkswagen Passat", ModelYear=2017}, 
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            _cars.Remove(_cars.SingleOrDefault(c => c.CarId == car.CarId));
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
