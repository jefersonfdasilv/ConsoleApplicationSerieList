
using AppSerie.Domain.Repository;
using AppSerie.Infrastructure.Repository.InMemory;
namespace AppSerie;

class Programa
{
    public static void Main()
    {
        ISerieRepository serieRepository = new SerieRepository();
        var app = new AppSerie.Application.CLI.Application(serieRepository);
        try
        {
            app.Run();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}