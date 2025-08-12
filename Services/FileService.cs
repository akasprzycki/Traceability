using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Traceability.Models;
using System.IO;

namespace Traceability.Services
{
    // Prosty serwis do zapisu/odczytu pliku konfiguracji (JSON).
    public class FileService
    {
        // Zapisz obiekt konfiguracyjny do pliku JSON.
        public void SaveConfig(ServerConfig config, string filePath)
        {
            var json = JsonConvert.SerializeObject(config, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        // Wczytaj konfigurację z pliku JSON (jeśli istnieje).
        public ServerConfig? LoadConfig(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<ServerConfig>(json);
        }
    }
}