using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ageas.Kata.Repository.IRepository;
using Ageas.Kata.Repository.Repository;
using Ageas.Kata.Service.IService;
using Ageas.Kata.Service.Service;
using Autofac;
using Autofac.Integration.Mvc;

namespace Ageas.Kata.Client.Helper
{
    public class BootStrapper
    {
        public static void RunConfig()
        {
            BuildAutoFac();
        }
     
        private static void BuildAutoFac()
        {
            int test = 1;
            var builder = new ContainerBuilder();
          
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            if (test == 0)
            {
                builder.RegisterType<UserService>().As<IUserService>();

            }
            else
            {
                builder.RegisterType<UserServiceMock>().As<IUserService>();
            }
              

            builder.RegisterControllers(typeof(MvcApplication).Assembly);



            var container = builder.Build();

            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}