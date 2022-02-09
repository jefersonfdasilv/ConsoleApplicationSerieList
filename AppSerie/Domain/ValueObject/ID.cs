namespace AppSerie.Domain.ValueObject
{
    public class ID : ValueObject
    {
        public readonly Guid Value;

        public ID()
        {
            Value = Guid.NewGuid();
        }

        public ID(string id)
        {
            Value = Guid.Parse(id);
        }

        public ID(Guid id)
        {
            this.Value = id;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
