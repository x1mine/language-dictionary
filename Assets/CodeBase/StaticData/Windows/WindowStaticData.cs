using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Windows {
    [CreateAssetMenu(menuName = "Static Data/Create Window Static Data", fileName = "WindowStaticData")]
    public class WindowStaticData : ScriptableObject {
        public List<WindowConfig> Configs;
    }
}