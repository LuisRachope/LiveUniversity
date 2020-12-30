using LiveUniversity.Business;
using LiveUniversity.Business.Dto;
using LiveUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace LiveUniversity.Controllers
{
    public class PessoaController : ApiController
    {
        const string ExternalUrl = "http://138.68.29.250:8082/";

        private static readonly HttpClient client = new HttpClient();

        // GET: Pessoa/Details/5
        public PessoaCriada Get(string codigogerado)
        {
            var codnome = ObterCodigo(codigogerado, "n", '_');
            var codsobrenome = ObterCodigo(codigogerado, "s", '_');
            var codemail = ObterCodigo(codigogerado, "e", '_');
            
            var business = new PessoaBusiness();
            var pessoaDto = business.Obter(codnome, codsobrenome, codemail);
            
            var pessoa = new PessoaCriada();
            pessoa.Email = pessoaDto.Email.Email;
            pessoa.Sobrenome = pessoaDto.Sobrenome.Sobrenome;
            pessoa.Nome = pessoaDto.Nome.Nome;
            pessoa.SomaEmail = pessoaDto.Email.Soma;
            pessoa.SomaSobrenome = pessoaDto.Sobrenome.Soma;
            pessoa.SomaNome = pessoaDto.Nome.Soma;
            return pessoa; 
        }

        // POST: Pessoa/Create
        [HttpPost]
        public void Post(Pessoa model)
        {
            if (model.CodigoGerado !="")
            {
                var pessoaDto = new PessoaDto();
                pessoaDto.Nome = new Business.Model.NomeModel()
                {
                    Nome = model.Nome,
                    Cod = ObterCodigo(model.CodigoGerado, "n", '#')
                };
                pessoaDto.Sobrenome = new Business.Model.SobrenomeModel(){ 
                    Sobrenome = model.Sobrenome, 
                    Cod = ObterCodigo(model.CodigoGerado, "s", '#')
                };
                pessoaDto.Email = new Business.Model.EmailModel(){
                    Email = model.Email,
                    Cod = ObterCodigo(model.CodigoGerado, "e", '#')
                };
                var business = new PessoaBusiness();
                business.Create(pessoaDto);
            }
        }
        public long ObterCodigo(string codigogerado, string tipo, char delimitador)
        {
            var array = codigogerado.Split(delimitador);
            var index = Array.IndexOf(array, tipo);
            return Convert.ToInt64(array[index + 1]);
        }
    }
}
