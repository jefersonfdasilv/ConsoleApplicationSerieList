using AppSerie.Domain.Repository;
using AppSerie.Domain.UseCase.Serie.DTO.Output;

namespace AppSerie.Domain.UseCase.Serie
{
    public class ListAll
    {
        private readonly ISerieRepository _serieRepository;

        public ListAll(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public ICollection<RetrieveOutput> Execute()
        {
            var series = _serieRepository.GetAll();
            var list = new List<RetrieveOutput>();

            foreach (var item in series)
            {
                list.Add(new RetrieveOutput(item));
            }

            return list;
        }
    }
}
