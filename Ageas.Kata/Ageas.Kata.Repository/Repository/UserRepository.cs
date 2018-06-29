using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ageas.Kata.BO;
using Ageas.Kata.Repository.IRepository;

namespace Ageas.Kata.Repository.Repository
{
    public class UserRepository  : IUserRepository
    {
        private readonly AgeasDBEntities _context = new AgeasDBEntities();

        public IEnumerable<User> GetAll()
        {
            var test = _context.User.Select(x => x);
            return _context.User.Select(x => x);
            
        }

        public User GetById(int id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

        public User Get(System.Linq.Expressions.Expression<Func<User, bool>> expression)
        {
            return _context.User.FirstOrDefault(expression);
        }

        public IQueryable<User> GetMany(System.Linq.Expressions.Expression<Func<User, bool>> expression)
        {
            return _context.User.Where(expression);
        }

        public void Insert(User obj)
        {
            _context.User.Add(obj);
        }

        public void Update(User obj)
        {
            _context.User.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var Rol = GetById(id);
            if (Rol != null)
            {
                _context.User.Remove(Rol);
            }
        }

        public int Count()
        {
            return _context.User.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
