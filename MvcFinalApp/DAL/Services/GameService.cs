using MvcFinalApp.DAL.Repository;
using MvcFinalApp.Models.RGameModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcFinalApp.DAL.Services
{
    public class GameService : IOperationRepository<Game>
    {
        private readonly RGameDbContext _rGameDbContext;
        public GameService(RGameDbContext rGameDbContext)
        {
            _rGameDbContext = rGameDbContext;
        }
        public void Add(Game proj)
        {
            _rGameDbContext.Games.Add(proj);
        }

        public void Delete(int id)
        {
            var proj = _rGameDbContext.Categories.FirstOrDefault(x => x.Id == id);
            _rGameDbContext.Entry(proj).State = EntityState.Deleted;
            _rGameDbContext.SaveChanges();
        }

        public List<Game> GetAll()
        {
            var getAll = _rGameDbContext.Games.ToList();
            return getAll;
        }

        public Game GetById(int id)
        {
            var getById = _rGameDbContext.Games.FirstOrDefault(x => x.Id == id);
            return getById;
        }

        public void Update(Game proj)
        {
            _rGameDbContext.Entry(proj).State = EntityState.Modified;
            _rGameDbContext.SaveChanges();
        }
    }
}