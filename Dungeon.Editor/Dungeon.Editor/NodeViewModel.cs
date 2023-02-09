using System.Collections.ObjectModel;

namespace Dungeon.Editor
{
    public class NodeViewModel
    {
        public string Title { get; set; }

        public ObservableCollection<ConnectorViewModel> Input { get; set; } = new ObservableCollection<ConnectorViewModel>();
        public ObservableCollection<ConnectorViewModel> Output { get; set; } = new ObservableCollection<ConnectorViewModel>();
    }
}
