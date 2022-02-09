
using AppSerie.Domain.Repository;
using AppSerie.Domain.UseCase.Serie.DTO.Input;
using AppSerie.Domain.UseCase.Serie.DTO.Output;

namespace AppSerie.Domain.UseCase.Serie
{
    public class Create
    {
        private readonly ISerieRepository _serieRepository;
        public Create(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }
        public CreateOutput Execute(CreateInput input)
        {

            var serie = new Model.Serie(title: input.Title, description: input.Description, genre: input.Genre, year: input.Year);
            _serieRepository.Save(serie);

            return new CreateOutput(serie);
        }
    }
}
