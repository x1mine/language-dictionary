using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.PersistentData {
    public class PersistentDataService : IPersistentDataService {
        public UserData Data { get; set; }
    }
}