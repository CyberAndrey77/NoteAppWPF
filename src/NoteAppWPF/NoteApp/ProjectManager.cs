using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace NoteApp
{
    /// <summary>
    /// Класс менеджер проектов.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Путь до папки.
        /// </summary>
        public static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Lapardin\NoteApp\";

        /// <summary>
        /// Название файла.
        /// </summary>
        public static readonly string FileName = @"project.json";

        /// <summary>
        /// Метод записывающий даннные в файл.
        /// </summary>
        /// <param name="project">Ссылка на класс Project.</param>
        /// <param name="path">Путь до файла.</param>
        public static void SaveFile(Project project, string path)
        {
            var directoryPath = System.IO.Path.GetDirectoryName(path);
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            
            var stringJSON = JsonConvert.SerializeObject(project, Formatting.Indented);

            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                streamWriter.Write(stringJSON);
            }
        }

        /// <summary>
        /// Вытаскивает данные из файла в класс.
        /// </summary>
        /// <param name="project">Ссылка на класс Project.</param>
        /// <param name="path">Путь до файла.</param>
        /// <returns>Возвращает ссылку на класс</returns>
        public static Project LoadFile(string path)
        {
            var project = new Project();
            var directoryPath = System.IO.Path.GetDirectoryName(path);
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            if (!directoryInfo.Exists)
            {
                return project;
            }

            if (!File.Exists(path))
            {
                return project;
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader(path))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                try
                {
                    project = serializer.Deserialize<Project>(jsonReader);
                }
                catch (Exception e)
                {
                    return project;
                }
                if (project == null)
                {
                    return project;
                }
            }

            return project;
        }
    }
}
