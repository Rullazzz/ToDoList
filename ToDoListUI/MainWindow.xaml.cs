﻿using System.Collections.ObjectModel;
using System.Windows;
using ToDoListBL;

namespace ToDoListUI
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<Purpose> _purposes;

		public MainWindow()
		{
			InitializeComponent();
			_purposes = new ObservableCollection<Purpose>();
			ToDoList.ItemsSource = _purposes;
		}

		private void AddPurposeButtom_Click(object sender, RoutedEventArgs e)
		{
			var addWindow = new AddWindow();
			addWindow.ShowDialog();

			if (addWindow.Purpose.TaskToComplete != "")
				_purposes.Add(addWindow.Purpose);
		}

		private void DeletePurposeButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedPurpose = (Purpose)ToDoList.SelectedItem;
			_purposes.Remove(selectedPurpose);
		}
	}
}
