using MvcFinalApp.DAL.Repository;
using MvcFinalApp.Models.ManageModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcFinalApp.DAL.Services
{
    public class UserService : IOperationRepository<User>
    {
        private readonly RGameDbContext _rGameDbContext;
        public UserService(RGameDbContext rGameDbContext)
        {
            _rGameDbContext = rGameDbContext;
        }
        public void Add(User proj)
        {
            
           _rGameDbContext.Users.Add(proj);
            _rGameDbContext.SaveChanges();




        }

        public void Delete(int id)
        {
            var proj = _rGameDbContext.Users.FirstOrDefault(x => x.Id == id);
            _rGameDbContext.Entry(proj).State = EntityState.Deleted;
            _rGameDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            var getAll = _rGameDbContext.Users.ToList();
            return getAll;
        }

        public User GetById(int id)
        {
            var getById = _rGameDbContext.Users.FirstOrDefault(x => x.Id == id);
            return getById;
        }

        public void Update(User proj)
        {
            _rGameDbContext.Entry(proj).State = EntityState.Modified;
            _rGameDbContext.SaveChanges();
        }
    }
}