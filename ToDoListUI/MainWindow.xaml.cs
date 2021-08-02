using System.Collections.ObjectModel;
using System.Windows;
using ToDoListBL;
using ToDoListBL.Model;

namespace ToDoListUI
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<Purpose> _purposes;
		private IDataSaver _dataSaver;

		public MainWindow()
		{
			InitializeComponent();
			_dataSaver = new SerializeDataSaver();
			_purposes = _dataSaver.Load<Purpose>() ?? new ObservableCollection<Purpose>();
			ToDoList.ItemsSource = _purposes;
		}

		private void AddPurposeButtom_Click(object sender, RoutedEventArgs e)
		{
			var addWindow = new AddWindow();
			addWindow.ShowDialog();

			if (addWindow.Purpose != null && addWindow.Purpose.TaskToComplete != "")
				_purposes.Add(addWindow.Purpose);
		}

		private void DeletePurposeButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedPurpose = (Purpose)ToDoList.SelectedItem;
			_purposes.Remove(selectedPurpose);
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{			
			_dataSaver.Save(_purposes);
		}
	}
}
