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
    public class CorController : ApiController
    {
        // GET: api/Cor
        public IEnumerable<Cor> Get()
        {
            var corBusiness = new CorBusiness();
            var cores = corBusiness.ObterTodos().Select(x => new Cor()
            {
                Id = x.Id,
                Nome = x.Cor,
                Total = x.Total,
            });
            return cores;
        }
    }
}
