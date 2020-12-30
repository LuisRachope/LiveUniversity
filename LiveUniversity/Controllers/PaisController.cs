using LiveUniversity.Business;
using LiveUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LiveUniversity.Controllers
{
    public class PaisController : ApiController
    {
        // GET: api/Pais
        public IEnumerable<Pais> Get()
        {
            var paisBusiness = new PaisBusiness();
            var paises = paisBusiness.ObterTodos().Select(x => new Pais()
            {
                Id = x.Id,
                Nome = x.Pais,
                Total = x.Total,
            });
            return paises;
        }
    }
}
