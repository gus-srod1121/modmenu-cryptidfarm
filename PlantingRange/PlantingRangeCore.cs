using CryptidLibrary.Core;
using MelonLoader;

[assembly: MelonInfo(typeof(PlantingRange.PlantingRangeCore), "PlantingRange", "1.0.0", "Author", null)]
[assembly: MelonGame(null, null)]

namespace PlantingRange
{
    public class PlantingRangeCore : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initializing PlantingRange");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (Scene.Game == (Scene)buildIndex)
            {
                LoggerInstance.Msg("Game Scene Detected.");
            }
        }
    }
}