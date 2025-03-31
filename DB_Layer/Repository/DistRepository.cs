using DB_Layer.AppContext;
using DB_Layer.Base;
using DB_Layer.Models;

namespace DB_Layer.Repository
{
    public class DistRepository : EntityFrameworkRepository<DistModel>
    {
        public DistRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
