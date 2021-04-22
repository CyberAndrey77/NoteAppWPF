using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NoteApp.Annotations;

namespace NoteApp
{
    /// <summary>
    /// Класс заметка.
    /// </summary>
    public class Note : ICloneable, IEquatable<Note>, INotifyPropertyChanged
    {
        /// <summary>
        /// Название заметки.
        /// </summary>
        private string _name;

        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NoteCategory _category;

        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _text;

        /// <summary>
        /// Дата создания.
        /// </summary>
        private DateTime _created;

        /// <summary>
        /// Время последнего изменения.
        /// </summary>
        private DateTime _modified;

        /// <summary>
        /// Задает и возвращает поле Название с ограничением в 50 символов.
        /// </summary>
        public string Name 
        {
            get 
            {
                return _name;
            } 
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException($"The length of the name must be less than 50, and it was {value.Length}!");
                }
                if (value.Length == 0)
                {
                    throw new ArgumentException($"The note must have a title!");
                }
                _name = value;
                OnPropertyChanged("Name");
                Modified = DateTime.Now;
            }
        }

        /// <summary>
        /// Задает и возвращает категорию заметки.
        /// </summary>
        public NoteCategory Category 
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
                Modified = DateTime.Now;
            }

        }

        /// <summary>
        /// Задает и возвращает поле Текст заметки.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
                Modified = DateTime.Now;
            }
        }

        /// <summary>
        /// Задает поле Дата создания. Доступно только для чтения.
        /// </summary>
        public DateTime Created
        {
            get
            {
                return _created;
            }
            private set
            {

            }
        }

        /// <summary>
        /// Задает и возвращает поле Дата последнего редактирования. 
        /// </summary>
        public DateTime Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
            }
        }

        /// <summary>
        /// Клонирование класса. Используется при редактировании заметки.
        /// </summary>
        /// <returns>Возвращает ссылку на копию класса.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Стандартный конструктор для класса
        /// </summary>
        public Note()
        {
            _created = DateTime.Now;
            _modified = DateTime.Now;
        }

        /// <summary>
        /// Конструктор для использования библиотекой Json
        /// </summary>
        /// <param name="name">Название заметки</param>
        /// <param name="category">Категория заметки</param>
        /// <param name="text">Поле для текста</param>
        /// <param name="created">Дата создания</param>
        /// <param name="modified">Дата последнего изменения</param>
        [JsonConstructor]
        private Note(string name, NoteCategory category, string text, DateTime created, DateTime modified)
        {
            _name = name;
            _category = category;
            _text = text;
            _created = created;
            _modified = modified;
        }

        /// <summary>
        /// Конструктор с вожмоностью задать любое время создания.
        /// </summary>
        /// <param name="created">Время создания.</param>
        public Note(DateTime created)
        {
            _created = created;
            _modified = created;
        }

        public bool Equals(Note other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _name == other._name &&
                   _category == other._category &&
                   _text == other._text  &&
                   _created == other._created &&
                   _modified.Equals(other._modified);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Note) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) _category;
                hashCode = (hashCode * 397) ^ (_text != null ? _text.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _created.GetHashCode();
                hashCode = (hashCode * 397) ^ _modified.GetHashCode();
                return hashCode;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
