using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traceability.Models;

namespace Traceability.Services
{
    // Serwis testowy: testuje dostępność bazy (synchron, prosty stub).
    public class DatabaseService
    {
        // W praktyce tutaj wykonasz próbne połączenie ADO/.NET -> zwróć true jeśli OK.
        public Task<bool> TestConnectionAsync(ServerConfig config)
        {
            // Tu należy zrealizować rzeczywiste połączenie do DB.
            // Na razie symulujemy (zawsze true).
            return Task.FromResult(true);
        }
    }
}