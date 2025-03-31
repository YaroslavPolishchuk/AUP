using DB_Layer.AppContext;
using DB_Layer.Base;
using DB_Layer.Models;

namespace DB_Layer.Repository
{
    public class AUPRepository : EntityFrameworkRepository<AddressInfo>
    {
        public AUPRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
