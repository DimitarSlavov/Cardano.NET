namespace Cardano.Core.Nomenclatures
{
	public class AddressStateEnum : EnumBase
	{
		public static readonly AddressStateEnum Used = new AddressStateEnum("used");
		public static readonly AddressStateEnum Unused = new AddressStateEnum("unused");

        protected AddressStateEnum(string value) 
            : base(value)
        {
        }
    }
}
