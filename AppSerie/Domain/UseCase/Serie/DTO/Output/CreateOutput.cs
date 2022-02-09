
namespace AppSerie.Domain.UseCase.Serie.DTO.Output
{
    public class CreateOutput
    {
        public readonly string ID;
        public readonly string Title;
        public readonly string Description;
        public readonly bool Active;
        public readonly string Genre;
        public readonly int Year;
        public CreateOutput(Model.Serie serie)
        {
            ID = serie.ID.ToString();
            Title = serie.Title.ToString();
            Description = serie.Description.ToString();
            Active = serie.Active;
            Genre = String.Format("{0}", serie.Genre.ToString());
            Year = serie.Year;
        }
    }
}
