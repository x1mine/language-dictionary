using CodeBase.Dictionary;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Windows;

namespace CodeBase.UI.Factory {
    public interface IUIFactory : IService {
        void CreateWindow(WindowId windowId);
        void CreateUIRoot(WordsDictionary wordsDictionary);
    }
}