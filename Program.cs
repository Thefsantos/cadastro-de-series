using Cadastro_de_Series;
using System;

namespace Cadastro_de_Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string UserOption = GetUserOption();

            while (UserOption.ToUpper() != "X")
            {
                switch (UserOption)
                {
                    case "1":
                        ListSerie();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        update();
                        break;
                    case "4":
                        delete();
                        break;
                    case "5":
                        ReturnById();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }

                UserOption = GetUserOption();
            }
        }

        private static void ListSerie()
        {
            Console.WriteLine("Listar Séries");

            var lista = repository.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada!.");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine($"#ID {serie.ReturnId()}: - {serie.ReturnTitle()}");
            }
        }

        private static  void InsertSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string enterTitle = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string enterDescription = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                                        genre: (Genre)enterGenre,
                                        title: enterTitle,
                                        year: enterYear,
                                        description: enterDescription);

            repository.Insert(newSerie);
            return;
        }

        private static void update()
        {
            Console.Write("Digite o Id da Série: ");
            int IdSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int enterGenre = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string enterTitle = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string enterDescription = Console.ReadLine();

            Serie updateSerie = new Serie(id: IdSerie,
                                        genre: (Genre)enterGenre,
                                        title: enterTitle,
                                        year: enterYear,
                                        description: enterDescription);

            repository.update(IdSerie, updateSerie);
        }

        private static void delete()
        {
            Console.Write("Digite o Id da Série: ");
            int IdSerie = int.Parse(Console.ReadLine());

            repository.delete(IdSerie);
        }

        private static void ReturnById()
        {
            Console.Write("Digite o Id da Série: ");
            int IdSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(IdSerie);

            Console.WriteLine(serie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("FJS Séries a seu comando!!!");
            Console.WriteLine("Informa a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string UserOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return UserOption;
        }
    }
}
