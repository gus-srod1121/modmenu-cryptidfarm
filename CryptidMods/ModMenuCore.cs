using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CryptidLibrary.Core;

[assembly: MelonInfo(typeof(grcubes.CryptidFarm.Mods.ModMenu.ModMenuCore), "ModMenu", "0.1.0", "grcubes", null)]
[assembly: MelonGame("GamebyFlamey", "Cryptid Farm")]

namespace grcubes.CryptidFarm.Mods.ModMenu
{
    public class ModMenuCore : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initializing Mod Menu.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (Scene.MainMenu == (Scene)buildIndex)
            {
                LoggerInstance.Msg($"Injecting Mod Menu Button.");
                CloneModMenuButton();
            }
        }

        private void CloneModMenuButton()
        {
            // Find button to clone
            GameObject quitButtonObj = AssetUtils.FindComponentByName<GameObject>("Quit button");
            if (!quitButtonObj)
            {
                LoggerInstance.Error("Quit button not found");
                return;
            }

            // Clone button object.
            GameObject clonedButtonObj = GameObject.Instantiate(quitButtonObj, quitButtonObj.transform.parent);
            if (!clonedButtonObj)
            {
                LoggerInstance.Error("Failed to clone Quit button object");
                return;
            }
            clonedButtonObj.name = "Mods button";

            // Adjust button position
            RectTransform btnRt = clonedButtonObj.GetComponent<RectTransform>();
            if (btnRt)
            {
                btnRt.anchoredPosition = new Vector2(btnRt.anchoredPosition.x, btnRt.anchoredPosition.y + 250);
                btnRt.rotation = Quaternion.Euler(btnRt.rotation.eulerAngles.x, btnRt.rotation.eulerAngles.y, btnRt.rotation.eulerAngles.z + 20);
            }

            // Find Button component in cloned object
            GameObject modButtonContent = clonedButtonObj.transform.Find("Button content").gameObject;
            if (!modButtonContent)
            {
                LoggerInstance.Error("Cloned Quit Button's Button content not found");
                return;
            }

            Button clonedQuitButton = modButtonContent.GetComponentInChildren<Button>();
            if (!clonedQuitButton)
            {
                LoggerInstance.Error("Mod Button Content's Button component not found");
                return;
            }

            // Destroy old quit button component
            GameObject.DestroyImmediate(clonedQuitButton);

            // Add new Button component
            Button modMenuButton = modButtonContent.AddComponent<Button>();
            if (!modMenuButton)
            {
                LoggerInstance.Error("Mod Menu button component failed to be added");
                return;
            }
            Animator anim = modButtonContent.GetComponent<Animator>();

            // Enable Animation transition
            modMenuButton.transition = Selectable.Transition.Animation;

            // Change button text
            TextMeshProUGUI btnText = modMenuButton.GetComponentInChildren<TextMeshProUGUI>();
            if (!btnText)
            {
                LoggerInstance.Error("Mod Menu Button's TMP component not found");
                return;
            }
            btnText.SetText("Mods");
            modMenuButton.onClick.AddListener(ToggleModMenuBtnPressed);
            LoggerInstance.Msg("Mod Menu Button created successfully");
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