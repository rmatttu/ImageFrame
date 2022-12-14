using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageFrame
{
    public class SaveDataIO
    {
        public static string Location { get; } = "SaveData.json";

        public static SaveData Load()
        {
            if (!File.Exists(Location)) return SaveData.GenerateSample();
            using StreamReader reader = new StreamReader(Location);
            return JsonSerializer.Deserialize<SaveData>(reader.BaseStream);
        }

        public static void Save(SaveData saveData)
        {
            using StreamWriter writer = new StreamWriter(Location, false);
            var json = JsonSerializer.Serialize(saveData);
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }
    }
}
