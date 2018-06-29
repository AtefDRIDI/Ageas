using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Ageas.Kata.BO;
using Ageas.Kata.Repository.IRepository;
using Ageas.Kata.Service.IService;

namespace Ageas.Kata.Service.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUsers(List<int> ids)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in ids)
                    {

                        _userRepository.Delete(item);
                        _userRepository.Save();

                    }
                    Trans.Complete();
                }

                catch (Exception E1)
                {
                    throw new Exception(E1.Message);

                }
            }
              

        }

        public void  ApprouveUsers(List<int> ids)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in ids)
                    {
                        var user = _userRepository.GetById(item);
                        user.Approuve= "A";
                        _userRepository.Update(user);
                        _userRepository.Save();
                    }
                    Trans.Complete();

                }
                catch (Exception E1)
                {
                    throw new Exception(E1.Message);

                }
            }
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public List<User> ApprouveUsersMock(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
