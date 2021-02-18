using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Name.Length < 2)
            {
                return new ErrorResult(Messages.InvalidCarName);
            }

            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.InvalidDailyPrice);
            }

            _carDal.Add(car);
            return new SuccesResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            if (_carDal.Get(c => c.CarId == car.CarId) == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }
            else
            {
                _carDal.Delete(car);
                return new SuccesResult(Messages.CarDeleted);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            // Business Logic
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            if (_carDal.Get(c => c.CarId == id) == null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            else
            {
                return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
            }
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update(Car car)
        {
            if (_carDal.Get(c => c.CarId == car.CarId) == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }
            else
            {
                _carDal.Update(car);
                return new SuccesResult(Messages.CarUpdated);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
