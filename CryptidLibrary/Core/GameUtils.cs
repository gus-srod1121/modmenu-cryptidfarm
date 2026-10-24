using MelonLoader;
using System.Collections;
using UnityEngine;

namespace CryptidLibrary.Core
{
    public class GameUtils
    {
        public static GameObject GameMaster;
        public static PlayerStats PlayerStats;

        private static int s_waitSeconds = 1;

        static GameUtils()
        {
            MelonCoroutines.Start(GetImportantObjects(s_waitSeconds));
        }

        private static IEnumerator GetImportantObjects(int seconds)
        {
            while (true)
            {
                GameMaster = AssetUtils.FindComponentByName<GameObject>("GameMaster");

                if (GameMaster)
                {
                    PlayerStats = GameMaster.GetComponent<PlayerStats>();
                    break;
                }
                yield return new WaitForSeconds(seconds);
            }
        }

        public static string GetStatInfo(PlayerStats.stat stat)
        {
            if (stat == null) return "Null Stat";

            return $"NAME: {stat.statName}\n" +
                "-------------------------------------------" +
                $"Initial Value: {stat.initialStatValue}\n" +
                $"Current Value: {stat.statValue}\n" +
                $"Value Additive: {stat.statValueAdditive}\n" +
                $"Rising Cost: {stat.risingCost}\n" +
                $"Upgrade Cost: {stat.upgradeCost}\n" +
                $"Times Upgraded: {stat.timesUpgraded}\n" +
                $"Defined Upgrades: {stat.definedUpgrades}\n" +
                $"Has Limit: {stat.hasLimit}\n" +
                $"Limit: {stat.limit}\n" +
                $"Purchaseable {stat.purchaseable}\n" +
                $"Progression Required: {stat.progressionRequired}\n" +
                $"Exponential: {stat.exponential}\n" +
                $"Tractor Locked Upgrades: {stat.tractorLockedUpgrades}\n";
        }
    }
}
