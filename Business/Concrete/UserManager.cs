﻿using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Contents;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private EUserDal _userDal;
        public UserManager(EUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (_userDal.Add(user, "AddUser"))
            {
                return new SuccessResult(Messages.UserAddSuccess);
            }
            return new ErrorResult(Messages.UserAddFail);
        }

        public IResult Delete(User user)
        {
            if (_userDal.Delete(user, "DeleteUser"))
            {
                return new SuccessResult(Messages.UserDeleteSuccess);
            }
            return new ErrorResult(Messages.UserDeleteFail);
        }
        public IResult Delete(List<User> users)
        {
            return null;
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var user = _userDal.Get(email, "GetUserByEmail");
            if(user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return null;
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(userId, "GetUser"));
        }

        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList("GetAllUsers").ToList());
        }

        public List<OperationClaim> GetUserOperationClaims(User user)
        {
            return null;
        }

        public IResult Update(User user)
        {
            _userDal.Update(user, "UpdateUser");
            return new SuccessResult(Messages.UserUpdateSuccess);
        }
    }
}
