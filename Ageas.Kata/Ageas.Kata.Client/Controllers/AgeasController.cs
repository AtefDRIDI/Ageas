using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ageas.Kata.BO;
using Ageas.Kata.Service.IService;

namespace Ageas.Kata.Client.Controllers
{
    public class AgeasController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AgeasController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }


        public ActionResult Index()
        {
            IEnumerable<User> user = _userService.GetAll().ToList();


            return View(user);
        }


        

        [HttpPost]
        public ActionResult DeleteUsers(List<int> Ids)
        {
            try
            {

                _userService.DeleteUsers(Ids);
                IEnumerable<User> user = _userService.GetAll().ToList();
                return PartialView("pv_users", user);

            }
            catch (Exception )
            {
                IEnumerable<User> user = _userService.GetAll().ToList();
              
                return PartialView("pv_users", user);
            }

        }

        [HttpPost]

        public ActionResult SendEmails(List<int> Ids)
        {

            try
            {
                _emailService.SendTemplatedEMails(Ids);

                IEnumerable<User> user = _userService.GetAll().ToList();
                return PartialView("pv_users", user);

            }
            catch (Exception)
            {

                IEnumerable<User> user = _userService.GetAll().ToList();
                return PartialView("pv_users", user);
            }

        }

        [HttpPost]
        public ActionResult ApprouveUsers(List<int> Ids)
        {
            try
            {

                _userService.ApprouveUsers(Ids);
                IEnumerable<User> user = _userService.GetAll().ToList();
                return PartialView("pv_users", user);

            }
            catch (Exception)
            {
                IEnumerable<User> user = _userService.GetAll().ToList();

                return PartialView("pv_users", user);
            }

        }


        [HttpPost]
        public ActionResult ApprouveUsersMock(List<int> Ids)
        {
            try
            {


                IEnumerable<User> user = _userService.ApprouveUsersMock(Ids);
                return PartialView("pv_users", user);

            }
            catch (Exception)
            {
                IEnumerable<User> user = _userService.GetAll().ToList();

                return PartialView("pv_users", user);
            }

        }



    }
}