﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegisterDto userRegisterDto);
        IDataResult<User> Login(UserLoginDto userLoginDto);
        IResult userExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
