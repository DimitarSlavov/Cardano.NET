namespace Cardano.Core.Nomenclatures
{
    public class WalletStyleEnum : EnumBase
    {
        public static readonly WalletStyleEnum Random = new WalletStyleEnum("random");
        public static readonly WalletStyleEnum Icarus = new WalletStyleEnum("icarus");
        public static readonly WalletStyleEnum Trezor = new WalletStyleEnum("trezor");
        public static readonly WalletStyleEnum Ledger = new WalletStyleEnum("ledger");

        public WalletStyleEnum(string value) : base(value)
        {
        }
    }
}
