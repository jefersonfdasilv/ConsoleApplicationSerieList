using ConsoleTables;

namespace AppSerie.Application.CLI
{
    public class Menu
    {
        public static void Principal()
        {
            var table = new ConsoleTable("Decription", "Option");

            table.AddRow("List All Series", "1");
            table.AddRow("Find one by ID", "2");
            table.AddRow("Add seire", "3");
            table.AddRow("Delete seire", "4");
            table.AddRow("Sair", "0");

            table.Write(Format.Alternative);
        }
    }
}
