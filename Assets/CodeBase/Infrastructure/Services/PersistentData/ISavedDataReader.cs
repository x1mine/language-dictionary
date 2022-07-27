using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.PersistentData {
    public interface ISavedDataReader {
        void LoadData(UserData data);
    }
}