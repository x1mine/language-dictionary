using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.Services.StaticData {
    public interface IStaticDataService : IService {
        void LoadWindowsData();
        WindowConfig ForWindow(WindowId addWord);
    }
}