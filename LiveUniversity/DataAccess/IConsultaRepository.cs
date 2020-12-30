using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveUniversity.DataAccess
{
    public interface IConsultaRepository<Tmodel>
    {
        Tmodel Obter(long cod);
        IEnumerable<Tmodel> Obter();
    }

}
