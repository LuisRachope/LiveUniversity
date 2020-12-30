using LiveUniversity.Business.Model;
using LiveUniversity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveUniversity.Business
{
    public class PaisBusiness
    {
        public IEnumerable<PaisModel> ObterTodos()
        {
            IConsultaRepository<PaisModel> paisRepository = new PaisRepository();
            return paisRepository.Obter();
        }
    }
}