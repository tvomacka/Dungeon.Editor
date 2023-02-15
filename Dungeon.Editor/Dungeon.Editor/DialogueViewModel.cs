using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Dungeon.Editor
{
    public class DialogueViewModel
    {
        public ObservableCollection<NodeViewModel> Nodes { get; } = new ObservableCollection<NodeViewModel>();
        public ObservableCollection<ConnectionViewModel> Connections { get; } = new ObservableCollection<ConnectionViewModel>();

        public PendingConnectionViewModel PendingConnection { get; }

        public ICommand DisconnectConnectorCommand { get; }

        public DialogueViewModel()
        {
            DisconnectConnectorCommand = new DelegateCommand<ConnectorViewModel>(connector =>
            {
                var connection = Connections.First(x => x.Source == connector || x.Target == connector);
                connection.Source.IsConnected = false;  // This is not correct if there are multiple connections to the same connector
                connection.Target.IsConnected = false;
                Connections.Remove(connection);
            });

            PendingConnection = new PendingConnectionViewModel(this);

            var welcome = new NodeViewModel
            {
                Title = "Welcome",
                Location = new Point(10, 10),
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
                Location = new Point(200, 10),
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

            Connections.Add(new ConnectionViewModel(source: welcome.Output[0], target: nodify.Input[0]));
        }

        public void Connect(ConnectorViewModel source, ConnectorViewModel target)
        {
            Connections.Add(new ConnectionViewModel(source, target));
        }
    }
}
