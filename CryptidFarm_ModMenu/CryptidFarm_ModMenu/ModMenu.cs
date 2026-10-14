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
            if (GUI.Button(new(20, 20, 300, 100), showMenu ? "Close Mod Menu" : "Open Mod Menu"))
            {
                LoggerInstance.Msg($"{(showMenu ? "Closing":"Opening")} Mod Menu");
                showMenu = !showMenu;
            }

            if (showMenu)
            {
                windowRect = GUI.Window(0, windowRect, DrawMenuWindow, "Cryptid Farm");
            }
        }

        private void DrawMenuWindow(int windowID)
        {
            GUILayout.BeginVertical();
            GUILayout.Label("Mod Menu");

            if (GUILayout.Button("Test Button"))
            {
                LoggerInstance.Msg("Test button pressed");
            }
            GUILayout.EndVertical();

            GUI.DragWindow(new(0, 0, 1000, 1000));
        }
    }
}