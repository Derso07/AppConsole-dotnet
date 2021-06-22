using System;
using DIO.Series.Classes;

namespace DIO.Times
{
    class Program
    {
        static TimeRepositorio repositorio = new TimeRepositorio();
        static void Main(string[] args)
        {
            string Resultado = ObterResultado();

            while(Resultado.ToUpper() != "X")
            {
                switch(Resultado)
                {
                    case "1":
                    ListaTimes();
                    break;
                    case "2":
                    InserirTime();
                    break;
                    case "3":
                    AtualizarTime();
                    break;
                    case "4":
                    ExcluirTime();
                    break;
                    case "5":
                    VisualizarTime();
                    break;
                    case "c":
                    Console.Clear();
                    break;
                    
                    default:
                    throw new ArgumentOutOfRangeException();
                }

                Resultado = ObterResultado();
            }
        }
        private static void ListaTimes()
        {
            Console.WriteLine("Listar Times");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum time encontrado.");
                return;
            }

            foreach(var time in lista)
            {
                var excluido = time.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", time.retornaId(), time.retornaNome(), (excluido ? "*Excluido" : ""));
            }
        }
        private static void InserirTime()
        {
            Console.WriteLine("Insira um novo time");

            foreach(int i in Enum.GetValues(typeof(Divisao))){
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Divisao), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaDivisao = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do time: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o estado do time: ");
            string entradaEstado = Console.ReadLine();

            Time novoTime = new Time(id: repositorio.ProximoId(),
                                    divisao: (Divisao)entradaDivisao,
                                    nome: entradaNome,
                                    estado: entradaEstado);

            repositorio.Insere(novoTime);
        }
        private static void AtualizarTime()
        {
                Console.WriteLine("Digite o id do time: ");
                int indiceTime = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Divisao))){
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Divisao), i));
            }

            Console.WriteLine("Digite o estado entre as opções acima: ");
            int entradaDivisao = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do time: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o estado do time: ".ToUpper());
            string entradaEstado = Console.ReadLine();

            Time atualizaTime = new Time(id: indiceTime,
                                    divisao: (Divisao)entradaDivisao,
                                    nome: entradaNome,
                                    estado: entradaEstado);

            repositorio.Atualiza(indiceTime, atualizaTime);
        }
        private static void ExcluirTime()
        {
            Console.WriteLine("Digite o id do time: ");
            int indiceTime = int.Parse(Console.ReadLine());

            repositorio.Equals(indiceTime);
        }
        private static void VisualizarTime(){
            Console.WriteLine("Digite o id do time: ");
            int visualizarTime = int.Parse(Console.ReadLine());

            var time = repositorio.RetornaPorId(visualizarTime);

            Console.WriteLine(time);
        }
        private static string ObterResultado(){
                Console.WriteLine();
                Console.WriteLine("Campeonato do Ederson");
                Console.WriteLine("Informe a opção desejada");

                Console.WriteLine("1 - Listar times");
                Console.WriteLine("2 - Inserir novo time");
                Console.WriteLine("3 - Atualizar Time");
                Console.WriteLine("4 - Excluir Time");
                Console.WriteLine("5 - Visualizar time");
                Console.WriteLine("c - Limpar tela");
                Console.WriteLine("X - Sair ");
                Console.WriteLine();

                string ObterResultado = Console.ReadLine().ToUpper();
                Console.WriteLine();

                return ObterResultado;

        }
    }
}
