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
            if (_rentalDal.Get(r => r.Id == rentalId) == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
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
