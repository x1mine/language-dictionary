using System;
using System.Collections.Generic;

namespace CodeBase.Data {
    [Serializable]
    public class DictionaryData {
        public Dictionary<string, string> Words;

        public DictionaryData() =>
            Words = new Dictionary<string, string>();
    }
}