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
        //public ObservableCollection<Note> Notes { get; set; }

        private Project _project;

        public Project Project
        {
            get => _project;
            set => Set(ref _project, value);
        }

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
            Project = new Project();
            var newNote = new Note()
            {
                Name = "123q",
                Category = NoteCategory.Work,
                Text = "dsasdweqweasd"
            };
            Project.Notes.Add(newNote);
            newNote = new Note()
            {
                Name = "123",
                Category = NoteCategory.Documents,
                Text = "dsasdвфывфывфывчясфы"
            };
            Project.Notes.Add(newNote);
            //Project.Notes.Add(newNote);
        }
    }
}
