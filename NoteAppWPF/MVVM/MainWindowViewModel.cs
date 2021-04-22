using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using NoteAppWPF.Annotations;
using NoteApp;

namespace NoteAppWPF.MVVM
{
    class MainWindowViewModel: INotifyPropertyChanged
    {
        private Note _selectedNote;

        private static string _path = ProjectManager.Path + ProjectManager.FileName;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Note> Notes { get; set; }

        //public Project Project;

        public Note SelectedNote
        {
            get
            {
                return _selectedNote;
            }
            set
            {
                _selectedNote = value;
                OnPropertyChanged("SelectedNote");
            }
        }

        public MainWindowViewModel()
        {
            //Project = ProjectManager.LoadFile(_path);
            Notes = new ObservableCollection<Note>();
            var newNote = new Note()
            {
                Name = "123q",
                Category = NoteCategory.Work,
                Text = "dsasdweqweasd"
            };
            Notes.Add(newNote);
            newNote = new Note()
            {
                Name = "123",
                Category = NoteCategory.Documents,
                Text = "dsasdвфывфывфывчясфы"
            };
            Notes.Add(newNote);
            //Project.Notes.Add(newNote);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
