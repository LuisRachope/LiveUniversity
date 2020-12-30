using LiveUniversity.Business.Dto;
using LiveUniversity.Business.Model;
using LiveUniversity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace LiveUniversity.Business
{
    public class PessoaBusiness
    {
        public void Create(PessoaDto Pessoa)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                IRepository<NomeModel> nomeRepository = new NomeRepository();
                nomeRepository.Create(Pessoa.Nome);

                IRepository<SobrenomeModel> sobrenomeRepository = new SobrenomeRepository();
                sobrenomeRepository.Create(Pessoa.Sobrenome);

                IRepository<EmailModel> emailRepository = new EmailRepository();
                emailRepository.Create(Pessoa.Email);

                scope.Complete();
            }
        }

        public PessoaDto Obter(long codnome, long codsobrenome, long codemail)
        {
            var pessoaDto = new PessoaDto();
            IConsultaRepository<NomeModel> nomeRepository = new NomeRepository();
            pessoaDto.Nome = nomeRepository.Obter(codnome);

            IConsultaRepository<SobrenomeModel> sobrenomeRepository = new SobrenomeRepository();
            pessoaDto.Sobrenome = sobrenomeRepository.Obter(codsobrenome);

            IConsultaRepository<EmailModel> emailRepository = new EmailRepository();
            pessoaDto.Email = emailRepository.Obter(codemail);

            return pessoaDto;
        }
    }
}