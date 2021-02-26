using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Business;
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
            IResult result = BusinessRules.Run(CheckIfBrandNameExists(brand.Name));
            if (result != null)
            {
                return result;
            }

            _brandDal.Add(brand);
            return new SuccesResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            IResult result = CheckIfBrandExists(brand.BrandId);
            if (!result.Success)
            {
                return result;
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
            IResult result = CheckIfBrandExists(id);
            if (!result.Success)
            {
                return new ErrorDataResult<Brand>(result.Message);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            IResult result = CheckIfBrandExists(brand.BrandId);
            if (!result.Success)
            {
                return result;
            }

            _brandDal.Update(brand);
            return new SuccesResult(Messages.BrandUpdated);
        }

        private IResult CheckIfBrandNameExists(string brandName)
        {
            if (_brandDal.Get(b => b.Name.ToLower() == brandName.ToLower()) != null)
            {
                return new ErrorResult(Messages.BrandAlreadyExists);
            }

            return new SuccesResult();
        }
        
        private IResult CheckIfBrandExists(int brandId)
        {
            if (_brandDal.Get(b => b.BrandId == brandId) == null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
            return new SuccesResult();
        }
    }
}
