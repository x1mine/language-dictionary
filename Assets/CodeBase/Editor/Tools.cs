using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor {
    public static class Tools {
        [MenuItem("Tools/ClearPrefs")]
        public static void ClearPrefs() {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}