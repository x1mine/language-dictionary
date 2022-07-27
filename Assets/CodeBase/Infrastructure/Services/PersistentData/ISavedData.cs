using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.PersistentData {
    public interface ISavedData : ISavedDataReader {
        void UpdateData(UserData data);
    }
}