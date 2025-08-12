using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Traceability.Models;
using Traceability.Services;

namespace Traceability.ViewModels
{
    // ViewModel dla zakładki "Serwer"
    public class ServerViewModel : ViewModelBase
    {
        private readonly FileService _fileService;
        private readonly DatabaseService _databaseService;
        private ServerConfig _model;

        public ServerViewModel(FileService fileService, DatabaseService databaseService)
        {
            _fileService = fileService;
            _databaseService = databaseService;

            // Spróbuj wczytać konfigurację z domyślnej ścieżki, jeśli jest
            _model = fileService.LoadConfig("server.config.json") ?? new ServerConfig();

            TestConnectionCommand = new RelayCommand(async _ => await TestConnectionAsync());
            SaveCommand = new RelayCommand(_ => SaveConfig());
        }

        // Właściwości powiązane z widokiem (binding -> two-way)
        public string IP { get => _model.IP; set { _model.IP = value; RaisePropertyChanged(); } }
        public string Port { get => _model.Port; set { _model.Port = value; RaisePropertyChanged(); } }
        public string Login { get => _model.Login; set { _model.Login = value; RaisePropertyChanged(); } }
        public string Password { get => _model.Password; set { _model.Password = value; RaisePropertyChanged(); } }
        public bool IsAvailable { get => _model.IsAvailable; private set { _model.IsAvailable = value; RaisePropertyChanged(); } }
        public string DatabaseName { get => _model.DatabaseName; set { _model.DatabaseName = value; RaisePropertyChanged(); } }

        // Komendy
        public ICommand TestConnectionCommand { get; }
        public ICommand SaveCommand { get; }

        // Metody komend
        private async Task TestConnectionAsync()
        {
            // Opcjonalnie tu ustawiasz UI w tryb busy
            var ok = await _databaseService.TestConnectionAsync(_model);
            IsAvailable = ok;
        }

        private void SaveConfig()
        {
            // Zapis do pliku poprzez serwis
            _fileService.SaveConfig(_model, "server.config.json");
        }
    }
}