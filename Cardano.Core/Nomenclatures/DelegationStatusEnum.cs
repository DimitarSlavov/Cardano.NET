namespace Cardano.Core.Nomenclatures
{
	public class DelegationStatusEnum : EnumBase
	{
		public static readonly DelegationStatusEnum NotDelegating = new DelegationStatusEnum("not_delegating");
		public static readonly DelegationStatusEnum Delegating = new DelegationStatusEnum("delegating");

        public DelegationStatusEnum(string value) 
            : base(value)
        {
        }
    }
}
