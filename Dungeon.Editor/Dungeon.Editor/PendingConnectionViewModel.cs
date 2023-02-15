using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dungeon.Editor
{
    public class PendingConnectionViewModel
    {
        private readonly DialogueViewModel dialogue;
        private ConnectorViewModel _source;

        public PendingConnectionViewModel(DialogueViewModel dialogue)
        {
            this.dialogue = dialogue;
            StartCommand = new DelegateCommand<ConnectorViewModel>(source => _source = source);
            FinishCommand = new DelegateCommand<ConnectorViewModel>(target =>
            {
                if (target != null)
                    this.dialogue.Connect(_source, target);
            });
        }

        public ICommand StartCommand { get; }
        public ICommand FinishCommand { get; }
    }
}
