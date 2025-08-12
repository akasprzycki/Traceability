using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Traceability.ViewModels
{
    // Pozycja menu: tytuł i komenda, którą wywołujemy przy kliknięciu.
    public class MenuItemViewModel
    {
        public string Title { get; }
        public ICommand Command { get; }

        public MenuItemViewModel(string title, ICommand command)
        {
            Title = title;
            Command = command;
        }
    }
}