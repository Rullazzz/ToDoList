using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBL.Model
{
	public interface IDataSaver
	{
        /// <summary>
        /// Сохранить данные.
        /// </summary>
        /// <param name="fileName"> Путь для сохранения данных. </param>
        /// <param name="item"> Объект сохранения. </param>
        void Save<T>(ObservableCollection<T> item, string _fileName) where T : class;

        /// <summary>
        /// Получить данные.
        /// </summary>
        /// <typeparam name="T"> Тип возвращаемых данных. </typeparam>
        /// <param name="fileName"> Путь для сохранения данных. </param>
        /// <returns> Данные из файла или Default(T). </returns>
        ObservableCollection<T> Load<T>(string _fileName) where T : class;
    }
}
