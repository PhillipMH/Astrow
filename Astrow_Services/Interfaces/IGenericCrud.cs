﻿using Astrow_Domain.Models;

namespace Astrow_Services.Interfaces
{
    public interface IGenericCrud
    {
        void Create<User>(User user); 
        Task<User> GetUserById<User>(Guid userid) where User : class;
        void Update<User>(User userid);
        void Delete<User>(User unilogin);
    }
}