namespace Cardano.Core.Nomenclatures
{
	public class NetworkEnum : EnumBase
	{
		public static readonly NetworkEnum Testnet = new NetworkEnum("testnet");
		public static readonly NetworkEnum Mainnet = new NetworkEnum("mainnet");

        public NetworkEnum(string value) 
            : base(value)
        {
        }
    }
}
