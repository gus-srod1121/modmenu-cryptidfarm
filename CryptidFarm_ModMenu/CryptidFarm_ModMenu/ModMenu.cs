using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(CryptidFarm_ModMenu.ModMenu), "ModMenu", "0.1.0", "grcubes", null)]
[assembly: MelonGame("GamebyFlamey", "Cryptid Farm")]

namespace CryptidFarm_ModMenu
{
    public class ModMenu : MelonMod
    {
        private bool showMenu = false;
        private Rect windowRect = new(20, 20, 1000, 1000);

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initializing Mod Menu.");
        }

        public override void OnGUI()
        {
            
        }
    }
}