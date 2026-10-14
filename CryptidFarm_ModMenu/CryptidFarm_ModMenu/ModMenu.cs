using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

[assembly: MelonInfo(typeof(CryptidFarm_ModMenu.ModMenu), "ModMenu", "0.1.0", "grcubes", null)]
[assembly: MelonGame("GamebyFlamey", "Cryptid Farm")]

namespace CryptidFarm_ModMenu
{
    public class ModMenu : MelonMod
    {
        private GameObject canvasObj;
        private GameObject modMenuObj;
        private bool showMenu = false;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initializing Mod Menu.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Scene Loaded: {sceneName}");

            if (sceneName.Equals("Menu Animated 2"))
            {
                LoggerInstance.Msg($"Main Menu Scene Detected. Injecting Mod Menu Button.");
                CreateModMenuUI();
            }
            else
            {
                GameObject.Destroy(canvasObj);
            }
        }

        private void CreateModMenuUI()
        {
            canvasObj = new("ModMenuCanvas");

            Canvas canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1 | AdditionalCanvasShaderChannels.TexCoord2 | AdditionalCanvasShaderChannels.TexCoord3;
            canvas.pixelPerfect = false;

            CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(2560, 1400);

            GameObject.DontDestroyOnLoad(canvasObj);

            GameObject toggleModMenuButton = new("ToggleModMenuButton");
        }
    }
}