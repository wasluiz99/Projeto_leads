namespace ProjetoLeads.Interface
{
    public interface IGeral<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        void DeleteById(int id);
        void DeleteAll();
        void SaveChanges();

    }
}
