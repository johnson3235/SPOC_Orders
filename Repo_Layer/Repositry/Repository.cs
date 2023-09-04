using Microsoft.EntityFrameworkCore;
using DB_Layer.Models;
using Repo_Layer.UnitOfWork;

namespace Repo_Layer.Repositry
{

    public class Repository<T> : IRepository<T> where T : class
    {


        private readonly DataDbContext context;

        public string ServiceId { get; set; }

        public Repository(DataDbContext context)
        {
            this.context = context;
        }


        public void Delete(int id)
        {
            context.Remove(Get(id));
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }


        public List<T> GetAll(string includes = null)
        {
            return includes != null ? context.Set<T>().Include(includes).ToList() : context.Set<T>().ToList();
        }

        public void Insert(T obj)
        {
            context.Add(obj);
        }

        //public void Save()
        //{
        //    context.SaveChanges();
        //}

        public void Update(T obj)
        {
            context.Update(obj);
        }
    }
}
