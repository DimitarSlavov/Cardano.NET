namespace Cardano.Core.Nomenclatures
{
	public class TransactionStatusEnum : EnumBase
	{
		public static readonly TransactionStatusEnum Pending = new TransactionStatusEnum("pending");
		public static readonly TransactionStatusEnum InLedger = new TransactionStatusEnum("in_ledger");

        public TransactionStatusEnum(string value) 
            : base(value)
        {
        }
    }
}
