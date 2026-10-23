using MelonLoader;

namespace CryptidLibrary.Core
{
    public class StatsUtils : MelonMod
    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (Scene.Game == (Scene)buildIndex)
            {
                
            }
        }

        public void Stat()
        {
            PlayerStats testStats = AssetUtils.FindComponentByName<PlayerStats>("GameMaster");
            if (testStats)
            {
                LoggerInstance.Msg("Test stats was found and it worked");
            }
            else
            {
                LoggerInstance.Msg("Test stats was not found, it didn't work");
            }
        }
    }
}
