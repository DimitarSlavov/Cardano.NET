namespace Cardano.Core.Nomenclatures
{
	public class BlockDirectionEnum : EnumBase
	{
		public static readonly BlockDirectionEnum Outgoing = new BlockDirectionEnum("outgoing");
		public static readonly BlockDirectionEnum Incoming = new BlockDirectionEnum("incoming");

        public BlockDirectionEnum(string value) 
            : base(value)
        {
        }
    }
}
