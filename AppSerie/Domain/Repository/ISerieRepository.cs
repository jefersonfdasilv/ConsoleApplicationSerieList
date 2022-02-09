using AppSerie.Domain.Model;
using AppSerie.Domain.ValueObject;

namespace AppSerie.Domain.Repository
{
    public interface ISerieRepository
    {
        Serie Save(Serie serie);
        Serie Get(ID id);
        Serie Update(Serie serie);
        void Delete(ID id);
        ICollection<Serie> GetAll();
    }
}
