using HBSIS.Entity.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Entity.Model
{
    public class Usuario : IEntity
    {
        public int Id_Usuario { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string Telefone { get; set; }
    }
}
