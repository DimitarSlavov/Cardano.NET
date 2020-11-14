namespace Cardano.Core.Nomenclatures
{
    public class OrderEnum : EnumBase
    {
        public static readonly OrderEnum Ascending = new OrderEnum("ascending");
        public static readonly OrderEnum Descending = new OrderEnum("descending");

        protected OrderEnum(string value) 
            : base(value)
        {
        }
    }
}
