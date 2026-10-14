using MelonLoader;

[assembly: MelonInfo(typeof(grcubes.CryptidFarm.CryptidLibrary.LibraryCore), "CryptidLibrary", "0.1.0", "grcubes", null)]
[assembly: MelonGame("GamebyFlamey", "Cryptid Farm")]

namespace grcubes.CryptidFarm.CryptidLibrary
{
    public class LibraryCore : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized Cryptid Library.");
        }
    }
}