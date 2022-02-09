
using AppSerie.Domain.Repository;
using AppSerie.Domain.UseCase.Serie.DTO.Input;
using AppSerie.Domain.UseCase.Serie.DTO.Output;

namespace AppSerie.Domain.UseCase.Serie
{
    public class Update
    {
        private readonly ISerieRepository _serieRepository;
        public Update(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }
        public UpdateOutput Execute(UpdateInput input)
        {
            var serie = _serieRepository.Get(new ValueObject.ID(input.Id));

            if (serie == null)
            {
                throw new ArgumentException("Serie not found");
            }

            serie.Title = new ValueObject.Title(input.Title);
            serie.Description = new ValueObject.Description(input.Description);

            _serieRepository.Update(serie);

            return new UpdateOutput(serie);
        }
    }
}
