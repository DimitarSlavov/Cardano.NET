namespace Cardano.Core.Nomenclatures
{
    public class DiscoveryEnum : EnumBase
    {
        public static readonly DiscoveryEnum Random = new DiscoveryEnum("random");
        public static readonly DiscoveryEnum Sequential = new DiscoveryEnum("sequential");

        public DiscoveryEnum(string value)
            : base(value)
        {
        }
    }
}
