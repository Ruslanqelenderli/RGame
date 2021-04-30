using MvcFinalApp.DAL.Repository;
using MvcFinalApp.Models.RGameModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcFinalApp.DAL.Services
{
    public class CategoryService : IOperationRepository<Category>
    {
        private readonly RGameDbContext _rGameDbContext;
        public CategoryService(RGameDbContext rGameDbContext)
        {
            _rGameDbContext = rGameDbContext;
        }
        public void Add(Category proj)
        {
            _rGameDbContext.Categories.Add(proj);
        }

        public void Delete(int id)
        {
            var proj = _rGameDbContext.Categories.FirstOrDefault(x => x.Id == id);
            _rGameDbContext.Entry(proj).State = EntityState.Deleted;
            _rGameDbContext.SaveChanges();
        }

        public List<Category> GetAll()
        {
            var getAll = _rGameDbContext.Categories.ToList();
            return getAll;
        }

        public Category GetById(int id)
        {
            var getById = _rGameDbContext.Categories.FirstOrDefault(x => x.Id == id);
            return getById;
        }

        public void Update(Category proj)
        {
            _rGameDbContext.Entry(proj).State = EntityState.Modified;
            _rGameDbContext.SaveChanges();
        }
    }
}