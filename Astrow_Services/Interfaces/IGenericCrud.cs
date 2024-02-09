using Astrow_Domain.Models;

namespace Astrow_Services.Interfaces
{
    public interface IGenericCrud
    {
        void Create<User>(User id);
        User GetUserById<User>(Guid id) where User : class;
        void Update<User>(User userid);
        void Delete<User>(User id);
        Task<bool> GenericLogin(string username, string password);
    }
}