using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceability.Models
{
    // Model danych konfiguracyjnych serwera bazy.
    public class ServerConfig
    {
        public string IP { get; set; } = "127.0.0.1";
        public string Port { get; set; } = "1433";           // trzymamy jako string ułatwiając binding
        public string Login { get; set; } = "sa";
        public string Password { get; set; } = "";           // uwaga: zaszyfrować przed produkcją
        public bool IsAvailable { get; set; } = false;
        public string DatabaseName { get; set; } = "TraceDB";
    }
}