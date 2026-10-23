using MelonLoader;
using UnityEngine;

using grcubes.CryptidLibrary;

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
                Test();
            }
        }

        public void Test()
        {
            LoggerInstance.Msg("==Test Prints==");

            //Get player stats
            GameObject gameMaster = AssetUtils.FindComponentByName<GameObject>("GameMaster");
            if (!gameMaster)
            {
                LoggerInstance.Error("GameMaster not found");
                return;
            }

            PlayerStats stats = gameMaster.GetComponent<PlayerStats>();
            if (!stats)
            {
                LoggerInstance.Error("GameMaster's PlayerStats not found");
                return;
            }

            PlayerStats testStats = AssetUtils.FindComponentByName<PlayerStats>("GameMaster");
            if (testStats)
            {
                LoggerInstance.Msg("Test stats was found and it worked");
            } else
            {
                LoggerInstance.Msg("Test stats was not found, it didn't work");
            }

            //Print those
            LoggerInstance.Msg(stats.Stats);
            LoggerInstance.Msg(stats.Perks);
            LoggerInstance.Msg(stats.buyBackEnabled);

            LoggerInstance.Msg("===============");
        }

        // TO-DO: Check out the PlayerStats, in the Game Master. Make a cheat maybe.
    }
}