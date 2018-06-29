using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ageas.Kata.BO;

namespace Ageas.Kata.Service.IService
{
    public interface IUserService
    {
        void DeleteUsers(List<int> ids);
        void ApprouveUsers(List<int> ids);
        List<User> ApprouveUsersMock(List<int> ids);
        IEnumerable<User> GetAll();
    }
}
