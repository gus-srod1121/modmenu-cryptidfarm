using MelonLoader;

[assembly: MelonInfo(typeof(grcubes.CryptidLibrary.LibraryCore), "CryptidLibrary", "1.0.0", "Author", null)]
[assembly: MelonGame(null, null)]

namespace grcubes.CryptidLibrary
{
    public class LibraryCore : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }
    }
}