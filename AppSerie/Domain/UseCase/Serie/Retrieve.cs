using AppSerie.Domain.Repository;
using AppSerie.Domain.UseCase.Serie.DTO.Input;
using AppSerie.Domain.UseCase.Serie.DTO.Output;

namespace AppSerie.Domain.UseCase.Serie
{
    public class Retrieve
    {
        private readonly ISerieRepository _serieRepository;

        public Retrieve(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public RetrieveOutput Execute(RetrieveInput input)
        {
            var serie = _serieRepository.Get(new ValueObject.ID(input.Id));

            return new RetrieveOutput(serie);
        }
    }
}
