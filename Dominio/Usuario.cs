using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EDL.Dominio
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public DateTime DataHora { get; set; }

        public string Erro { get; set; }
    }
}
