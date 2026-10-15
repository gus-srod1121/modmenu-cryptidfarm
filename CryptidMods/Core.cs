using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using grcubes.CryptidFarm.CryptidLibrary.Core;

[assembly: MelonInfo(typeof(grcubes.CryptidFarm.Mods.ModMenu.Core), "ModMenu", "0.1.0", "grcubes", null)]
[assembly: MelonGame("GamebyFlamey", "Cryptid Farm")]

namespace grcubes.CryptidFarm.Mods.ModMenu
{
    public class Core : MelonMod
    {
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
                CloneModMenuButton();
                // CreateModMenuButtonUI();
            }
        }

        private void CloneModMenuButton()
        {
            // Find button to clone
            GameObject quitButtonObj = AssetUtils.FindComponentByName<GameObject>("Quit button"); ;

            if (!quitButtonObj)
            {
                LoggerInstance.Error("Nope, no button found");
                return;
            }

            // Clone button object.
            GameObject clonedButtonObj = GameObject.Instantiate(quitButtonObj, quitButtonObj.transform.parent);
            if (!clonedButtonObj)
            {
                LoggerInstance.Error("Failed to clone button object");
                return;
            }

            // Adjust button position
            RectTransform btnRt = clonedButtonObj.GetComponent<RectTransform>();
            if (btnRt)
            {
                btnRt.anchoredPosition = new Vector2(btnRt.anchoredPosition.x, btnRt.anchoredPosition.y + 200);
            }

            // Find Button component in cloned object
            GameObject modButtonContent = clonedButtonObj.transform.Find("Button content").gameObject;
            if (!modButtonContent)
            {
                LoggerInstance.Error("Couldn't find Button Content in mod button object");
                return;
            }
            Button quitButton = modButtonContent.GetComponentInChildren<Button>();
            if (!quitButton)
            {
                LoggerInstance.Error("Couldn't find Mod Button Content Button component");
                return;
            }

            // Destroy old quit button functionality
            Button quitButtonComponent = quitButton;
            if (!quitButtonComponent)
            {
                LoggerInstance.Error("Couldn't find Quit button component");
                return;
            }
            GameObject.Destroy(quitButton);

            // Copy button animations
            Button modMenuButton = clonedButtonObj.AddComponent<Button>();
            if (!modMenuButton)
            {
                LoggerInstance.Error("Mod Menu button component not added");
                return;
            }

            // Change button text
            TextMeshProUGUI btnText = modMenuButton.GetComponentInChildren<TextMeshProUGUI>();
            if (!btnText)
            {
                LoggerInstance.Error("Couldn't find TMP component in Button");
                return;
            }
            btnText.SetText("Mods");

            modMenuButton.onClick.AddListener(ToggleModMenuBtnPressed);
        }

        private void CreateModMenuButtonUI()
        {
            //// Create canvas
            //canvasObj = new GameObject("ModMenuCanvas");
            //Canvas canvas = canvasObj.AddComponent<Canvas>();
            //canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            //canvas.additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1 | AdditionalCanvasShaderChannels.TexCoord2 | AdditionalCanvasShaderChannels.TexCoord3;
            //canvas.pixelPerfect = false;
            //canvasObj.AddComponent<GraphicRaycaster>();

            //// Scale canvas
            //CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
            //canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            //canvasScaler.referenceResolution = new Vector2(2560, 1400);

            //// Dont Destroy
            //GameObject.DontDestroyOnLoad(canvasObj);

            //// Create Button
            //Button toggleModMenuButton = new GameObject("toggleModMenuButton").AddComponent<Button>();
            //toggleModMenuButton.transform.SetParent(canvasObj.transform, false);
            //Image modMenuBtnImage = toggleModMenuButton.gameObject.AddComponent<Image>();

            //// Apply native Animator Controller "AnimMenu_Button".
            // RuntimeAnimatorController animController = AssetUtils.FindComponentByName<RuntimeAnimatorController>("AnimMenu_Button");
            //if (animController)
            //{
            //    Animator anim = toggleModMenuButton.gameObject.AddComponent<Animator>();
            //    anim.runtimeAnimatorController = animController;
            //}

            ////Add animations to the button
            //toggleModMenuButton.transition = Selectable.Transition.Animation;

            //// Find and apply leaf background sprite "leaf button 1"
            //Sprite leafSprite = AssetUtils.FindComponentByName<Sprite>("leaf button 1");

            //if (leafSprite)
            //{
            //    modMenuBtnImage.sprite = leafSprite;
            //}
            //else
            //{
            //    modMenuBtnImage.color = new(0.2f, 0.2f, 0.2f, 0.9f);
            //}

            //// Position Button
            //RectTransform btnRect = toggleModMenuButton.GetComponent<RectTransform>();

            //btnRect.anchorMin = new Vector2(0.5f, 0.5f);    // Top-Left Anchor
            //btnRect.anchorMax = new Vector2(0.5f, 0.5f);    // Bottom-Right Anchor
            //btnRect.pivot = new Vector2(0.5f, 0.5f);        // Pivot

            //btnRect.anchoredPosition = new(440, -8);        // Relative Position
            //btnRect.sizeDelta = new(600, 250);              // Button Size

            //// On Button Press
            //toggleModMenuButton.onClick.AddListener(ToggleModMenuBtnPressed);

            ////Add Text to Button
            //TextMeshProUGUI modMenuButtonText = new GameObject("Text").AddComponent<TextMeshProUGUI>();
            //modMenuButtonText.transform.SetParent(toggleModMenuButton.transform, false);
            //modMenuButtonText.SetText("Mod Menu");

            //modMenuButtonText.fontSize = 48;
            //modMenuButtonText.alignment = TextAlignmentOptions.Midline;
            //modMenuButtonText.color = new(1f, 1f, 1f, 1f); RectTransform textRect = modMenuButtonText.GetComponent<RectTransform>();
            //textRect.anchorMin = Vector2.zero;
            //textRect.anchorMax = Vector2.one;
            //textRect.sizeDelta = Vector2.zero;
        }

        private void ToggleModMenuBtnPressed()
        {
            LoggerInstance.Msg("Mod Menu Button Pressed");
        }

        private void LogAllObjectInfo(GameObject obj)
        {
            LoggerInstance.Msg($"Name: {obj.name}; #Children: {obj.transform.childCount};");
        }
    }
}