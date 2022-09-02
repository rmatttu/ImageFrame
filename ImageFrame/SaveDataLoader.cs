using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageFrame
{
    public class SaveDataLoader
    {
        public static string Location { get; } = "SaveData.json";

        public static SaveData Load()
        {
            if (!File.Exists(Location)) return SaveData.GenerateSample();
            using StreamReader reader = new StreamReader(Location);
            return JsonSerializer.Deserialize<SaveData>(reader.BaseStream);
        }
    }
}
