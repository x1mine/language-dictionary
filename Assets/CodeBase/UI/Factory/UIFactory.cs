using CodeBase.Dictionary;
using CodeBase.Extensions;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.PersistentData;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.UI.Factory {
    public class UIFactory : IUIFactory {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticDataService;
        private readonly IPersistentDataService _dataService;
        private Transform _uiRoot;
        private WordsDictionary _dictionary;

        public UIFactory(IAssetProvider assets, IStaticDataService staticDataService,
            IPersistentDataService dataService) {
            _assets = assets;
            _staticDataService = staticDataService;
            _dataService = dataService;
        }

        public void CreateAddWordWindow() {
            var config = _staticDataService.ForWindow(WindowId.AddWord);
            Object.Instantiate(config.Prefab, _uiRoot)
                .With(window => window.Construct(_dataService, _dictionary));
        }

        public void CreateUIRoot(WordsDictionary wordsDictionary) {
            _dictionary = wordsDictionary;
            _uiRoot = _assets.Instantiate(UIRootPath).transform;
        }
    }
}