using Astrow_Domain.DBContext;
using Astrow_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astrow_Domain.Repositories
{
    public class GenericCrud : IGenericCrud
    {
        private readonly Astrow_DomainContext _dbcontext;
        public GenericCrud(Astrow_DomainContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Create<User>(User hello)
        {
            _dbcontext.Add(hello);
            _dbcontext.SaveChanges();
        }
        public void Update<User>(User hello)
        {
            _dbcontext.ChangeTracker.Clear();
            _dbcontext.UpdateRange(hello);
            _dbcontext.SaveChanges();
        }
        public Teachers GetTeacherById(Guid id) 
        {
        return _dbcontext.Teachers.Find(id);
        }
        public void Delete<User>(User id)
        {
            _dbcontext.Remove(id);
            _dbcontext.SaveChanges();
        }
    }
}
