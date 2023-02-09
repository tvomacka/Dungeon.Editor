using System.Collections.ObjectModel;

namespace Dungeon.Editor
{
    public class EditorViewModel
    {
        public ObservableCollection<NodeViewModel> Nodes { get; } = new ObservableCollection<NodeViewModel>();
        public ObservableCollection<ConnectionViewModel> Connections { get; } = new ObservableCollection<ConnectionViewModel>();

        public EditorViewModel()
        {
            var welcome = new NodeViewModel
            {
                Title = "Welcome",
                Input = new ObservableCollection<ConnectorViewModel>
                {
                    new ConnectorViewModel
                    {
                        Title = "In"
                    }
                },
                Output = new ObservableCollection<ConnectorViewModel>
                {
                    new ConnectorViewModel
                    {
                        Title = "Out"
                    }
                }
            };

            var nodify = new NodeViewModel
            {
                Title = "To Nodify",
                Input = new ObservableCollection<ConnectorViewModel>
                {
                    new ConnectorViewModel
                    {
                        Title = "In"
                    }
                }
            };

            Nodes.Add(welcome);
            Nodes.Add(nodify);

            Connections.Add(new ConnectionViewModel
            {
                Source = welcome.Output[0],
                Target = nodify.Input[0]
            });
        }
    }
}
