﻿using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainModels.Models;

namespace DomainModels.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        private CalcContext context { get; set; }

        public UserRepository()
        {
            this.context = new CalcContext();
        }

        public User Create()
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public bool Valid(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
