using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
		private ObservableCollection<Purpose> _completedPurposes;
		private SerializeDataSaver _dataSaver;

		public MainWindow()
		{
			InitializeComponent();
			_dataSaver = new SerializeDataSaver();
			_purposes = _dataSaver.Load<Purpose>("Purposes") ?? new ObservableCollection<Purpose>();
			_completedPurposes = _dataSaver.Load<Purpose>("CompletedPurposes") ?? new ObservableCollection<Purpose>();
			ToDoList.ItemsSource = _purposes;
			CompletedPurposes.ItemsSource = _completedPurposes;
		}

		private void AddPurposeButtom_Click(object sender, RoutedEventArgs e)
		{
			var addWindow = new AddWindow();
			addWindow.ShowDialog();

			if (addWindow.Purpose != null && addWindow.Purpose.TaskToComplete != "")
			{
				_purposes.Add(addWindow.Purpose);
				ToDoList.SelectedItem = _purposes.Last();
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{			
			_dataSaver.Save(_purposes, "Purposes");
			_dataSaver.Save(_completedPurposes, "CompletedPurposes");
		}

		private void ChangePurposeButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedPurpose = (Purpose)ToDoList.SelectedItem;
			if (selectedPurpose != null)
			{
				var addWindow = new AddWindow(selectedPurpose);
				addWindow.ShowDialog();

				if (addWindow.Purpose != null && addWindow.Purpose.TaskToComplete != "")
				{
					selectedPurpose.TaskToComplete = addWindow.Purpose.TaskToComplete;
					selectedPurpose.Deadline = addWindow.Purpose.Deadline;
				}
			}
		}

		private void CompletePurposeButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedPurposes = new List<Purpose>();
			foreach (Purpose purpose in ToDoList.SelectedItems)
			{
				selectedPurposes.Add(purpose);
			}

			if (selectedPurposes.Count > 0)
			{
				foreach (var purpose in selectedPurposes)
				{
					_completedPurposes.Add(purpose);
					_purposes.Remove(purpose);
				}	
				ToDoList.SelectedItem = _purposes.FirstOrDefault();
			}
		}

		private void DeleteAllPurposesButton_Click(object sender, RoutedEventArgs e)
		{
			_purposes.Clear();
		}

		private void DeleteAllCompletedPurposesButton_Click(object sender, RoutedEventArgs e)
		{
			_completedPurposes.Clear();
		}
	}
}
