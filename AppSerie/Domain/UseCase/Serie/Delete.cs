
using AppSerie.Domain.Repository;
using AppSerie.Domain.UseCase.Serie.DTO.Input;

namespace AppSerie.Domain.UseCase.Serie
{
    public class Delete
    {
        private readonly ISerieRepository _serieRepository;
        public Delete(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }
        public void Execute(DeleteInput input)
        {
            var id = new ValueObject.ID(input.Id);
            var serie = _serieRepository.Get(id);

            if (serie == null)
            {
                throw new ArgumentException("Serie not found");
            }

            _serieRepository.Delete(id);

        }
    }
}
