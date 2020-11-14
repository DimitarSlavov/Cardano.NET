namespace Cardano.Core.Nomenclatures
{
	public class FilterEnum : EnumBase
	{
		public static readonly FilterEnum Redeemed = new FilterEnum("redeemed");
		public static readonly FilterEnum NotRedeemed = new FilterEnum("notredeemed");
		public static readonly FilterEnum All = new FilterEnum("all");

        public FilterEnum(string value) 
			: base(value)
        {
        }
    }
}
