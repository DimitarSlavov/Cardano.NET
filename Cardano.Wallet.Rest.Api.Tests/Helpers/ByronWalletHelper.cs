using Cardano.Core.Nomenclatures;
using Cardano.Wallet.Rest.Api.Models.Byron.Wallet;

namespace Cardano.Wallet.Rest.Api.Tests.Helpers
{
    internal static class ByronWalletHelper
    {
        private static readonly string[] MnemonicSentence12Words = new string[]
        {
            "squirrel",
            "material",
            "silly",
            "twice",
            "direct",
            "slush",
            "pistol",
            "razor",
            "become",
            "junk",
            "kingdom",
            "flee"
        };

        private static readonly string[] MnemonicSentence15Words = new string[]
        {
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "ability",
            "abandon"
        };

        public const string Passphrase = "Secure_Passphrase_FF126849-0EEE-4A4C-A40C-B96650CC61A4";

        public static RestoreNonRandomWalletFromXpub NonRandomWalletFromXpub => new RestoreNonRandomWalletFromXpub
        {
            Name = "Non_Random_Xpub_Wallet_FDA175A4-2D6D-41E5-97B9-202721674623",
            AccountPublicKey = "1423856bc91c49e928f6f30f4e8d665d53eb4ab6028bd0ac971809d514c92db11423856bc91c49e928f6f30f4e8d665d53eb4ab6028bd0ac971809d514c92db1",
            AddressPoolGap = 20
        };

        public static RestoreRandomWalletFromXprv RandomWalletFromXprv => new RestoreRandomWalletFromXprv
        {
            Name = "Random_Xprv_Wallet_32E3AC40-4932-4946-92D7-E277680AF4CE",
            PassphraseHash = "31347c387c317c574342652b796362417576356c2b4258676a344a314c6343675375414c2f5653393661364e576a2b7550766655513d3d7c2f376738486c59723174734e394f6e4e753253302b6a65515a6b5437316b45414941366a515867386539493d",
            EncryptedRootPrivateKey = "65b0a8a43341078aa25e499457902bed3e7d63a74d6079a563e08f0a7e2854dc918ed1b98c2e262d837276cce3fa8c3825ae5aa0f24535168b597127bd62461b323dba7f9c2beb5dbf24b528b6981e83c2e21a4aa7684746d86b763191aada4f980a05ec790380f10c8d05df95750bdd482870ed294ffc2f6356da69d0287950"
        };

        public static RestoreWalletStyle WalletStyleLedger => new RestoreWalletStyle(WalletStyleEnum.Ledger)
        {
            Name = "Ledger_Wallet_D7126C58-37B9-4112-A255-ACE2787A9E35",
            Passphrase = Passphrase,
            MnemonicSentence = MnemonicSentence12Words,
        };

        public static RestoreWalletStyle WalletStyleTrezor => new RestoreWalletStyle(WalletStyleEnum.Trezor)
        {
            Name = "Trezor_Wallet_3DFCA8F3-5C72-4E34-9463-598816F4286B",
            Passphrase = Passphrase,
            MnemonicSentence = MnemonicSentence12Words,
        };

        public static RestoreWalletStyle WalletStyleRandom => new RestoreWalletStyle(WalletStyleEnum.Random)
        {
            Name = "Random_Wallet_231BBB42-D21B-4829-BB0E-7E95039B9F88",
            Passphrase = Passphrase,
            MnemonicSentence = MnemonicSentence12Words
        };

        public static RestoreWalletStyle WalletStyleIcarus => new RestoreWalletStyle(WalletStyleEnum.Icarus)
        {
            Name = "Icarus_Wallet_F47A0BF8-3D1F-4481-A8D5-999120FEF965",
            Passphrase = Passphrase,
            MnemonicSentence = MnemonicSentence15Words
        };
    }
}
