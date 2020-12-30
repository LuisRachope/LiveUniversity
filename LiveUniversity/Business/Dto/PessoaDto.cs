using LiveUniversity.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveUniversity.Business.Dto
{
    public class PessoaDto
    {
        public NomeModel Nome { get; set; }
        public SobrenomeModel Sobrenome { get; set; }
        public EmailModel Email { get; set; }
    }
}