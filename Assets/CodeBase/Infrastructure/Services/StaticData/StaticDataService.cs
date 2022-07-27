using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData {
    public class StaticDataService : IStaticDataService {
        private const string StaticDataWindowsPath = "StaticData/UI/WindowsStaticData";
        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void LoadWindowsData() {
            _windowConfigs = Resources
                .Load<WindowStaticData>(StaticDataWindowsPath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out var config)
                ? config
                : null;
    }
}