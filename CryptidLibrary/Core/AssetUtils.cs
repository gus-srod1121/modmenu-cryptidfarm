using UnityEngine;

namespace CryptidLibrary.Core
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

        /// <summary>
        /// Finds any loaded Unity object or component whose name contains the substring
        /// </summary>
        /// <typeparam name="T">The object type you are searching for</typeparam>
        /// <param name="subs">The substring to search for the object or component</param>
        /// <returns>The first T object containing the substring, or null if none are found.</returns>
        public static T FindComponentWithNameContaining<T>(string subs) where T : UnityEngine.Object
        {
            foreach (T temp in Resources.FindObjectsOfTypeAll<T>())
            {
                if (temp.name.Contains(subs))
                {
                    return temp;
                }
            }
            return null;
        }
    }
}