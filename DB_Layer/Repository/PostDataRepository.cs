using DB_Layer.Abstract;
using DB_Layer.AppContext;
using Microsoft.EntityFrameworkCore;

namespace DB_Layer.Repository
{
    public class PostDataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _context;
        public PostDataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int UploadData()
        {
            try
            {
               _context.Database.ExecuteSqlRaw("CALL Upload_AUP()");
               return 0;
            }
            
            catch (Exception e)
            {
                throw;
            }
}
    }
}
