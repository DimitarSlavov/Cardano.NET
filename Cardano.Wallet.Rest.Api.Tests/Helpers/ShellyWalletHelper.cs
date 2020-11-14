using Cardano.Wallet.Rest.Api.Models.Wallet;

namespace Cardano.Wallet.Rest.Api.Tests.Helpers
{
    internal static class ShellyWalletHelper
    {
        private static readonly string[] MnemonicSentence15Words1 = new string[]
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

        private static readonly string[] MnemonicSentence15Words2 = new string[]
        {
            "lunar",
            "hamster",
            "midnight",
            "junk",
            "need",
            "shed",
            "issue",
            "that",
            "tube",
            "accuse",
            "tilt",
            "beauty",
            "zero",
            "curtain",
            "north"
        };

        public const string Passphrase = "Secure_Passphrase_AAA232F7-2A15-46C3-8D8D-9BF24645BC73";

        public static CreateRestoreWallet1 NonRandomWalletFromXpub => new CreateRestoreWallet1
        {
            Name = "Non_Random_Xpub_Wallet_FDA175A4-2D6D-41E5-97B9-202721674623",
            AccountPublicKey = "1423856bc91c49e928f6f30f4e8d665d53eb4ab6028bd0ac971809d514c92db11423856bc91c49e928f6f30f4e8d665d53eb4ab6028bd0ac971809d514c92db1",
            AddressPoolGap = 20
        };

        public static CreateRestoreWallet2 WalletIcarus => new CreateRestoreWallet2
        {
            Name = "Icarus_Wallet_0D9A90DA-5DD6-491D-B0D7-3FAADA17DA0D",
            Passphrase = Passphrase,
            MnemonicSentence = MnemonicSentence15Words1
        };

        public static CreateRestoreWallet2 WalletTest2 => new CreateRestoreWallet2
        {
            Name = "Test_Wallet_2_ADC15C14-4B1E-41B1-A96D-35AB433641B0",
            Passphrase = Passphrase,
            MnemonicSentence = MnemonicSentence15Words2
        };
    }
}
