using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ageas.Kata.BO;
using Ageas.Kata.Service.IService;

namespace Ageas.Kata.Service.Service
{
    public class UserServiceMock : IUserService
    {
        

        public void DeleteUsers(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            List<User> userList = new List<User>();
            userList.Add(new User { Id = 1, FirstName = "Atef", LastName = "Dridi", Adress = "Paris", Approuve = "A" });
            userList.Add(new User { Id = 2, FirstName = "Antoine", LastName = "Simon", Adress = "Paris", Approuve = "A" });
            userList.Add(new User { Id = 3, FirstName = "Jule", LastName = "Dupon", Adress = "Nante",  });
            userList.Add(new User { Id = 4, FirstName = "Sophia", LastName = "Dupon", Adress = "marseille", });


            return userList;
        }


        public List<User> ApprouveUsersMock (List<int> ids)
        {
            List<User> userListNew = new List<User>();

            foreach (var curentuser in GetAll() )
            {
                User user = new User();
                user = curentuser;

                foreach (var item in ids)
                {
                    if (user.Id ==  item)
                        user.Approuve = "A";
                }

                userListNew.Add(user);

            }
               
         
            return userListNew;



        }

        void IUserService.ApprouveUsers(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
