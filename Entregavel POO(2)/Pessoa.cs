using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregavel_POO_2_
{
    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Genero { get; set; }
        public string Profissao { get; set; }
        public Suite Suite { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public decimal TotalDiaria { get; set; }

        public void Dados()
        {
            string Arquivo = $"{Nome}.txt";
            using (StreamWriter writer = new StreamWriter(Arquivo))
            {
                writer.WriteLine($"Nome: {Nome}");
                writer.WriteLine($"Idade: {Idade}");
                writer.WriteLine($"Gênero: {Genero}");
                writer.WriteLine($"Profissão: {Profissao}");
                writer.WriteLine($"Suíte: {Suite.Capacidade} pessoas, Valor da diária: {Suite.Diaria:C}");
                writer.WriteLine($"Ínicio da Estadia: {Inicio.ToShortDateString()}");
                writer.WriteLine($"Fim da Estadia: {Fim.ToShortDateString()}");
                writer.WriteLine($"Valor total da diária: {TotalDiaria:C}");
            }
        }
        public void ValorDiaria()
        {
            decimal Base = 150;

            TimeSpan duracao = Fim - Inicio;
            TotalDiaria = Base + int.Parse(duracao.TotalDays.ToString());
            if (duracao.TotalDays > 10)
            {
                TotalDiaria *= 0.9m;
            }
            else
            {
                TotalDiaria = Base + int.Parse(duracao.TotalDays.ToString()); 
            }
        }
        
    }
}
