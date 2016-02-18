using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Object = System.Object;

public static class Serializer 
{
    private static readonly JsonSerializer serializer;



    static Serializer()
    {
        serializer = new JsonSerializer();
    }


    /// <summary>
    /// Deserialize using for convertion JSON data file into data class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public static T Deserialize<T>(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            using (JsonReader jsonReader = new JsonTextReader(reader))
            {
                return serializer.Deserialize<T>(jsonReader);

            }
        }
        else
        {
            //Debug.LogError(path + " Not Exist");
            return default(T);
        }
    }

    /// <summary>
    /// Serialize using for convert object data to config JSON data file.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="path"></param>
    public static void Serialize(object obj, string path)
    {
		string l_Directory = Path.GetDirectoryName (path);
		Debug.Log (Path.GetDirectoryName(path));

		if (!Directory.Exists (path))
		{
			Directory.CreateDirectory (l_Directory);
		}

		if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path));
			#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
			#endif
        }

        using (StreamWriter sw = new StreamWriter(path))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, obj);
        }
    }
}
