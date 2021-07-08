﻿using Business.Abstract;
using Core.Utilities.Contents;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private EContactDal _contactDal;
        private EGroupDal _groupDal;
        public ContactManager(EContactDal contactDal, EGroupDal groupDal)
        {
            _contactDal = contactDal;
            _groupDal = groupDal;
        }

        public IResult Add(Contact contact)
        {
            if (_contactDal.Add(contact, "AddContact"))
            {
                return new SuccessResult(Messages.ContactAddSuccess);
            }
            return new ErrorResult(Messages.ContactAddFail);
        }

        public IResult Delete(int contact)
        {
            if (_contactDal.Delete(contact, "DeleteContact"))
            {
                return new SuccessResult(Messages.ContactDeleteSuccess);
            }
            return new ErrorResult(Messages.ContactDeleteFail);
        }

        public IResult Delete(List<int> contacts)
        {
            if (_contactDal.Delete(contacts, "DeleteContact"))
            {
                return new SuccessResult(Messages.ContactsDeleteSuccess);
            }
            return new ErrorResult(Messages.ContactDeleteFail);
        }

        public IDataResult<Contact> GetById(int contactId)
        {
            var contact = _contactDal.Get(contactId, "GetContact");
            if (contact != null)
            {
                return new SuccessDataResult<Contact>(contact);
            }
            return new ErrorDataResult<Contact>(Messages.ContactGetFail);
        }

        public IDataResult<List<Contact>> GetList()
        {
            try
            {
                var contactList = _contactDal.GetList("GetAllContacts").ToList();
                return new SuccessDataResult<List<Contact>>(contactList);
            }
            catch (ArgumentNullException)
            {
                return new ErrorDataResult<List<Contact>>(Messages.ContactGetListFail);
            }
        }
        public IDataResult<List<Contact>> GetList(int pageNumber, int pageSize)
        {
            return null;
        }

        public IDataResult<List<Contact>> GetListByUserId(int userId)
        {
            try
            {
                var contactList = _contactDal.GetList(userId, "UserId", "GetContactsByUserId").ToList();
                return new SuccessDataResult<List<Contact>>(contactList);
            }
            catch (ArgumentNullException)
            {
                return new ErrorDataResult<List<Contact>>(Messages.ContactGetListFail);
            }
        }

        public IDataResult<List<Group>> GetListByContactId(int contactId)
        {
            try
            {
                var contactGroupList = _groupDal.GetList(contactId, "ContactId", "GetGroupsOfAContact").ToList();
                return new SuccessDataResult<List<Group>>(contactGroupList);
            }
            catch (ArgumentNullException)
            {
                return new ErrorDataResult<List<Group>>(Messages.GetGroupsOfAContactFail);
            }
        }

        public IResult Update(Contact contact)
        {
            if (_contactDal.Update(contact, "UpdateContact"))
            {
                return new SuccessResult(Messages.ContactUpdateSuccess);
            }
            return new ErrorResult(Messages.ContactUpdateFail);
        }
    }
}
