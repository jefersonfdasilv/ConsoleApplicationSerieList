
using AppSerie.Domain.Model;
using AppSerie.Domain.Repository;
using AppSerie.Domain.ValueObject;

namespace AppSerie.Infrastructure.Repository.InMemory
{
    public class SerieRepository : ISerieRepository
    {
        private IDictionary<string, Serie> _Series;

        public SerieRepository()
        {
            _Series = new Dictionary<string, Serie>();
        }
        public void Delete(ID id)
        {
            if (_Series.ContainsKey(id.ToString()))
            {
                _Series.Remove(id.ToString());
            }
        }

        public Serie Get(ID id)
        {
            _Series.TryGetValue(id.ToString(), out Serie serie);
            return serie;
        }

        public ICollection<Serie> GetAll()
        {
            return _Series.Values;
        }

        public Serie Save(Serie serie)
        {
            _Series.Add(serie.ID.ToString(), serie);
            return serie;
        }

        public Serie Update(Serie serie)
        {
            if (serie == null)
            {
                throw new ArgumentNullException("Serie can not be null");
            }

            var id = serie.ID.ToString();
            if (!_Series.ContainsKey(id))
            {
                throw new ArgumentException("Serie not found");
            }

            _Series.Remove(id);
            _Series.Add(id, serie);

            return serie;

        }
    }
}
