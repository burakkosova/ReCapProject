using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccesResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            if (_carDal.Get(c => c.CarId == car.CarId) == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }
            _carDal.Delete(car);
            return new SuccesResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            // Business Logic
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(c => c.CarId == id);
            if (result == null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            return new SuccessDataResult<Car>(result, Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            var result = _carDal.GetAll(c => c.BrandId == id);
            if (result == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.BrandNotFound);
            }
            return new SuccessDataResult<List<Car>>(result, Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            var result = _carDal.GetAll(c => c.ColorId == id);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.ColorNotFound);
            }
            return new SuccessDataResult<List<Car>>(result, Messages.CarsListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            if (_carDal.Get(c => c.CarId == car.CarId) == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }
            _carDal.Update(car);
            return new SuccesResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            var result = _carDal.GetCarDetailsByColorId(colorId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ColorNotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetailsByBrandId(brandId);
            if (result.Count==0)
            {
                return new ErrorDataResult<List<CarDetailDto>>(result, Messages.BrandNotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result,Messages.CarsListed);
        }
    }
}
