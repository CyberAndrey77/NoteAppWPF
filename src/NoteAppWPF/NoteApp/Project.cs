using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NoteApp.Annotations;

namespace NoteApp
{
    /// <summary>
    /// Класс проект.
    /// </summary>
    public class Project : INotifyPropertyChanged
    {
        /// <summary>
        /// Задает и возвращает список классов заметки.
        /// </summary>
        public ObservableCollection<Note> Notes { get; set; }
        
        /// <summary>
        /// Задает и возвращает индекс выбранной заметки.
        /// </summary>
        public int SelectedNoteIndex { get; set; }

        /// <summary>
        /// Стандартный конструктор для класса.
        /// </summary>
        public Project()
        {
            Notes = new ObservableCollection<Note>();
        }

        /// <summary>
        /// Метод сортирующий список.
        /// </summary>
        /// <param name="notes">Список классов.</param>
        /// <returns>Ссылку на отсортированный список.</returns>
        public static List<Note> SortProjectByModified(List<Note> notes)
        {
            ModifiedCompare compare = new ModifiedCompare();
            notes.Sort(compare);
            return notes;
        }

        /// <summary>
        /// Метод фильтрующий список с по выбраной категории.
        /// </summary>
        /// <param name="notes">Список классов.</param>
        /// <param name="noteCategory">Категория заметки.</param>
        /// <returns>Ссылку на отфильтрованый список.</returns>
        public static List<Note> FilterProjectByCategory(List<Note> notes, NoteCategory noteCategory)
        {
            List<Note> newNotes = new List<Note>();
            foreach (var note in notes)
            {
                if (note.Category == noteCategory)
                {
                    newNotes.Add(note);
                }
            }
            
            return newNotes;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
