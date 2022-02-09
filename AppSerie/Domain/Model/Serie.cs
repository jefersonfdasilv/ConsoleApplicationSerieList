using AppSerie.Domain.ValueObject;

namespace AppSerie.Domain.Model
{
    public class Serie
    {
        public ID ID { get; set; }
        public Title Title { get; set; }
        public Description Description { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }
        public bool Active { get; set; } = true;

        public Serie()
        {
            ID = new ID();
        }

        public Serie(string id, string title)
        {
            ID = new ID(id);
            Title = new Title(title);
        }

        public Serie(string title, string description, Genre genre, int year, bool active = true)
        {
            ID = new ID();
            Title = new Title(title);
            Description = new Description(description);
            Active = active;
            Genre = genre;
            Year = year;
        }

        public override string ToString()
        {
            return Title.ToString();
        }
    }
}
