using CodeBase.Infrastructure.Services;

namespace CodeBase.UI.Factory {
    public interface IUIFactory : IService {
        void CreateAddWordWindow();
        void CreateUIRoot();
    }
}