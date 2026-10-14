using MelonLoader;
using TMPro;
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
            // Create canvas
            canvasObj = new("ModMenuCanvas");
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1 | AdditionalCanvasShaderChannels.TexCoord2 | AdditionalCanvasShaderChannels.TexCoord3;
            canvas.pixelPerfect = false;

            // Scale canvas
            CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(2560, 1400);

            // Dont Destroy
            GameObject.DontDestroyOnLoad(canvasObj);

            // Create Button
            Button toggleModMenuButton = new GameObject("toggleModMenuButton").AddComponent<Button>();
            toggleModMenuButton.transform.SetParent(canvasObj.transform, false);
            Image modMenuBtnImage = toggleModMenuButton.gameObject.AddComponent<Image>();
            modMenuBtnImage.color = new(0.2f, 0.2f, 0.2f, 0.9f);

            // Apply native Animator COntroller "AnimMenu_Button".

            // Find and apply leaf background sprite "leaf button 1"

            // Position Button
            RectTransform btnRect = toggleModMenuButton.GetComponent<RectTransform>();

            btnRect.anchorMin = new Vector2(1, 0.5f);   // Top-Left Anchor
            btnRect.anchorMax = new Vector2(1, 0.5f);   // Bottom-Right Anchor
            btnRect.pivot = new Vector2(1, 0.5f);       // Pivot

            btnRect.anchoredPosition = new(-50, 0);     // Relative Position
            btnRect.sizeDelta = new(600, 250);          // Button Size

            // On Button Press
            toggleModMenuButton.onClick.AddListener(ToggleModMenuBtnPressed);

            //Add Text to Button
            TextMeshProUGUI modMenuButtonText = new GameObject("Text").AddComponent<TextMeshProUGUI>();
            modMenuButtonText.transform.SetParent(toggleModMenuButton.transform, false);
            modMenuButtonText.SetText("Mod Menu");

            modMenuButtonText.fontSize = 48;
            modMenuButtonText.alignment = TextAlignmentOptions.Midline;
            modMenuButtonText.color = new(1f, 1f, 1f, 1f); RectTransform textRect = modMenuButtonText.GetComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.sizeDelta = Vector2.zero;
        }

        private void ToggleModMenuBtnPressed()
        {
            LoggerInstance.Msg("Mod Menu Button Pressed");
        }
    }
}