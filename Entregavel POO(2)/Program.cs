using System;
using System.Threading.Channels;

namespace Entregavel_POO_2_
{
    class Program
    {
        static List<Pessoa> pessoas = new List<Pessoa>();
        static List<Suite> suites = new List<Suite>();

        static void Main(string[] args)
        {
            bool sair = false;
            do
            {
                Console.WriteLine("MENU: ");
                Console.WriteLine("1. Cadastro");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Listar");
                Console.WriteLine("4. Sair");
                Console.WriteLine("Escolha uma opção (Num): ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MenuCadastrar();
                        break;
                    case "2":
                        MenuConsultas();
                        break;
                    case "3":
                        MenuListar();
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente");
                        break;
                }
            } while (!sair) ;
        }
        static void MenuCadastrar()
        {
            Console.WriteLine("CADASTRO:");
            Console.WriteLine("1. Suíte"); 
            Console.WriteLine("2. Hóspede");
            Console.WriteLine("3. Sair");
            Console.WriteLine("Escolha uma opção (Num): ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastroSuite();
                    break;
                case "2":
                    CadastroHospede();
                    break;
                case "3":
                    Console.WriteLine("Finalizando o programa...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opa, tivemos algum erro. Vamos de novo?");
                    break;


            }
        }
        static void CadastroHospede()
        {
            Console.WriteLine("CADASTRO DE HÓSPEDE:");
            Pessoa pessoa = new Pessoa();
            Console.WriteLine("Nome: ");
            pessoa.Nome = Console.ReadLine();
            Console.WriteLine("Idade: ");
            pessoa.Idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Sexo: ");
            pessoa.Genero = Console.ReadLine();
            Console.WriteLine("Profissão: ");
            pessoa.Profissao = Console.ReadLine();
            Console.WriteLine("Escolha a sua súite: ");

            foreach (var suite in suites)
            {
                Console.WriteLine($"{suites.IndexOf(suite) + 1}. Capacidade: {suite.Capacidade}, Valor da diária: {suite.Diaria:C}");
            }

            int SuiteIndice = int.Parse(Console.ReadLine()) - 1;
            pessoa.Suite = suites[SuiteIndice];
            Console.WriteLine("Quando será o inicio da estadia?: (DD/MM/YYYY)");
            pessoa.Inicio = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("E até qual dia pretende ficar?: (DD/MM/YYYY)");
            pessoa.Fim = DateTime.Parse(Console.ReadLine());
             


            Reserva reserva = new Reserva()
            {
                Hospede = pessoa,
                Suite = pessoa.Suite,
                Inicio = pessoa.Inicio,
                Fim = pessoa.Fim,
            };

            pessoa.ValorDiaria();

            pessoa.Dados();

            pessoas.Add(pessoa);
        }
        static void CadastroSuite()
        {
            Console.WriteLine("CADASTRO DE SUÍTES");
            Console.WriteLine("Capacidade: ");
            int capacidade = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor da diária: ");
            decimal Diaria = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Número da suíte: ");
            int num = int.Parse(Console.ReadLine());

            Suite suite = new Suite(num, capacidade, Diaria, true);

            suites.Add(suite);
        }
        static void MenuConsultas()
        {
            Console.WriteLine("CONSULTAR");
            Console.WriteLine("1. Hospede");
            Console.WriteLine("2. Suíte");
            Console.WriteLine("3. Sair");
            Console.WriteLine("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ConsultaHospede();
                    break;
                case "2":
                    ConsultaSuites();
                    break;
                case "3":
                    Console.WriteLine("Finalizando o programa...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opa, digitou algo errado hein. Tente novamente.");
                    break;


            }
        }
        static void ConsultaHospede()
        {
            Console.WriteLine("CONSULTA DE HÓSPEDES");
            Console.WriteLine("Nome do Hóspede: ");
            string nome = Console.ReadLine();
            Pessoa pessoa = pessoas.Find(p => p.Nome == nome);
            if (pessoa != null)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}");
                Console.WriteLine($"Idade: {pessoa.Idade}");
                Console.WriteLine($"Sexo: {pessoa.Genero}");
                Console.WriteLine($"Profissão: {pessoa.Profissao}");
                Console.WriteLine($"Suite: {pessoa.Suite.Capacidade} pessoas, Valor da Diária: {pessoa.Suite.Diaria:C}");
                Console.WriteLine($"Data Início da Reserva: {pessoa.Inicio.ToShortDateString()}");
                Console.WriteLine($"Data Fim da Reserva: {pessoa.Fim.ToShortDateString()}");
                Console.WriteLine($"Valor Total da Diária: {pessoa.TotalDiaria:C}");
            }
            else
            {
                Console.WriteLine("Cuidado na digitação chefia, o hóspede não foi encontrado.");
            }
        }

        static void ConsultaSuites()
        {
            Console.WriteLine("CONSULTA SUÍTES");
            Console.WriteLine("Qual a suíte que deseja consultar?: ");
            int SuiteNum = int.Parse(Console.ReadLine());

            Suite suiteValida = suites.Find(Suite => Suite.Num == SuiteNum);
            if (suiteValida != null)
            {
                Console.WriteLine($"Capacidade: {suiteValida.Capacidade}");
                Console.WriteLine($"Valor da Diária: {suiteValida.Diaria:C}");
                Console.WriteLine($"Disponível: {suiteValida.Disponivel}");
            }
            else
            {
                Console.WriteLine($"Suíte não encontrada.");
            }
        }


        static void MenuListar()
        {
            Console.WriteLine("LISTAR");
            Console.WriteLine("1. Hóspedes");
            Console.WriteLine("2. Suítes");
            Console.WriteLine("3. Sair");
            Console.WriteLine("Escolha uma das opções");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ListarHospedes();
                    break;
                case "2":
                    ListarSuites();
                    break;
                case "3":
                    Environment.Exit(0);
                    Console.WriteLine("Finalizando o programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente");
                    break;


            }
        }
        static void ListarHospedes()
        {
            Console.WriteLine("Listagem de Hóspedes:");
            foreach (var pessoa in pessoas)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}, Suíte: {pessoa.Suite.Capacidade} pessoas, Valor da Diária: {pessoa.Suite.Diaria:C}");
            }
        }
        static void ListarSuites()
        {
            Console.WriteLine("Listagem de Suítes:");
            foreach (var suite in suites)
            {
                Console.WriteLine($"Capacidade: {suite.Capacidade}, Valor da Diária: {suite.Diaria:C}");
            }
        }
    }
}
