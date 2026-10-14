using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

[assembly: MelonInfo(typeof(CryptidFarm_ModMenu.Core), "ModMenu", "0.1.0", "grcubes")]
[assembly: MelonGame("GamebyFlamey", "Cryptid Farm")]

namespace CryptidFarm_ModMenu
{
    public class Core : MelonMod
    {
        public bool menuIsOpen = false;

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                MelonLogger.Msg("Toggle Mod Menu");
                menuIsOpen = !menuIsOpen;
            }
        }

        public override void OnGUI()
        {
            if (menuIsOpen)
            {
                Rect window = GUI.Window(0, new Rect(100, 100, 1000, 1000), DrawMenuContent, "Yes");
            }
        }

        private void DrawMenuContent(int window)
        {
            GUILayout.Label("Hello");
            GUI.Box(new Rect(0, 0, 1000, 1000), "BOXX");
        }
    }
}