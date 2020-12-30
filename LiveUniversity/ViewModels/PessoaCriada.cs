using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveUniversity.ViewModels
{
    public class PessoaCriada
    {
        public string Nome { get; set; }
        public int SomaNome { get; set; }
        public string Sobrenome { get; set; }
        public int SomaSobrenome { get; set; }
        public string Email { get; set; }
        public long SomaEmail { get; set; }
        public string CodigoGerado { get; set; }
        public long SomaTotal { get { return SomaNome + SomaSobrenome + SomaEmail; } }
    }
}