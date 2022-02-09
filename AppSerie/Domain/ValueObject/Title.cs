namespace AppSerie.Domain.ValueObject
{
    public class Title : ValueObject
    {
        public readonly string Value;

        public Title(string value)
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
            if (value.Length < 3)
                throw new ArgumentException($"The {nameof(value)} is too short.");
            if (value.Length > 50)
                throw new ArgumentException($"The {nameof(value)} is too long.");
        }


    }
}
