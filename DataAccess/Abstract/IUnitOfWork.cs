﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork 
    {
        IContactDal Contacts { get; }
        IGroupDal Groups { get; }
        IGroupContactDal GroupsContacts { get; }
        IUserDal Users { get; }
    }
}
