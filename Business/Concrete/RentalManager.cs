using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var carRentalList = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var carRental in carRentalList)
            {
                if (carRental.ReturnDate == null || carRental.ReturnDate > DateTime.Now)
                {
                    return new ErrorResult("Araç kiralanamaz çünkü başka bir müşteride ");
                }
            }
            _rentalDal.Add(rental);
            return new SuccesResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            if (_rentalDal.Get(r => r.Id == rental.Id) == null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }
            _rentalDal.Delete(rental);
            return new SuccesResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var rental = _rentalDal.Get(r => r.Id == rentalId);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }
            return new SuccessDataResult<Rental>(rental);
        }

        public IResult Update(Rental rental)
        {
            if (_rentalDal.Get(r => r.Id == rental.Id) == null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }
            _rentalDal.Update(rental);
            return new ErrorResult(Messages.RentalUpdated);
        }
    }
}
