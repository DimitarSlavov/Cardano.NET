namespace Cardano.Core.Nomenclatures
{
    public class CardanoStatusesEnum : EnumBase
    {
        public static readonly CardanoStatusesEnum Ok = new CardanoStatusesEnum("ok");
        public static readonly CardanoStatusesEnum Accepted = new CardanoStatusesEnum("accepted");
        public static readonly CardanoStatusesEnum NoContent = new CardanoStatusesEnum("no_content");
        public static readonly CardanoStatusesEnum NotImplemented = new CardanoStatusesEnum("not_implemented");
        public static readonly CardanoStatusesEnum BadRequest = new CardanoStatusesEnum("bad_request");
        public static readonly CardanoStatusesEnum Forbidden = new CardanoStatusesEnum("forbidden");
        public static readonly CardanoStatusesEnum NotFound = new CardanoStatusesEnum("not_found");
        public static readonly CardanoStatusesEnum MethodNotAllowed = new CardanoStatusesEnum("method_not_allowed");
        public static readonly CardanoStatusesEnum NotAcceptable = new CardanoStatusesEnum("not_acceptable");
        public static readonly CardanoStatusesEnum UnsupportedMediaType = new CardanoStatusesEnum("unsupported_media_type");
        public static readonly CardanoStatusesEnum WalletAlreadyExists = new CardanoStatusesEnum("wallet_already_exists");
        public static readonly CardanoStatusesEnum NoRootKey = new CardanoStatusesEnum("no_root_key");
        
        public CardanoStatusesEnum(string value) 
            : base(value)
        {
        }
    }
}
