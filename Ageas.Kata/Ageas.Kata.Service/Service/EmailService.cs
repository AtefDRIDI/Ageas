using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ageas.Kata.BO;
using Ageas.Kata.Repository.IRepository;
using Ageas.Kata.Service.IService;

namespace Ageas.Kata.Service.Service
{
    public class EmailService : IEmailService
    {

        private readonly IUserRepository _userRepository;

        public EmailService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private void SendTemplatedEMail(User user)
        {
            // do send mail
        }

        public void SendTemplatedEMails(List<int> ids)
        {
            foreach (var item in ids)
            {
                try
                {
                    User user = _userRepository.GetById(item);
                    SendTemplatedEMail(user);
                }
                catch(Exception E1)
                {
                    throw new Exception(E1.Message);

                }
            }
        }

    }
}
