using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.UI.Factory {
    public class UIFactory : IUIFactory {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticDataService;
        private Transform _uiRoot;

        public UIFactory(IAssetProvider assets, IStaticDataService staticDataService) {
            _assets = assets;
            _staticDataService = staticDataService;
        }

        public void CreateAddWordWindow() {
            var config = _staticDataService.ForWindow(WindowId.AddWord);
            Object.Instantiate(config.Prefab, _uiRoot);
        }

        public void CreateUIRoot() =>
            _uiRoot = _assets.Instantiate(UIRootPath).transform;
    }
}