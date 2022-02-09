
namespace AppSerie.Domain.UseCase.Serie.DTO.Input
{
    public class UpdateInput
    {
        public readonly string Id;
        public readonly string Title;
        public readonly string Description;

        public UpdateInput(string id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
