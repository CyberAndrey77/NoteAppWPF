using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс проект.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Задает и возвращает список классов заметки.
        /// </summary>
        public List<Note> Notes { get; set; }
        
        /// <summary>
        /// Задает и возвращает индекс выбранной заметки.
        /// </summary>
        public int SelectedNoteIndex { get; set; }

        /// <summary>
        /// Стандартный конструктор для класса.
        /// </summary>
        public Project()
        {
            Notes = new List<Note>();
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
    }
}
