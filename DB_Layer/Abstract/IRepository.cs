using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Layer.Abstract
{
    public interface IRepository<T>
    {     
        IEnumerable<T> GetAll();   
    }
}
