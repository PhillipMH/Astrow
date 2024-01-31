using Astrow_Domain.Models;

namespace Astrow_Domain.Repositories
{
    public interface IGenericCrud
    {
        void Create<User>(User hello);
        void Update<User>(User hello);
        Teachers GetTeacherById(Guid id);
        void Delete<User>(User id);
    }
}