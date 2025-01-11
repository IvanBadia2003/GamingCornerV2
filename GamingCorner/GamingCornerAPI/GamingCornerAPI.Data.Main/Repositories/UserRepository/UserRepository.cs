using GamingCornerAPI.Domain.Entities;
using GamingCornerAPI.Domain.Main;
using GamingCornerAPI.Domain.Main.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCornerAPI.Data.Main.Repositories.UserRepository
{
    public class UsuarioRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public void Add(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetBySpec(Specification<Usuario> specification)
        {
            var query = _context.Usuarios.AsQueryable();
            return query.Where(specification.SatisfiedBy());
        }

    }

}
