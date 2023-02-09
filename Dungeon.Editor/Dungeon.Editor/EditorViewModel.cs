using System.Collections.ObjectModel;

namespace Dungeon.Editor
{
    public class EditorViewModel
    {
        public ObservableCollection<NodeViewModel> Nodes { get; } = new ObservableCollection<NodeViewModel>();

        public EditorViewModel()
        {
            Nodes.Add(new NodeViewModel { Title = "Welcome" });
        }
    }
}
