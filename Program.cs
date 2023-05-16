using System;

namespace Crud
{
    class Program
    {
        static SerieRepository serieRepository = new SerieRepository();
        static void Main(string[] args)
        {
            string UserOption = RequestUserOption();

            while(UserOption.ToUpper() != "X")
            {

                switch(UserOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        RemoveSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static string RequestUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Inform a opção desejada");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar séries");
            Console.WriteLine("4 - Excluir séries");
            Console.WriteLine("5 - Vizualizar séries");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string UserOption = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return UserOption;
        }

        private static void InsertSeries()
        {
            Console.WriteLine("Inserir nova séries");

            var listSeries =  serieRepository.List();

            foreach(int gender in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine("#Id {0} - {1}", gender, Enum.GetName(typeof(Genres),gender));
            }

            Console.Write("Digite o generô entre as opções acima:");
            int inputGender = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o titulo da série:");
            string inputTitle = Console.ReadLine();
          
            Console.Write("Digite o ano de início da série:");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série:");
            string inputDescription = Console.ReadLine();
          
            Serie newSerie = new Serie (
                                        id: serieRepository.NextId(),
                                        gender: (Genres)inputGender,
                                        title: inputTitle,
                                        year: inputYear,
                                        description: inputDescription                                  
                                       );
            serieRepository.Insert(newSerie);

        }
        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var listSeries =  serieRepository.List();

            if(listSeries.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(var serie in listSeries)
            {
                var deletion = serie.ReturnDeletion();
                Console.WriteLine("#Id {0} - {1} - {2}", serie.ReturnId(), serie.ReturnTitle(), (deletion ? "Excluido" : ""));
            }
        }

        private static void UpdateSeries()
        {
            Console.WriteLine("Inserir o id da série");
            int index = int.Parse(Console.ReadLine());

            foreach(int gender in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine("{0} - {1}", gender, Enum.GetName(typeof(Genres),gender));
            }

            Console.Write("Digite o generô entre as opções acima:");
            int inputGender = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o titulo da série:");
            string inputTitle = Console.ReadLine();
          
            Console.Write("Digite o ano de início da série:");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série:");
            string inputDescription = Console.ReadLine();
          
            Serie updateSerie = new Serie (
                                        id: serieRepository.NextId(),
                                        gender: (Genres)inputGender,
                                        title: inputTitle,
                                        year: inputYear,
                                        description: inputDescription                                  
                                       );
            serieRepository.Update(index, updateSerie);
        }
        
        private static void RemoveSeries()
        {
            Console.WriteLine("Inserir o id da série");
            int index = int.Parse(Console.ReadLine());

            serieRepository.Remove(index);
        }

        private static void ViewSeries()
        {
            Console.WriteLine("Inserir o id da série");
            int index = int.Parse(Console.ReadLine());

            var serie = serieRepository.ReturnById(index);

            Console.WriteLine(serie);
        }
    }
}