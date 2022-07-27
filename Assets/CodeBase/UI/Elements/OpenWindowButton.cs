using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements {
    public class OpenWindowButton : MonoBehaviour {
        [SerializeField] private Button _button;
        [SerializeField] private WindowId _windowId;
        private IWindowService _windowService;

        private void Awake() {
            _windowService = AllServices.Container.GetSingle<IWindowService>();
            _button.onClick.AddListener(Open);
        }

        private void Open() => 
            _windowService.Open(_windowId);
    }
}