using Astrow_Domain.DBContext;
using Astrow_Domain.Models;
using Astrow_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Services.Services
{
    public class GenericCrud : IGenericCrud
    {
        private readonly Astrow_DomainContext _dbcontext;
        public GenericCrud(Astrow_DomainContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async void Create<User>(User userid)
        {
            _dbcontext.Add(userid);
            await _dbcontext.SaveChangesAsync();
        }
        public async void Update<User>(User userid)
        {
            _dbcontext.ChangeTracker.Clear();
            _dbcontext.UpdateRange(userid);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<User> GetUserById<User>(Guid userid) where User : class
        {
            return _dbcontext.Set<User>().Find(userid);
        }
        public async void Delete<User>(User id)
        {
            _dbcontext.Remove(id);
            await _dbcontext.SaveChangesAsync();
        }
    }
        
}
    

