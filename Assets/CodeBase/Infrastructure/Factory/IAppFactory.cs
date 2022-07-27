using System.Collections.Generic;
using CodeBase.Dictionary;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentData;

namespace CodeBase.Infrastructure.Factory {
    public interface IAppFactory : IService {
        List<ISavedData> DataWriters { get; }
        List<ISavedDataReader> DataReaders { get; }

        WordsDictionary CreateDictionary();
    }
}