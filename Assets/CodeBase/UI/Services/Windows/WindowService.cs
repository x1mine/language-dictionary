using CodeBase.UI.Factory;

namespace CodeBase.UI.Services.Windows {
    public class WindowService : IWindowService {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory) {
            _uiFactory = uiFactory;
        }

        public void Open(WindowId windowId) => 
            _uiFactory.CreateWindow(windowId);
    }
}