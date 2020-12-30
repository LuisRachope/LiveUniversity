using LiveUniversity.Business.Model;
using LiveUniversity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveUniversity.Business
{
    public class CorBusiness
    {
        public IEnumerable<CorModel> ObterTodos()
        {
            IConsultaRepository<CorModel> corRepository = new CorRepository();
            return corRepository.Obter();
        }
    }
}