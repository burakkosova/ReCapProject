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
            // Business Logic
            _carDal.Add(car);
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
            return _carDal.GetById(id);
        }

        public void Update(Car car)
        {
            // Business Logic
            _carDal.Update(car);
        }
    }
}
