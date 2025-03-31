using DB_Layer.Abstract;
using DB_Layer.AppContext;
using Microsoft.EntityFrameworkCore;

namespace DB_Layer.Base
{
    public abstract class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityFrameworkRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
