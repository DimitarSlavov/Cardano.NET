namespace Cardano.Core.Nomenclatures
{
	public class WalletStatusEnum : EnumBase
	{
		public static readonly WalletStatusEnum Ready = new WalletStatusEnum("ready");
		public static readonly WalletStatusEnum Syncing = new WalletStatusEnum("syncing");
		public static readonly WalletStatusEnum NotResponding = new WalletStatusEnum("not_responding");

        public WalletStatusEnum(string value) 
			: base(value)
        {
        }
    }
}
