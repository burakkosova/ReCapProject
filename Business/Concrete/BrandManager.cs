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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if(_brandDal.Get(b => b.Name.ToUpper() == brand.Name.ToUpper()) != null)
            {
                return new ErrorResult(Messages.BrandAlreadyExists);
            }
            _brandDal.Add(brand);
            return new SuccesResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (_brandDal.Get(b => b.BrandId == brand.BrandId) == null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }

            _brandDal.Delete(brand);
            return new SuccesResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            if (_brandDal.Get(b => b.BrandId == id) == null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            if (_brandDal.Get(b => b.BrandId == brand.BrandId) == null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }

            _brandDal.Update(brand);
            return new SuccesResult(Messages.BrandUpdated);
        }
    }
}
