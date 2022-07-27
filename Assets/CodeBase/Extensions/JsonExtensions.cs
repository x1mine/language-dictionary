using Newtonsoft.Json;

namespace CodeBase.Extensions {
    public static class JsonExtensions {
        public static T ToDeserialized<T>(this string json) =>
            JsonConvert.DeserializeObject<T>(json);

        public static string ToJson(this object obj) =>
            JsonConvert.SerializeObject(obj);
    }
}