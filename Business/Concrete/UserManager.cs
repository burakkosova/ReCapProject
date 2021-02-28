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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length>2 && user.LastName.Length > 2 && user.Email.Length > 2 && user.Password.Length > 2)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            return new ErrorResult(Messages.InvalidUser);
        }

        public IResult Delete(User user)
        {
            if (_userDal.Get(u => u.UserId == user.UserId) == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            if (_userDal.Get(u => u.UserId == userId) == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            if (_userDal.Get(u => u.UserId == user.UserId) == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
