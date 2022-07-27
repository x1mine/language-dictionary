using System.Collections.Generic;
using CodeBase.Dictionary;
using CodeBase.Extensions;
using CodeBase.Infrastructure.Services.PersistentData;
using CodeBase.Infrastructure.Services.SaveLoad;

namespace CodeBase.Infrastructure.Factory {
    public class AppFactory : IAppFactory {
        public List<ISavedData> DataWriters { get; } = new();
        public List<ISavedDataReader> DataReaders { get; } = new();

        public WordsDictionary CreateDictionary() =>
            new WordsDictionary()
                .With(Register);

        private void Register(ISavedDataReader progressReader) {
            if (progressReader is ISavedData progressWriter)
                DataWriters.Add(progressWriter);

            DataReaders.Add(progressReader);
        }
    }
}