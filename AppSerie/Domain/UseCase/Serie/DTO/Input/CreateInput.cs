
using AppSerie.Domain.Model;

namespace AppSerie.Domain.UseCase.Serie.DTO.Input
{
    public class CreateInput
    {
        public readonly string Title;
        public readonly string Description;
        public readonly Genre Genre;
        public readonly int Year;
        public CreateInput(string title, string description, int genre, int year)
        {
            Title = title.Trim();
            Description = description.Trim();
            if (Enum.IsDefined(typeof(Genre), genre))
                Genre = (Genre)genre;
            Year = year;
        }
    }
}
