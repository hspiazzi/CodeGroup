using PM.Domain.Model;
using PM.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PM.Repository.Concrete
{
    public class ProjetoRepository : IRepository<Projeto>
    {
        private readonly LocalDbContext _context;

        public ProjetoRepository(LocalDbContext context)
        {
            _context = context;
        }

        public Projeto GetById(int id)
        {
            return _context.Projetos.Find(id);
        }

        public IEnumerable<Projeto> GetAll()
        {
            return _context.Projetos.ToList();
        }

        public void Add(Projeto entity)
        {
            _context.Projetos.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Projeto entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Projeto entity)
        {
            _context.Projetos.Remove(entity);
            _context.SaveChanges();
        }
    }
}