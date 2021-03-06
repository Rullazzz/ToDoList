using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ToDoListBL.Model
{
    public class SerializeDataSaver : IDataSaver
    {       
        public ObservableCollection<T> Load<T>(string _fileName) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = _fileName;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is ObservableCollection<T> items)
                    return items;
                else
                    return default(ObservableCollection<T>);
            }
        }

        public void Save<T>(ObservableCollection<T> item, string _fileName) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = _fileName;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
