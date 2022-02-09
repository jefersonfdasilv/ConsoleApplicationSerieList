using AppSerie.Domain.Repository;
using AppSerie.Domain.UseCase.Serie;
using AppSerie.Domain.UseCase.Serie.DTO.Input;
using AppSerie.Domain.UseCase.Serie.DTO.Output;
using ConsoleTables;

namespace AppSerie.Application.CLI
{
    public class Application
    {
        private readonly Create _createUseCase;
        private readonly Update _updateUseCase;
        private readonly ListAll _listaAllUseCase;
        private readonly Delete _deleteUseCase;
        private readonly Retrieve _retrieveUseCase;
        private ISerieRepository serieRepository;

        public Application(Create createUseCase, Update updateUseCase, ListAll listaAllUseCase, Delete deleteUseCase, Retrieve retrieveUseCase)
        {
            _createUseCase = createUseCase;
            _updateUseCase = updateUseCase;
            _listaAllUseCase = listaAllUseCase;
            _deleteUseCase = deleteUseCase;
            _retrieveUseCase = retrieveUseCase;
        }

        public Application(ISerieRepository serieRepository)
        {
            this.serieRepository = serieRepository;
            _createUseCase = new Create(serieRepository);
            _updateUseCase = new Update(serieRepository);
            _listaAllUseCase = new ListAll(serieRepository);
            _deleteUseCase = new Delete(serieRepository);
            _retrieveUseCase = new Retrieve(serieRepository);
        }

        public void Run()
        {
            while (true)
            {
                Menu.Principal();
                string option = ReadLine.Read("Choose your option: ");
                int.TryParse(option, out var opt);
                Command(opt);
            }
        }

        private void Command(int option)
        {
            switch (option)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    ListAll();
                    break;
                case 2:
                    FindOne();
                    break;
                case 3:
                    Add();
                    break;
                case 4:
                    Delete();
                    break;
                default:
                    InvalidOption();
                    break;
            }
        }
        public void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("Invalid option, try again.");
            Console.WriteLine();
        }
        private void Delete()
        {
            var id = ReadLine.Read("Enter the ID: ");
            _deleteUseCase.Execute(new DeleteInput(id));
            Console.Clear();
            ListAll();
        }

        private void Add()
        {
            var title = ReadLine.Read("Enter the Title: ");
            var descripition = ReadLine.Read("Enter the Description: ");
            var year = ReadLine.Read("Enter the Year: ");
            var genre = ReadLine.Read("Enter the Genre: ");

            var yearValue = int.Parse(year);
            var genreValue = int.Parse(genre);

            CreateInput input = new CreateInput(title, descripition, genreValue, yearValue);

            var result = _createUseCase.Execute(input);

            Console.Clear();

            Show(result);

        }

        private void FindOne()
        {
            var id = ReadLine.Read("Enter the ID: ");
            var serie = _retrieveUseCase.Execute(new RetrieveInput(id));
            Console.Clear();
            if (serie != null)
            {
                Show(serie);
            }
            else
            {
                Console.WriteLine($"Serie [{id}] not found.");
            }
            PressEnter();

        }

        private void Show(CreateOutput output)
        {
            Console.WriteLine($"ID: {output.ID}");
            Console.WriteLine($"Title: {output.Title}");
            Console.WriteLine($"Description: {output.Description}");
            Console.WriteLine($"Year: {output.Year}");
            Console.WriteLine($"Genre: {output.Genre}");
            Console.WriteLine($"Active: {output.Active}");
        }

        private void ListAll()
        {
            Console.Clear();

            var list = _listaAllUseCase.Execute();
            var table = new ConsoleTable("ID", "Title", "Year");

            foreach (var item in list)
            {
                table.AddRow(item.ID, item.Title, item.Year);
            }

            table.Write();
            PressEnter();
        }

        private void PressEnter(bool clearAfter = true)
        {
            Console.WriteLine();
            ReadLine.Read("press enter to continue >");
            if (clearAfter)
                Console.Clear();
        }
    }
}