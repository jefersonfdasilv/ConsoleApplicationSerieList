namespace AppSerie.Domain.ValueObject
{
    public class Description : ValueObject
    {
        public readonly string Value;

        public Description(string value)
        {
            var _value = CleanInput.Sanitize(value);
            Validate(_value);
            Value = _value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }

        private void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException($"Invalid value of {nameof(value)}.");
            if (value.Length < 10)
                throw new ArgumentException($"The {nameof(value)} is too short.");
            if (value.Length > 200)
                throw new ArgumentException($"The {nameof(value)} is too long.");
        }


    }
}
