namespace Repo_Layer.Repositry
{
    public interface IRepository<T>
    {
        string ServiceId { get; set; }
        List<T> GetAll(string includes = null);
        T Get(int id);
        void Update(T cat);
        void Insert(T cat);
        void Delete(int id);
        //void Save();
    }
}
