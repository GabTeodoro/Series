using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        BuscarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por usar nosso sistema.");
            System.Console.WriteLine();
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar series: ");
            var lista = repositorio.Listar();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série encontrada.");
                return;
            }
            foreach (var serie in lista)
            {
                System.Console.WriteLine($"#{serie.Id} - {serie.Titulo} {(serie.Excluido ? "**Excluído**" : "")}");
            }

        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir uma nova série: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            System.Console.Write("Digite umas das opções de gênero acima: ");
            int genero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título da Série: ");
            var titulo = Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento: ");
            int lancamento = int.Parse(Console.ReadLine());

            System.Console.Write("Digite uma Descrição para a Série: ");
            var descricao = Console.ReadLine();

            Serie serie = new Serie(repositorio.ProximoId(), (Genero)genero, titulo, descricao, lancamento);
            repositorio.Inserir(serie);
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Atualizar Série: ");
            System.Console.Write("Digite o id da série que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            System.Console.Write("Digite umas das opções de gênero acima: ");
            int genero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título da Série: ");
            var titulo = Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento: ");
            int lancamento = int.Parse(Console.ReadLine());

            System.Console.Write("Digite uma Descrição para a Série: ");
            var descricao = Console.ReadLine();

            Serie serie = new Serie(id, (Genero)genero, titulo, descricao, lancamento);
            repositorio.Atualizar(id, serie);

        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Excluir Série:");
            System.Console.Write("Digite o id da série: ");
            int id = int.Parse(Console.ReadLine());

            repositorio.Excluir(id);
        }

        private static void BuscarSerie()
        {
            System.Console.WriteLine("Buscando Série: ");
            System.Console.Write("Digite o id da série: ");
            int id = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(id);
            System.Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Olá, Séries ao seu dispor!!");
            System.Console.WriteLine("Informe a opção que deseja: ");

            System.Console.WriteLine("1. Listar séries");
            System.Console.WriteLine("2. Inserir nova série");
            System.Console.WriteLine("3. Atualizar série");
            System.Console.WriteLine("4. Excluir série");
            System.Console.WriteLine("5. Buscar série");
            System.Console.WriteLine("C. Limpar Tela");
            System.Console.WriteLine("X. Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
