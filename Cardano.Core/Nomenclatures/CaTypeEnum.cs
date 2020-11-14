namespace Cardano.Core.Nomenclatures
{
	public class CaTypeEnum : EnumBase
	{
		public static readonly CaTypeEnum CPubKeyAddress = new CaTypeEnum(nameof(CPubKeyAddress));
		public static readonly CaTypeEnum CRedeemAddress = new CaTypeEnum(nameof(CRedeemAddress));

        public CaTypeEnum(string value) 
            : base(value)
        {
        }
    }
}
