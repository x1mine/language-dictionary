using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.PersistentData {
    public interface IPersistentDataService : IService {
        UserData Data { get; set; }
    }
}