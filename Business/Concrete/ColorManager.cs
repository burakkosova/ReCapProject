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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (_colorDal.Get(c => c.Name.ToUpper() == color.Name.ToUpper()) != null)
            {
                return new ErrorResult(Messages.ColorAlreadyExists);
            }
            _colorDal.Add(color);
            return new SuccesResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            if (_colorDal.Get(c => c.ColorId == color.ColorId) == null)
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
            _colorDal.Delete(color);
            return new SuccesResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            if (_colorDal.Get(c => c.ColorId == id) == null)
            {
                return new ErrorDataResult<Color>(Messages.ColorNotFound);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        public IResult Update(Color color)
        {
            if (_colorDal.Get(c => c.ColorId == color.ColorId) == null)
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
            _colorDal.Update(color);
            return new SuccesResult(Messages.ColorUpdated);
        }
    }
}
