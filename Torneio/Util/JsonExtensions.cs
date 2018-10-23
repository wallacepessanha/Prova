using Newtonsoft.Json;
using System.Diagnostics;

namespace Util
{
    public static class JsonExtensions
    {

        /// <summary></summary>
        [DebuggerStepThrough]
        public static string ToJson<T>(this T obj)
        //where T : class, new()
        {
            if (obj == null)
                return null;

            // Strings should not be serialized.
            if (typeof(T).FullName == typeof(string).FullName)
                return obj as string;

            // Serializing object to json data  
            var jsonData = JsonConvert
                .SerializeObject(obj
                    // Don't format, it takes up space in the messages.
                    /*, Formatting.Indented*/
                    );

            return jsonData;
        }


        /// <summary>
        /// Deserializes a string to object, throwing an exception if not possible.
        /// </summary>
        //[DebuggerStepThrough]
        public static object FromJson(this string str)
        {
            if (str == null)
                return null;
            var obj = JsonConvert.DeserializeObject(str);
            return obj;
        }



        /// <summary>Deserializes a string to object, throwing an exception if not possible.</summary>
        public static T FromJson<T>(this string str)
        {
            return Deserialize<T>(str);
        }

        /// <summary>Deserializes a string to object, throwing an exception if not possible.</summary>
        public static T Deserialize<T>(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return default(T);

            if (typeof(T) != typeof(string) && typeof(T).IsClass && str.StartsWith("\""))
            {
                // Strange conversation while saving. Fix it now.
                str = JsonConvert.DeserializeObject<string>(str);
            }

            if (typeof(T) == typeof(string))
                return (T)(object)str;

            var obj = JsonConvert.DeserializeObject<T>(str);
            return obj;
        }

        /// <summary>Tryes to deserializes a string to object, returning default(T) if not possible.</summary>
        public static T TryFromJson<T>(this string str)
        {
            return TryDeserialize<T>(str);
        }

        /// <summary>Tryes to deserializes a string to object, returning default(T) if not possible.</summary>
        public static T TryDeserialize<T>(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return default(T);

            try
            {
                var obj = JsonConvert.DeserializeObject<T>(str);
                return obj;
            }
            catch (JsonSerializationException)
            {
                return default(T);
            }
        }

    }
}