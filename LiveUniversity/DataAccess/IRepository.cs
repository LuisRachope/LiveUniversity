using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveUniversity.DataAccess
{
    public interface IRepository<Tmodel>
    {
        void Create(Tmodel Model);
    }
}