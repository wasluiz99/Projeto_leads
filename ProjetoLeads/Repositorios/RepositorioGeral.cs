using Microsoft.EntityFrameworkCore;
using ProjetoLeads.Interface;
using ProjetoLeads.Models;

namespace ProjetoLeads.Repositorios
{
    public class RepositorioGeral<T> : IGeral<T>, IDisposable where T : class
    {
        private TesteContext _context;
        public bool _SaveChanges = true;

        public RepositorioGeral(bool saveChanges = true)
        {
            _SaveChanges = saveChanges;
            _context = new TesteContext();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Create(T entity)
        {
            _context.Add(entity);

            if (_SaveChanges)
            {
                _context.SaveChanges();
            }

            return entity;
        }

        public T Update(T entity)
        {
            _context.Update(entity);

            if (_SaveChanges)
            {
                _context.SaveChanges();
            }

            return entity;
        }

        public void DeleteById(int id)
        {
            var entityToDelete = _context.Set<T>().Find(id);

            if (entityToDelete != null)
            {
                _context.Remove(entityToDelete);

                if (_SaveChanges)
                {
                    _context.SaveChanges();
                }
            }

        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
