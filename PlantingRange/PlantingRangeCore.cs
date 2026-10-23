using MelonLoader;
using UnityEngine;
using CryptidLibrary.Core;

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
            }
            else
            {
                LoggerInstance.Msg("Test stats was not found, it didn't work");
            }

            //Print those
            foreach (PlayerStats.stat s in stats.Stats.Values)
            {
                LoggerInstance.Msg($"Name: {s.statName}\n" +
                    $"Initial Value: {s.initialStatValue}\n" +
                    $"Current Value: {s.statValue}\n" +
                    $"Value Additive: {s.statValueAdditive}\n" +
                    $"Rising Cost: {s.risingCost}\n" +
                    $"Upgrade Cost: {s.upgradeCost}\n" +
                    $"Times Upgraded: {s.timesUpgraded}\n" +
                    $"Defined Upgrades: {s.definedUpgrades}\n" +
                    $"Has Limit: {s.hasLimit}\n" +
                    $"Limit: {s.limit}\n" +
                    $"Purchaseable {s.purchaseable}\n" +
                    $"Progression Required: {s.progressionRequired}\n" +
                    $"Exponential: {s.exponential}\n" +
                    $"Tractor Locked Upgrades: {s.tractorLockedUpgrades}\n" +
                    $"");
            }

            LoggerInstance.Msg(stats.buyBackEnabled);

            LoggerInstance.Msg("===============");
        }

        // TO-DO: Check out the PlayerStats, in the Game Master. Make a cheat maybe.
    }
}