using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregavel_POO_2_
{
    class Reserva
    {
        public Pessoa Hospede {  get; set; }
        public Suite Suite { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

       
    }
}
