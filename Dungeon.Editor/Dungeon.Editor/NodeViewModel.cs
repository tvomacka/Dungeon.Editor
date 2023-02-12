using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Dungeon.Editor
{
    public class NodeViewModel
    {
        public string Title { get; set; }

        public ObservableCollection<ConnectorViewModel> Input { get; set; } = new ObservableCollection<ConnectorViewModel>();
        public ObservableCollection<ConnectorViewModel> Output { get; set; } = new ObservableCollection<ConnectorViewModel>();

        private Point _location;
        public Point Location
        {
            set
            {
                _location = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Location)));
            }
            get => _location;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
