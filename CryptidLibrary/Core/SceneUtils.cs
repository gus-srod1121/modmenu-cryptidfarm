using UnityEngine.SceneManagement;

namespace CryptidLibrary.Core
{
    public static class SceneUtils
    {
        public static int CurrentScene { get => SceneManager.GetActiveScene().buildIndex; }
    }

    public enum Scenes
    {
        MainMenu = 0,
        Game = 1,
    }
}
