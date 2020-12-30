using LiveUniversity.Business.Model;
using LiveUniversity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveUniversity.Business
{
    public class AnimalBusiness
    {
        public IEnumerable<AnimalModel> ObterTodos()
        {
            IConsultaRepository<AnimalModel> animalRepository = new AnimalRepository();
            return animalRepository.Obter();
        }
    }
}