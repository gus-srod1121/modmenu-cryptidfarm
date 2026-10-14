using UnityEngine;

namespace grcubes.CryptidFarm.CryptidLibrary.Core
{
    public static class AssetUtils
    {
        /// <summary>
        /// Finds any loaded Unity object or component by its <b>exact</b> name.
        /// </summary>
        /// <typeparam name="T">The object type you are searching for</typeparam>
        /// <param name="name">The exact name of the object or component</param>
        /// <returns>The first T object with the matching name, or null if it is not found.</returns>
        public static T FindComponentByName<T>(string name) where T : UnityEngine.Object
        {
            foreach (T temp in Resources.FindObjectsOfTypeAll<T>())
            {
                if (temp.name == name)
                {
                    return temp;
                }
            }
            return null;
        }
    }
}