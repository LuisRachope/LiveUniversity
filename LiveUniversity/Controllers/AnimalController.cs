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
    public class AnimalController : ApiController
    {
        // GET: api/Animal
        public IEnumerable<Animal> Get()
        {
            var animalBusiness = new AnimalBusiness();
            var animais = animalBusiness.ObterTodos().Select(x => new Animal()
            {
                Id = x.Id,
                Nome = x.Animal,
                Total = x.Total,
            });
            return animais;
        }

    }
}
