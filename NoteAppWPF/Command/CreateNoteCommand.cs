using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NoteAppWPF.Command.Base;

namespace NoteAppWPF.Command
{
    internal class CreateNoteCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            NoteWindow noteWindow = new NoteWindow();
            noteWindow.Show();
        }
    }
}
