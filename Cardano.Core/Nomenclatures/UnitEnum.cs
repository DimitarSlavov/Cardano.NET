namespace Cardano.Core.Nomenclatures
{
    public class UnitEnum : EnumBase
    {
        public static readonly UnitEnum Block = new UnitEnum("block");
        public static readonly UnitEnum Lovelace = new UnitEnum("lovelace");
        public static readonly UnitEnum Percent = new UnitEnum("percent");
        public static readonly UnitEnum Slot = new UnitEnum("slot");
        public static readonly UnitEnum Second = new UnitEnum("second");
        public static readonly UnitEnum Microsecond = new UnitEnum("microsecond");
        
        public UnitEnum(string value) 
            : base(value)
        {
        }
    }
}
