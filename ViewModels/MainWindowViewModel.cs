using System.Collections.ObjectModel;

namespace Traceability.ViewModels
{
    // Główny ViewModel – trzyma menu i aktualny widok (CurrentView).
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase? _currentView;

        // Zawartość menu
        public ObservableCollection<MenuItemViewModel> MenuItems { get; } = new();

        // Aktualnie wyświetlany ViewModel (ContentControl w XAML)
        public ViewModelBase? CurrentView
        {
            get => _currentView;
            set => Set(ref _currentView, value);
        }

        public MainWindowViewModel()
        {
            // Tworzymy instancje ViewModeli (możesz w przyszłości wstrzykiwać serwisy)
            var serverVM = new ServerViewModel(new Services.FileService(), new Services.DatabaseService());
            var structureVM = new StructureViewModel();
            var devicesVM = new DevicesViewModel();
            var templateVM = new PlaceholderViewModel("Template (TODO)");     // zastępnik

            MenuItems.Add(new MenuItemViewModel("Serwer", new RelayCommand(_ => CurrentView = serverVM)));
            MenuItems.Add(new MenuItemViewModel("Struktura", new RelayCommand(_ => CurrentView = structureVM)));
            MenuItems.Add(new MenuItemViewModel("Urządzenia", new RelayCommand(_ => CurrentView = devicesVM)));

            // Domyślny widok
            CurrentView = serverVM;
        }
    }

    // Prosty placeholder ViewModel (tylko do demo)
    public class PlaceholderViewModel : ViewModelBase
    {
        public string Message { get; }
        public PlaceholderViewModel(string message) => Message = message;
    }
}