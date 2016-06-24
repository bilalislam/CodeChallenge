using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallange.Entity;
using CodeChallenge.Data.CoreRepository;

namespace CodeChallenge.Data.UserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public int GetTotalCount()
        {
            return (Context as CodeKataEntities).GetTotalCount().First().Value;
        }
    }

    public interface IUserRepository
    {
        int GetTotalCount();
    }
}
