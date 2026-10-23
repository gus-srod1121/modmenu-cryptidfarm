using MelonLoader;
using UnityEngine;
using UnityEngine.InputSystem;
using CryptidLibrary.Core;

[assembly: MelonInfo(typeof(PlantingRange.PlantingRangeCore), "PlantingRange", "1.0.0", "Author", null)]
[assembly: MelonGame(null, null)]

namespace PlantingRange
{
    public class PlantingRangeCore : MelonMod
    {
        private bool inGameScene = false;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initializing PlantingRange");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            inGameScene = Scene.Game == (Scene)buildIndex;
        }

        public override void OnUpdate()
        {
            if (!inGameScene) return;

            if (Keyboard.current.backslashKey.wasPressedThisFrame)
            {
                PrintStatsInfo();
            }
        }

        public void PrintStatsInfo()
        {
            //Print those
            LoggerInstance.Msg("=========================");

            LoggerInstance.Msg("PLAYER STATS:");

            foreach (PlayerStats.stat s in GameUtils.PlayerStats.Stats.Values)
            {
                LoggerInstance.Msg("\n");
                LoggerInstance.Msg(GameUtils.GetStatInfo(s));
                LoggerInstance.Msg("\n\n");
            }

            LoggerInstance.Msg("Buy Back Enabled: " + GameUtils.PlayerStats.buyBackEnabled);

            LoggerInstance.Msg("=========================");
        }

        // TO-DO: Check out the PlayerStats, in the Game Master. Make a cheat maybe.
    }
}