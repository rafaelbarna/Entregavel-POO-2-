using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregavel_POO_2_
{
    class Suite
    {
        public int Num {  get; set; }
        public bool Disponivel { get; set; }
        public int Capacidade {  get; set; }
        public decimal Diaria { get; set; }

        public Suite(int num, int capacidade, decimal valorDiaria, bool disponivel)
        {
            Num = num;
            Capacidade = capacidade;
            Diaria = valorDiaria;
            Disponivel = disponivel;
        }

        public Suite() 
        {
        
        }
    }
}
