using CryptidLibrary;
using MelonLoader;

[assembly: MelonInfo(typeof(LibraryCore), "CryptidLibrary", "0.1.0", "grcubes", null)]
[assembly: MelonGame("GamebyFlamey", "Cryptid Farm")]

namespace CryptidLibrary
{
    public class LibraryCore : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized Cryptid Library.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Scene {buildIndex} Loaded: {sceneName}");
        }
    }
}