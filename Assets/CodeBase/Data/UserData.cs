using System;

namespace CodeBase.Data {
    [Serializable]
    public class UserData {
        public DictionaryData DictionaryData;

        public UserData() {
            DictionaryData = new DictionaryData();
        }
    }
}