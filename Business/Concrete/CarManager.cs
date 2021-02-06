using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Name.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception("Araba ismi 2 karakterden uzun ve günlük fiyatı 0'dan büyük olmalıdır.");
            }
        }

        public void Delete(Car car)
        {
            // Business Logic
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            // Business Logic
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            // Business Logic
            return _carDal.Get(c => c.Id == id);
        }

        public List<Car> GetByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            // Business Logic
            _carDal.Update(car);
        }
    }
}
