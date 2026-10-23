using UnityEngine.SceneManagement;

namespace CryptidLibrary.Core
{
    public static class SceneUtils
    {
        public static int CurrentScene { get => SceneManager.GetActiveScene().buildIndex; }
    }

    public enum Scene
    {
        MainMenu = 0,
        Game = 1,
    }
}
