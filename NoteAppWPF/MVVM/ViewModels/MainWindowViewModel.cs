using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NoteApp;
using NoteAppWPF.Annotations;
using NoteAppWPF.MVVM.ViewModels.Base;

namespace NoteAppWPF.MVVM.ViewModels
{
    class MainWindowViewModel: BaseViewModel
    {
        private Note _selectedNote;
        
        /// <summary>
        /// Коллецкция заметок.
        /// </summary>
        public ObservableCollection<Note> Notes { get; set; }

        //public Project Project;

        /// <summary>
        /// Свойство выбранной заметки.
        /// </summary>
        public Note SelectedNote
        {
            get => _selectedNote;
            set => Set(ref _selectedNote, value);
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
    }
}
