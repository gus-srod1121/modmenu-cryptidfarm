using UnityEngine.SceneManagement;

namespace CryptidLibrary.Core
{

    public static class SceneUtils
    {
        public delegate void LoadedScene(int buildIndex);
        public static event LoadedScene OnSceneLoaded;

        public static int CurrentScene { get => SceneManager.GetActiveScene().buildIndex; }
        public static void SceneLoaded(int buildIndex)
        {
            OnSceneLoaded.Invoke(buildIndex);
        }
    }

    public enum Scene
    {
        MainMenu = 0,
        Game = 1,
    }
}
