namespace Cardano.Core.Nomenclatures
{
    public abstract class EnumBase
    {
        protected readonly string Value;

        protected EnumBase(string value)
        {
            Value = value;
        }

        public string GetValue() => Value;
    }
}
